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
        public int elevation = 0;                           //how much elevation does the spot have
        public sbyte temperature = 0;
        public Brush color;
        public Brush heightColor;
        public Brush continentColor;
        public Brush temperatureColor;
        public int dir;
        public Rectangle visual = new Rectangle{
            Stroke = Brushes.Red,
            StrokeThickness = 8
        };

        //-----------constructor-------------------------------------------------
        public Node(int Xcoordinate, int Ycoordinate, Canvas mainCanvas)
        {
            x = Xcoordinate;
            y = Ycoordinate;
            makeRectangle(mainCanvas);
        }

        //constructor for making a temporary node 
        public Node(int Xcoordinate, int Ycoordinate)
        {
            x = Xcoordinate;
            y = Ycoordinate;
        }

        //----------funktions--------------------------------------------------

        //find out what direction the nearby continent is going
        public int conflictContinent()
        {
            foreach (Node neighbour in neighbours)
            {
                if (neighbour.continentColor != continentColor)
                {
                    return neighbour.dir;
                }
            }
            return 0;
        }

        //checks if node is on border of continents
        public bool isConflict()
        {
            foreach (Node neighbour in neighbours)
            {
                if (neighbour.continentColor != continentColor)
                {
                    return true;
                }
            }
            return false;
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
                case "temperature":
                    visual.Stroke = temperatureColor;
                    break;
            }
        }

        //set neighbours
        public void SetNeighbours(List<List<Node>> FreeNodes, int width, int height)
        {
            //unless is left row
            if (x != 0) { neighbours.Add(FreeNodes[x-1][y]); }
            //unless top row
            if (y != 0) { neighbours.Add(FreeNodes[x][y-1]); }
            //unless right row
            if (x != width) { neighbours.Add(FreeNodes[x+1][y]); }
            //unless bottom row
            if (y != height) { neighbours.Add(FreeNodes[x][y+1]); }
            //topleft
            if (!(x == 0 || y == 0)) { neighbours.Add(FreeNodes[x-1][y-1]); }
            //topright   
            if (!(x == width || y == 0)) { neighbours.Add(FreeNodes[x + 1][y - 1]); }
            //bottomleft     
            if (!(x == 0 || y == height)) { neighbours.Add(FreeNodes[x - 1][y + 1]); }
            //bottomright
            if (!(x == width || y == height)) { neighbours.Add(FreeNodes[x + 1][y + 1]); }
        }

        //temperature setting
        public void setTemperature(sbyte temp, ColorsStorage color)
        {
            temperature = temp;
            temperatureColor = color.temperature[temp];
            if (elevation >= 7)
            {
                temperature -= (sbyte)(elevation - 6);
                if (temperature < 0) { temperature = 0; }
            }
            temperatureColor = color.temperature[temperature];
        }

        //adjust height so there isnt too great differences between neighbours
        public void Smooth()
        {
            foreach (Node neighbour in neighbours)
            {
                if (neighbour.elevation < elevation)
                {
                    neighbour.elevation = elevation - 1;
                }
            }
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
