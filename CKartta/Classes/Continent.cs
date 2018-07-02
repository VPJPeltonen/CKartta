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
        List<Node> areas = new List<Node>();      //area coordinates list
        List<Node> doneAreas = new List<Node>();  //areas that cant spread anymore
        private int X;                          //starting X
        private int Y;                          //starting Y

        //constructor
        public Continent(Brush drawColor, List<Node> freeNodes, int hgt, int wdt)
        {         
            color = drawColor;
            Random Rnd = new Random();
            bool startSet = true;
            while (startSet == true)
            {
                X = Rnd.Next(0,hgt-1);
                Y = Rnd.Next(0,wdt-1);
                Node temp = new Node(X, Y);
                foreach (Node node in freeNodes)
                {
                    if (node.x == temp.x && node.y == temp.y) 
                    {
                        areas.Add(node);
                        freeNodes.Remove(node);
                        startSet = false;
                        break;
                    }
                }

                /*/bool containsItem = freeNodes.Contains(temp);
                if (containsItem)
                {
                    areas.Add(temp);
                    freeNodes.Remove(temp);
                    break;                    
                } */               
            }
            depth = Rnd.Next(0, 10);
        }

        //create rectangles for the grid
        public void drawSelf(Canvas mainCanvas)
        {
            foreach (Node spot in areas) {
                Rectangle temp = new Rectangle
                {
                    Stroke = color,
                    StrokeThickness = 8
                };
                Canvas.SetLeft(temp, spot.x*8);
                Canvas.SetTop(temp, spot.y*8);
                mainCanvas.Children.Add(temp);
            }
            foreach (Node spot in doneAreas)
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

        //move area around lists
        private bool MovedAreas(bool found,List<Node> Areas, List<Node> FreeAreas, Node Area)
        {
            if (found)
            {
                Areas.Add(Area);
                FreeAreas.Remove(Area);
                return false;
            }
            else { return true;}
        }

        //spread continent across the screen
        public void Spread(int wdt, List<Node> freeNodes)
        {
            Random Rnd = new Random(2);
            List<Node> tempareas = new List<Node>(areas);
            
            foreach (Node spot in tempareas)
            {
                int flip = Rnd.Next(0, 2);
                if (flip == 1)
                {
                    //foreach (Node node in freeNodes.ToList())
                    //{
                    bool done = true;
                    List<Node> tempNeighbours = new List<Node>(spot.neighbours);
                    foreach (Node neighbour in tempNeighbours)
                    {                        
                        if (freeNodes.Contains(neighbour))
                        {
                            areas.Add(neighbour);
                            freeNodes.Remove(neighbour);
                            done = false;
                        }

                    }
                    if (done)
                    {
                        doneAreas.Add(spot);
                        areas.Remove(spot);
                    }
                }
                //}
                /*bool done = true;
                //check neighbours
                //left
                Node temp = new Node(spot.x-1, spot.y);
                bool containsItem = freeNodes.Contains(temp);
                done = MovedAreas(containsItem,areas, freeNodes, temp);*/
                /* if (node.x == temp.x && node.y == temp.y)
                 {
                     areas.Add(node);
                     freeNodes.Remove(node);
                     startSet = false;
                     break;
                 }*/
                /*
                //right
                temp.x += 2;
                containsItem = freeArea.Contains(temp);
                done = MovedAreas(containsItem, areas, freeArea, temp);
                //up
                temp.x = spot.x;
                temp.y = spot.y-1;
                containsItem = freeArea.Contains(temp);
                done = MovedAreas(containsItem, areas, freeArea, temp);
                //down
                temp.y += 2;
                containsItem = freeArea.Contains(temp);
                done = MovedAreas(containsItem, areas, freeArea, temp);
                //move spot to another list if it cant spread anymore 
                if (done)
                {
                    doneAreas.Add(spot);
                    areas.Remove(spot);
                }*/

            }
        }
    }
}
