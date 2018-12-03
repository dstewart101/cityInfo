using CityInfo.API.Data;
using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CityInfo.API.Controllers
{
    [Route("api/cities/")]
    [ApiController]
    public class PointsOfInterestController : Controller
    {
        [HttpGet("{cityId}/pointsOfInterest")]
        public IActionResult GetPointsOfInterest(int cityId) {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null) {
                return NotFound();
            }
            return Ok(city.PointsOfInterest);
        }

        [HttpGet("{cityId}/pointsOfInterest/{id}", Name = "GetPointOfInterest")]
        public IActionResult GetPointOfInterest(int cityId, int id) {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterest = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);
            if (pointOfInterest == null) {
                return NotFound();
            }

            return Ok(pointOfInterest);
        }

        [HttpPost("{cityId}/pointsOfInterest/")]
        public IActionResult CreatePointOfInterest(int cityId, [FromBody] PointOfInterestForCreationDTO pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest(ModelState);
            }

            if (pointOfInterest.Description == pointOfInterest.Name)
            {
                ModelState.AddModelError("Description", "The desciption should be different from the name");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var maxPointOfInterestId = CitiesDataStore.Current.Cities
                .SelectMany(c => c.PointsOfInterest)
                .Max(m => m.Id);

            var PointOfInterest = new PointOfInterestDTO()
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            city.PointsOfInterest.Add(PointOfInterest);

            return CreatedAtRoute("GetPointOfInterest", new { cityId = cityId, id = PointOfInterest.Id } , PointOfInterest); 
            // return NamedRoute(cityId, PointOfInterestId, and the point of interest in the body)
        }

        [HttpPut("{cityId}/pointsofinterest/{id}")]
        public IActionResult UpdatePointOfInterest(int cityId, int id, [FromBody] PointOfInterestFoeUpdateDTO pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest(ModelState);
            }

            if (pointOfInterest.Description == pointOfInterest.Name)
            {
                ModelState.AddModelError("Description", "The desciption should be different from the name");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);
            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }

            pointOfInterestFromStore.Name = pointOfInterest.Name;
            pointOfInterestFromStore.Description = pointOfInterest.Description;

            return NoContent();
        }
    }
}