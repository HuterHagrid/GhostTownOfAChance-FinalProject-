﻿
/// <summary>
/// Level4.cs
/// 
/// Level 4 is the penultimate level. Ghosts are added and all enemies are present.
/// Methods: Constructor, Next
/// </summary>

namespace PlatformGame2
{
    class Level4 : CustomForm
    {
        public Level4(int score, int lives, Splash splash) : base(score, lives, splash)
        {
            Text += ": Level 4";

            SplashHold = splash;

            // Platforms
            Platform plat1 = new Platform(10, 39 * JS, 50, 10, "platform");
            Controls.Add(plat1);
            Platform plat2 = new Platform(10, 31 * JS, 80, 10, "platform");
            Controls.Add(plat2);
            Platform plat3 = new Platform(200, 33 * JS, 80, 10, "platform");
            Controls.Add(plat3);
            Platform plat4 = new Platform(350, 31 * JS, 80, 10, "platform");
            Controls.Add(plat4);
            Platform plat5 = new Platform(480, 36 * JS, 120, 10, "platform");
            Controls.Add(plat5);
            Platform plat6 = new Platform(660, 36 * JS, 120, 10, "platform");
            Controls.Add(plat6);
            Platform plat7 = new Platform(760, 30 * JS, 80, 10, "platform");
            Controls.Add(plat7);
            Platform edge4 = new Platform(820, 20 * JS, 11, 75, "edge");
            Controls.Add(edge4);
            Platform plat8 = new Platform(800, 25 * JS, 80, 10, "platform");
            Controls.Add(plat8);
            Platform edge2 = new Platform(750, 14 * JS, 11, 90, "edge");
            Controls.Add(edge2);
            Platform plat9 = new Platform(750, 20 * JS, 80, 10, "platform");
            Controls.Add(plat9);
            Platform plat10 = new Platform(750, 14 * JS, 80, 10, "platform");
            Controls.Add(plat10);
            Platform plat11 = new Platform(600, 16 * JS, 100, 10, "platform");
            Controls.Add(plat11);
            Platform plat12 = new Platform(500, 14 * JS, 80, 10, "platform");
            Controls.Add(plat12);
            Platform plat13 = new Platform(400, 14 * JS, 80, 10, "platform");
            Controls.Add(plat13);
            Platform plat14 = new Platform(200, 14 * JS, 100, 10, "platform");
            Controls.Add(plat14);
            Platform plat15 = new Platform(70, 14 * JS, 130, 10, "platform");
            Controls.Add(plat15);
            Platform edge3 = new Platform(150, 14 * JS, 11, 100, "edge");
            Controls.Add(edge3);
            Platform plat16 = new Platform(50, 20 * JS, 100, 10, "platform");
            Controls.Add(plat16);

            // Coins and heart
            Entity coin1 = new Entity(580, 505, "coin");
            Controls.Add(coin1);
            Entity coin2 = new Entity(570, 505, "coin");
            Controls.Add(coin2);
            Entity coin3 = new Entity(560, 505, "coin");
            Controls.Add(coin3);
            Entity coin4 = new Entity(780, 195, "coin");
            Controls.Add(coin4);
            Entity coin5 = new Entity(790, 195, "coin");
            Controls.Add(coin5);
            Entity heart = new Entity(850, 360, "heart");
            Controls.Add(heart);

            // Exit
            Entity exit = new Entity(100, 250, "exit");
            Controls.Add(exit);

            // Barrels
            Barrel barrel1 = new Barrel(710, 650, true);
            Controls.Add(barrel1);
            Barrel barrel2 = new Barrel(730, 650, true);
            Controls.Add(barrel2);
            Barrel barrel3 = new Barrel(750, 650, true);
            Controls.Add(barrel3);
            Barrel barrel4 = new Barrel(690, 650, true);
            Controls.Add(barrel4);
            Barrel barrel5 = new Barrel(670, 650, true);
            Controls.Add(barrel5);
            Barrel barrel6 = new Barrel(650, 650, true);
            Controls.Add(barrel6);
            Barrel barrel7 = new Barrel(770, 650, true);
            Controls.Add(barrel7);
            Barrel barrel8 = new Barrel(630, 650, true);
            Controls.Add(barrel8);

            // Ghosts
            Ghost ghost1 = new Ghost(250, 580, false);
            Controls.Add(ghost1);
            Ghost ghost2 = new Ghost(500, 580, false);
            Controls.Add(ghost2);
            Ghost ghost3 = new Ghost(880, 280, true);
            Controls.Add(ghost3);
            Ghost ghost4 = new Ghost(250, 480, true);
            Controls.Add(ghost4);
            Ghost ghost5 = new Ghost(550, 450, false);
            Controls.Add(ghost5);
            Ghost ghost6 = new Ghost(400, 200, false);
            Controls.Add(ghost6);
            Ghost ghost7 = new Ghost(500, 400, true);
            Controls.Add(ghost7);
            Ghost ghost8 = new Ghost(600, 200, false);
            Controls.Add(ghost8);

            // Turtles
            Turtle turtle1 = new Turtle(480, 524, false);
            Controls.Add(turtle1);
            Turtle turtle2 = new Turtle(660, 524, false);
            Controls.Add(turtle2);


        }

        // Begin level 5
        public override void Next()
        {
            Hide();
            Level5 level5 = new Level5(GetScore(), GetLives(), SplashHold);
            level5.Closed += (s, args) => SplashHold.Close();
            level5.Show();
            Dispose();
        }

        // Set up and begin level's objects
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
