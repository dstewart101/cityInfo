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
                new CityDTO() { Id = 1, Name = "New York", Description = "The big Apple" },
                new CityDTO() { Id = 2, Name = "Belfast", Description = "Home town" },
                new CityDTO() { Id = 3, Name = "Ballygowan", Description = "Legends are born here"}
            };
        }
    }
}
