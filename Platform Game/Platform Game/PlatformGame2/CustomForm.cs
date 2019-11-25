using System.Drawing;
using System.Windows.Forms;

namespace PlatformGame2
{
    public class CustomForm : Form
    {
        // Jump Speed
        public const int JS = 15;

        // Global Controls
        private Entity player;
        private Label scoreKeep;
        private Label livesKeep;

        // User Inputs
        private bool goLeft;
        private bool goRight;
        private bool jumping;

        // Player Stats
        private int jumpSpeed;
        private int force;
        private int score;
        private int lives;

        // Platform Tracker
        private bool onPlatform;
        private Platform currentPlatform;

        // Game Timer
        private Timer timer;

        private System.ComponentModel.IContainer components;

        public CustomForm() { }
        
        public CustomForm(int score, int lives)
        {
            InitializeComponent();

            // Initialize Score Keeper
            scoreKeep = labelMaker();
            scoreKeep.Location = new Point(880, 10);
            scoreKeep.ForeColor = Color.Yellow;
            UpdateScore(score);
            Controls.Add(scoreKeep);

            // Initialize Lives Keeper
            livesKeep = labelMaker();
            livesKeep.Location = new Point(880, 40);
            livesKeep.ForeColor = Color.Red;
            livesKeep.Text = lives.ToString();
            UpdateLives(lives);
            Controls.Add(livesKeep);

            // Initialize platform
            onPlatform = false;
            currentPlatform = null;

            // Initialize player
            player = new Entity(50, 600, "player");
            Controls.Add(player);

            // Game Bounds
            Platform left = new Platform(0, 0, 20, Height, "edge");
            Controls.Add(left);
            Platform right = new Platform(Width - 40, 0, 20, Height, "edge");
            Controls.Add(right);
            Platform bottom = new Platform(0, Height - 75, Width, 20, "floor");
            Controls.Add(bottom);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 20;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // CustomForm
            // 
            this.ClientSize = new System.Drawing.Size(978, 695);
            this.Name = "CustomForm";
            this.Text = "Ghost Town of a Chance";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);
            this.ResumeLayout(false);
        }

        // Detects User Inputs
        private void keyisdown(object sender, KeyEventArgs e)
        {
            // Left and Right, can only do one at a time
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
                goRight = false;
            }
            else if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                goLeft = false;
            }

            // Jumping, cannot double jump
            if (e.KeyCode == Keys.Space && !jumping)
            {
                jumping = true;
                onPlatform = false;
                currentPlatform = null;
            }
        }

        // Detects end of user inputs
        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (jumping)
            {
                jumping = false;
            }
        }

        // Game timer that determines player movement and collisions
        private void timer_Tick(object sender, System.EventArgs e)
        {
            // If player is not on a platform, apply jumpspedd
            if (!onPlatform)
            {
                player.Top += jumpSpeed;
            }

            // Prevents infinite jump
            if (jumping && force < 0)
            {
                jumping = false;
            }

            // Left and right movements
            if (goLeft)
            {
                player.Left -= 6;
            }
            else if (goRight)
            {
                player.Left += 6;
            }

            // When jumping, apply negative jumpspeed and force
            if (jumping)
            {
                jumpSpeed = -1 * JS;
                force -= 1;
            }
            // Else, apply positive jumpspeed
            else
            {
                jumpSpeed = JS;
            }

            // Collision Checks
            foreach (Control x in this.Controls)
            {
                // Intersection Checks
                if (player.Bounds.IntersectsWith(x.Bounds))
                {
                    // Player cannot go through floor
                    if (x.Tag.Equals("floor") && !jumping)
                    {
                        force = 8;
                        player.Top = x.Top - player.Height;
                        onPlatform = true;
                    }
                    // Player cannot go through edges
                    if (x.Tag.Equals("edge"))
                    {
                        if (goLeft)
                        {
                            player.Left = x.Left + player.Width;
                        }
                        if (goRight)
                        {
                            player.Left = x.Left - player.Width;
                        }
                    }
                    // Player collects a coin
                    if (x.Tag.Equals("coin"))
                    {
                        UpdateScore(10);
                        x.Dispose();
                    }
                    // Player collects a heart
                    if (x.Tag.Equals("heart"))
                    {
                        UpdateLives(1);
                        x.Dispose();
                    }
                    // Player reaches the exit
                    if (x.Tag.Equals("exit"))
                    {
                        timer.Stop();
                        UpdateScore(50);
                        Next();
                    }
                } // End of Intersection Checks

                // Player landing on platform check
                if (x.Tag.Equals("platform") && player.Right > x.Left && player.Left < x.Right
                        && (player.Bottom <= x.Top && player.Bottom > x.Top - JS) && !jumping)
                {
                    force = 8;
                    player.Top = x.Top - player.Height;
                    onPlatform = true;
                    currentPlatform = (Platform)x;
                }

                // Player landing on a turtle of barrel, or getting hit by them
                if ((x.Tag.Equals("turtle") || x.Tag.Equals("barrel")))
                {
                    // If player land on a turtle or barrel, kill it and add to score
                    if (player.Right > x.Left && player.Left < x.Right &&
                        (player.Bottom < x.Top && player.Bottom >= x.Top - JS) && !jumping)
                    {
                        if (x.Tag.Equals("turtle"))
                        {
                            UpdateScore(15);
                        }
                        else
                        {
                            UpdateScore(20);
                        }
                        x.Dispose();
                    }

                    // Else player is attacked by turtle or barrel, reset to start and lose a life
                    else if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        player.Left = 60;
                        player.Top = 600;
                        onPlatform = false;
                        UpdateScore(-10);
                        UpdateLives(-1);
                        if (NoLives())
                        {
                            End();
                        }
                    }
                }

                // Player is attacked by a ghost
                if (x.Tag.Equals("ghost") && player.Bounds.IntersectsWith(x.Bounds))
                {
                    player.Left = 60;
                    player.Top = 600;
                    onPlatform = false;
                    UpdateScore(-10);
                    UpdateLives(-1);
                    if (NoLives())
                    {
                        End();
                    }
                }

                // Update Enemy movements
                if (x is Enemy)
                {
                    Enemy temp = (Enemy)x;
                    temp.Movement();
                }

                // Barrel Gravity
                if (x.Tag.Equals("barrel"))
                {
                    Barrel temp = (Barrel)x;
                    foreach (Control y in this.Controls)
                    {
                        // If barrel is not on a platform or another barrel
                        if (!temp.onPlatform && !(y is Barrel))
                        {
                            // If barrel intersects with a platform or floo,
                            // set it as the platform that it is on.
                            if ((y.Tag.Equals("platform") || y.Tag.Equals("floor"))
                                && temp.Bounds.IntersectsWith(y.Bounds))
                            {
                                Platform temp2 = (Platform)y;
                                temp.platform = temp2;
                            }
                        }
                    }
                } // End of Barrel Gravity

            } // End of Collision Checks

            // If a player is on a platform and moves off of the platform, they begin to fall
            if (currentPlatform != null)
            {
                // Leave from the left
                if (goLeft && player.Right < currentPlatform.Left)
                {
                    onPlatform = false;
                    currentPlatform = null;
                }

                // Leave from the right
                if (goRight && player.Left > currentPlatform.Right)
                {
                    onPlatform = false;
                    currentPlatform = null;
                }
            }
        }

        // Determines the Next level to go to
        public virtual void Next() { }

        public virtual void End() { }

        public bool NoLives()
        {
            return lives == 0;
        }

        // Creates a Label for a stat keeper
        public Label labelMaker()
        {
            Label newLabel = new Label();
            newLabel.AutoSize = false;
            newLabel.TextAlign = ContentAlignment.MiddleRight;
            newLabel.Size = new Size(75, 25);
            newLabel.BackColor = Color.Black;
            newLabel.Font = new Font("Helvetica", 12, FontStyle.Regular);
            newLabel.Tag = "label";
            return newLabel;
        }

        // Getters for Score and Lives
        public int GetScore()
        {
            return score;
        }

        public int GetLives()
        {
            return lives;
        }
        
        // Updaters for Score and Lives
        public void UpdateScore(int num)
        {
            score += num;
            scoreKeep.Text = score.ToString();
        }

        public void UpdateLives(int num)
        {
            lives += num;
            livesKeep.Text = lives.ToString();
        }
    }
}
