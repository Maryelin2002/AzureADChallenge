using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureADChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphController : ControllerBase
    {
        public MSGraphService graphService = new MSGraphService();

        [HttpGet("user")]
        public ActionResult GetTokenAsync()
        {
            var user = graphService.GetMyUser();

            return Ok(user);
        }
    }
}
