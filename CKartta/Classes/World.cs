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
        List<Continent> continents = new List<Continent>(); //continentlist

        //constructor
        public World() { } 
        
        public void WorldInit(short gridSize, int width, int heigth, Random Rnd, Canvas mainCanvas)
        {
            gSize = gridSize;
            wdt = width;
            hgt = heigth;
            //create the grid
            makeGrid(Rnd,mainCanvas);
        }

        public List<Node> GetList()
        {
            List<Node> freeNodes= new List<Node>(worldGrid);
            return freeNodes;
        }

        //create continents
        public List<Continent> createContinents(int amount,List<Node> freeNodes,int GWidth,int GHeight,Random Rnd){
            ColorsStorage temp = new ColorsStorage();
            for(int i = 0; i<amount;i++){
                continents.Add(new Continent(temp.colors[i], freeNodes, GWidth, GHeight,Rnd));
            }
            return continents;
        }

        //find conflict
        public void continentConflicts(){
            foreach(Continent temp in continents){
                temp.conflicts();
                temp.boundaryEffect();
            }
        }
        //random
        public void erode(){
            Random coin = new Random();
            int flip;
            foreach(Node node in worldGrid){
                flip = coin.Next(0,32);
                if (flip == 1){
                    node.elevation += 2;
                }
            }
        }

        //smooth world
        public void Smooth(){
            //erode();
            Queue<Node> highPoints = new Queue<Node>();
            for(int i = 15 ;i > 1;i--){
                foreach(Node node in worldGrid){
                    if(node.elevation == i){highPoints.Enqueue(node);}
                } 
                while(highPoints.Count != 0){
                    Node temp = highPoints.Dequeue();
                    temp.Smooth();
                }
            }
        }

        //-----------------------visual stuff------------------------------------------------
        public void show(string selection){
            //int i is the amount land is either above or below waterlevel
            if (selection == "height"){
                ColorsStorage color = new ColorsStorage();
                foreach(Node node in worldGrid){
                    if (node.elevation >= 5){
                        int i = node.elevation-5;
                        Brush tempColor = color.land[i];
                        node.color = tempColor;
                    }else{
                        int i = Math.Abs(node.elevation-4);
                        Brush tempColor = color.water[i];
                        node.color = tempColor;
                    }
                }
            }else{
                foreach(Continent continent in continents){
                    continent.colorize(selection);
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

        //------------------private funktions---------------------------------------------
        public void makeGrid(Random Rnd, Canvas mainCanvas){
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
    }
}
