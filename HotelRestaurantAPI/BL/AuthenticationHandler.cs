using JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace HotelRestaurantAPI.BL
{
    public class AuthenticationHandler : DelegatingHandler
    {
        public AuthenticationHandler(HttpConfiguration httpConfiguration)
        {
            InnerHandler = new HttpControllerDispatcher(httpConfiguration);
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                        CancellationToken cancellationToken)
        {
            HttpResponseMessage errorResponse = null;

            try
            {
                IEnumerable<string> authHeaderValues;
                request.Headers.TryGetValues("Authorization", out authHeaderValues);


                if (authHeaderValues == null)
                {
                    errorResponse = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
                else
                {
                    string bearerToken = authHeaderValues.ElementAt(0);
                    if (String.IsNullOrEmpty(bearerToken))
                    {
                        errorResponse = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    }
                    else
                    {
                        string token = bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : null;
                        if (String.IsNullOrEmpty(token))
                        {
                            errorResponse = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                        }
                        else
                        {
                            //var secret = ConfigurationManager.AppSettings.Get("jwtKey");
                            var secret = "secretKey";

                            Thread.CurrentPrincipal = HotelRestaurantAPI.Utility.TokenManagerTest.ValidateToken(
                                token,
                                secret,
                                true
                                );

                            if (HttpContext.Current != null)
                            {
                                HttpContext.Current.User = Thread.CurrentPrincipal;
                            }
                        }

                    }
                }
            }
            catch (SignatureVerificationException ex)
            {
                errorResponse = request.CreateErrorResponse(HttpStatusCode.Unauthorized, ex.Message);
            }
            catch (Exception ex)
            {
                errorResponse = request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return errorResponse != null
                ? Task.FromResult(errorResponse)
                : base.SendAsync(request, cancellationToken);
        }
    }
}