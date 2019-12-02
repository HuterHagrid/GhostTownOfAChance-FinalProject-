
namespace PlatformGame2
{
    class Level4 : CustomForm
    {
        public Level4(int score, int lives, Splash splash) : base(score, lives, splash)
        {
            Text += ": Level 4";

            SplashHold = splash;

            // Platforms
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

            // Coins
            Entity coin1 = new Entity(580, 505, "coin");
            Controls.Add(coin1);
            Entity coin2 = new Entity(565, 505, "coin");
            Controls.Add(coin2);
            Entity coin3 = new Entity(550, 505, "coin");
            Controls.Add(coin3);
            Entity coin4 = new Entity(535, 505, "coin");
            Controls.Add(coin4);

            // Heart
            Entity heart1 = new Entity(880, 630, "heart");
            Controls.Add(heart1);

            // Exit
            Entity exit = new Entity(100, 250, "exit");
            Controls.Add(exit);

            // Barrels
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

            // Ghosts
            Ghost ghost1 = new Ghost(200, 400, true);
            Controls.Add(ghost1);
            Ghost ghost2 = new Ghost(200, 200, false);
            Controls.Add(ghost2);
            Ghost ghost3 = new Ghost(700, 280, true);
            Controls.Add(ghost3);

            // Turtles
            Turtle turtle1 = new Turtle(670, 584, false);
            Controls.Add(turtle1);
            Turtle turtle2 = new Turtle(750, 584, false);
            Controls.Add(turtle2);
            Turtle turtle3 = new Turtle(750, 509, false);
            Controls.Add(turtle3);
            Turtle turtle4 = new Turtle(510, 284, false);
            Controls.Add(turtle4);
        }

        // Last level, return to splash
        public override void Next()
        {
            End();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Level4
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(292, 268);
            this.Name = "Level4";
            this.ResumeLayout(false);
        }
    }
}
