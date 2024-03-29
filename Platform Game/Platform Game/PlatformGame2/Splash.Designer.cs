﻿namespace PlatformGame2
{
    partial class Splash
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.playGameButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.highScoresRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // playGameButton
            // 
            this.playGameButton.BackColor = System.Drawing.Color.Red;
            this.playGameButton.Location = new System.Drawing.Point(432, 313);
            this.playGameButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.playGameButton.Name = "playGameButton";
            this.playGameButton.Size = new System.Drawing.Size(80, 21);
            this.playGameButton.TabIndex = 0;
            this.playGameButton.Text = "Play";
            this.playGameButton.UseVisualStyleBackColor = false;
            this.playGameButton.Click += new System.EventHandler(this.PlayGameButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.Color.Red;
            this.quitButton.Location = new System.Drawing.Point(432, 344);
            this.quitButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(80, 21);
            this.quitButton.TabIndex = 1;
            this.quitButton.Text = "Exit";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // highScoresRichTextBox
            // 
            this.highScoresRichTextBox.BackColor = System.Drawing.Color.Yellow;
            this.highScoresRichTextBox.Enabled = false;
            this.highScoresRichTextBox.Location = new System.Drawing.Point(412, 385);
            this.highScoresRichTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.highScoresRichTextBox.Name = "highScoresRichTextBox";
            this.highScoresRichTextBox.Size = new System.Drawing.Size(117, 138);
            this.highScoresRichTextBox.TabIndex = 2;
            this.highScoresRichTextBox.Text = "";
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(963, 658);
            this.Controls.Add(this.highScoresRichTextBox);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.playGameButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Splash";
            this.Text = "Ghost Town of a Chance";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button playGameButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.RichTextBox highScoresRichTextBox;
    }
}

