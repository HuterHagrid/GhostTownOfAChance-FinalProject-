using System.Drawing;
using System.Windows.Forms;

/// <summary>
/// Platform.cs
/// 
/// This class file defines the platforms used in game levels.
/// Methods: Constructor
/// </summary>

namespace PlatformGame2
{
    class Platform : PictureBox
    {
        public Platform(int locX, int locY, int width, int height, string tag)
        {
            // Set location, size, and Tag
            Location = new Point(locX, locY);
            Size = new Size(width, height);
            Tag = tag;

            // Set the platform image
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
