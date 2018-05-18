using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Script.Serialization;
using JWT;
using DAL.Entities;
using JWT.Algorithms;
using JWT.Serializers;
using JWT.Builder;

namespace HotelRestaurantAPI.Utility
{
    public static class TokenManager
    {
        public static ClaimsPrincipal ValidateToken(string token, string secret, bool checkExpiration)
        {
            var jsonSerializer = new JavaScriptSerializer();

            //const string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJjbGFpbTEiOjAsImNsYWltMiI6ImNsYWltMi12YWx1ZSJ9.8pwBI_HtXqI3UgQHQ_rDRnSQRxFL1SR8fbQoS-5kM5s";
            //const string secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";
            var payloadJson = "";
            try
            {
                var json = new JwtBuilder()
                            .WithSecret(secret)
                            .MustVerifySignature()
                            .Decode(token);
                Console.WriteLine(json);
            }
            //catch (TokenExpiredException e)
            //{
            //    Console.WriteLine("Token has expired"+e.Message);
            //    throw new Exception("U must to re-log in!");
            //}
            //catch (SignatureVerificationException e)
            //{
            //    Console.WriteLine("Token has invalid signature" + e.Message);
            //    throw new Exception("Bad user authenticated!"+e.Message);
            //}
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception("Smth.  went wrong while authenticating!"+e.Message);
            }

            //var payloadJson = JWT.JsonWebToken.Decode(token, secret);
            var payloadData = jsonSerializer.Deserialize<Dictionary<string, object>>(payloadJson);


            //object exp;
            //if (payloadData != null && (checkExpiration && payloadData.TryGetValue("exp", out exp)))
            //{
            //    var validTo = FromUnixTime(long.Parse(exp.ToString()));
            //    if (DateTime.Compare(validTo, DateTime.UtcNow) <= 0)
            //    {
            //        throw new Exception(
            //            string.Format("Token is expired. Expiration: '{0}'. Current: '{1}'", validTo, DateTime.UtcNow));
            //    }
            //}

            var subject = new ClaimsIdentity("Federation", ClaimTypes.Name, ClaimTypes.Role);

            var claims = new List<Claim>();


            foreach (var pair in payloadData)
            {
                var claimType = pair.Key;

                //var source = pair.Value as ArrayList;

                if (pair.Value is ArrayList source)
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
                {"username", user.UserName},
                {"nbf", notBefore},
                {"iat", issuedAt},
                {"exp", expiry}
            };

            //var secret = ConfigurationManager.AppSettings.Get("jwtKey");
            const string apikey = "secretKey";


            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            var token = encoder.Encode(payload, apikey);

            //var token = JsonWebToken.Encode(payload, apikey, JwtHashAlgorithm.HS256);

            return token;
        }
    }
}