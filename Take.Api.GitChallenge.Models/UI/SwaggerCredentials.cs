using System.Diagnostics.CodeAnalysis;

namespace Take.Api.GitChallenge.Models.UI
{
    [ExcludeFromCodeCoverage]
    public class SwaggerCredentials
    {
        /// <summary>
        /// Username to access swagger
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password to access swagger
        /// </summary>
        public string Password { get; set; }
    }
}
