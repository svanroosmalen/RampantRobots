using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RampantRobots
{
    class Factory
    {
        static Random random = new Random();
        public int Height { get; set; }
        public int Width { get; set; }
        public int Turns { get; set; }
        Mechanic Simone = new Mechanic(1, 1);
        Robot rob = new Robot(2, 2);
        public List<Robot> robots;      // lijst met robots, zodat je robots kan toevoegen en verwijderen.


        // width = 4;      //breedte van de fabriek
        // height = 4;     //hoogte van de fabriek
        // robots = 2;     //Aantal robots op het begin
        // turns = 5;      // Maximale aantal turns
        // robotsMove = false; // Robots kunnen niet bewegen

        // fabriek aanmaken en lijst met robots vullen
        public Factory(int width, int height, int aantalRobots, int turns, bool robotsMove)
        {   //fabriek aanmaken
            Height = height;
            Width = width;
            Turns = turns;
            Simone = new Mechanic(1, 1);
            //nieuwe robot aanmaken
            robots = new List<Robot>();
            while (robots.Count < aantalRobots)
            {
                Robot nieuw = new Robot(random.Next(1, width), random.Next(1, height));
                if (GetObjectByPosition(nieuw.xpositie, nieuw.ypositie) == null)
                {   //toevoegen als hij niet bestaat of op dezelfde plaats staat als de Mechanic. 
                    robots.Add(nieuw);
                }

            }
        }

        public void PrintFactory()
        {
            StringBuilder sb = new StringBuilder();
            string[,] matrix = new string[Width, Height];

            for (int ii = 1; ii <= Height; ii++)
            {
                for (int jj = 1; jj <= Width; jj++)
                {
                    GameObject ItemAtIJ = GetObjectByPosition(ii, jj);
                    if (ItemAtIJ is Mechanic)
                    {
                        sb.Append('M');
                    }
                    else if (ItemAtIJ is Robot)
                    {
                        sb.Append('R');
                    }
                    else
                    {
                        sb.Append('.');
                    }

                }
                sb.Append(Environment.NewLine);
            }

            Console.WriteLine(sb.ToString());
        }

        
        public GameObject GetObjectByPosition(int i, int j)
        {
            if (Simone.xpositie == i & Simone.ypositie == j)
            {
                return Simone;
            }
            foreach (Robot robot in robots)
            {
                if (robot.xpositie == i & robot.ypositie == j)
                {
                    return robot;
                }
            }
            return null;
        }

        // 1 ronde en als je verloren hebt een nieuw spel
        public void Ronde(int turns, bool win)
        {
            //Console.WriteLine("Druk op enter om verder te gaan" +
            //    "");
            PrintFactory();
            Console.Write("Geef de stappen: ");
            string input = Console.ReadLine();
            foreach (char direction in input)
            {
                Simone.Move(direction);
                // Zorgen dat Mechanic in de fabriek blijft
                if (Simone.ypositie < 1)
                    Simone.ypositie = 1;
                else if (Simone.xpositie < 1)
                    Simone.xpositie = 1;
                else if (Simone.ypositie > Height)
                    Simone.ypositie = Height;
                else if (Simone.xpositie > Width)
                    Simone.xpositie = Width;
                // checken op dooie robots
                for (int ii = robots.Count - 1; ii >= 0; ii--)
                {
                    if (Simone.xpositie == robots[ii].xpositie & Simone.ypositie == robots[ii].ypositie)
                        robots.RemoveAt(ii);
                }
                PrintFactory();
                // checken of robot uit veld loopt
                // Don't let simone go out of bounds
                
            }

            Console.WriteLine(String.Format("You've got {0} turns left.", turns-1));

            if (turns == 0)
            {
                Console.Clear();
                Console.WriteLine("Verloren");
                Start_newgame(win, turns);
            }

            win = WinCheck(win, turns);
            Start_newgame(win, turns);
        }
        //Run de ronde meerdere malen.
        public void Run()
        {
//            Console.Clear();
            Console.WriteLine("Hallo! Leuk dat je meespeelt met Rampant Robot\n" +
            "Je kunt meespelen met de toetsen awsd.");
            bool win = false;

            for (int ii = Turns - 1; ii >= 0; ii--)
            {
                Ronde(ii, win);
            }

            //Console.ReadLine();
        }

        public bool WinCheck(bool win, int turns)
        
            {
            if (robots.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Gefeliciteerd, je hebt het spel uitgespeeld");
                Console.WriteLine("You've had {0} turns left.", turns);
                win = true;
            }

            return win;
        }
        public void Start_newgame(bool win, int turns)
        {
            if (win == true | turns == 0)
            {
                Console.WriteLine("Do you want to play again? (y/n)");
                string newgame = Console.ReadLine();

                if (newgame == "y")
                {
                    Console.WriteLine("Succes met het volgende potje :)");
                    Factory fabriek = new Factory(5, 5, 3, 5, false);
                    fabriek.Run();
                }
                else if (newgame == "n")
                {
                    Console.WriteLine("Ha! durf je niet meer?!");
                    Console.ReadLine();
                    Environment.Exit(1);
                }
            }
        }


    }


}

        
