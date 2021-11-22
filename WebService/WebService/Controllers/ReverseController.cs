using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReverseController : Controller
    {
        private readonly ILogger<ReverseController> _logger;

        public ReverseController(ILogger<ReverseController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get([FromQuery] string data)
        {
            if(int.TryParse(data, out int number))
            {
                return Json(new { result = Math.Sqrt(number) });
            }

            return Json(new { result = $"{new string(data.Reverse().ToArray())}" });
        }
    }
}
