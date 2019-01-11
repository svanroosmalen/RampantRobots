using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RampantRobots
{
   //GameObject aangemaakt voor Robot en Mechanic 
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
   //Mechanic met xpositie en ypositie
     class Mechanic : GameObject
    {
        public Mechanic(int Xposition, int Yposition) : base(Xposition, Yposition)
        {
        }
        //Laat de Mechanic naar boven,onder,links en rechts bewegen
        public void Move(char direction)
        {
            if (direction == 'w')
                xpositie--;
            else if (direction == 'a')
                ypositie--;
            else if (direction == 'd')
                ypositie++;
            else if (direction == 's')
                xpositie++;
            else
                //sluit programma af als je niet de goede direction invult.
                throw new ArgumentException("Invalid driection!");
        }

           
    }
    //Robot met xpositie en ypositie
    class Robot: GameObject
    {
        public Robot(int Xposition, int Yposition) : base(Xposition, Yposition)
        {
        }
        //laat robot een random kant op bewegen, links rechts boven of onder
        public List<int> Robotmoves(int width, int height) //List<Robot> robots)
        {
            Random Randomdirection = new Random();
            int direction = Randomdirection.Next(0, 4);
            List<int> result = new List<int>();
            result.Add(xpositie); result.Add(ypositie);
            switch (direction)
            {
                case 0:
                    if (ypositie > 1) result[1] -= 1; break;
                case 1:
                    if (xpositie < width) result[0] += 1; break;
                case 2:
                    if (ypositie < height) result[1] += 1; break;
                case 3:
                    if (xpositie > 1) result[0] -= 1; break;

            }
            return result;
        }
    }
}
