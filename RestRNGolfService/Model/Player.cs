using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestRNGolfService.Model
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int PlayerSwings { get; set; }
        public int PlayerScore { get; set; }

        public Player( string playerName, int playerSwings, int playerScore)
        {
            
            PlayerName = playerName;
            PlayerSwings = playerSwings;
            PlayerScore = playerScore;
        }

        public Player()
        {
            
        }

        public override string ToString()
        {
            return $"{nameof(PlayerId)}: {PlayerId}, {nameof(PlayerName)}: {PlayerName}, {nameof(PlayerSwings)}: {PlayerSwings}, {nameof(PlayerScore)}: {PlayerScore}";
        }
    }
}
