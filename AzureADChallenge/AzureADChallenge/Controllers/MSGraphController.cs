using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureADChallenge.Controllers
{
    [ApiController]
    [Route("api")]
    public class MSGraphController : ControllerBase
    {
        public MSGraphService graphService = new MSGraphService();

        [HttpGet("token")]
        public ActionResult GetTokenAsync()
        {
            var token = graphService.GetMyUser();

            return Ok();
        }

    }
}
