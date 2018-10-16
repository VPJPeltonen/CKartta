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
        public sbyte rainfall = 0;
        public string climate = "";
        public Brush color;
        public Brush heightColor;
        public Brush continentColor;
        public Brush temperatureColor;
        public Brush rainfallColor;
        public Brush enviromentColor;
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
                case "enviroment":
                    visual.Stroke = enviromentColor;
                    break;
                case "rainfall":
                    visual.Stroke = rainfallColor;
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
        public void HeightAdjust()
        {
            if (elevation >= 7)
            {
                temperature -= (sbyte)(elevation - 6);
                if (temperature < 0) { temperature = 0; }
            }
        }

        //mountainside rains
        public void Mountainsides()
        {
            if (elevation >= 7)
            {
                foreach (Node neighbour in neighbours)
                {
                    if (elevation != neighbour.elevation)
                    {
                        neighbour.rainfall += 1;
                    }
                }
            }
        }

        //set climate base on rainfall and temperature
        public void SetClimate(ColorsStorage color)
        {
            switch (rainfall)
            {
                case 0:
                    switch (temperature) {                     
                        case 0: climate = "Polar Desert"; break;
                        case 1: climate = "Polar Desert"; break;
                        case 2: climate = "Cool Desert"; break;
                        case 3: climate = "Cool Desert"; break;
                        case 4: climate = "Extreme Desert"; break;
                        case 5: climate = "Extreme Desert"; break;
                        case 6: climate = "Extreme Desert"; break;
                    } break;
                case 1: 
                    switch (temperature)
                    {
                        case 0: climate = "Polar Desert"; break;
                        case 1: climate = "Polar Desert"; break;
                        case 2: climate = "Cool Desert"; break;
                        case 3: climate = "Cool Desert"; break;
                        case 4: climate = "Desert"; break;
                        case 5: climate = "Desert"; break;
                        case 6: climate = "Desert"; break;
                    }
                    break;
                case 2: 
                    switch (temperature)
                    {
                        case 0: climate = "Polar Desert"; break;
                        case 1: climate = "Polar Desert"; break;
                        case 2: climate = "Steppe"; break;
                        case 3: climate = "Steppe"; break;
                        case 4: climate = "Subtropical Scrub"; break;
                        case 5: climate = "Subtropical Scrub"; break;
                        case 6: climate = "Tropical Scrub"; break;
                    }
                    break;
                case 3: 
                    switch (temperature)
                    {
                        case 0: climate = "Ice Cap"; break;
                        case 1: climate = "Tundra"; break;
                        case 2: climate = "Boreal Forest"; break;
                        case 3: climate = "Temperate Woodlands"; break;
                        case 4: climate = "Subtropical Woodlands"; break;
                        case 5: climate = "Subtropical Woodlands"; break;
                        case 6: climate = "Tropical Woodlands"; break;
                    }
                    break;
                case 4: 
                    switch (temperature)
                    {
                        case 0: climate = "Ice Cap"; break;
                        case 1: climate = "Tundra"; break;
                        case 2: climate = "Boreal Forest"; break;
                        case 3: climate = "Temperate Woodlands"; break;
                        case 4: climate = "Mediterranean"; break;
                        case 5: climate = "Subtropical Dry Forest"; break;
                        case 6: climate = "Tropical Dry Forest"; break;
                    }
                    break;
                case 5: 
                    switch (temperature)
                    {
                        case 0: climate = "Ice Cap"; break;
                        case 1: climate = "Wet Tundra"; break;
                        case 2: climate = "Boreal Forest"; break;
                        case 3: climate = "Temperate Forest"; break;
                        case 4: climate = "Temperate Forest"; break;
                        case 5: climate = "Subtropical Forest"; break;
                        case 6: climate = "Tropical Wet Forest"; break;
                    }
                    break;
                case 6: 
                    switch (temperature)
                    {
                        case 0: climate = "Ice Cap"; break;
                        case 1: climate = "Wet Tundra"; break;
                        case 2: climate = "Boreal Forest"; break;
                        case 3: climate = "Temperate Wet Forest"; break;
                        case 4: climate = "Temperate Wet Forest"; break;
                        case 5: climate = "Subtropical Wet Forest"; break;
                        case 6: climate = "Tropical Wet Forest"; break;
                    }
                    break;
                case 7: 
                    switch (temperature)
                    {
                        case 0: climate = "Ice Cap"; break;
                        case 1: climate = "Polar Wetlands"; break;
                        case 2: climate = "Polar Wetlands"; break;
                        case 3: climate = "Temperate Wetlands"; break;
                        case 4: climate = "Temperate Wetlands"; break;
                        case 5: climate = "Subtropical Wetlands"; break;
                        case 6: climate = "Tropical Wetlands"; break;
                    }
                    break;
            }
            enviromentColor = color.ClimateColor(climate);
        }

        //adjust height so there isnt too great differences between neighbours
        public void SmoothElevation()
        {
            foreach (Node neighbour in neighbours)
            {
                if (neighbour.elevation < elevation){neighbour.elevation = elevation - 1;}
            }
        }

        //adjust temperature
        public void SmoothRainfall()
        {
            foreach (Node neighbour in neighbours)
            {
                if (neighbour.rainfall < rainfall) { neighbour.rainfall = (sbyte)(rainfall - 1); }
            }
        }

        //adjust temperature
        public void SmoothTemperature()
        {
            foreach (Node neighbour in neighbours)
            {
                if (neighbour.temperature < temperature) { neighbour.temperature = (sbyte)(temperature - 1); }
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
