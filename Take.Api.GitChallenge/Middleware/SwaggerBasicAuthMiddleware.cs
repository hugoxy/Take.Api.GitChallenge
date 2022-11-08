using System;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Take.Api.GitChallenge.Models.UI;

using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace Take.Api.GitChallenge.Middleware
{
    /// <summary>
    /// Add security to swagger endpoint
    /// </summary>
    public class SwaggerBasicAuthMiddleware
    {
        private const string SWAGGER_PATH = "/swagger";
        private const string INDEX_PATH = "/index.html";
        private const string AUTHORIZATION_HEADER_BASIC = "Basic";
        private const char SEPARATOR = ':';
        private const string SPACE = " ";
        private const int USERNAME_INDEX = 0;
        private const int PASSWORD_INDEX = 1;

        private readonly RequestDelegate _next;
        private readonly SwaggerCredentials _credentials;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="next"></param>
        /// <param name="credentials"></param>
        public SwaggerBasicAuthMiddleware(RequestDelegate next, SwaggerCredentials credentials)
        {
            _next = next;
            _credentials = credentials;
        }

        /// <summary>
        /// Invoke validate the swagger endpoint
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments(SWAGGER_PATH) || context.Request.Path.StartsWithSegments(INDEX_PATH))
            {
                string authHeader = context.Request.Headers[HeaderNames.Authorization];
                if (authHeader != null && authHeader.StartsWith(AUTHORIZATION_HEADER_BASIC+SPACE))
                {
                    // Get the credentials from request header
                    var header = AuthenticationHeaderValue.Parse(authHeader);
                    var inBytes = Convert.FromBase64String(header.Parameter);
                    var credentials = Encoding.UTF8.GetString(inBytes).Split(SEPARATOR);
                    var username = credentials[USERNAME_INDEX];
                    var password = credentials[PASSWORD_INDEX];
                    // validate credentials
                    if (username.Equals(_credentials.Username)
                      && password.Equals(_credentials.Password))
                    {
                        await _next.Invoke(context).ConfigureAwait(false);
                        return;
                    }
                }
                context.Response.Headers[HeaderNames.WWWAuthenticate] = AUTHORIZATION_HEADER_BASIC;
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }
            else
            {
                await _next.Invoke(context).ConfigureAwait(false);
            }
        }
    }
}
