using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AzureADChallenge
{
    public class MSGraphService
    {
        public static string resource = "https://graph.windows.net";
        public static string aadInstance = "https://login.microsoftonline.com/{0}";
        public static string appId = "b33c5303-8cb2-416a-b0ef-b19daff437dd";
        public static string tenant = "b378ae0f-f575-4ca8-ace3-81ace31f3706";
        public static string appSecret = "k7_7Dt0_wI2gV8OHSSc~yM2ZL7.hulRqOW";
        public static string authority = String.Format(CultureInfo.InvariantCulture, aadInstance, tenant);

        private static HttpClient httpClient = new HttpClient();
        private static AuthenticationContext context = new AuthenticationContext(authority);
        private static ClientCredential credential = new ClientCredential(appId, appSecret);

        public string HardCodedToken()
        {
            return "EwBYA8l6BAAU6k7+XVQzkGyMv7VHB/h4cHbJYRAAAfaakZIACvfo4GdawWtThil8ejElrkJ2zYm0A2m+Kg7lNpqomp7l5e6/kh0dGILf65bJUIPhSFn57YHMYe34FG3eHtKpsWrX2Vta9yD7NippMM9WHEwNYr5bUgyzkWqNcBAd56CkxzgjHy/lDqvFBO9oRwLkNjCSqCWBTloemdaFUaq2jdhfbhsgXBvDTrTLmMNP6dC7Olj7lb84Ii8HcMTJVdAwcVrLTTg3YzMCLHgrIld7zuuBBRCIvNc5AI8cgtpsXdBFkmE8UFI9//WVV20yWUhkTOetno2vRO6gCAqENWX6lESaWX5wfD90unKPGEYr1rVRsyD0SuticgvpnmkDZgAACJaZHfWRx8ncKAI05FwHs21C3iuHU0IN0LVRtUMjHqYOFpCUEgMnUGx/AJVmiB5qLi78H0hjPSNJzoUeCeQOJtlZJq0FBcE8lGxSPdkenRcsWT2XDQrDynjKPOO/P7CBEbqtcqDoNsqIERYyJEk9w8XoD8I/h9sZpqD8B54rkDheAg2GC+qAJ0We5XPC3s3o48nz75hvZqXlCO1GIhPUKrzWzSVgW5ZQ1Gjom3R5w2ijx/Of+Nsqgs+KhhUUe02OYThqVUPz6CZNGyevdDFP2MP6UBSXRzdnz7Qyz5XYySjghvrn/wCaUM/rx5lBijn+Mhiazg8bIvXgUBL6qMZz/h5jHANhuL4eN5EZSwhKiaAq73GSFaREIfYFpcWKHG42TEvIUnYlReXhKFtWD0weyViCb5XCK4OxMb/rN3mm2+CzImqiYmHpa5hUY3StESi88/Qoxm8E4B/5CxNT0aapO5I7wP+gTxiVbnZAOn1rfwRzshV/RbmiRv1othTXDaqn81NxGMRdThCAAGcrR5eXTkT5gqRe8KPdZiEJxJBiKILl+e21/orRiovuPhdY0G3+B2LJDyMXxuVxJtF7plW81275YfUAP11lM60I0/vbkJkWefmaqN6vPmiL2Ay6CBDLxYGjbB05mUNPq9CBrN/QA0LFDSHmp3iUu1x/jjF7rEsw/YqyHv0obUZfWq9XBlPmBOr2kkmFAVZMek8PItWl0OGGnhwPRj1TdIrZmZ0fLU2qqA5uAg==";
        }

        /*public async Task<string> GetUser(string token)
        {
            //string user = "17030064-bbd5-4380-9697-d5997a9be24e";
            //string url = "https://graph.windows.net/"+ tenant + "/users?api-version=1.6";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string url = "https://graph.microsoft.com/v1.0/users/me";

            var result = await httpClient.GetAsync(url);

            return await result.Content.ReadAsStringAsync();
        }*/

        /*public async Task<string> GetMyUser()
        {
            var user = await GetUser(HardCodedToken());
            Console.WriteLine(user);

            return "nitido";
        }*/

        public async Task<string> GetToken()
        {
            string url = ("https://login.microsoftonline.com/b378ae0f-f575-4ca8-ace3-81ace31f3706/oauth2/v2.0/token HTTP/1.1");

            var result = await httpClient.GetAsync(url);

            return await result.Content.ReadAsStringAsync();
        }

        public async Task<string> GetAllUsers(string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            string url = "https://graph.microsoft.com/v1.0/users/";

            var result = await httpClient.GetAsync(url);

            return await result.Content.ReadAsStringAsync();
        }
    }
}
