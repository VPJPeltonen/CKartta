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
        public int elevation = 0;                               //how much elevation does the spot have
        public Brush color;
        public Brush heightColor;
        public Brush continentColor;
        public int dir;
        public Rectangle visual = new Rectangle{
            Stroke = Brushes.Red,
            StrokeThickness = 8
        };

        //-----------constructor-------------------------------------------------
        public Node(int Xcoordinate, int Ycoordinate, int depth, Canvas mainCanvas)
        {
            x = Xcoordinate;
            y = Ycoordinate;
            elevation = depth;
            makeRectangle(mainCanvas);
        }

        //constructor for making a temporary node 
        public Node(int Xcoordinate, int Ycoordinate)
        {
            x = Xcoordinate;
            y = Ycoordinate;
        }

        //----------funktions--------------------------------------------------
        //set neighbours
        public void SetNeighbours(List<Node> FreeNodes,int width,int height)
        {
            int nAmount = 8;
            if (x == 0){nAmount -= 1;}//check left
            if (x == width){nAmount -= 1;}//check right
            if (y == 0){nAmount -= 1;}//check top
            if (y == height){nAmount -= 1;}//check bottom
            foreach(Node node in FreeNodes)
            {                
                if (node.x == x+1 && node.y == y){neighbours.Add(node);}//right              
                if (node.x == x-1 && node.y == y){neighbours.Add(node);}//left               
                if (node.x == x && node.y == y-1){neighbours.Add(node);}//up                
                if (node.x == x && node.y == y+1){neighbours.Add(node);}//down
                //corners                
                if (node.x == x-1 && node.y == y-1){neighbours.Add(node);}//topleft                
                if (node.x == x+1 && node.y == y-1){neighbours.Add(node);}//topright                
                if (node.x == x-1 && node.y == y+1){neighbours.Add(node);}//bottomleft                
                if (node.x == x+1 && node.y == y+1){neighbours.Add(node);}//bottomright
                //stop if all neightbours found
                if (neighbours.Count == nAmount){break;}
            }
        }

        //adjust height so there isnt too great differences between neighbours
        public void Smooth(){
            foreach(Node neighbour in neighbours){
                if (neighbour.elevation < elevation){
                    neighbour.elevation = elevation-1;
                }
            }
        }

        //set color of of the window
        public void setColor(string selection){
            switch(selection){
                case "continent":
                    visual.Stroke = continentColor;
                    break;
                case "elevation":
                    visual.Stroke = heightColor;
                    break;
            }
        }

        //checks if node is on border of continents
        public bool isConflict(){
            foreach(Node neighbour in neighbours){
                if (neighbour.continentColor != continentColor){
                    return true;
                } 
            }
            return false;
        }
        
        //find out what direction the nearby continent is going
        public int conflictContinent(){
            foreach(Node neighbour in neighbours){
                if (neighbour.continentColor != continentColor){
                    return neighbour.dir;
                }
            }
            return 0;
        }
        //-------------------------------private funktions--------------------
        //make rectangle
        private void makeRectangle(Canvas mainCanvas){
            //create link
            Canvas.SetLeft(visual, x * 8);
            Canvas.SetTop(visual, y * 8);
            mainCanvas.Children.Add(visual);
        }
    }
}
