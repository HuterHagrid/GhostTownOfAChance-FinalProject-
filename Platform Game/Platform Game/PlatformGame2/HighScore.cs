using System;

/// <summary>
/// HighScore.cs
/// 
/// This class file defines a High Score
/// Properties: Name, Score
/// Methods: Constructor, ToString, CompareTo
/// </summary>

namespace PlatformGame2
{
    class HighScore : IComparable
    {
        // Properties
        public string Name { set; get; }
        public int Score { set; get; }

        // Full Constructor
        public HighScore(string name, int score)
        {
            Name = name;
            Score = score;
        }

        // String representation of a High Score
        public override string ToString()
        {
            return string.Format("{0} {1}", Name, Score);
        }

        // Compares two Scores, returns -1 if this one is less than the other,
        // 0 if they are equal and 1 if this one is greater than the other
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            if (obj is HighScore other)
            {
                return Score.CompareTo(other.Score);
            }
            else
            {
                throw new ArgumentException("Object is not a High Score");
            }
        }
    }
}
