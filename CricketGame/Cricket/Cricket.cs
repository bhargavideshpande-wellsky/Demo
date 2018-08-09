using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketGame
{
    public class Cricket
    {
        public int PlayerScore { get; set; }
        public int PlayerScore1 { get; set; }
        public int PlayerScore2 { get; set; }
        public bool PlayerStatus { get; set; }
        public bool Player1Status { get; set; }
        public bool Player2Status { get; set; }
        public int Winner;
        public Cricket()
        {
            PlayerScore = 0;
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            PlayerStatus = true;
            Player1Status = true;
            Player2Status = true;
        }
        public void Score(int runs)
        {
            if (runs >= 6)
            {
                PlayerScore = 0;
            }
            else
            {
                if (PlayerStatus == true)
                {
                    PlayerScore = PlayerScore + runs;
                }
                
            }

            //throw new NotImplementedException();
        }
        public void Score2(int runs1, int runs2)
        {
            if (Player1Status == true)
            {
                PlayerScore1 = PlayerScore1 + runs1;
            }
            if (Player2Status == true)
            {
                PlayerScore2 = PlayerScore2 + runs2;
            }
            if (PlayerScore1 > PlayerScore2)
            {
                Winner = PlayerScore1;
            }
            else
            {
                Winner = PlayerScore2;
            }
            
        }
        
    }
}
