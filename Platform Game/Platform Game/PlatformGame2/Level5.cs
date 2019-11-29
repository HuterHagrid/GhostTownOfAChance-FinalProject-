using System.Windows.Forms;

namespace PlatformGame2
{
    class Level5 : CustomForm
    {
        public Level5(int score, int lives, Splash splash) : base(score, lives, splash)
        {
            Text += ": Level 5";

            SplashHold = splash;

            


        }

        // Last level, return to splash
        public override void Next()
        {
            End();
        }
    }
}
