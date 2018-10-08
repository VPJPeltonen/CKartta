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
        List<List<Node>> nodeGrid = new List<List<Node>>(); //new list of lists for grid
        List<Node> conConflicts = new List<Node>(); //list of conflict zones

        //constructor
        public World() { } 
        
        public void WorldInit(short gridSize, int width, int heigth, Random Rnd, Canvas mainCanvas)
        {
            gSize = gridSize;
            wdt = width;
            hgt = heigth;
            //create the grid
            for (int i = 0; i < wdt; i++)
            {                
                List<Node> tempList = new List<Node>();
                for(int j = 0; j < hgt; j++)
                {
                    int depth = Rnd.Next(0,2);
                    Node temp = new Node(i, j, depth, mainCanvas);
                    worldGrid.Add(temp);
                    tempList.Add(temp);
                }
                nodeGrid.Add(tempList);
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

        //show conflicts
        public void ShowConflict(){
            foreach(Node con in conConflicts){
                con.color = Brushes.Red;
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

        //find conflict
        public void continentConflicts(){
            int tempX,tempY;
            foreach (Node node in worldGrid)
            {
                if(node.isConflict()){
                    conConflicts.Add(node);
                }
            }
        }
    }
}
