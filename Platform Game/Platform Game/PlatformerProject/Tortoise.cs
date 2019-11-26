using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerProject
{
    class Tortoise : Enemy
    {
        int leftCount;
        int rightCount;
        int movespeed = 0;

        public object Image { get; private set; }

        public Tortoise() : base()
        {
        }

        public void TortoiseMovement()
        {

            while (leftCount > 6 && rightCount == 0)
            {
                if (movespeed < 3)
                    movespeed += 1;
                this.Left -= movespeed;
                //this.Image = Image.FromFile("run_left.gif");
                leftCount++;
            }
            SwitchDirection(leftCount, rightCount);
            while (leftCount < 6 && rightCount > 6)
            {
                if (movespeed < 3)
                    movespeed += 1;
                this.Left += movespeed;
                //this.Image = Image.FromFile("run_right.gif");
                rightCount++;
            }
            SwitchDirection(leftCount, rightCount);
        }

        public void SwitchDirection(int leftCount, int rightCount)
        {
            if (leftCount >= 6)
            {
                leftCount = 0;
            }

            if (rightCount >= 6)
            {
                rightCount = 0;
            }
        }


    }
}
