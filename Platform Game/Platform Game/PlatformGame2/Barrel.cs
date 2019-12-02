using System.Drawing;

/// <summary>
/// Barrel.cs
/// 
/// This class file details the function of the barrel enemy.
/// Constant: SPEED
/// Properties: OnPlatform, GoingLeft, platform
/// Methods: Constructor, Movement
/// </summary>

namespace PlatformGame2
{
    class Barrel : Enemy
    {
        private const int SPEED = 5;

        // Properties
        public bool OnPlatform { set; get; }
        public bool GoingLeft { set; get; }
        public Platform Platform { set; get; }

        public Barrel(int locX, int locY, bool left) : base(locX, locY, "barrel")
        {
            this.GoingLeft = left;
            OnPlatform = false;
        }

        public override void Movement()
        {
            // Move left
            if (GoingLeft)
            {
                Left -= SPEED;
                Image = Image.FromFile("barrelLeft.gif");
            }
            // Move right
            else
            {
                Left += SPEED;
                Image = Image.FromFile("barrelRight.gif");
            }

            // Barrel is on a platform
            if (Platform != null)
            {
                OnPlatform = true;

                // If barrel moves off the end of the platform, fall
                if (Right < Platform.Left || Left > Platform.Right)
                {
                    OnPlatform = false;
                }
            }

            // If not on a platform, fall
            if (!OnPlatform)
            {
                Top += SPEED;
            }
        }
    }
}
