using Microsoft.AspNetCore.Mvc;
using RestRNGolfService.Model;
using System.Collections.Generic;

namespace RestRNGolfService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwingDataController : ControllerBase
    {

        //liste af swing data fra UDPGolf og raspberry pi'en efter de er blev omdannet til afstand

        public static List<int> SwingDistanceList = new List<int>
        {
            200
        };


        // GET: api/SwingData
        [HttpGet]
        public IEnumerable<int> Get()
        {

            ScoreCalculator.NoOfSwings++;

            return SwingDistanceList;
        }

        // GET: api/SwingData/GetScore 
        [HttpGet]
        [Route("GetScore")]
        public int[] GetScore(int par)
        {
            ScoreCalculator.CalculateScore(par);
            int[] scoreAndNoOfSwings = new[] { ScoreCalculator.Score, ScoreCalculator.NoOfSwings };
            return scoreAndNoOfSwings;
        }

        // PUT: api/SwingData/ResetSwings
        [HttpPut]
        [Route("ResetSwings")]
        public void ResetSwings()
        {
            ScoreCalculator.NoOfSwings = 0;
        }

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
