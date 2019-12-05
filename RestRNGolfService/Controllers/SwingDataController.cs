using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestRNGolfService.Model;

namespace RestRNGolfService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwingDataController : ControllerBase
    {

        //liste af swing data fra UDPGolf og raspberry pi'en efter de er blev omdannet til afstand

        public static List<int> SwingDistanceList = new List<int>();





        // GET: TEST - Slet mig igen
        [HttpGet]
        public int Get()
        {

            return 200;
        }

        // GET: api/SwingData
        //[HttpGet]
        //public IEnumerable<int> Get()
        //{
            
        //    return SwingDistanceList;
        //}

        // GET: api/SwingData/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SwingData
        [HttpPost]
        public void PostSwingDataAsDistance([FromBody] SwingData swingSpeed)
        {
            
                int swingDistance = DistanceMeasurer.CalculateDistance(swingSpeed);

                if (swingDistance != 0)
                {
                    SwingDistanceList.Add(swingDistance);
                }
            
             
        }

        // PUT: api/SwingData/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
