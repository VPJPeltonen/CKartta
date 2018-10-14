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
        public Brush continentColor;           //color for just seeing continents
        List<Node> areas = new List<Node>();      //area coordinates list
        List<Node> doneAreas = new List<Node>();  //areas that cant spread anymore
        List<Node> edges = new List<Node>();       //list of edge nodes
        List<int> edgeDir = new List<int>();    //direction edges are moving
        private int X;                          //starting X
        private int Y;                          //starting Y
        private int dir;                        //direction the continent moves

        //constructor
        public Continent(Brush drawColor, List<Node> freeNodes, int hgt, int wdt, Random Rnd)
        {         
            color = drawColor;
            continentColor = color;
            bool startSet = true;
            //get depth of continent
            //depth = Rnd.Next(4, 6);
            dir = Rnd.Next(0, 360);
            while (startSet == true)
            {
                X = Rnd.Next(0,hgt-1);
                Y = Rnd.Next(0,wdt-1);
                int flip = Rnd.Next(0, 6);
                if (flip == 1){depth = 6;}
                else if(flip == 2){depth = 7;}
                else{depth = 2;}
                Node temp = new Node(X, Y);
                //check on the list of not take nodes if the node is free. start from column it most likely is in
                for (int i = X*wdt; i < freeNodes.Count; i++)
                {
                    if (temp.x == freeNodes[i].x && temp.y == freeNodes[i].y){
                        freeNodes[i].elevation += depth; //set the nodes elevation as the same as continents
                        freeNodes[i].continentColor = color;
                        freeNodes[i].dir = dir;
                        areas.Add(freeNodes[i]);
                        freeNodes[i].elevation = depth;
                        freeNodes.Remove(freeNodes[i]);
                        startSet = false;
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
                    List<Node> tempNeighbours = new List<Node>(spot.neighbours);
                    foreach (Node neighbour in tempNeighbours)
                    {                        
                        if (freeNodes.Contains(neighbour))
                        {
                            areas.Add(neighbour);
                            freeNodes.Remove(neighbour);
                            neighbour.elevation = depth; //set the nodes elevation as the same as continents
                            neighbour.continentColor = color;
                        } 
                    }
                    doneAreas.Add(spot);
                    areas.Remove(spot);
                }
            }
        }

        //combine area lists
        public void finishList(){
            foreach(Node area in areas){doneAreas.Add(area);}
            areas = null;
        }

        //find conflict
        public void conflicts(){
            foreach (Node node in doneAreas)
            {
                if(node.isConflict()){
                    edges.Add(node);
                    edgeDir.Add(node.conflictContinent());
                }
            }
        }

        //compare stuff
        public void boundaryEffect(){
            Random coin = new Random();
            for(int i= 0; i < edges.Count();i++){
                Node node = edges[i]; 
                //what part of edge it is 1 means up, 2 means right, -1 means left and -2 means down
                int edgeDirection = nodeDirection(node);
                int conDir = conDirection(dir);
                int neighbourDirection = conDirection(edgeDir[i]);

                //if directions are opposite(if same x/y scale && not same direction)
                if(Math.Abs(conDir) == Math.Abs(neighbourDirection) && neighbourDirection != conDir){
                    //if continents are crashing
                    if(edgeDirection == conDir){
                        node.elevation += 5;
                    }
                    //if continents are moving away from eachother
                    else{
                        node.elevation -= 3;
                    }                    
                }else{                    if(Math.Abs(conDir) == Math.Abs(neighbourDirection)){
                        int flip = coin.Next(0,16);
                        if (flip == 1){
                            if (node.elevation == 2){node.elevation += 3;}
                            else{node.elevation += 2;}
                        }                        
                    }
                }
            }
        }

        //-----------------------visual stuff-----------------------------
        public void colorize(){                                   
            foreach(Node node in edges){
                node.visual.Stroke = Brushes.Red;
            }          
        } 

        //------------------private functions---------------------- 
        private int nodeDirection(Node node){
            int xDif = X-node.x;
            int yDif = Y-node.y;
            //if horizontal difference is larger than vertical
            if (Math.Abs(xDif) >= Math.Abs(yDif)){
                if(node.x > X){ return 2; }//right
                else{return -2;}//left
            }else{
                if (node.y > Y){return -1; }//down
                else {return 1;}//up
            }                
        }

        private int conDirection(int dir){
            if(dir <= 45 || dir >= 315){
                return 1;//up
            }
            else if(dir > 45 && dir < 135){
                return 2;//right
            }
            else if(dir > 135 && dir < 225){
                return -1;//down
            }                           
            else{
                return -2;//left
            }
        }
    }
}
