using System.Drawing;
/// <summary>
/// Barrel.cs
/// 
/// This class file details the function of the turtle enemy.
/// Variables: SPEED, OnPlatform, GoingLeft, platform
/// Methods: Constructor, movement
/// </summary>
namespace PlatformGame2
{
    class Barrel : Enemy
    {
        private const int SPEED = 5;

        public bool OnPlatform { set; get; }

        public bool GoingLeft { set; get; }

        public Platform platform { set; get; }

        public Barrel(int locX, int locY, bool left) : base(locX, locY, "barrel")
        {
            this.GoingLeft = left;
            OnPlatform = false;
        }

        public override void Movement()
        {
            if (GoingLeft)
            {
                Left -= SPEED;
                Image = Image.FromFile("barrelRight.gif");
            }
            else
            {
                Left += SPEED;
                Image = Image.FromFile("barrelLeft.gif");
            }

            if (platform != null)
            {
                OnPlatform = true;
                if (Right < platform.Left || Left > platform.Right)
                {
                    OnPlatform = false;
                }
            }

            if (!OnPlatform)
            {
                Top += SPEED;
            }
        }
    }
}
