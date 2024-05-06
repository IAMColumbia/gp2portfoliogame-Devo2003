using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public static class Score
    {
        public static int CurrentScore = 1000;
        public static int HighScore = 1000;
        //public static int L
        //public static int FinalScore;
        //public static int StartScore;


        public static void UpdateScore()
        {
            
            if (CurrentScore > HighScore)
            {
                HighScore = CurrentScore;
            }
            
            
        }

        public static void AddScore(int score)
        {
            CurrentScore += score;
            //scoreText.text = "Score: " + Score.CurrentScore.ToString();
        }
    }
}
