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
        Mechanic Simone = new Mechanic(1, 1);
        Robot rob = new Robot(2, 2);
        // lijst met robots, zodat je robots kan toevoegen en verwijderen.
        public List<Robot> robots;

        // width = 4;      //breedte van de fabriek
        // height = 4;     //hoogte van de fabriek
        // robots = 2;     //Aantal robots op het begin
        // turns = 5;      // Maximale aantal turns
        // robotsMove = false; // Robots kunnen niet bewegen
        public Factory(int width, int height, int aantalRobots)
        {   //fabriek aanmaken
            Height = height;
            Width = width;
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



            StringBuilder sb = new StringBuilder();
            string[,] matrix = new string[Width, Height];

            for (int ii = 1; ii <= Height; ii++)
            {
                for (int jj = 1; jj <= Width; jj++)
                {
                    GameObject ItemAtIJ = GetObjectByPosition(ii, jj);
                    if(ItemAtIJ is Mechanic)
                    {
                        sb.Append('M');
                    }else if(ItemAtIJ is Robot)
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
 
        //check of er eeen mechanic of robot op de positie zit.
        public GameObject GetObjectByPosition(int i, int j)
        {
            if (Simone.xpositie == i & Simone.ypositie == j)
            {
                return Simone;
            }
            foreach(Robot robot in robots)
            {
                if (robot.xpositie == i & robot.ypositie == j)
                {
                    return robot;
                }
            }
            return null;
        }

    }
}
