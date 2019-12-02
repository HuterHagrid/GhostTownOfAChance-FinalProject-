
/// <summary>
/// Level3.cs
/// 
/// Level 3 introduces the player to the next enemy, the barrel.
/// Methods: Constructor, Next
/// </summary>
/// 
namespace PlatformGame2
{
    class Level3 : CustomForm
    {
        public Level3(int score, int lives, Splash splash) : base(score, lives, splash)
        {
            Text += ": Level 3";

            SplashHold = splash;

            // Platforms
            Platform plat1 = new Platform(265, 685, 100, 10, "floor");
            Controls.Add(plat1);
            Platform plat2 = new Platform(365, 675, 100, 10, "floor");
            Controls.Add(plat2);
            Platform plat3 = new Platform(465, 665, 100, 10, "floor");
            Controls.Add(plat3);
            Platform plat4 = new Platform(565, 655, 100, 10, "floor");
            Controls.Add(plat4);
            Platform plat5 = new Platform(665, 645, 100, 10, "floor");
            Controls.Add(plat5);
            Platform plat6 = new Platform(765, 635, 100, 10, "floor");
            Controls.Add(plat6);
            Platform plat7 = new Platform(865, 625, 100, 10, "floor");
            Controls.Add(plat7);
            Platform plat8 = new Platform(750, 550, 100, 10, "platform");
            Controls.Add(plat8);
            Platform plat20 = new Platform(650, 500, 100, 10, "platform");
            Controls.Add(plat20);
            Platform plat9 = new Platform(450, 450, 200, 10, "platform");
            Controls.Add(plat9);
            Platform plat10 = new Platform(650, 350, 315, 10, "platform");
            Controls.Add(plat10);
            Platform plat11 = new Platform(540, 200, 10, 250, "edge");
            Controls.Add(plat11);
            Platform plat12 = new Platform(920, 270, 50, 10, "platform");
            Controls.Add(plat12);
            Platform plat13 = new Platform(700, 200, 200, 10, "platform");
            Controls.Add(plat13);
            Platform plat14 = new Platform(400, 190, 300, 10, "floor");
            Controls.Add(plat14);
            Platform plat15 = new Platform(700, 200, 200, 10, "platform");
            Controls.Add(plat15);
            Platform plat16 = new Platform(700, 200, 200, 10, "platform");
            Controls.Add(plat16);
            Platform plat17 = new Platform(300, 0, 10, 450, "edge");
            Controls.Add(plat17);
            Platform plat18 = new Platform(0, 500, 450, 10, "floor");
            Controls.Add(plat18);
            Platform plat19 = new Platform(450, 450, 10, 60, "edge");
            Controls.Add(plat19);
            Platform plat21 = new Platform(300, 320, 150, 10, "platform");
            Controls.Add(plat21);
            Platform plat22 = new Platform(20, 420, 100, 10, "platform");
            Controls.Add(plat22);
            Platform plat23 = new Platform(170, 350, 130, 10, "platform");
            Controls.Add(plat23);
            Platform plat24 = new Platform(200, 260, 100, 10, "platform");
            Controls.Add(plat24);
            Platform plat25 = new Platform(300, 320, 150, 10, "platform");
            Controls.Add(plat25);
            Platform plat26 = new Platform(120, 180, 100, 10, "platform");
            Controls.Add(plat26);
            Platform plat27 = new Platform(0, 100, 100, 10, "platform");
            Controls.Add(plat27);

            // Barrels
            Barrel barrel1 = new Barrel(400, 100, false);
            Controls.Add(barrel1);
            Barrel barrel2 = new Barrel(600, 400, true);
            Controls.Add(barrel2);
            Barrel barrel3 = new Barrel(800, 500, false);
            Controls.Add(barrel3);
            Barrel barrel4 = new Barrel(800, 600, true);
            Controls.Add(barrel4);
            Barrel barrel5 = new Barrel(600, 600, true);
            Controls.Add(barrel5);
            Barrel barrel6 = new Barrel(100, 300, false);
            Controls.Add(barrel6);
            Barrel barrel7 = new Barrel(100, 300, true);
            Controls.Add(barrel7);

            // Coins
            Entity coin1 = new Entity(910, 580, "coin");
            Controls.Add(coin1);
            Entity coin2 = new Entity(500, 420, "coin");
            Controls.Add(coin2);
            Entity coin3 = new Entity(600, 420, "coin");
            Controls.Add(coin3);
            Entity coin4 = new Entity(935, 315, "coin");
            Controls.Add(coin4);
            Entity coin5 = new Entity(450, 160, "coin");
            Controls.Add(coin5);
            Entity coin6 = new Entity(550, 160, "coin");
            Controls.Add(coin6);
            Entity coin7 = new Entity(650, 160, "coin");
            Controls.Add(coin7);
            Entity coin8 = new Entity(250, 230, "coin");
            Controls.Add(coin8);
            Entity coin9 = new Entity(250, 320, "coin");
            Controls.Add(coin9);

            // Hearts
            Entity heart1 = new Entity(910, 450, "heart");
            Controls.Add(heart1);
            Entity heart2 = new Entity(50, 250, "heart");
            Controls.Add(heart2);

            // Exit
            Entity exit = new Entity(50, 75, "exit");
            Controls.Add(exit);
        }

        // Begin level 4
        public override void Next()
        {
            Hide();
            Level4 level4 = new Level4(GetScore(), GetLives(), SplashHold);
            level4.Closed += (s, args) => SplashHold.Close();
            level4.Show();
            Dispose();
        }
        // Set up and begin level's objects
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
