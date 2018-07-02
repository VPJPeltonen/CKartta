using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKartta
{
    /*
    * Single node for the map
    * Should hold info on that part of map
    */
    class Node
    {
        public int x;
        public int y;
        public List<Node> neighbours = new List<Node>();

        //constructor
        public Node(int Xcoordinate, int Ycoordinate)
        {
            x = Xcoordinate;
            y = Ycoordinate;
        }

        //set neighbours
        public void SetNeighbours(List<Node> FreeNodes)
        {
            //right
            foreach(Node node in FreeNodes)
            {
                //right
                if (node.x == x+1 && node.y == y)
                {
                    neighbours.Add(node);
                }
                //left
                if (node.x == x-1 && node.y == y)
                {
                    neighbours.Add(node);
                }
                //up
                if (node.x == x && node.y == y-1)
                {
                    neighbours.Add(node);
                }
                //down
                if (node.x == x && node.y == y+1)
                {
                    neighbours.Add(node);
                }
                //stop if all neightbours found
                if (neighbours.Count == 4)
                {
                    break;
                }
            }
        }
    }
}
