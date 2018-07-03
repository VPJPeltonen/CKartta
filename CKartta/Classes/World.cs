using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CKartta
{
    /*
     * Holds info of the world
    */
    class World
    {
        private short gSize;    //size of squares
        private int wdt;        //width of map in squares
        private int hgt;        //height of the map in squares
        List<Node> worldGrid = new List<Node>();

        //constructor
        public World() { } 
        
        public void WorldInit(short gridSize, int width, int heigth, Random Rnd)
        {
            gSize = gridSize;
            wdt = width;
            hgt = heigth;
            //create the grid
            for (int i = 0; i < wdt; i++)
            {                
                for(int j = 0; j < hgt; j++)
                {
                    int depth = Rnd.Next(0,2);
                    Node temp = new Node(i, j, depth);
                    worldGrid.Add(temp);
                }
            }
        }

        public List<Node> GetList()
        {
            List<Node> freeNodes= new List<Node>(worldGrid);
            return freeNodes;
        }

        public void WaterLevels(List<Object> continents)
        {
            int averageLevel = 0;
            foreach (Node node in worldGrid) { averageLevel += node.elevation; }
            averageLevel = averageLevel / worldGrid.Count;
            foreach (Node node in worldGrid)
            {
                if (node.elevation <= averageLevel) { node.color = Brushes.Blue; }
                else { node.color = Brushes.Green; }
            }
        }

        //draw the nodes
        public void DrawWorld(Canvas mainCanvas)
        {
            foreach (Node node in worldGrid)
            {
                Rectangle temp = new Rectangle
                {
                    Stroke = node.color,
                    StrokeThickness = 8
                };
                Canvas.SetLeft(temp, node.x * 8);
                Canvas.SetTop(temp, node.y * 8);
                mainCanvas.Children.Add(temp);
            }
        }

    }
}
