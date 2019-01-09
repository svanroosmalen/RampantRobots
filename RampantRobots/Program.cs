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
            //Console.WriteLine("gebruik wasd knoppen om naar boven, links, onder of rechts te gaan");
            Factory fabriek = new Factory(5, 5 , 3, 3, false);
            fabriek.Run();
            //fabriek.Run();
            //Console.ReadLine();
            //Mechanic Simone = new Mechanic(1, 2);
            //Factory brieque = new Factory(4, 4, 5, 3, true);
            //string userInput;
            ////do
            ////{
            ////    Console.WriteLine(brieque.ToString());
            ////    userInput = Console.ReadLine(); // Vraag input van de gebruiker
            ////    brieque.Fabriek_metMR(Simone); 
            ////} while (("wasd".Contains(userInput.ToLower())));
            ////{    
            ////    Console.ReadLine();
            ////}
            //Mechanic Simone = new Mechanic(1, 1);
            //Console.WriteLine("Druk Enter om door te gaan"); 

            //fabriek.Fabriek_metMR(Simone);

            //Console.ReadLine();
            //Console.Clear();
            //Factory fabriek = new Factory(5, 5, 3);


        }


    }
}
