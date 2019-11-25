using System.Drawing;
using System.Windows.Forms;

namespace PlatformGame2
{
    class Platform : PictureBox
    {
        public Platform(int locX, int locY, int width, int height, string tag)
        {
            Location = new Point(locX, locY);
            Size = new Size(width, height);
            Tag = tag;
            if (tag.Equals("platform"))
            {
                BackColor = Color.Brown;
            }
            else
            {
                BackColor = Color.Black;
            }
        }
    }
}
