using System.Drawing;
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
                Size = new Size(20, 30);
                BackColor = Color.Blue;
            }
            else if (tag.Equals("coin"))
            {
                Size = new Size(20, 20);
                BackColor = Color.Yellow;
            }
            else if (tag.Equals("heart"))
            {
                Size = new Size(20, 20);
                BackColor = Color.Red;
            }
            else if (tag.Equals("exit"))
            {
                Size = new Size(40, 50);
                BackColor = Color.Green;
            }
            else if (tag.Equals("turtle"))
            {
                Size = new Size(30, 20);
                BackColor = Color.Green;
            }
            else if (tag.Equals("barrel"))
            {
                Size = new Size(40, 30);
                BackColor = Color.Brown;
            }
            else if (tag.Equals("ghost"))
            {
                Size = new Size(30, 30);
                BackColor = Color.Gray;
            }
        }
    }
}
