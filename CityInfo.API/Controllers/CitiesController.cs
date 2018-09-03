using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class CitiesController
    {
        [HttpGet()]
        public JsonResult GetCities() {
            return new JsonResult(CitiesDataStore.Current.Cities);
        }

        [HttpGet("{id}")]
        public JsonResult GetCity(int id) {
        return new JsonResult(CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == id));
        }
    }
}