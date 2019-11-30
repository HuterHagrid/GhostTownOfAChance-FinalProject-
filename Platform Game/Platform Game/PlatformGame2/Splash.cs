using System;
using System.Windows.Forms;

namespace PlatformGame2
{
    public partial class Splash : Form
    {
        // Sound Player
        private System.Media.SoundPlayer sp;

        public Splash()
        {
            InitializeComponent();

            // Update the high scores and play splash music
            UpdateHS();
            ResetMusic();
        }

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
        private void playGameButton_Click(object sender, EventArgs e)
        {
            // Stop the splash music and start playing the game music
            sp.Stop();

            // Hide the splash and open level
            Hide();
            Level2 level1 = new Level2(0, 5, this);
            // Adds closing function to the level to close all windows
            level1.Closed += (s, args) => this.Close();
            level1.Show();
        }

        // Quits the game
        private void quitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
