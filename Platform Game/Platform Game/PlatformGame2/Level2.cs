
namespace PlatformGame2
{
    class Level2 : CustomForm
    {
        public Level2(int score, int lives) : base(score, lives)
        {
            Text += ": Level 2";

            Turtle turtle1 = new Turtle(300, 655, false);
            Controls.Add(turtle1);
            Turtle turtle2 = new Turtle(500, 655, false);
            Controls.Add(turtle2);

            Platform plat1 = new Platform(500, 38 * JS, 300, 20, "platform");
            Controls.Add(plat1);
            Platform plat2 = new Platform(850, 33 * JS, 100, 20, "platform");
            Controls.Add(plat2);
            Platform plat3 = new Platform(300, 27 * JS, 500, 20, "platform");
            Controls.Add(plat3);

            Entity coin1 = new Entity(580, 530, "coin");
            Controls.Add(coin1);
            Entity coin2 = new Entity(680, 530, "coin");
            Controls.Add(coin2);
            Entity coin3 = new Entity(890, 450, "coin");
            Controls.Add(coin3);

            Entity heart1 = new Entity(880, 630, "heart");
            Controls.Add(heart1);

            Turtle turtle3 = new Turtle(450, 385, true);
            Controls.Add(turtle3);
            Turtle turtle4 = new Turtle(650, 385, true);
            Controls.Add(turtle4);

            Platform plat4 = new Platform(170, 22 * JS, 100, 20, "platform");
            Controls.Add(plat4);
            Platform plat5 = new Platform(100, 16 * JS, 100, 20, "platform");
            Controls.Add(plat5);

            Entity coin4 = new Entity(210, 290, "coin");
            Controls.Add(coin4);
            Entity coin5 = new Entity(140, 200, "coin");
            Controls.Add(coin5);

            Platform plat6 = new Platform(250, 10 * JS, 600, 20, "platform");
            Controls.Add(plat6);

            Turtle turtle5 = new Turtle(300, 130, false);
            Controls.Add(turtle5);
            Turtle turtle6 = new Turtle(600, 130, true);     
            Controls.Add(turtle6);

            Entity exit = new Entity(740, 122, "exit");
            Controls.Add(exit);

            // These will be moved to other levels, this shows they work
            Barrel barrel1 = new Barrel(600, 500, true);
            Controls.Add(barrel1);

            Ghost ghost1 = new Ghost(400, 400, true);
            Controls.Add(ghost1);
            Ghost ghost2 = new Ghost(200, 200, false);
            Controls.Add(ghost2);
            
        }

        public override void Next()
        {
            Close();
            
            // When Level 3 is addded change to:

            // Hide();
            // Level3 level3 = new Level3(GetScore(), GetLives());
            // level3.Closed += (s, args) => this.Close();
            // level3.Show();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Level2
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(292, 268);
            this.Name = "Level2";
            this.ResumeLayout(false);

        }
    }
}
