using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CKartta
{
    class ColorsStorage
    {
        //height
        public List<Brush> colors = new List<Brush>(); //colors for continents
        public List<Brush> land = new List<Brush>(); //colors for land elevation
        public List<Brush> water = new List<Brush>(); //colors for sea elevation
        public List<Brush> temperature = new List<Brush>(); //colors for temperatures
        public SolidColorBrush clear = new SolidColorBrush(Color.FromArgb(0x00, 0x1f, 0xf2, 0x90));

        public ColorsStorage()
        {        
            //continents
            colors.Add(Brushes.Blue);
            colors.Add(Brushes.Red);
            colors.Add(Brushes.Green);
            colors.Add(Brushes.Yellow);
            colors.Add(Brushes.Orange);            
            colors.Add(new SolidColorBrush(Color.FromArgb(0xff, 0x1f, 0xf2, 0x90)));
            colors.Add(Brushes.Purple);
            colors.Add(Brushes.Black);
            colors.Add(Brushes.Aqua);
            colors.Add(Brushes.Salmon);
            colors.Add(Brushes.DeepSkyBlue);
            colors.Add(Brushes.Brown);

            //ground format = alpha rpg
            land.Add(new SolidColorBrush(Color.FromArgb(0xff, 0x23, 0x84, 0x43)));//#238443
            land.Add(new SolidColorBrush(Color.FromArgb(0xff, 0x78, 0xc6, 0x79)));//#78c679
            land.Add(new SolidColorBrush(Color.FromArgb(0xff, 0xc2, 0xe6, 0x99)));//#c2e699
            land.Add(new SolidColorBrush(Color.FromArgb(0xff, 0xff, 0xff, 0xcc)));//#ffffcc
            land.Add(new SolidColorBrush(Color.FromArgb(0xff, 0xfe, 0xd9, 0x8e)));//#fed98e
            land.Add(new SolidColorBrush(Color.FromArgb(0xff, 0xfe, 0x99, 0x29)));//#fe9929
            land.Add(new SolidColorBrush(Color.FromArgb(0xff, 0xd9, 0x5f, 0x0e)));//#d95f0e
            land.Add(new SolidColorBrush(Color.FromArgb(0xff, 0x99, 0x34, 0x04)));//#993404
            land.Add(new SolidColorBrush(Color.FromArgb(0xff, 0x96, 0x96, 0x96)));//#969696
            land.Add(new SolidColorBrush(Color.FromArgb(0xff, 0xcc, 0xcc, 0xcc)));//cccccc

            //water 4,3,2,1,0,-1
            water.Add(new SolidColorBrush(Color.FromArgb(0xff, 0xef, 0xf3, 0xff)));//#eff3ff
            water.Add(new SolidColorBrush(Color.FromArgb(0xff, 0xc6, 0xdb, 0xef)));//#c6dbef
            water.Add(new SolidColorBrush(Color.FromArgb(0xff, 0x9e, 0xca, 0xe1)));//#9ecae1
            water.Add(new SolidColorBrush(Color.FromArgb(0xff, 0x6b, 0xae, 0xd6)));//#6baed6
            water.Add(new SolidColorBrush(Color.FromArgb(0xff, 0x31, 0x82, 0xbd)));//#3182bd
            water.Add(new SolidColorBrush(Color.FromArgb(0xff, 0x08, 0x51, 0x9c)));//#08519c

            //temperatures 7
            temperature.Add(new SolidColorBrush(Color.FromArgb(0xff, 0x45, 0x75, 0xb4)));//#4575b4
            temperature.Add(new SolidColorBrush(Color.FromArgb(0xff, 0x91, 0xbf, 0xdb)));//#91bfdb
            temperature.Add(new SolidColorBrush(Color.FromArgb(0xff, 0xe0, 0xf3, 0xf8)));//#e0f3f8
            temperature.Add(new SolidColorBrush(Color.FromArgb(0xff, 0xff, 0xff, 0xbf)));//#ffffbf
            temperature.Add(new SolidColorBrush(Color.FromArgb(0xff, 0xfe, 0xe0, 0x90)));//#fee090
            temperature.Add(new SolidColorBrush(Color.FromArgb(0xff, 0xfc, 0x8d, 0x59)));//#fc8d59
            temperature.Add(new SolidColorBrush(Color.FromArgb(0xff, 0xd7, 0x30, 0x27)));//#d73027 0xd7, 0x30, 0x27
        }
    }
}
