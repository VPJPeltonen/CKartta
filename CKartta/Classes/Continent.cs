using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace CKartta
{
    /*
     * Continental plate info
     */ 
    class Continent
    {
        private string name;                //name of the continent
        private string color;               //color the continent will be on screen
        List<Crd> areas = new List<Crd>();  //area coordinates list
        private short X;
        private short Y;

        //constructor
        public Continent(string continentName, string drawColor, List<Crd> freeArea, int hgt, int wdt)
        {
            name = continentName;
            color = drawColor;
            Random Rnd = new Random();
            while (true)
            {
                X = (short)Rnd.Next(0,hgt);
                Y = (short)Rnd.Next(0,wdt);
                Crd temp = new Crd(X, Y);
                bool containsItem = freeArea.Contains(temp);
                if (containsItem)
                {
                    areas.Add(temp);
                    freeArea.Remove(temp);
                    break;                    
                }                
            }            
        }

        public void drawSelf()
        {
            Rectangle square = new Rectangle();
        }

        //spread continent across the screen
        public void Spread()
        {
        }
    }
}
