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
        private string name;                     //name of the continent
        private Color color;                    //color the continent will be on screen
        List<Crd> areas = new List<Crd>();      //area coordinates list
        List<Crd> doneAreas = new List<Crd>();  //areas that cant spread anymore
        private int X;                          //starting X
        private int Y;                          //starting Y

        //constructor
        public Continent(string continentName, Color drawColor, List<Crd> freeArea, int hgt, int wdt)
        {
            name = continentName;
            color = drawColor;
            Random Rnd = new Random();
            while (true)
            {
                X = Rnd.Next(0,hgt);
                Y = Rnd.Next(0,wdt);
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

        public void drawSelf(Grid mapGrid)
        {
            foreach (Crd spot in areas) { 
                //get position from list
                Rectangle temp = new Rectangle();
                temp.Fill = new SolidColorBrush(color);
                Grid.SetRow(temp, spot.x);
                Grid.SetColumn(temp, spot.y);
                mapGrid.Children.Add(temp);
            }
        }

        //spread continent across the screen
        public void Spread(int wdt, List<Crd> freeArea)
        {
            Random Rnd = new Random();
            foreach (Crd spot in freeArea)
            {
                int flip = Rnd.Next(0, 1);
                if (flip == 1)
                {
                    bool done = true;
                    //check neighbours
                    //left
                    Crd temp = new Crd(spot.x-1, spot.y);
                    bool containsItem = freeArea.Contains(temp);
                    if (containsItem)
                    {
                        areas.Add(temp);
                        freeArea.Remove(temp);
                        done = false;
                    }
                    //right
                    temp.x += 2;
                    containsItem = freeArea.Contains(temp);
                    if (containsItem)
                    {
                        areas.Add(temp);
                        freeArea.Remove(temp);
                        done = false;
                    }
                    //up
                    temp.x -= 1;
                    temp.y -= 1;
                    containsItem = freeArea.Contains(temp);
                    if (containsItem)
                    {
                        areas.Add(temp);
                        freeArea.Remove(temp);
                        done = false;
                    }
                    //down
                    temp.y += 2;
                    containsItem = freeArea.Contains(temp);
                    if (containsItem)
                    {
                        areas.Add(temp);
                        freeArea.Remove(temp);
                        done = false;
                    }

                    //move spot to another list if it cant spread anymore 
                    if (done)
                    {
                        doneAreas.Add(spot);
                        areas.Remove(spot);
                    }
                }
            }
        }
    }
}
