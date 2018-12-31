using System.Collections.Generic;
using System.Linq;
using CityInfo.API.Data;
using CityInfo.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CityInfo.API.Models;
using AutoMapper;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class CitiesController : Controller
    {

        private ICityInfoRepository _cityInfoRepository;

        public CitiesController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository;
        }

        [HttpGet()]
        public IActionResult GetCities() {
            //return Ok(CitiesDataStore.Current.Cities);
            var cityEntities = _cityInfoRepository.GetCities();
            var results = Mapper.Map<IEnumerable<CityWithoutPointsOfInterestDTO>>(cityEntities);

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includePointsOfInterest = false) {

            var cityEntity = _cityInfoRepository.GetCity(id, includePointsOfInterest);
            if (cityEntity == null)
            {
                return NotFound();
            }

            if (includePointsOfInterest)
            {

                var cityResult = Mapper.Map<IEnumerable<CityDTO>>(cityEntity);
                return Ok(cityResult);
            }

            var CityWithoutPointsOfInterestResult = Mapper.Map<IEnumerable<CityWithoutPointsOfInterestDTO>>(cityEntity);

            return Ok(CityWithoutPointsOfInterestResult);
        }
    }
}