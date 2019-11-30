using System.Windows.Forms;

namespace PlatformGame2
{
    // Level 2 introduces the player to the first enemy, the turtle.
    class Level2 : CustomForm
    {
        public Level2(int score, int lives, Splash splash) : base(score, lives, splash)
        {
            Text += ": Level 2";

            SplashHold = splash;

            // First row of Turtles
            Turtle turtle1 = new Turtle(300, 670, false);
            Controls.Add(turtle1);
            Turtle turtle2 = new Turtle(500, 670, true);
            Controls.Add(turtle2);
            Turtle turtle7 = new Turtle(600, 670, false);
            Controls.Add(turtle7);

            // Lower platforms
            Platform plat1 = new Platform(500, 39 * JS, 300, 10, "platform");
            Controls.Add(plat1);
            Platform plat2 = new Platform(850, 34 * JS, 100, 10, "platform");
            Controls.Add(plat2);
            Platform plat3 = new Platform(300, 28 * JS, 500, 10, "platform");
            Controls.Add(plat3);

            // Lower coins
            Entity coin1 = new Entity(580, 560, "coin");
            Controls.Add(coin1);
            Entity coin2 = new Entity(640, 560, "coin");
            Controls.Add(coin2);
            Entity coin6 = new Entity(700, 560, "coin");
            Controls.Add(coin6);
            Entity coin3 = new Entity(890, 485, "coin");
            Controls.Add(coin3);

            Entity heart1 = new Entity(880, 665, "heart");
            Controls.Add(heart1);

            // Second row of Turtles
            Turtle turtle3 = new Turtle(450, 405, true);
            Controls.Add(turtle3);
            Turtle turtle4 = new Turtle(650, 405, true);
            Controls.Add(turtle4);

            // Upper platforms
            Platform plat4 = new Platform(170, 23 * JS, 100, 10, "platform");
            Controls.Add(plat4);
            Platform plat5 = new Platform(100, 17 * JS, 100, 10, "platform");
            Controls.Add(plat5);
            Platform plat6 = new Platform(250, 11 * JS, 600, 10, "platform");
            Controls.Add(plat6);

            // Upper coins
            Entity coin4 = new Entity(210, 320, "coin");
            Controls.Add(coin4);
            Entity coin5 = new Entity(140, 230, "coin");
            Controls.Add(coin5);

            // Top row of turtles
            Turtle turtle5 = new Turtle(300, 150, false);
            Controls.Add(turtle5);
            Turtle turtle6 = new Turtle(600, 150, true);     
            Controls.Add(turtle6);

            // Exit
            Entity exit = new Entity(740, 137, "exit");
            Controls.Add(exit);
        }

        public override void Next()
        {
            Hide();
            Level3 level3 = new Level3(GetScore(), GetLives(), SplashHold);
            level3.Closed += (s, args) => this.Close();
            level3.Show();
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
