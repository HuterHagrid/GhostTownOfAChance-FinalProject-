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
                BackgroundImage = Image.FromFile("block.png");
            }
            else if (tag.Equals("edge"))
            {
                BackgroundImage = Image.FromFile("wall.png");
            }
            else
            {
                BackgroundImage = Image.FromFile("ground.png");
            }
        }
    }
}
