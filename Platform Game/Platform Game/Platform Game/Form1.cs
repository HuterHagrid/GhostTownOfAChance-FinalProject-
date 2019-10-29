using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Platform_Game
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

        private void keyisdown(object sender, KeyEventArgs e)
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

        private void keyisup(object sender, KeyEventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
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
            }
            else if (goright)
            {
                if (movespeed < 10)
                    movespeed += 1;
                player.Left += movespeed;
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

        }
    }
}
