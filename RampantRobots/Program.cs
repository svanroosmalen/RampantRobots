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
            //Fabriek aanmaken en runnen.
            //fabriek(xlengte, ylengte, aantal robots, aantal turns)
            int turns = 3;
            int xlength = 5;
            int ylength = 5;
            int aantal_robots = 3;
            Factory fabriek = new Factory(xlength, ylength, aantal_robots, turns);
            //fabriek runnen(zelfde aantal turns)
            fabriek.Run(turns);


        }

    }
}
