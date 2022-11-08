using System;
using System.Text;
using System.Threading.Tasks;

using Take.Api.GitChallenge.Middleware;
using Take.Api.GitChallenge.Models.UI;

using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

using NSubstitute;

using Xunit;

namespace Take.Api.GitChallenge.Tests.Middleware
{
    public class SwaggerAuthenticationTests
    {
        private const string SWAGGER_PATH = "/swagger";
        private readonly RequestDelegate _requestDelegate;
        private readonly SwaggerCredentials _credential;
        private readonly SwaggerBasicAuthMiddleware _middleware;

        public SwaggerAuthenticationTests()
        {
            _requestDelegate = Substitute.For<RequestDelegate>();
            _credential = new SwaggerCredentials();
            _credential.Username = "username";
            _credential.Password = "password";

            _middleware = new SwaggerBasicAuthMiddleware(_requestDelegate, _credential);
        }

        [Fact]
        public async Task WhenPathIsNotSwagger_CallNextAsync()
        {
            var context = new DefaultHttpContext();

            await _middleware.InvokeAsync(context);

            Assert.False(StatusCodes.Status401Unauthorized == context.Response.StatusCode);
        }

        [Fact]
        public async Task WhenPathIsSwagger_IsNotAuthenticated_CallNextAsync()
        {
            var context = new DefaultHttpContext();
            context.Request.Headers[HeaderNames.Authorization] = "NotValidAuthorization";
            context.Request.Path = SWAGGER_PATH;

            await _middleware.InvokeAsync(context);

            Assert.True(StatusCodes.Status401Unauthorized == context.Response.StatusCode);
        }

        [Fact]
        public async Task WhenPathIsSwagger_IsAuthenticated_CallNextAsync()
        {
            var context = new DefaultHttpContext();
            var bytesIn = Encoding.UTF8.GetBytes($"{_credential.Username}:{_credential.Password}");
            context.Request.Headers[HeaderNames.Authorization] = $"Basic {Convert.ToBase64String(bytesIn)}";
            context.Request.Path = SWAGGER_PATH;

            await _middleware.InvokeAsync(context);

            Assert.False(StatusCodes.Status401Unauthorized == context.Response.StatusCode);
        }
    }
}
