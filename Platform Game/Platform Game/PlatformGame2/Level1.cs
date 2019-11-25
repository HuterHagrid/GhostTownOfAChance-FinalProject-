
namespace PlatformGame2
{
    public class Level1 : CustomForm
    {
        public Level1(int score, int lives) : base(score, lives)
        {
            Text += ": Level 1";
            
            Platform plat1 = new Platform(250, 40 * JS, 100, 20, "platform");
            Controls.Add(plat1);
            Platform plat2 = new Platform(400, 35 * JS, 100, 20, "platform");
            Controls.Add(plat2);
            Platform plat3 = new Platform(400, 28 * JS, 100, 20, "platform");
            Controls.Add(plat3);
            Platform plat4 = new Platform(575, 25 * JS, 300, 20, "platform");
            Controls.Add(plat4);
            Platform plat5 = new Platform(300, 20 * JS, 100, 20, "platform");
            Controls.Add(plat5);
            Platform plat6 = new Platform(100, 23 * JS, 100, 20, "platform");
            Controls.Add(plat6);
            Platform plat7 = new Platform(100, 15 * JS, 100, 20, "platform");
            Controls.Add(plat7);
            Platform plat8 = new Platform(200, 9 * JS, 100, 20, "platform");
            Controls.Add(plat8);
            Platform plat9 = new Platform(375, 5 * JS, 150, 20, "platform");
            Controls.Add(plat9);
            Platform plat10 = new Platform(660, 13 * JS, 215, 20, "platform");
            Controls.Add(plat10);
            Platform plat11 = new Platform(675, 32 * JS, 200, 20, "platform");
            Controls.Add(plat11);

            Entity coin1 = new Entity(630, 340, "coin");
            Controls.Add(coin1);
            Entity coin2 = new Entity(710, 340, "coin");
            Controls.Add(coin2);
            Entity coin3 = new Entity(790, 340, "coin");
            Controls.Add(coin3);
            Entity coin4 = new Entity(710, 445, "coin");
            Controls.Add(coin4);
            Entity coin5 = new Entity(790, 445, "coin");
            Controls.Add(coin5);
            Entity coin6 = new Entity(440, 45, "coin");
            Controls.Add(coin6);
            Entity exit = new Entity(800, 145, "exit");
            Controls.Add(exit);
        }

        public override void Next()
        {
            Hide();
            Level2 level2 = new Level2(GetScore(), GetLives());
            level2.Closed += (s, args) => this.Close();
            level2.Show();
        }
    }
}
