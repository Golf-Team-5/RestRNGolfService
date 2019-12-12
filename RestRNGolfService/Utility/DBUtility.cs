using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RestRNGolfService.Model;

namespace RestRNGolfService.Utility
{
    public class DBUtility
    {
        //Connection to Database

        #region Database Connection

        private const string connectionString = "Server = tcp:golfserver.database.windows.net,1433; Initial Catalog = RNGolfDB; Persist Security Info=False; User ID = GolfMaster; Password=HoleInOne!; MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=False; Connection Timeout = 30;";
        private const string GET_ALL = "Select * From Player";
        

        /// <summary>
        /// This method iterates through the database and returns a list of all the Player objects in the database.
        /// </summary>
        /// <returns></returns>
        public static List<Player> GetPlayersFromDatabase()
        {
            List<Player> playerList = new List<Player>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(GET_ALL, conn))
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Player player = NextPlayer(reader);
                        playerList.Add(player);
                    }
                    reader.Close();
                }
                return playerList;
            }

        }

        /// <summary>
        /// This method returns a single Player object from the database, using the Player objects PlayerName property.
        /// </summary>
        /// <param name="playerName"></param>
        /// <returns></returns>
        public static Player GetSinglePlayerFromDB(string playerName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand())
                {
                    
                    command.CommandText = "Select * From Player WHERE Player.PlayerName = @playerName";
                    command.Parameters.AddWithValue("@playerName", playerName);
                    var playerId = command.ExecuteScalar();
                    //TODO method returns ID not player object

                }
            }
        }

        /// <summary>
        /// This method creates a new Player object using data from a specific row in the database.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected static Player NextPlayer(SqlDataReader reader)
        {
            Player player = new Player();
            player.PlayerId = reader.GetInt32(0);
            player.PlayerName = reader.GetString(1);
            player.PlayerSwings = reader.GetInt32(2);
            player.PlayerScore = reader.GetInt32(3);
            return player;
        }

        public static void PostPlayerToDB(Player player)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    using (SqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = "Insert into Player values (@Param1, @Param2, @Param3)";
                        command.Parameters.AddWithValue("@Param1", player.PlayerName);
                        command.Parameters.AddWithValue("@Param2", player.PlayerSwings);
                        command.Parameters.AddWithValue("@Param3", player.PlayerScore);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }


        #endregion
    }
}
