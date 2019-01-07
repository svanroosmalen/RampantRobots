using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RampantRobots
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("gebruik wasd knoppen om naar boven, links, onder of rechts te gaan");
            Factory fabriek = new Factory(5, 5 , 3);
            Console.WriteLine("Druk Enter om door te gaan");
            Console.ReadLine();

        }
    }
}
