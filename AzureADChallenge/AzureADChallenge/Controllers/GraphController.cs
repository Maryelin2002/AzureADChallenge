using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AzureADChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphController : ControllerBase
    {
        public MSGraphService graphService = new MSGraphService();
        private static HttpClient httpClient = new HttpClient();
        public string token;

        [HttpPost("token")]
        public async Task<string> GetTokenAsync()
        {
            string url = ("https://login.microsoftonline.com/b378ae0f-f575-4ca8-ace3-81ace31f3706/oauth2/v2.0/token HTTP/1.1");

            var result = await httpClient.GetAsync(url);
            token = await result.Content.ReadAsStringAsync();

            return token;
        }

        [HttpGet("user")]
        public ActionResult GetUser()
        {
            var result = graphService.GetAllUsers(token);



            return Ok(result);
        }
    }
}
