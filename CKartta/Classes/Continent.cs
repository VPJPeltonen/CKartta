using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKartta
{
    /*
     * Continental plate info
     */ 
    class Continent
    {
        private string name;    //name of the continent
        private string color;   //color the continent will be on screen

        public Continent(string continentName, string drawColor)
        {
            name = continentName;
            color = drawColor;
        }
    }
}
