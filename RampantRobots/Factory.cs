using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RampantRobots
{
     class Factory
    {
        static Random random = new Random(1);
        public int Height { get; set; }
        public int Width { get; set; }
        Mechanic Simone = new Mechanic(1, 1);
        Robot rob = new Robot(2, 2);
        public List<Robot> robots;
 
        public Factory(int width, int height, int aantalRobots)
        {
            Height = height;
            Width = width;

            robots = new List<Robot>();
            for (int ii = 0; ii < aantalRobots; ii++)
            {
                Robot nieuw = new Robot(random.Next(1, width), random.Next(1, height));
                if (nieuw.xpositie == Simone.xpositie & nieuw.ypositie == Simone.ypositie | robots.Contains(nieuw))
                    ii--;
                else
                    robots.Add(nieuw);

                    
            }




            // width = 4;      //breedte van de fabriek
            // height = 4;     //hoogte van de fabriek
            // robots = 2;     //Aantal robots op het begin
            // turns = 5;      // Maximale aantal turns
            // robotsMove = false; // Robots kunnen niet bewegen
            
                StringBuilder sb = new StringBuilder();
                string[,] matrix = new string[Width, Height];

                for (int ii = 1; ii <= Height; ii++) {
                    for (int jj = 1; jj <= Width; jj++)
                    {
                    var rob = new Robot(ii, jj);
                    if (ii == Simone.xpositie & jj == Simone.ypositie)
                        sb.Append('M');
                    //else if (robots.Contains(rob))
                    else if ((robots.Select(x => x.xpositie).Distinct().ToList()).Count > 1 & (robots.Select(y => y.ypositie).Distinct().ToList()).Count > 1)
                          sb.Append('R');
                    else
                        sb.Append('.');

                    }
                    sb.Append(Environment.NewLine);
                }
                
                Console.WriteLine(sb.ToString());

        }

    }
}
