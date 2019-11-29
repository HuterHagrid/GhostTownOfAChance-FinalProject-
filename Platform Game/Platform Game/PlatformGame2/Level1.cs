using System.Windows.Forms;

namespace PlatformGame2
{
    // Level 1 is an intro level. There are only platforms and coins in order to get
    // the player familiar with the game controls.
    public class Level1 : CustomForm
    {
        public Level1(int score, int lives, Splash splash) : base(score, lives, splash)
        {
            Text += ": Level 1";

            SplashHold = splash;
            
            // Platforms
            Platform plat1 = new Platform(250, 40 * JS, 100, 10, "platform");
            Controls.Add(plat1);
            Platform plat2 = new Platform(400, 35 * JS, 100, 10, "platform");
            Controls.Add(plat2);
            Platform plat3 = new Platform(400, 28 * JS, 100, 10, "platform");
            Controls.Add(plat3);
            Platform plat4 = new Platform(575, 25 * JS, 300, 10, "platform");
            Controls.Add(plat4);
            Platform plat5 = new Platform(300, 20 * JS, 100, 10, "platform");
            Controls.Add(plat5);
            Platform plat6 = new Platform(100, 23 * JS, 100, 10, "platform");
            Controls.Add(plat6);
            Platform plat12 = new Platform(100, 30 * JS, 100, 10, "platform");
            Controls.Add(plat12);
            Platform plat7 = new Platform(100, 15 * JS, 100, 10, "platform");
            Controls.Add(plat7);
            Platform plat8 = new Platform(200, 9 * JS, 100, 10, "platform");
            Controls.Add(plat8);
            Platform plat9 = new Platform(375, 5 * JS, 150, 10, "platform");
            Controls.Add(plat9);
            Platform plat10 = new Platform(660, 13 * JS, 215, 10, "platform");
            Controls.Add(plat10);
            Platform plat11 = new Platform(675, 32 * JS, 200, 10, "platform");
            Controls.Add(plat11);

            // Coins
            Entity coin1 = new Entity(630, 350, "coin");
            Controls.Add(coin1);
            Entity coin2 = new Entity(710, 350, "coin");
            Controls.Add(coin2);
            Entity coin3 = new Entity(790, 350, "coin");
            Controls.Add(coin3);
            Entity coin4 = new Entity(710, 455, "coin");
            Controls.Add(coin4);
            Entity coin5 = new Entity(790, 455, "coin");
            Controls.Add(coin5);
            Entity coin6 = new Entity(420, 55, "coin");
            Controls.Add(coin6);
            Entity coin7 = new Entity(470, 55, "coin");
            Controls.Add(coin7);
            Entity coin8 = new Entity(145, 425, "coin");
            Controls.Add(coin8);
            Entity coin9 = new Entity(840, 175, "coin");
            Controls.Add(coin9);

            // Exit
            Entity exit = new Entity(800, 170, "exit");
            Controls.Add(exit);
        }

        public override void Next()
        {
            Hide();
            Level2 level2 = new Level2(GetScore(), GetLives(), SplashHold);
            level2.Closed += (s, args) => this.Close();
            level2.Show();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Level1
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(292, 268);
            this.Name = "Level1";
            this.ResumeLayout(false);

        }
    }
}
