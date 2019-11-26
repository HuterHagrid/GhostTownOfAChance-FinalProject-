using System;
using System.Windows.Forms;

namespace PlatformGame2
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void playGameButton_Click(object sender, EventArgs e)
        {
            Hide();
            Level2 level1 = new Level2(0, 10);
            level1.Closed += (s, args) => this.Close();
            level1.Show();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
