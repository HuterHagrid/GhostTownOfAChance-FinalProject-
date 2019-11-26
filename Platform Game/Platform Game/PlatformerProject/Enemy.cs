using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerProject
{
    class Enemy : Form1
    {
        bool isAlive;
        int hitPoints;
        public Enemy()
        {
            hitPoints = 1;
            isAlive = true;
        }
        public Enemy(int hitPoints, bool isAlive)
        {
            this.hitPoints = hitPoints;
            this.isAlive = isAlive;
        }
    }
}
