using AzureADChallenge.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AzureADChallenge.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GraphController : ControllerBase
    {
        public GraphService graphService = new GraphService();

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var result = await graphService.GetAllUsers();

            return Ok(result);
        }
    }
}
