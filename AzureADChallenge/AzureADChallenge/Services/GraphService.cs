using Azure.Identity;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AzureADChallenge.Services
{
    public class GraphService
    {
        public static string clientId = "b33c5303-8cb2-416a-b0ef-b19daff437dd";
        public static string tenantId = "b378ae0f-f575-4ca8-ace3-81ace31f3706";
        public static string clientSecret = "k7_7Dt0_wI2gV8OHSSc~yM2ZL7.hulRqOW";

        public async Task<IGraphServiceUsersCollectionPage> GetAllUsers()
        {
            var clientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret);

            var graphClient = new GraphServiceClient(clientSecretCredential);

            var users = await graphClient.Users.Request().GetAsync();

            return users;
        }
    }
}
