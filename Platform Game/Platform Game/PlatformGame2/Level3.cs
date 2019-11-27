
namespace PlatformGame2
{
    class Level3 : CustomForm
    {
        public Level3(int score, int lives) : base(score, lives)
        {
            Text += ": Level 3";

            Turtle turtle1 = new Turtle(300, 655, false);
            Controls.Add(turtle1);
            

            Platform plat1 = new Platform(500, 38 * JS, 300, 20, "platform");
            Controls.Add(plat1);
            

            Entity coin1 = new Entity(580, 530, "coin");
            Controls.Add(coin1);
            

            Entity heart1 = new Entity(880, 630, "heart");
            Controls.Add(heart1);



            Platform plat6 = new Platform(250, 10 * JS, 600, 20, "platform");
            Controls.Add(plat6);

            

            Entity exit = new Entity(100, 250, "exit");
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
            
            // When Level 4 is addded change to:

            // Hide();
            // Level4 level4 = new Level4(GetScore(), GetLives());
            // level4.Closed += (s, args) => this.Close();
            // level4.Show();
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
