
using System.Collections.Generic;
using System.IO;

namespace PlatformGame2
{
    class HighScores
    {
        private List<string> highscores;

        public HighScores()
        {
            highscores = new List<string>(10);

            
        }

        public void Read()
        {
            using (StreamReader sr = new StreamReader("HighScores.txt"))
            {

            }
        }
    }
}
