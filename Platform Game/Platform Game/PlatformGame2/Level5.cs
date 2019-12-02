using System.Windows.Forms;

namespace PlatformGame2
{
    class Level5 : CustomForm
    {
        public Level5(int score, int lives, Splash splash) : base(score, lives, splash)
        {
            Text += ": Level 5";

            SplashHold = splash;

            Platform plat1 = new Platform(10, 38 * JS, 1000, 10, "platform");
            Controls.Add(plat1);


        }

        // Last level, return to splash
        public override void Next()
        {
            End();
        }
    }
}
