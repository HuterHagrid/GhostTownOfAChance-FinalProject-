﻿using System.Windows.Forms;

namespace PlatformGame2
{
    class Level4 : CustomForm
    {
        public Level4(int score, int lives, Splash splash) : base(score, lives, splash)
        {
            Text += ": Level 4";

            SplashHold = splash;

            Platform plat1 = new Platform(10, 35 * JS, 950, 10, "platform");
            Controls.Add(plat1);
            

            Entity coin1 = new Entity(580, 505, "coin");
            Controls.Add(coin1);
            

            Entity heart1 = new Entity(880, 630, "heart");
            Controls.Add(heart1);

            Entity exit = new Entity(100, 250, "exit");
            Controls.Add(exit);

            // Barrels
            Barrel barrel1 = new Barrel(600, 500, true);
            Controls.Add(barrel1);
            

            Ghost ghost1 = new Ghost(200, 400, true);
            Controls.Add(ghost1);
            Ghost ghost2 = new Ghost(200, 200, false);
            Controls.Add(ghost2);
            Ghost ghost3 = new Ghost(700, 280, true);
            Controls.Add(ghost3);

            Turtle turtle1 = new Turtle(670, 584, false);
            Controls.Add(turtle1);
            

        }

        public override void Next()
        {
            Hide();
            Level5 level5 = new Level5(GetScore(), GetLives(), SplashHold);
            level5.Closed += (s, args) => SplashHold.Close();
            level5.Show();
            Dispose();
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
