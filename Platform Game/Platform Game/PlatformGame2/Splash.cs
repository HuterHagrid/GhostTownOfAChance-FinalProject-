using System;
using System.Windows.Forms;

namespace PlatformGame2
{
    public partial class Splash : Form
    {
        private System.Media.SoundPlayer sp;

        public Splash()
        {
            InitializeComponent();

            sp = new System.Media.SoundPlayer(@"Fastest Gun in the 8-bit West.wav");
            sp.PlayLooping();
        }

        public void ResetMusic()
        {
            sp.Stop();
            sp = new System.Media.SoundPlayer(@"Fastest Gun in the 8-bit West.wav");
            sp.PlayLooping();
        }

        private void playGameButton_Click(object sender, EventArgs e)
        {
            sp.Stop();

            sp = new System.Media.SoundPlayer
                (@"Stayin' Alive (8 Bit Cover Version) _Tribute to Bee Gees_ - 8 Bit Universe.wav");
            sp.PlayLooping();

            Hide();
            Level1 level1 = new Level1(0, 10, this);
            level1.Closed += (s, args) => this.Close();
            level1.Show();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
