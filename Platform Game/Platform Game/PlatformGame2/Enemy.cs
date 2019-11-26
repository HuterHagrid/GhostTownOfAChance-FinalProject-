using System.Windows.Forms;

namespace PlatformGame2
{
    class Enemy : Entity
    {
        public Enemy(int locX, int locY, string tag) : base(locX, locY, tag) { }

        public virtual void Movement() { }
    }
}
