using System.Drawing;
/// <summary>
/// Turtle.cs
/// 
/// This class file details the function of the Turtle enemy.
/// Variables: MAX, STEP, x, goLeft
/// Methods: Constructor, movement
/// </summary>
namespace PlatformGame2
{
    class Turtle : Enemy
    {
        //variables
        private const int MAX = 100;
        private const int STEP = 1;
        
        private int x;
        private bool goLeft;

        //full constructor
        public Turtle(int locX, int locY, bool offset) : base(locX, locY, "turtle")
        {
            if (offset)
            {
                x = MAX / 2;
                Left -= MAX / 2;
            }
            else
            {
                x = 0;
            }
            goLeft = true;
        }

        //movement method
        public override void Movement()
        {
            if (goLeft)
            {
                Left += STEP;
                if (x++ > MAX)
                {
                    goLeft = false;
                    Image = Image.FromFile("tortoiseLeft.gif");
                }
            }
            else
            {
                Left -= STEP;
                if (x-- < 0)
                {
                    goLeft = true;
                    Image = Image.FromFile("tortoiseRight.gif");

                }
            }
        }
    }
}
