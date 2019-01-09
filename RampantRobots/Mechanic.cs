using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RampantRobots
{
    class GameObject
    {
        public int xpositie { get; set; }
        public int ypositie { get; set; }

        public GameObject(int Xposition, int Yposition)
        {
            xpositie = Xposition;
            ypositie = Yposition;
        }

    }
   
     class Mechanic : GameObject
    {
        public Mechanic(int Xposition, int Yposition) : base(Xposition, Yposition)
        {
        }
        public void Move(char direction)
        {
            if (direction == 'a')
                xpositie--;
            else if (direction == 'w')
                ypositie--;
            else if (direction == 'd')
                ypositie++;
            else if (direction == 's')
                xpositie++;
            else
                throw new ArgumentException("Invalid driection!");
        }

           
    }
    class Robot: GameObject
    {
        public Robot(int Xposition, int Yposition) : base(Xposition, Yposition)
        {
        }

    }
}
