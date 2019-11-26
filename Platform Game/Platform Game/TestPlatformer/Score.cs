using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
    class Score
    {
        long scoreNumber;
        public Score()
        {
            this.scoreNumber = 0;
        }

        public Score(Score obj)
        {
            this.scoreNumber = obj.scoreNumber;
        }

    }
}
