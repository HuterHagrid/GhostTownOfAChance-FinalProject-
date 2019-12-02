using System;
using System.Windows.Forms;

/// <summary>
/// Splash.cs
/// 
/// This class file defines the splash screen used when the game runs.
/// Methods: Constructor, ResetMusic, UpdateHS, PlayGameButton_Click, QuitButton_Click
/// </summary>

namespace PlatformGame2
{
    public partial class Splash : Form
    {
        // Sound Player
        private System.Media.SoundPlayer sp;

        // Constructor
        public Splash()
        {
            InitializeComponent();

            // Update the high scores and play splash music
            UpdateHS();
            ResetMusic();
        }

        // Plays the splash screen music
        public void ResetMusic()
        {
            sp = new System.Media.SoundPlayer(@"Fastest Gun in the 8-bit West.wav");
            sp.PlayLooping();
        }

        // Updates the High Scores text box to the most recent leaderboard
        public void UpdateHS()
        {
            HighScores hs = new HighScores();
            highScoresRichTextBox.Text = hs.ToString();
        }

        // Lets player play the game
        private void PlayGameButton_Click(object sender, EventArgs e)
        {
            // Stop the splash music and start playing the game music
            sp.Stop();

            // Hide the splash and open level
            Hide();
            Level1 level1 = new Level1(0, 10, this);
            // Adds closing function to the level to close all windows
            level1.Closed += (s, args) => this.Close();
            level1.Show();
        }

        // Quits the game
        private void QuitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
