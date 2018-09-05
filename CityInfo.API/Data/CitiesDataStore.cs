using CityInfo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Data
{
    public class CitiesDataStore
    {
        public List<CityDTO> Cities { get; set; }

        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public CitiesDataStore() {
            Cities = new List<CityDTO>()
            {
                new CityDTO() { Id = 1, Name = "New York", Description = "The big Apple",
                PointsOfInterest = new List<PointOfInterestDTO>() {
                   new PointOfInterestDTO { Id = 1, Name = "Central Park", Description = "The most visited park anywhere!"},
                   new PointOfInterestDTO { Id = 2, Name = "Statue Of Liberty", Description = "Actually a big girl with an Olympic torch"}
                } },
                new CityDTO() { Id = 2, Name = "Belfast", Description = "Home town",
                PointsOfInterest = new List<PointOfInterestDTO>() {
                   new PointOfInterestDTO { Id = 3, Name = "City Hall", Description = "Big building for getting married and eating lunch"},
                   new PointOfInterestDTO { Id = 4, Name = "Primark", Description = "Burnt out, unfortunately"}
                } },
                new CityDTO() { Id = 3, Name = "Ballygowan", Description = "Legends are born here",
                PointsOfInterest = new List<PointOfInterestDTO>() {
                   new PointOfInterestDTO { Id = 5, Name = "The Garage", Description = "Everything and anything under one roof. And petrol"},
                   new PointOfInterestDTO { Id = 6, Name = "Community Centre", Description = "This is where is all happens"}
                } }
            };
        }
    }
}
