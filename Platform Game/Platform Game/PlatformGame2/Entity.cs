﻿using System.Drawing;
using System.Windows.Forms;

namespace PlatformGame2
{
    class Entity : PictureBox
    {
        public Entity(int locX, int locY, string tag)
        {
            Location = new Point(locX, locY);
            Tag = tag;
            if (tag.Equals("player"))
            {
                Size = new Size(16, 21);
                //BackColor = Color.Blue;
                Image = Image.FromFile("stand_right.png");
            }
            else if (tag.Equals("coin"))
            {
                Size = new Size(9, 11);
                //BackColor = none;
                Image = Image.FromFile("coin.png");
            }
            else if (tag.Equals("heart"))
            {
                Size = new Size(20, 20);
                BackColor = Color.Red;
            }
            else if (tag.Equals("exit"))
            {
                Size = new Size(16, 28);
                Image = Image.FromFile("door.png");
            }
            else if (tag.Equals("turtle"))
            {
                Size = new Size(18, 16);
                //BackColor = Color.Green;
                Image = Image.FromFile("tortoiseLeft.gif");
            }
            else if (tag.Equals("barrel"))
            {
                Size = new Size(40, 30);
                BackColor = Color.Brown;
                Image = Image.FromFile("barrelLeft.gif");
            }
            else if (tag.Equals("ghost"))
            {
                Size = new Size(14, 14);
                //BackColor = Color.Gray;
                Image = Image.FromFile("ghostLeft.gif");
            }
        }
    }
}