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
        public List<Brush> colors = new List<Brush>();
        public List<Brush> land = new List<Brush>();
        public List<Brush> water = new List<Brush>();
        public Brush deepWater = new SolidColorBrush(Color.FromArgb(0xff, 0x45, 0x4f, 0xff));
        public Brush lowWater = new SolidColorBrush(Color.FromArgb(0xff, 0xa5, 0xde, 0xff)); //a5deff
        public Brush lowLand = new SolidColorBrush(Color.FromArgb(0xff, 0x31, 0xa1, 0x37)); //31a137
        public Brush midLand = new SolidColorBrush(Color.FromArgb(0xff, 0xbd, 0xa5, 0x21)); //bda521
        public Brush highLand = new SolidColorBrush(Color.FromArgb(0xff, 0x99, 0x6e, 0x06)); //996e06

        public ColorsStorage()
        {            
            colors.Add(Brushes.Blue);
            colors.Add(Brushes.Red);
            colors.Add(Brushes.Green);
            colors.Add(Brushes.Yellow);
            colors.Add(Brushes.Orange);
            //alpha rpg
            colors.Add(new SolidColorBrush(Color.FromArgb(0xff, 0x1f, 0xf2, 0x90)));
            colors.Add(Brushes.Purple);
            colors.Add(Brushes.Black);
            colors.Add(Brushes.Aqua);
            colors.Add(Brushes.Salmon);
            colors.Add(Brushes.DeepSkyBlue);
            colors.Add(Brushes.Brown);

            //ground
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

            //water
            water.Add(new SolidColorBrush(Color.FromArgb(0xff, 0xf1, 0xee, 0xf6)));//#f1eef6
            water.Add(new SolidColorBrush(Color.FromArgb(0xff, 0xbd, 0xc9, 0xe1)));//#bdc9e1
            water.Add(new SolidColorBrush(Color.FromArgb(0xff, 0x74, 0xa9, 0xcf)));//#74a9cf
            water.Add(new SolidColorBrush(Color.FromArgb(0xff, 0x05, 0x70, 0xb0)));//#0570b0
        }
    }
}
