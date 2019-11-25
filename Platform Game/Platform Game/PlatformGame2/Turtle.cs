﻿
namespace PlatformGame2
{
    class Turtle : Enemy
    {
        private const int MAX = 100;
        private const int STEP = 1;
        
        private int x;
        private bool goLeft;

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

        public override void Movement()
        {
            if (goLeft)
            {
                Left += STEP;
                if (x++ > MAX)
                {
                    goLeft = false;
                }
            }
            else
            {
                Left -= STEP;
                if (x-- < 0)
                {
                    goLeft = true;
                }
            }
        }
    }
}
