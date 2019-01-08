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
    public void Move(GameObject Simone)
    {
        string input = Console.ReadLine();
        for (int ii = 0; ii <= input.Length; ii++)
        {
            if (input[ii] == 'a')
                Simone.xpositie--;
            else if (input[ii] == 'w')
                Simone.ypositie--;
            else if (input[ii] == 's')
                Simone.ypositie++;
            else if (input[ii] == 'd')
                Simone.xpositie++;
            else
                Console.WriteLine("tik a, w, s of d in");
        }
    }
    class Mechanic : GameObject
    {
        public Mechanic(int Xposition, int Yposition) : base(Xposition, Yposition)
        {
        }

    }
    class Robot: GameObject
    {
        public Robot(int Xposition, int Yposition) : base(Xposition, Yposition)
        {
        }

    }
}
