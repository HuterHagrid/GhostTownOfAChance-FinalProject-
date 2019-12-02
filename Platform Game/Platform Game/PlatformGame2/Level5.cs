using System.Windows.Forms;

namespace PlatformGame2
{
    class Level5 : CustomForm
    {
        public Level5(int score, int lives, Splash splash) : base(score, lives, splash)
        {
            Text += ": Bonus Stage";

            SplashHold = splash;
            //platforms
            Platform plat1 = new Platform(10, 38 * JS, 950, 10, "platform");
            Controls.Add(plat1);
            Platform edge5 = new Platform(500, 30 * JS, 12, 120, "edge");
            Controls.Add(edge5);
            Platform edge6 = new Platform(200, 30 * JS, 12, 120, "edge");
            Controls.Add(edge6);
            Platform edge7 = new Platform(800, 30 * JS, 12, 120, "edge");
            Controls.Add(edge7);
            Platform plat2 = new Platform(10, 30 * JS, 950, 10, "platform");
            Controls.Add(plat2);
            Platform plat3 = new Platform(10, 22 * JS, 950, 10, "platform");
            Controls.Add(plat3);
            Platform edge3 = new Platform(666, 22 * JS, 12, 120, "edge");
            Controls.Add(edge3);
            Platform edge4 = new Platform(333, 22 * JS, 12, 120, "edge");
            Controls.Add(edge4);
            Platform plat4 = new Platform(10, 14 * JS, 950, 10, "platform");
            Controls.Add(plat4);
            Platform edge1 = new Platform(666, 6 * JS, 12, 120, "edge");
            Controls.Add(edge1);
            Platform edge2 = new Platform(333, 6 * JS, 12, 120, "edge");
            Controls.Add(edge2);
            Platform plat5 = new Platform(10, 6 * JS, 950, 10, "platform");
            Controls.Add(plat5);
            Platform edge8 = new Platform(500, 14 * JS, 12, 120, "edge");
            Controls.Add(edge8);
            Platform edge9 = new Platform(200, 14 * JS, 12, 120, "edge");
            Controls.Add(edge9);
            Platform edge10 = new Platform(800, 14 * JS, 12, 120, "edge");
            Controls.Add(edge10);

            //barrels
            Barrel barrel1 = new Barrel(710, 650, true);
            Controls.Add(barrel1);
            Barrel barrel2 = new Barrel(730, 650, true);
            Controls.Add(barrel2);
            Barrel barrel3 = new Barrel(750, 650, true);
            Controls.Add(barrel3);

            // exit
            Entity exit = new Entity(500, 61, "exit");
            Controls.Add(exit);

            //coins
            Entity coin1 = new Entity(900, 180, "coin");
            Controls.Add(coin1);
            Entity coin2 = new Entity(880, 180, "coin");
            Controls.Add(coin2);
            Entity coin3 = new Entity(860, 180, "coin");
            Controls.Add(coin3);
            Entity coin4 = new Entity(840, 180, "coin");
            Controls.Add(coin4);
            Entity coin5 = new Entity(820, 180, "coin");
            Controls.Add(coin5);
            Entity coin6 = new Entity(800, 180, "coin");
            Controls.Add(coin6);
            Entity coin7 = new Entity(780, 180, "coin");
            Controls.Add(coin7);
            Entity coin8 = new Entity(760, 180, "coin");
            Controls.Add(coin8);
            Entity coin9 = new Entity(900, 180, "coin");
            Controls.Add(coin9);
            Entity coin10 = new Entity(880, 180, "coin");
            Controls.Add(coin10);
            Entity coin11 = new Entity(860, 180, "coin");
            Controls.Add(coin11);
            Entity coin12 = new Entity(840, 180, "coin");
            Controls.Add(coin12);
            Entity coin13 = new Entity(820, 180, "coin");
            Controls.Add(coin13);
            Entity coin14 = new Entity(800, 180, "coin");
            Controls.Add(coin14);
            Entity coin15 = new Entity(780, 180, "coin");
            Controls.Add(coin15);
            Entity coin16 = new Entity(760, 180, "coin");
            Controls.Add(coin16);


        }

        // Last level, return to splash
        public override void Next()
        {
            End();
        }
    }
}
