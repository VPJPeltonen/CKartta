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
        public int depth;                      //how high does the continent stand
        public Brush color;                    //color the continent will be on screen
        List<Crd> areas = new List<Crd>();      //area coordinates list
        List<Crd> doneAreas = new List<Crd>();  //areas that cant spread anymore
        private int X;                          //starting X
        private int Y;                          //starting Y

        //constructor
        public Continent(Brush drawColor, List<Crd> freeArea, int hgt, int wdt)
        {         
            color = drawColor;
            Random Rnd = new Random();
            while (true)
            {
                X = Rnd.Next(0,hgt-1);
                Y = Rnd.Next(0,wdt-1);
                Crd temp = new Crd(X, Y);
                bool containsItem = freeArea.Contains(temp);
                if (containsItem)
                {
                    areas.Add(temp);
                    freeArea.Remove(temp);
                    break;                    
                }                
            }
            depth = Rnd.Next(0, 10);
        }

        //create rectangles for the grid
        public void drawSelf(Canvas mainCanvas)
        {
            foreach (Crd spot in areas) {
                Rectangle temp = new Rectangle
                {
                    Stroke = color,
                    StrokeThickness = 8
                };
                Canvas.SetLeft(temp, spot.x*8);
                Canvas.SetTop(temp, spot.y*8);
                mainCanvas.Children.Add(temp);

                /*/get position from list
                Rectangle temp = new Rectangle();
                temp.Fill = new SolidColorBrush(color);
                temp.Margin = new System.Windows.Thickness (0,0,0,0);
                Grid.SetRow(temp, spot.x);
                Grid.SetColumn(temp, spot.y);
                mapGrid.Children.Add(temp);*/
            }
            foreach (Crd spot in doneAreas)
            {
                Rectangle temp = new Rectangle
                {
                    Stroke = color,
                    StrokeThickness = 8
                };
                Canvas.SetLeft(temp, spot.x * 8);
                Canvas.SetTop(temp, spot.y * 8);
                mainCanvas.Children.Add(temp);
            }
        }

        //spread continent across the screen
        public void Spread(int wdt, List<Crd> freeArea)
        {
            Random Rnd = new Random(2);
            List<Crd> tempareas = new List<Crd>(areas);
             foreach (Crd spot in tempareas)
             {
                 int flip = Rnd.Next(0, 2);
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
                     temp.x = spot.x;
                     temp.y = spot.y-1;
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
