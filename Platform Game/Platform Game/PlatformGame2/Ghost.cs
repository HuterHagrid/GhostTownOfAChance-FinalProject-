using System.Drawing;

namespace PlatformGame2
{
    class Ghost : Enemy
    {
        private const int MAX = 40;
        private const int STEP = 4;
        
        public bool Box { set; get; }

        private int x;
        private int y;

        private bool moveX;
        private bool goLeft;
        private bool goUp;

        public Ghost(int locX, int locY, bool box) : base(locX, locY, "ghost")
        {
            Box = box;
            x = 0;
            if (box)
            {
                y = 0;
            }
            else
            {
                y = MAX;
            }
            moveX = true;
            goLeft = true;
            goUp = true;
        }

        public override void Movement()
        {
            if (Box)
            {
                if (moveX)
                {
                    if (goLeft)
                    {
                        if (x++ < MAX)
                        {
                            Left -= STEP;
                            Image = Image.FromFile("ghostLeft.gif");
                        }
                        else
                        {
                            goLeft = false;
                            moveX = false;
                        }
                    }
                    else
                    {
                        if (x-- > 0)
                        {
                            Left += STEP;
                            Image = Image.FromFile("ghostRight.gif");
                        }
                        else
                        {
                            goLeft = true;
                            moveX = false;
                        }
                    }
                }
                else
                {
                    if (goUp)
                    {
                        if (y++ < MAX)
                        {
                            Top -= STEP;
                        }
                        else
                        {
                            goUp = false;
                            moveX = true;
                        }
                    }
                    else
                    {
                        if (y-- > 0)
                        {
                            Top += STEP;
                        }
                        else
                        {
                            goUp = true;
                            moveX = true;
                        }
                    }
                }
            }

            else
            {
                if (goLeft)
                {
                    if (x++ < MAX * 2)
                    {
                        Image = Image.FromFile("ghostLeft.gif");
                        Left -= STEP / 2;
                    }
                    else
                    {
                        goLeft = false;
                    }
                }
                else
                {
                    if (x-- > 0)
                    {
                        Image = Image.FromFile("ghostRight.gif");
                        Left += STEP / 2;
                    }
                    else
                    {
                        goLeft = true;
                    }
                }
                if (goUp)
                {
                    if(y++ < MAX * 2)
                    {
                        Top -= STEP / 2;
                    }
                    else
                    {
                        goUp = false;
                    }
                }
                else
                {
                    if(y-- > 0)
                    {
                        Top += STEP / 2;
                    }
                    else
                    {
                        goUp = true;
                    }
                }
            }
        }
    }
}
