using DocuSign.eSign.Client;
using DocuSign.eSign.Client.Auth;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Docusign.JobContract.API.Core.Common
{
    public class DocuSignJWTHelper
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;

        public DocuSignJWTHelper(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public ApiClient GetApiClient()
        {
            var apiClient = new ApiClient(_config["DocuSign:BasePath"]);
            apiClient.Configuration.DefaultHeader.Add("Authorization", "Bearer " + GetAccessToken());
            return apiClient;
        }
        private string GetAccessToken()
        {
            var integratorKey = _config["DocuSign:IntegratorKey"];
            var userId = _config["DocuSign:UserId"];
            var authServer = _config["DocuSign:AuthServer"];
            var privateKeyFile = _config["DocuSign:PrivateKeyFile"];

            var apiClient = new ApiClient();
            apiClient.SetOAuthBasePath(authServer); // account-d.docusign.com for sandbox

            var privateKeyBytes = File.ReadAllBytes(privateKeyFile);

            var scopes = new List<string>
                {
                    "signature",       // required for sending envelopes
                    "impersonation"    // required for JWT impersonation
                };

            OAuth.OAuthToken token = apiClient.RequestJWTUserToken(
                integratorKey,
                userId,
                "account-d.docusign.com", // AuthServer
                privateKeyBytes,
                1, // Expiration in hours
                scopes);

            return token.access_token;
        }

    }
}
