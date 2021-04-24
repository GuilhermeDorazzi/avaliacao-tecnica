using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Citel.Api.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("v1/Home")]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
