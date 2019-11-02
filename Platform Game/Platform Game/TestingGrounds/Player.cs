using System;
using System.Collections.Generic;
using System.Text;

namespace TestingGrounds
{
    class Player
    {
        bool goLeft = false;
        bool goRight = false;
        bool jumping = false;


        int jumpSpeed = 10;
        int force = 7;

        private void KeyDown()
        {
            if(e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Space && !jumping)
            {
                jumping = true;
            }
        }

        private void KeyUp()
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (jumping)
            {
                jumping = false;
            }
        }
    }
}
