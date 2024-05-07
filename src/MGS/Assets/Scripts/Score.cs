using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Score
    {
        public static int CurrentScore = 1000;
        public static int HighScore = 2100;


        public static int startingScore = 1000;
        public static int totalScore;
        // Private static variables to hold the instance of the class
        private static Score instance;

        // Public properties to access the instance
        public static Score Instance
        {
            get
            {
               
                if (instance == null)
                {
                    instance = new Score();
                }
                return instance;
            }
        }


        public static void UpdateScore()
        {
            if (totalScore > HighScore)
            {
                HighScore = totalScore;
            }
        }

        
    }
}
