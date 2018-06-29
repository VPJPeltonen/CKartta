using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;

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
        private short X;                    //starting X
        private short Y;                    //starting Y

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

        public void drawSelf(System.Windows.Controls.Grid mapGrid)
        {
            //get position from list
            Crd position = areas[0];
            Rectangle temp = new Rectangle();
            temp.Fill = new SolidColorBrush(Colors.Blue);
            System.Windows.Controls.Grid.SetRow(temp, position.x);
            System.Windows.Controls.Grid.SetColumn(temp, position.y);
            mapGrid.Children.Add(temp);
        }

        //spread continent across the screen
        public void Spread()
        {
        }
    }
}
