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
        List<Node> sea = new List<Node>();
        List<Node> land = new List<Node>();

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
        public List<Continent> createContinents(int amount,List<Node> freeNodes,int GWidth,int GHeight,Random Rnd,ColorsStorage temp){
            for(int i = 0; i<amount;i++){
                continents.Add(new Continent(temp.colors[i], freeNodes, GWidth, GHeight,Rnd));
            }
            return continents;
        }

        //generate nature
        public void formWorld(ColorsStorage color){
            continentConflicts();
            setElevations(color);
            setTemperature(color);
            SetRainfall(color);
            SetClimate(color);
        }


        //-----------------------visual stuff------------------------------------------------
        public void show(string selection){
            //int i is the amount land is either above or below waterlevel
            switch(selection){
                case "continents":
                    foreach(Node node in worldGrid){node.setColor("continent");}
                    break;
                case "edges":
                    foreach(Continent continent in continents){continent.colorize();}
                    break;
                case "elevation":
                    foreach(Node node in worldGrid){node.setColor("elevation");}
                    break;
                case "enviroment":
                    foreach (Node node in worldGrid) { node.setColor("enviroment"); }
                    break;
                case "rainfall":
                    foreach(Node node in worldGrid) { node.setColor("rainfall"); }
                    break;
                case "temperature":
                    foreach(Node node in worldGrid){node.setColor("temperature");}
                    break;
            }
        }       

        //------------------private funktions---------------------------------------------
        //find conflict
        private void continentConflicts(){
            foreach(Continent temp in continents){
                temp.conflicts();
                temp.boundaryEffect();
            }
        }

        public void makeGrid(Random Rnd, Canvas mainCanvas)
        {
            /*
             * nodegrid[width units][height units]
             */
            for (int i = 0; i <= wdt; i++)
            {
                List<Node> tempList = new List<Node>();
                for (int j = 0; j <= hgt; j++)
                {
                    Node temp = new Node(i, j, mainCanvas);
                    worldGrid.Add(temp);
                    tempList.Add(temp);
                }
                nodeGrid.Add(tempList);
            }
            foreach(Node node in worldGrid) { node.SetNeighbours(nodeGrid,wdt,hgt); }
        }

        //set climate
        private void SetClimate(ColorsStorage color)
        {
            foreach(Node node in land) { node.SetClimate(color); }
            foreach(Node node in sea) {
                if (node.temperature == 0 && node.rainfall >= 3) { node.enviromentColor = color.ClimateColor("Ice Cap"); }
                else { node.enviromentColor = color.clear; }
            }
        }

        //finish elevation
        private void setElevations(ColorsStorage color){
            Smooth();
            foreach(Node node in worldGrid){
                if (node.elevation >= 5){
                    int i = node.elevation-5;
                    Brush tempColor = color.land[i];
                    node.heightColor = tempColor;
                    land.Add(node);
                }else{
                    int i = Math.Abs(node.elevation-4);
                    Brush tempColor = color.water[i];
                    node.heightColor = tempColor;
                    sea.Add(node);
                }
            }
        }

        private void SetRainfall(ColorsStorage color)
        {
            //coast tiles
            foreach(Node node in sea) {
                foreach(Node neighbour in node.neighbours)
                {
                    if (neighbour.elevation >= 5) { neighbour.rainfall += 1; }
                }
            }
            //tropics
            int slice = hgt / 13;
            for (int i = 0; i <wdt;i++) {
                for (int j = slice * 6; j < slice * 7; j++) { nodeGrid[i][j].rainfall += 4; }
            }
            //mountainsides
            foreach (Node node in land) { node.Mountainsides(); }
            //even it out
            Queue<Node> highPoints = new Queue<Node>();
            for (int i = 8; i > 0; i--)
            {
                foreach (Node node in worldGrid)
                {
                    if (node.rainfall == i) { highPoints.Enqueue(node); }
                }
                while (highPoints.Count != 0)
                {
                    Node temp = highPoints.Dequeue();
                    temp.SmoothRainfall();
                }
            }
            //color it all
            foreach (Node node in sea) { node.temperatureColor = color.clear; }
            foreach (Node node in land) {
                if (node.rainfall >= 8) { node.rainfall = 7; }
                node.rainfallColor = color.rainfall[node.rainfall];
            }
        }

        //set temperatures
        private void setTemperature(ColorsStorage color){
            int slice = hgt/13;
            for(int i = 0; i < wdt; i++){
                int j = 0;
                for (; j < slice;j++){nodeGrid[i][j].temperature = 0;}              
                for (; j < slice*2;j++){nodeGrid[i][j].temperature = 1; }
                for (; j < slice*3;j++){nodeGrid[i][j].temperature = 2; }
                for (; j < slice*4;j++){nodeGrid[i][j].temperature = 3; }
                for (; j < slice*5;j++){nodeGrid[i][j].temperature = 4; }
                for (; j < slice*6;j++){nodeGrid[i][j].temperature = 5; }
                for (; j < slice*7;j++){nodeGrid[i][j].temperature = 6; }
                for (; j < slice*8;j++){nodeGrid[i][j].temperature = 5; }
                for (; j < slice*9;j++){nodeGrid[i][j].temperature = 4; }
                for (; j < slice*10;j++){nodeGrid[i][j].temperature = 3; }
                for (; j < slice*11;j++){nodeGrid[i][j].temperature = 2; }
                for (; j < slice*12;j++){nodeGrid[i][j].temperature = 1; }
                for (; j < hgt;j++){nodeGrid[i][j].temperature = 0; }
            }
            foreach (Node node in land) { node.HeightAdjust(); }
            //smooth temperature differences
            Queue<Node> highPoints = new Queue<Node>();
            for (int i = 8; i > 0; i--)
            {
                foreach (Node node in worldGrid)
                {
                    if (node.temperature == i) { highPoints.Enqueue(node); }
                }
                while (highPoints.Count != 0)
                {
                    Node temp = highPoints.Dequeue();
                    temp.SmoothTemperature();
                }
            }
            foreach (Node node in land) { node.temperatureColor = color.temperature[node.temperature]; }
            foreach (Node node in sea) { node.temperatureColor = color.clear; }
        }

        //smooth world
        private void Smooth()
        {
            Queue<Node> highPoints = new Queue<Node>();
            for (int i = 15; i > 1; i--)
            {
                foreach (Node node in worldGrid)
                {
                    if (node.elevation == i) { highPoints.Enqueue(node); }
                }
                while (highPoints.Count != 0)
                {
                    Node temp = highPoints.Dequeue();
                    temp.SmoothElevation();
                }
            }
        }
    }
}