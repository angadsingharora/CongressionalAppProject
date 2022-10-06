using System;
using AirTagAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirTagAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirTagsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<LongLat> GetLongLat()
        {
            var list = new List<LongLat>();
            string[] lines = System.IO.File.ReadAllLines(@"OriginalAirtag.txt");
            foreach (string line in lines)
            {
                var longLat = line.Split(' ');
                var longitude = Convert.ToDouble(longLat[0]);
                var latitude = Convert.ToDouble(longLat[1]);
                list.Add(new LongLat
                {
                    Longitude = longitude,
                    Latitude = latitude
                });

            }
            return list;
        }
    }
}

