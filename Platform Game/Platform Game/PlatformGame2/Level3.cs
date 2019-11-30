using System.Windows.Forms;

namespace PlatformGame2
{
    class Level3 : CustomForm
    {
        public Level3(int score, int lives, Splash splash) : base(score, lives, splash)
        {
            Text += ": Level 3";

            SplashHold = splash;

            Platform plat1 = new Platform(10, 35 * JS, 950, 10, "platform");
            Controls.Add(plat1);
            Platform plat2 = new Platform(10, 28 * JS, 300, 10, "platform");
            Controls.Add(plat2);
            Platform plat3 = new Platform(670, 40 * JS, 300, 10, "platform");
            Controls.Add(plat3);
            Platform plat4 = new Platform(370, 22 * JS, 100, 10, "platform");
            Controls.Add(plat4);
            Platform plat5 = new Platform(510, 20 * JS, 150, 10, "platform");
            Controls.Add(plat5);
            Platform plat6 = new Platform(250, 10 * JS, 600, 10, "platform");
            Controls.Add(plat6);
            Platform plat7 = new Platform(600, 15 * JS, 150, 10, "platform");
            Controls.Add(plat7);

            Entity coin1 = new Entity(580, 505, "coin");
            Controls.Add(coin1);
            Entity coin2 = new Entity(565, 505, "coin");
            Controls.Add(coin2);
            Entity coin3 = new Entity(550, 505, "coin");
            Controls.Add(coin3);
            Entity coin4 = new Entity(535, 505, "coin");
            Controls.Add(coin4);

            Entity heart1 = new Entity(880, 630, "heart");
            Controls.Add(heart1);

            Entity exit = new Entity(100, 250, "exit");
            Controls.Add(exit);

            // BArrels
            Barrel barrel1 = new Barrel(600, 500, true);
            Controls.Add(barrel1);
            Barrel barrel2 = new Barrel(800, 500, true);
            Controls.Add(barrel2);
            Barrel barrel3 = new Barrel(400, 500, true);
            Controls.Add(barrel3);
            Barrel barrel4 = new Barrel(200, 500, true);
            Controls.Add(barrel4);
            Barrel barrel5 = new Barrel(300, 500, true);
            Controls.Add(barrel5);

            Ghost ghost1 = new Ghost(200, 400, true);
            Controls.Add(ghost1);
            Ghost ghost2 = new Ghost(200, 200, false);
            Controls.Add(ghost2);
            Ghost ghost3 = new Ghost(700, 280, true);
            Controls.Add(ghost3);

            Turtle turtle1 = new Turtle(670, 584, false);
            Controls.Add(turtle1);
            Turtle turtle2 = new Turtle(750, 584, false);
            Controls.Add(turtle2);
            Turtle turtle3 = new Turtle(750, 509, false);
            Controls.Add(turtle3);
            Turtle turtle4 = new Turtle(510, 284, false);
            Controls.Add(turtle4);

        }

        public override void Next()
        {
            Hide();
            Level4 level4 = new Level4(GetScore(), GetLives(), SplashHold);
            level4.Closed += (s, args) => this.Close();
            level4.Show();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Level3
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(292, 268);
            this.Name = "Level3";
            this.ResumeLayout(false);

        }
    }
}
