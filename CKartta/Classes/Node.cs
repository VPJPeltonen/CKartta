using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace CKartta
{
    /*
    * Single node for the map
    * Should hold info on that part of map
    */
    class Node
    {
        public int x;                                       //x coordinate
        public int y;                                       //y coordinate 
        public List<Node> neighbours = new List<Node>();    //list of neighbours
        public int elevation;                               //how much elevation does the spot have
        public Brush color;

        //constructor
        public Node(int Xcoordinate, int Ycoordinate, int depth)
        {
            x = Xcoordinate;
            y = Ycoordinate;
            elevation = depth;
        }

        //constructor
        public Node(int Xcoordinate, int Ycoordinate)
        {
            x = Xcoordinate;
            y = Ycoordinate;
        }
        //set neighbours
        public void SetNeighbours(List<Node> FreeNodes)
        {
            foreach(Node node in FreeNodes)
            {
                //right
                if (node.x == x+1 && node.y == y){neighbours.Add(node);}
                //left
                if (node.x == x-1 && node.y == y){neighbours.Add(node);}
                //up
                if (node.x == x && node.y == y-1){neighbours.Add(node);}
                //down
                if (node.x == x && node.y == y+1){neighbours.Add(node);}
                //corners
                //topleft
                if (node.x == x-1 && node.y == y-1){neighbours.Add(node);}
                //topright
                if (node.x == x+1 && node.y == y-1){neighbours.Add(node);}
                //bottomleft
                if (node.x == x-1 && node.y == y+1){neighbours.Add(node);}
                //bottomright
                if (node.x == x+1 && node.y == y+1){neighbours.Add(node);}
                //stop if all neightbours found
                if (neighbours.Count == 8){break;}
            }
        }

        //adjust height so there isnt too great differences between neighbours
        public void Smooth(){
            int average = 0;
            //get average of neighbours
            foreach(Node neighbour in neighbours){
                average += neighbour.elevation;        
            } 
            average = average/neighbours.Count;
            //move elevation
            if (average >= elevation ){
                elevation = elevation+(average-elevation)/2;
            }else{
                elevation = elevation-(elevation-average)/2;
            }
        }

        public void draw(Canvas mainCanvas){
            Rectangle temp = new Rectangle
            {
                Stroke = color,
                StrokeThickness = 8
            };
            Canvas.SetLeft(temp, x * 8);
            Canvas.SetTop(temp, y * 8);
            mainCanvas.Children.Add(temp);
        }
    }
}
