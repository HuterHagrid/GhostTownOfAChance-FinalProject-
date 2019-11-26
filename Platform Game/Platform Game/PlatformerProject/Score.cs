using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerProject
{
    class Score
    {
        long scoreNumber;
        
        public Score()
        {
            this.scoreNumber = 0;
        }

        public Score(Score obj)
        {
            this.scoreNumber = obj.scoreNumber;
        }

        public void IncrementScore(int pointValue)
        {
            this.scoreNumber += pointValue;
            GetScore();

        }
        public long GetScore()
        {
            return scoreNumber;
        }

        public override string ToString()
        {
            return "Score: " + scoreNumber;
        }
    }
}
