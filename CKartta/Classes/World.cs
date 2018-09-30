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

        //Set the waterlevels of the world
        public void WaterLevels(List<Object> continents)
        {
            foreach(Continent cont in continents){
                cont.waterlevel();
            }
        }

        //show continents
        public void ShowContinents(List<Object> continents){
            foreach(Continent continent in continents){
                continent.continentColors();
            }
        }

        //smooth world
        public void Smooth(int smoothTime){
            for (int i = 0; i <= smoothTime; i++){
                foreach(Node node in worldGrid){
                    node.Smooth();
                } 
            }
        } 

        //draw the nodes
        public void DrawWorld(Canvas mainCanvas)
        {
            foreach (Node node in worldGrid)
            {
                node.draw(mainCanvas);
            }
        }

    }
}
