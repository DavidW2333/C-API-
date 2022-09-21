using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CS335_A1.Controllers
{
    [Route("api")]
    [ApiController]
    public class VersionController : Controller
    {
        [HttpGet("GetVersion")]
        public ContentResult GetVersion()
        {
            string v1 = "<html><body>v1</body></html> ";
            ContentResult c = new ContentResult
            {
                Content = v1,
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
            };
            return c;
        
    }
    }
}
