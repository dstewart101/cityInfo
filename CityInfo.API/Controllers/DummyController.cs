using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    public class DummyController : Controller
    {

        private CityInfoContext _context;

        public DummyController(CityInfoContext cityInfoContext)
        {
            _context = cityInfoContext;
        }

        [HttpGet]
        [Route("api/testdb")]
        public IActionResult Test()
        {
            return Ok();
        }
    }
}