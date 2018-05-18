using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Script.Serialization;
using JWT;
using HotelRestaurantAPI.DTO;
using DAL.Entities;
using JWT.Algorithms;
using JWT.Serializers;

namespace HotelRestaurantAPI.Utility
{
    public static class TokenManagerTest
    {
        public static ClaimsPrincipal ValidateToken(string token, string secret, bool checkExpiration)
        {
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IDateTimeProvider dateTimeProvider = new UtcDateTimeProvider();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtValidator jwtValidator = new JwtValidator(serializer, dateTimeProvider);
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            IJwtDecoder decoder = new JwtDecoder(serializer, jwtValidator, urlEncoder);


            var jsonSerializer = new JavaScriptSerializer();

            var payloadJson = decoder.Decode(token, secret, true);

            var payloadData = jsonSerializer.Deserialize<Dictionary<string, object>>(payloadJson);


            object exp;
            if (payloadData != null && (checkExpiration && payloadData.TryGetValue("exp", out exp)))
            {
                //var validTo = FromUnixTime(long.Parse(exp.ToString()));
                var validTo = FromUnixTime((long)Convert.ToDouble(exp.ToString()));
                if (DateTime.Compare(validTo, DateTime.UtcNow) <= 0)
                {
                    throw new Exception(
                        string.Format("Token is expired. Expiration: '{0}'. Current: '{1}'", validTo, DateTime.UtcNow));
                }
            }

            var subject = new ClaimsIdentity("Federation", ClaimTypes.Name, ClaimTypes.Role);

            var claims = new List<Claim>();

            if (payloadData != null)
                foreach (var pair in payloadData)
                {
                    var claimType = pair.Key;

                    var source = pair.Value as ArrayList;

                    if (source != null)
                    {
                        claims.AddRange(from object item in source
                                        select new Claim(claimType, item.ToString(), ClaimValueTypes.String));

                        continue;
                    }

                    switch (pair.Key)
                    {
                        case "username":
                            claims.Add(new Claim(ClaimTypes.Name, pair.Value.ToString(), ClaimValueTypes.String));
                            break;
                    }
                }

            subject.AddClaims(claims);
            return new ClaimsPrincipal(subject);
        }

        private static DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

        public static string CreateToken(User user)
        {
            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var expiry = Math.Round((DateTime.UtcNow.AddHours(2) - unixEpoch).TotalSeconds);
            var issuedAt = Math.Round((DateTime.UtcNow - unixEpoch).TotalSeconds);
            var notBefore = Math.Round((DateTime.UtcNow.AddMonths(6) - unixEpoch).TotalSeconds);


            var payload = new Dictionary<string, object>
            {
                //{"username", user.UserName},
                //{"nbf", notBefore},
                //{"iat", issuedAt},
                //{"exp", expiry}
                { "sub", "1234567890"},
                { "name", "John Doe"},
                { "admin", true}
            };

            //var secret = ConfigurationManager.AppSettings.Get("jwtKey");
            const string apikey = "secretKey";

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IDateTimeProvider dateTimeProvider = new UtcDateTimeProvider();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtValidator jwtValidator = new JwtValidator(serializer, dateTimeProvider);
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            IJwtDecoder decoder = new JwtDecoder(serializer, jwtValidator, urlEncoder);

            var token = encoder.Encode(payload, apikey); // (payload, apikey, JwtHashAlgorithm.HS256);

            return apikey;
        }
    }
}
