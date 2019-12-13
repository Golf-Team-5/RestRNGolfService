using System;
using Microsoft.AspNetCore.Mvc;
using RestRNGolfService.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using RestRNGolfService.Utility;

namespace RestRNGolfService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwingDataController : ControllerBase
    {
        //variabel til at holde swing data fra UDPGolf og raspberry pi'en efter den er blev omdannet til afstand

        //liste af swing data fra UDPGolf og raspberry pi'en efter de er blev omdannet til afstand

        public static List<int> SwingDistanceList = new List<int>
        {
            800
        };
        public static int FinalSwingDistance = 800;



        // GET: api/SwingData
        [HttpGet]
        public int Get()
        {

            ScoreCalculator.NoOfSwings++;

            return FinalSwingDistance;
            
        }

        // GET: api/SwingData/GetScore 
        [HttpGet]
        [Route("GetScore")]
        public int GetScore(int par, int hits)
        {
            ScoreCalculator.CalculateScore(par, hits);
            int scoreAndNoOfSwings = ScoreCalculator.Score;
            return scoreAndNoOfSwings;
        }

        // GET: api/SwingData/GetLeaderboard
        [HttpGet]
        [Route("GetLeaderboard")]
        public List<Player> GetLeaderboard()
        {
            List<Player> playerList = DBUtility.GetPlayersFromDatabase();
            return playerList;
            
        }

        // GET: api/SwingData/5
        [HttpGet]
        [Route("GetSinglePlayer/" + "{playerName}" )]
        public Player GetSinglePlayer(string playerName )
        {
            Player singlePlayer = DBUtility.GetSinglePlayerFromDB(playerName);
            return singlePlayer;
        }

       
        // PUT: api/SwingData/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        
        // POST: api/SwingData
        [HttpPost]
        public void PostSwingDataAsDistance([FromBody] SwingData swingSpeed)
        {

            int swingDistance = DistanceMeasurer.CalculateDistance(swingSpeed);

            if (swingDistance != 0)
            {
                FinalSwingDistance = swingDistance;
            }


        }

        // POST: api/SwingData/PostPlayerScore
        [HttpPost]
        [Route("PostPlayerScore")]
        public void PostPlayerScore([FromBody] Player player)
        {

            DBUtility.PostPlayerToDB(player);

        }

        

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("{id}")]
        public void DeletePlayerFromDB(int id)
        {
            DBUtility.DeletePlayerFromDatabase(id);
        }
    }
}
