using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestPlatformer
{
    public partial class Form1 : Form
    {
        private const int FORCE = 8;
        private const int JUMP_SPEED = 10;

        bool goleft = false;
        bool goright = false;
        bool jumping = false;

        int jumpspeed = JUMP_SPEED;
        int movespeed = 0;
        int force = FORCE;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
                goright = false;
            }
            else if (e.KeyCode == Keys.Right)
            {
                goright = true;
                goleft = false;
            }

            if (e.KeyCode == Keys.Space && !jumping)
            {
                jumping = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if (jumping)
            {
                jumping = false;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            player.Top += jumpspeed;

            if (jumping && force < 0)
            {
                jumping = false;
            }

            if (goleft)
            {
                if (movespeed < 10)
                    movespeed += 1;
                player.Left -= movespeed;
                player.Image = Image.FromFile("run_right.gif");
            }
            else if (goright)
            {
                if (movespeed < 10)
                    movespeed += 1;
                player.Left += movespeed;
                player.Image = Image.FromFile("run_left.gif");
            }
            else if (!goleft && !goright)
            {
                if (movespeed > 0)
                    movespeed -= 1;
            }

            if (jumping)
            {
                jumpspeed = -1 * JUMP_SPEED;
                force -= 1;
                player.Image = Image.FromFile("jump_right.png");
            }
            else
            {
                jumpspeed = JUMP_SPEED;
            }

            // Collision Check
            foreach (Control x in this.Controls)
            {
                // Keep player on platform
                if (x is PictureBox && x.Tag == "platform")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && !jumping)
                    {
                        force = FORCE;
                        player.Top = x.Top - player.Height;
                    }
                }

                //
                if (x is PictureBox && x.Tag == "platform_bottom")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        player.Top = x.Top + player.Height;
                    }
                }

                // Player cannot go through edges
                if (x is PictureBox && x.Tag == "edge")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        if (goleft)
                        {
                            player.Left = x.Left + player.Width;
                        }
                        if (goright)
                        {
                            player.Left = x.Left - player.Width;
                        }
                    }
                }
            }
            // End of Collision Check
            //player.Image = Image.FromFile("run_right.gif");
        }
    }

    /*
     public partial class Form1 : Form
    {
        bool right;
        bool left;
        bool jump;
        int gravity = 16;
        int force;
        int index = 0;

        public Form1()
        {
            InitializeComponent();
            player.Top = screen.Height - player.Height;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            index++;
            //gif replay
            if(right == true && index % 15 == 0)
            {
                player.Image = Image.FromFile("run_right.gif");
            }
            if (left == true && index % 15 == 0)
            {
                player.Image = Image.FromFile("run_left.gif");
            }

            //Side Collision 
            if (player.Right > block.Left && 
                player.Left < block.Right - player.Width
                && player.Bottom < block.Bottom && player.Bottom > block.Top)
            {
                right = false;
            }
            //side collision
            if (player.Left < block.Right &&
                player.Right > block.Left + player.Width
                && player.Bottom < block.Bottom && player.Bottom > block.Top)
            {
                left = false;
            }
            //2.
            if (right == true)
            {
                player.Left += 2;
            }
            if (left == true)
            {
                player.Left -= 2;
            }

            if (jump == true)
            {
                //falling(if the player has jumped before)
                player.Top -= force;
                force -= 1;
            }
            if(player.Top + player.Height >= screen.Height)
            {
                player.Top = screen.Height - player.Height; //stop falling at bottom
                if (jump == true)
                {
                    player.Image = Image.FromFile("stand_right.png");
                }
                jump = false;
            }
            else //falling
            {
                player.Top += 2;
            }

            //3. top collision
            if (player.Left + player.Width > block.Left && player.Left + player.Width < block.Left + block.Width+player.Width && player.Top + player.Height >= block.Top && player.Top < block.Top)
            {
                jump = false;
                force = 0;
                player.Top = block.Location.Y - player.Height;
            }

            //head collision
            if(player.Left + player.Width > block.Left && player.Left + player.Width < block.Left + block.Width + player.Width && player.Top - block.Bottom <=10 && player.Top - block.Top >  -10)
            {
                force = -1;

            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(jump != true)
            {
                if(e.KeyCode == Keys.Space)
                {
                    jump = true;
                    force = gravity;
                    player.Image = Image.FromFile("jump_right.png");
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                right = true;
                //player.Image = Image.FromFile("run_right.gif");
            }
            if (e.KeyCode == Keys.Left)
            {
                left = true;
                //player.Image = Image.FromFile("run_left.gif");
            }
            if (e.KeyCode == Keys.Escape) { this.Close(); } // Escape -> Exit
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = false;
                player.Image = Image.FromFile("stand_right.png");
            }
            if (e.KeyCode == Keys.Left)
            {
                left = false;
                player.Image = Image.FromFile("stand_left.png");
            }
        }


    }
     */
}
