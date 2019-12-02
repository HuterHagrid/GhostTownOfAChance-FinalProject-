/// <summary>
/// Enemy.cs
/// 
/// This class file is a constructor base class for the various enemy types (turtle, barrel, ghost)
/// Methods: Constructor, Movement - virtual method that each enemy can override
/// </summary>

namespace PlatformGame2
{
    class Enemy : Entity 
    {
        //full constructor
        public Enemy(int locX, int locY, string tag) : base(locX, locY, tag) { }

        //virtual movement method to be overridden by child enemy types
        public virtual void Movement() { }
    }
}
