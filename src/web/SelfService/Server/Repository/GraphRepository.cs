using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using SelfService.Server.Models;

namespace SelfService.Server.Repository
{
    internal class GraphRepository : IGraphRepository
    {
        ConnectionInfo connectionInfo;
        public GraphRepository(IOptions<ConnectionInfo> options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            this.connectionInfo = options.Value ?? throw new ArgumentNullException("connectioninfo");
        }

        public async IAsyncEnumerable<GraphUser> GetUsers()
        {
            var clientApp = ConfidentialClientApplicationBuilder.Create(connectionInfo.ClientId)
                .WithClientSecret(connectionInfo.ClientSecret)
                .WithRedirectUri("http://localhost")
                .WithAuthority($"https://login.microsoftonline.com/{connectionInfo.TenantId}")
                .Build();

            string[] scopes = new string[] { "https://graph.microsoft.com/.default" };
            var token = await clientApp.AcquireTokenForClient(scopes).ExecuteAsync();
            var cl = new GraphServiceClient("https://graph.microsoft.com/v1.0",
            new DelegateAuthenticationProvider(async (requestMessage) =>
                       {
                           requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", token.AccessToken);
                       }));

            var user = await cl.Users.Request().GetAsync();
            foreach (var u in user)
            {
                yield return new GraphUser
                {
                    Id = u.Id,
                    Email = u.Mail,
                    Name = u.DisplayName,
                };
            }
        }
    }
}