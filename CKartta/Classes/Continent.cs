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
        public Continent(Brush drawColor, List<Node> freeNodes, int hgt, int wdt, Random Rnd)
        {         
            color = drawColor;
            bool startSet = true;
            //get depth of continent
            depth = Rnd.Next(0, 10);
            while (startSet == true)
            {
                X = Rnd.Next(0,hgt-1);
                Y = Rnd.Next(0,wdt-1);
                depth = Rnd.Next(0, 10);
                Node temp = new Node(X, Y);
                //check on the list of not take nodes if the node is free. start from column it most likely is in
                for (int i = X*wdt; i < freeNodes.Count; i++)
                {
                    if (temp.x == freeNodes[i].x && temp.y == freeNodes[i].y){
                        freeNodes[i].elevation += depth; //set the nodes elevation as the same as continents
                        freeNodes[i].color = color;
                        areas.Add(freeNodes[i]);
                        freeNodes.Remove(freeNodes[i]);
                        startSet = false;

                        break;
                    }
                }
                //if something goes wrong
                foreach (Node node in freeNodes)
                {
                    if (node.x == temp.x && node.y == temp.y) 
                    {
                        areas.Add(node);
                        freeNodes.Remove(node);
                        startSet = false;
                        node.elevation += depth; //set the nodes elevation as the same as continents
                        node.color = color;
                        break;
                    }
                }       
            }
            
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
                            neighbour.elevation = depth; //set the nodes elevation as the same as continents
                            neighbour.color = color;
                            done = false;
                        } 
                    }
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
