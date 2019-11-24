namespace PlatformGame2
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
            this.playGameButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playGameButton
            // 
            this.playGameButton.Location = new System.Drawing.Point(414, 301);
            this.playGameButton.Name = "playGameButton";
            this.playGameButton.Size = new System.Drawing.Size(120, 33);
            this.playGameButton.TabIndex = 0;
            this.playGameButton.Text = "Play Game";
            this.playGameButton.UseVisualStyleBackColor = true;
            this.playGameButton.Click += new System.EventHandler(this.playGameButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(414, 350);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(120, 33);
            this.quitButton.TabIndex = 1;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 695);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.playGameButton);
            this.Name = "Form1";
            this.Text = "Ghost Town of a Chance";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button playGameButton;
        private System.Windows.Forms.Button quitButton;
    }
}

