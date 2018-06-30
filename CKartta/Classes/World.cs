using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CKartta
{
    /*
     * Holds info of the world
    */
    class World
    {
        private short gSize;    //size of squares
        private int wdt;        //width of map in squares
        private int hgt;        //height of the map in squares
        List<Crd> worldGrid = new List<Crd>();

        //constructor
        public World(short gridSize, int width, int heigth)
        {
            gSize = gridSize;
            wdt = width;
            hgt = heigth;
            //create the grid
            for (int i = 0; i < wdt; i++)
            {                
                for(int j = 0; j < hgt; j++)
                {
                    Crd temp = new Crd(i, j);
                    worldGrid.Add(temp);
                }
            }
        }

        public List<Crd> GetList()
        {
            List<Crd> freezones = new List<Crd>(worldGrid);
            return freezones;
        }

        public void WaterLevels(List<Object> continents)
        {
            int averageLevel = 0;
            foreach (Continent leveling in continents) {averageLevel += leveling.depth;}
            averageLevel = averageLevel / continents.Count;
            foreach (Continent watering in continents)
            {
                if (watering.depth <= averageLevel){watering.color = Brushes.Blue;}
                else{ watering.color = Brushes.Green; }
            }
        }

    }
}
