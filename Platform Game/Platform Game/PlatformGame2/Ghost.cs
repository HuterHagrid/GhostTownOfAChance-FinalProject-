using System.Drawing;

/// <summary>
/// Ghost.cs
/// 
/// This class file details the function of the Ghost enemy.
/// Constants: MAX, STEP
/// Property: Box
/// Variables: x, y, moveX, goLeft goUp
/// Methods: Constructor, Movement
/// </summary>

namespace PlatformGame2
{
    class Ghost : Enemy
    {
        // Constants
        private const int MAX = 40;
        private const int STEP = 4;
        
        // Properties
        public bool Box { set; get; }

        // Class Variables
        private int x;
        private int y;

        private bool moveX;
        private bool goLeft;
        private bool goUp;

        // Full Constructor
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

        // Movement method
        public override void Movement()
        {
            // Box Movement
            if (Box)
            {
                // Horizontal movement
                if (moveX)
                {
                    // Left
                    if (goLeft)
                    {
                        // Move Left
                        if (x++ < MAX)
                        {
                            Left -= STEP;
                            Image = Image.FromFile("ghostLeft.gif");
                        }
                        // Stop left movement, switch to vertical movement
                        else
                        {
                            goLeft = false;
                            moveX = false;
                        }
                    }
                    // Right
                    else
                    {
                        // Move Right
                        if (x-- > 0)
                        {
                            Left += STEP;
                            Image = Image.FromFile("ghostRight.gif");
                        }
                        // Stop right movement, switch to vertical movement
                        else
                        {
                            goLeft = true;
                            moveX = false;
                        }
                    }
                }
                // Vertical movement
                else
                {
                    // Up
                    if (goUp)
                    {
                        // Move Up
                        if (y++ < MAX)
                        {
                            Top -= STEP;
                        }
                        // Stop up movement, switch to horizontal movement
                        else
                        {
                            goUp = false;
                            moveX = true;
                        }
                    }
                    // Down
                    else
                    {
                        // Move Down
                        if (y-- > 0)
                        {
                            Top += STEP;
                        }
                        // Stop down movement, switch to horizontal movement
                        else
                        {
                            goUp = true;
                            moveX = true;
                        }
                    }
                }
            }
            // Diamond Movement
            else
            {
                // Left
                if (goLeft)
                {
                    // Move left
                    if (x++ < MAX * 2)
                    {
                        Image = Image.FromFile("ghostLeft.gif");
                        Left -= STEP / 2;
                    }
                    // Switch to right
                    else
                    {
                        goLeft = false;
                    }
                }
                // Right
                else
                {
                    // Move Right
                    if (x-- > 0)
                    {
                        Image = Image.FromFile("ghostRight.gif");
                        Left += STEP / 2;
                    }
                    // Switch to left
                    else
                    {
                        goLeft = true;
                    }
                }

                // Up
                if (goUp)
                {
                    // Move up
                    if(y++ < MAX * 2)
                    {
                        Top -= STEP / 2;
                    }
                    // Switch to down
                    else
                    {
                        goUp = false;
                    }
                }
                // Down
                else
                {
                    // Move down
                    if(y-- > 0)
                    {
                        Top += STEP / 2;
                    }
                    // Switch to up
                    else
                    {
                        goUp = true;
                    }
                }
            }
        }
    }
}
