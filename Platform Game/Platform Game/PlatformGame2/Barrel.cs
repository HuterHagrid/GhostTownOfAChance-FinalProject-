using System.Drawing;
namespace PlatformGame2
{
    class Barrel : Enemy
    {
        private const int SPEED = 5;

        public bool onPlatform { set; get; }

        private bool left;

        public Platform platform { set; get; }

        public Barrel(int locX, int locY, bool left) : base(locX, locY, "barrel")
        {
            this.left = left;
            onPlatform = false;
        }

        public override void Movement()
        {
            if (left)
            {
                Left -= SPEED;
            }
            else
            {
                Left += SPEED;
            }

            if (platform != null)
            {
                onPlatform = true;
                if (Right < platform.Left || Left > platform.Right)
                {
                    onPlatform = false;
                }
            }

            if (!onPlatform)
            {
                Top += SPEED;
            }
        }
    }
}
