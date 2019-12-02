using System.Collections.Generic;
using System.IO;
using System.Text;

/// <summary>
/// HighScores.cs
/// 
/// This class file defines a High Scores List
/// Variable: highscores
/// Methods: Constructor, Read, Write, Worthy, AddNewHs, Oreder, ToString
/// </summary>

namespace PlatformGame2
{
    class HighScores
    {
        // Instance Variable, List of the High Scores
        private List<HighScore> highscores;

        public HighScores()
        {
            // Holds the top 10 High Scores
            highscores = new List<HighScore>(10);
            // Read the input file
            Read();
        }

        // Reads the High Scores text file and adds the scores to the List
        public void Read()
        {
            using (StreamReader sr = new StreamReader("HighScores.txt"))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] info = line.Split();
                    highscores.Add(new HighScore(info[0], int.Parse(info[1])));
                    line = sr.ReadLine();
                }
            }
        }

        // Writes the contents of the List onto the High Scores text file
        public void Write()
        {
            Order();
            using (StreamWriter sw = new StreamWriter("HighScores.txt"))
            {
                foreach (HighScore hs in highscores)
                {
                    sw.WriteLine(hs);
                }
            }
        }

        // Determines if a new score belongs on the High Scores List
        public bool Worthy(int newScore)
        {
            if (highscores.Count < 10)
            {
                return true;
            }
            else if (highscores[9].Score.CompareTo(newScore) < 0)
            {
                return true;
            }
            return false;
        }

        // Adds a new High Score to the List if it is worthy
        public void AddNewHs(HighScore newhs)
        {
            if (Worthy(newhs.Score))
            {
                if (highscores.Count == 10)
                {
                    highscores[9] = newhs; 
                }
                else
                {
                    highscores.Add(newhs);
                }
                Order();
            }
        }

        // Orders the High Scores from highest to lowest
        public void Order()
        {
            highscores.Sort();
            highscores.Reverse();
        }

        // Returns a string of the numbered high scores
        public override string ToString()
        {
            int i = 1;
            StringBuilder sb = new StringBuilder();
            foreach (HighScore hs in highscores)
            {
                if (i == 10)
                {
                    sb.Append(string.Format("{0}. {1}", i++, hs));
                }
                else
                {
                    sb.Append(string.Format(" {0}. {1}\n", i++, hs));
                }
            }
            while (i < 11)
            {
                if (i == 10)
                {
                    sb.Append(string.Format("{0}.", i++));
                }
                else
                {
                    sb.Append(string.Format(" {0}.\n", i++));
                }
            }
            return sb.ToString();
        }
    }
}
