using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            for (short i = 0; i < wdt; i++)
            {                
                for(short j = 0; j < hgt; j++)
                {
                    Crd temp = new Crd(i, j);
                    worldGrid.Add(temp);
                }
            }
        }
        
    }
}
