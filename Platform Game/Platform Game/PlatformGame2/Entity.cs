using System.Drawing;
using System.Windows.Forms;

/// <summary>
/// Entity.cs
/// 
/// This class file sets up the different elements in the CustomForm window of gameplay
/// Methods: Full Constructor
/// </summary>

namespace PlatformGame2
{
    class Entity : PictureBox
    {
        //Full Constructor
        public Entity(int locX, int locY, string tag)
        {
            // Set the Entity's starting location and Tag
            Location = new Point(locX, locY);
            Tag = tag;

            // Set the size and starting image for the entity
            if (tag.Equals("player"))
            {
                Size = new Size(16, 21);
                Image = Image.FromFile("stand_right.png");
            }
            else if (tag.Equals("coin"))
            {
                Size = new Size(9, 11);
                Image = Image.FromFile("coin.png");
            }
            else if (tag.Equals("heart"))
            {
                Size = new Size(20, 20);
                Image = Image.FromFile("lifeHeart.png");
            }
            else if (tag.Equals("exit"))
            {
                Size = new Size(16, 28);
                Image = Image.FromFile("door.png");
            }
            else if (tag.Equals("turtle"))
            {
                Size = new Size(18, 16);
                Image = Image.FromFile("tortoiseRight.gif");
            }
            else if (tag.Equals("barrel"))
            {
                Size = new Size(14, 14);
                Image = Image.FromFile("barrelLeft.gif");
            }
            else if (tag.Equals("ghost"))
            {
                Size = new Size(14, 14);
                Image = Image.FromFile("ghostLeft.gif");
            }
        }
    }
}
