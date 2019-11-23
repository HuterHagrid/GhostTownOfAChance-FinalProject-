using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlatformerProject
{
    public partial class Form1 : Form
    {
        private const int FORCE = 12;
        private const int JUMP_SPEED = 8;
        Score score;
        /*
         Score Point value:
            Coin = 50
            Tortise = 100
            Ghost = 500
            Barrel = 100
         */

        bool goleft = false;
        bool goright = false;
        bool jumping = false;

        int jumpspeed = JUMP_SPEED;
        int movespeed = 0;
        int force = FORCE;

        public Form1()
        {
            InitializeComponent();
            score = new Score();
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
                player.Image = Image.FromFile("stand_left.png");
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
                player.Image = Image.FromFile("stand_right.png");
            }
            if (jumping)
            {
                jumping = false;
            }
        }

        private void GameOver()
        {
            player.Image = Image.FromFile("death.png");
            timer1.Stop();
            MessageBox.Show("Game Over \nScore: " + score.ToString());
            this.Controls.Remove(player);
            Application.Exit();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            UpdateScore();
            
            player.Top += jumpspeed;

            if (jumping && force < 0)
            {
                jumping = false;
            }

            if (goleft)
            {
                if (movespeed < 3)
                    movespeed += 1;
                player.Left -= movespeed;
                player.Image = Image.FromFile("run_left.gif");
            }
            else if (goright)
            {
                if (movespeed < 3)
                    movespeed += 1;
                player.Left += movespeed;
                player.Image = Image.FromFile("run_right.gif");
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

            if (player.Bounds.IntersectsWith(pictureBox1.Bounds)) {
                force = FORCE;
                player.Top = pictureBox1.Top - player.Height;
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

                // Collect coin for 50 points
                if (x is PictureBox && x.Tag == "coin")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        score.IncrementScore(50);
                        
                    }
                }
                //enemy controls
                if (x is PictureBox && x.Tag == "enemy" || x.Tag == "ghost")
                {
                    this.movespeed = 3;
                    if(this.Bounds.IntersectsWith(x.Bounds) && x.Tag == "edge")
                    {

                    }

                    //death
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        GameOver();
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
            /*
             if EnemyObject collides with player
                
            */
        }

        private void UpdateScore()
        {
            scoreTextBox.Text = "Score " + score.GetScore();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
