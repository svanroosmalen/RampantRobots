using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RampantRobots
{
    class Mechanic
    {
        public int xpositie { get; set; }
        public int ypositie { get; set; }
        
        public Mechanic(int Xposition, int Yposition)
        {
            xpositie = Xposition;
            ypositie = Yposition;
        }
     
    }
}
