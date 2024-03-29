﻿using System;
using System.Windows.Forms;

/// <summary>
/// Prompt.cs
/// 
/// This class file defines the prompt that displays if the user is has a high score.
/// Variables: newhs, score, splash
/// Methods: Constructor, EnterButton_Click
/// </summary>

namespace PlatformGame2
{
    // Displays a prompt to enter a high score to the leaderboard
    class Prompt : Form
    {
        // Form components
        private Label messageLabel;
        private Label nameLabel;
        private Label scoreLabel;
        private TextBox nameTextBox;
        private TextBox scoreTextBox;
        private Button enterButton;

        // Instance Variables
        private HighScore newhs;
        private int score;
        private Splash splash;

        // Constructor
        public Prompt(int score, Splash splashhold)
        {
            InitializeComponent();

            this.score = score;
            splash = splashhold;
            newhs = null;

            // Displays the user's final score
            scoreTextBox.Text = score.ToString();

            // Waits for this window to be closed before going back to the game
            ShowDialog();
        }

        // Enters the players name and score to the leaderboard
        private void EnterButton_Click(object sender, EventArgs e)
        {
            // Gets user input name
            string name = nameTextBox.Text;

            // No whitespace in name
            name = name.Replace(" ", "");

            // If player does not enter a name, they are Unknown
            if (name == "")
            {
                name = "Unknown";
            }

            // Names limited to 10 characters
            if (name.Length > 10)
            {
                name = name.Substring(0, 10);
            }

            // Create the new High Score and add it to the leaderboard
            newhs = new HighScore(name, score);
            HighScores hs = new HighScores();
            hs.AddNewHs(newhs);

            // Write the scores to the file and update the splash screen
            hs.Write();
            splash.UpdateHS();
            Close();
        }

        private void InitializeComponent()
        {
            this.messageLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.scoreTextBox = new System.Windows.Forms.TextBox();
            this.enterButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(55, 27);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(167, 13);
            this.messageLabel.TabIndex = 0;
            this.messageLabel.Text = "Congratulations! New High Score!";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(55, 66);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(41, 13);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Name: ";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Location = new System.Drawing.Point(55, 108);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(41, 13);
            this.scoreLabel.TabIndex = 2;
            this.scoreLabel.Text = "Score: ";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(112, 63);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 3;
            // 
            // scoreTextBox
            // 
            this.scoreTextBox.Enabled = false;
            this.scoreTextBox.Location = new System.Drawing.Point(112, 105);
            this.scoreTextBox.Name = "scoreTextBox";
            this.scoreTextBox.Size = new System.Drawing.Size(100, 20);
            this.scoreTextBox.TabIndex = 4;
            // 
            // enterButton
            // 
            this.enterButton.Location = new System.Drawing.Point(99, 153);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(75, 29);
            this.enterButton.TabIndex = 5;
            this.enterButton.Text = "Enter";
            this.enterButton.UseVisualStyleBackColor = true;
            this.enterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // Prompt
            // 
            this.ClientSize = new System.Drawing.Size(289, 211);
            this.Controls.Add(this.enterButton);
            this.Controls.Add(this.scoreTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.messageLabel);
            this.Name = "Prompt";
            this.Text = "New High Score!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
