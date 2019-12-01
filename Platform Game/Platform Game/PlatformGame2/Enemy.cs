using System.Windows.Forms;
/// <summary>
/// Turtle.cs
/// 
/// This class file is a constructor base class for the various enemy types (turtle, barrel, ghost)
/// Methods: Constructor
/// </summary>
namespace PlatformGame2
{
    class Enemy : Entity
    {
        public Enemy(int locX, int locY, string tag) : base(locX, locY, tag) { }

        public virtual void Movement() { }
    }
}
