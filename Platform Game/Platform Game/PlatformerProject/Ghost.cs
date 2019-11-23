using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Ghost Class
/// This object class is to move randomly throughout the playable area.
/// </summary>
namespace PlatformerProject
{
    class Ghost : Enemy
    {
        int movespeed = 0;
        int ticker;
        public Ghost() : base()
        {
            ticker = 0;
        }

       public void Movement()
        {
            Random random = new Random();

            ticker++;
            //movement cases
            if(ticker %2 == 0) //move right
            {
                
                movespeed = random.Next();
                this.Left = -movespeed;
            }
            else //move left
            {
                movespeed = random.Next();
                this.Left = movespeed;
            }
            
            if(ticker >= 99) //reset ticker
            {
                ticker = 0;
            }
            
        }
    }
}
