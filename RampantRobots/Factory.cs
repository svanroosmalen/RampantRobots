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
        public int AantalRobots { get; set; }
        //Maak een mechanic aan genaamd Simone
        Mechanic Simone = new Mechanic(1, 1);
        public List<Robot> robots;      // lijst met robots, zodat je robots kan toevoegen en verwijderen.

        // fabriek aanmaken en lijst met robots vullen
        public Factory(int width, int height, int aantalRobots, int turns)
        {   //fabriek aanmaken
            Height = height;
            Width = width;
            Turns = turns;
            AantalRobots = aantalRobots;
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
        //Print de fabriek
        public void PrintFactory()
        {
            StringBuilder sb = new StringBuilder();
            //alle punten afgaan in de fabriek en daar een . R of M neer zetten
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

        //Staat er een robot of Mechanic
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

        // 1 ronde en verloren spel afsluiten
        public void Ronde(int turns, bool win)
        {
            PrintFactory();
            Console.Write("Geef de stappen: ");
            string input = Console.ReadLine();
            //Ga iedere zet af of er robots op een mechanic staan, of een robot op een robot staat, mechanic 
            //in de fabriek houden en checken op dode robots
            foreach (char direction in input)
            {
                List<Robot> toRemove = new List<Robot>();
                foreach(Robot robot in robots)
                {
                    List<int> newPosition = robot.Robotmoves(Width, Height);
                    GameObject objectOnNewPosition = GetObjectByPosition(newPosition[0], newPosition[1]);
                    if(objectOnNewPosition is Mechanic)
                    {
                        // robot verwijderen
                        toRemove.Add(robot);
                    }
                    else if(!(objectOnNewPosition is Robot))
                    {
                        
                        robot.xpositie = newPosition[0];
                        robot.ypositie = newPosition[1];
                    }
                }
                foreach(Robot robot in toRemove)
                {
                    robots.Remove(robot);
                }
                Simone.Move(direction);
                // Zorgen dat Mechanic in de fabriek blijft
                //Als mechanic uit de fabriek loopt, blijft die op dezelfde plek staan. 
                if (Simone.ypositie < 1)
                    Simone.ypositie = 1;
                else if (Simone.xpositie < 1)
                    Simone.xpositie = 1;
                else if (Simone.ypositie > Height)
                    Simone.ypositie = Height;
                else if (Simone.xpositie > Width)
                    Simone.xpositie = Width;
                // checken op dode robots
                for (int ii = robots.Count - 1; ii >= 0; ii--)
                {
                    if (Simone.xpositie == robots[ii].xpositie & Simone.ypositie == robots[ii].ypositie)
                        robots.RemoveAt(ii);
                }

                 
            }

            Console.WriteLine(String.Format("You've got {0} turns left.", turns));
            //als je geen rondes meer over hebt, heb je verloren
            if (turns == 0)
            {
                Console.Clear();
                Console.WriteLine("Verloren");
            }

            win = win_je(win, turns);
        }
        //Run de ronde meerdere malen.
        public void Run(int turns)
        {
            Turns = turns;
            Console.WriteLine("Hallo! Leuk dat je meespeelt met Rampant Robot\n" +
            "Je kunt meespelen met de toetsen awsd.");
            bool win = false;

            for (int ii = Turns - 1; ii >= 0; ii--)
            {
                Ronde(ii, win);
            }
        }
        //checken of je gewonnen hebt
        public bool win_je(bool win, int turns)
        
            {
            if (robots.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Gefeliciteerd, je hebt het spel uitgespeeld");
                Console.WriteLine("You've had {0} turns left.", turns);
                win = true;
                Console.WriteLine("Druk nog een keer op Enter als je af wilt sluiten");
                Console.ReadLine();
                Environment.Exit(1);

            }

            return win;
        }

    }
}

        
