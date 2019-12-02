using System.Drawing;
using System.Windows.Forms;

/// <summary>
/// CustomForm.cs
/// 
/// This class file defines the base game mechanics used for each level such as player movement,
/// enemy movement, collision detection, score keeping, next level, and end of game functionality.
/// Constant: JS (jump speed)
/// Variables: player, scoreKeep, livesKeep, goLeft, goRight, jumping, jumpSpeed, force, score,
///            lives, onPlatform, currentPlatform, timer, lookLeft
/// Property: SplashHold
/// Methods: Constructor, Keyisdown, Keyisup, Timer_Tick, Next, End, LabelMaker, GetScore,
///          GetLives, UpdateScore, UpdateLives
/// </summary>

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

        // Splash Holder
        public Splash SplashHold { set; get; }

        private bool lookLeft;

        private System.ComponentModel.IContainer components;

        public CustomForm() { }

        public System.Media.SoundPlayer sfxPlayer;

        // Constructor
        public CustomForm(int score, int lives, Splash splash)
        {
            InitializeComponent();

            // Initialize Score Keeper
            scoreKeep = LabelMaker();
            scoreKeep.Location = new Point(880, 10);
            scoreKeep.ForeColor = Color.Yellow;
            UpdateScore(score);
            Controls.Add(scoreKeep);

            // Initialize Lives Keeper
            livesKeep = LabelMaker();
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
            lookLeft = false;

            // Game Bounds
            // Left wall
            Platform left = new Platform(0, 0, 20, Height, "edge");
            Controls.Add(left);
            // Right wall
            Platform right = new Platform(Width - 35, 0, 20, Height, "edge");
            Controls.Add(right);
            // Floor
            Platform bottom = new Platform(0, Height - 55, Width, 20, "floor");
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
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // CustomForm
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(978, 695);
            this.Name = "CustomForm";
            this.Text = "Ghost Town of a Chance";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Keyisup);
            this.ResumeLayout(false);

        }

        // Detects User Inputs
        private void Keyisdown(object sender, KeyEventArgs e)
        {
            // Left and Right, can only do one at a time
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
                goRight = false;
                lookLeft = true;
                player.Image = Image.FromFile("run_left.gif");
            }
            else if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                goLeft = false;
                lookLeft = false;
                player.Image = Image.FromFile("run_right.gif");
            }

            // Jumping, cannot double jump
            if (e.KeyCode == Keys.Space && !jumping)
            {
                jumping = true;
                sfxPlayer = new System.Media.SoundPlayer("jump.wav");
                sfxPlayer.Play();
                onPlatform = false;
                currentPlatform = null;

                if (goLeft && !onPlatform)
                {
                    player.Image = Image.FromFile("jump_left.png");
                }
                else if (goRight && !onPlatform)
                {
                    player.Image = Image.FromFile("jump_right.png");
                }
            }
        }

        // Detects end of user inputs
        private void Keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
                player.Image = Image.FromFile("stand_left.png");
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
                player.Image = Image.FromFile("stand_right.png");
            }
            if (jumping)
            {
                jumping = false;
            }
        }

        // Game timer that determines player and enemy movement and collisions
        private void Timer_Tick(object sender, System.EventArgs e)
        {
            // If player is not on a platform, apply jumpspeed
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
                        currentPlatform = (Platform)x;

                        // When player lands on floor, switch sprite from jumping to
                        // appropriate image
                        if (goLeft)
                        {
                            player.Image = Image.FromFile("run_left.gif");
                        }
                        else if (goRight)
                        {
                            player.Image = Image.FromFile("run_right.gif");
                        }
                        else
                        {
                            if (lookLeft)
                            {
                                player.Image = Image.FromFile("stand_left.png");
                            }
                            else
                            {
                                player.Image = Image.FromFile("stand_right.png");
                            }
                        }
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
                        sfxPlayer = new System.Media.SoundPlayer("Coin.wav");
                        sfxPlayer.Play();
                    }
                    // Player collects a heart
                    if (x.Tag.Equals("heart"))
                    {
                        UpdateLives(1);
                        x.Dispose();
                        sfxPlayer = new System.Media.SoundPlayer("getItem.wav");
                        sfxPlayer.Play();
                    }
                    // Player reaches the exit
                    if (x.Tag.Equals("exit"))
                    {
                        UpdateScore(50);
                        timer.Stop();
                        Next();
                    }
                } // End of Intersection Checks

                // Player landing on platform check
                if (x.Tag.Equals("platform") && player.Right > x.Left && player.Left < x.Right
                        && (player.Bottom <= x.Top && player.Bottom >= x.Top - 20) && !jumping)
                {
                    force = 8;
                    player.Top = x.Top - player.Height;
                    onPlatform = true;
                    currentPlatform = (Platform)x;

                    // When player lands on platform, switch sprite from jumping to
                    // appropriate image
                    if (goLeft)
                    {
                        player.Image = Image.FromFile("run_left.gif");
                    }
                    else if (goRight)
                    {
                        player.Image = Image.FromFile("run_right.gif");
                    }
                    else
                    {
                        if (lookLeft)
                        {
                            player.Image = Image.FromFile("stand_left.png");
                        }
                        else
                        {
                            player.Image = Image.FromFile("stand_right.png");
                        }
                    }
                }

                // Player landing on a turtle of barrel, or getting hit by them
                if ((x.Tag.Equals("turtle") || x.Tag.Equals("barrel")))
                {
                    // If player land on a turtle or barrel, kill it and add to score
                    if (player.Right > x.Left && player.Left < x.Right &&
                        (player.Bottom < x.Top && player.Bottom >= x.Top - 20) && !jumping)
                    {
                        if (x.Tag.Equals("turtle"))
                        {
                            UpdateScore(15);
                            sfxPlayer = new System.Media.SoundPlayer("turtledie.wav");
                            sfxPlayer.Play();
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
                        player.Image = Image.FromFile("death.png");
                        onPlatform = false;
                        UpdateScore(-10);
                        UpdateLives(-1);
                        if (GetLives() == 0)
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
                    player.Image = Image.FromFile("death.png");
                    onPlatform = false;
                    UpdateScore(-10);
                    UpdateLives(-1);
                    if (GetLives() == 0)
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
                        if (!temp.OnPlatform && !(y is Barrel))
                        {
                            // If barrel intersects with a platform or floo,
                            // set it as the platform that it is on.
                            if ((y.Tag.Equals("platform") || y.Tag.Equals("floor"))
                                && temp.Bounds.IntersectsWith(y.Bounds))
                            {
                                Platform temp2 = (Platform)y;
                                temp.Platform = temp2;
                            }
                        }

                        // Reverse the barrel direction if it hits an edge
                        if (y.Tag.Equals("edge") && temp.Bounds.IntersectsWith(y.Bounds))
                        {
                            if (temp.GoingLeft)
                            {
                                temp.GoingLeft = false;
                            }
                            else
                            {
                                temp.GoingLeft = true;
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

        // Ends the game if player loses all lives
        // If player has a high score, they can enter their name to the leaderboard
        public void End()
        {
            // Go back to splash screen
            Hide();
            SplashHold.ResetMusic();
            SplashHold.Show();

            // Check if player score is good enough for leaderboard
            HighScores hs = new HighScores();
            if (hs.Worthy(GetScore()))
            {
                // Initiate high score prompt
                new Prompt(GetScore(), SplashHold);
            }
            Dispose();
        }

        // Creates a Label for a stat keeper
        public Label LabelMaker()
        {
            Label newLabel = new Label();
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
        
        // Updaters\Setters for Score and Lives
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
