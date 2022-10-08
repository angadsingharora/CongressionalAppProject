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
        public IEnumerable<LongLat> GetLongLat(int? lastItemCount)
        {
            var list = new List<LongLat>();
            string[] lines = System.IO.File.ReadAllLines(@"OriginalAirtag.txt");
            foreach (string line in lines)
            {
                var longLat = line.Split(' ');
                var latitude = Convert.ToDouble(longLat[0]);
                var longitude = Convert.ToDouble(longLat[1]);
                list.Add(new LongLat
                {
                    Longitude = longitude,
                    Latitude = latitude
                });

            }
            if(lastItemCount != null && lastItemCount > 0)
            {
                var listArray = list.ToArray();
                var valuesToReturn = new List<LongLat>();

                for(int i = list.Count-lastItemCount.Value; i<list.Count; i++)
                {
                    valuesToReturn.Add(listArray[i]);
                }
                return valuesToReturn;
            }
            return list;
        }
    }
}

