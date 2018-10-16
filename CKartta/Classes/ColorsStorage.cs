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
        public List<Brush> rainfall = new List<Brush>(); //colors for rainfall
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

            //rainfall 8
            rainfall.Add(new SolidColorBrush(Color.FromArgb(0xff, 0x8c, 0x51, 0x0a)));//#8c510a
            rainfall.Add(new SolidColorBrush(Color.FromArgb(0xff, 0xbf, 0x81, 0x2d)));//# bf812d
            rainfall.Add(new SolidColorBrush(Color.FromArgb(0xff, 0xdf, 0xc2, 0x7d)));//# dfc27d
            rainfall.Add(new SolidColorBrush(Color.FromArgb(0xff, 0xf6, 0xe8, 0xc3)));//# f6e8c3
            rainfall.Add(new SolidColorBrush(Color.FromArgb(0xff, 0xc7, 0xea, 0xa5)));//# c7eae5
            rainfall.Add(new SolidColorBrush(Color.FromArgb(0xff, 0x80, 0xcd, 0xc1)));//#80cdc1
            rainfall.Add(new SolidColorBrush(Color.FromArgb(0xff, 0x35, 0x97, 0x8f)));//#35978f
            rainfall.Add(new SolidColorBrush(Color.FromArgb(0xff, 0x01, 0x66, 0x5e)));//#01665e
        }

        public Brush ClimateColor(string climate)
        {
            switch (climate)
            {
                case "Polar Desert":            return new SolidColorBrush(Color.FromArgb(0xff, 0x5a, 0x5a, 0x5a));  //5a5a5a
                case "Ice Cap":                 return new SolidColorBrush(Color.FromArgb(0xff, 0xff, 0xff, 0xff));  //ffffff
                case "Tundra":                  return new SolidColorBrush(Color.FromArgb(0xff, 0xbf, 0xbf, 0xbf));  //bfbfbf
                case "Wet Tundra":              return new SolidColorBrush(Color.FromArgb(0xff, 0xcc, 0xc0, 0xda));  //ccc0da
                case "Polar Wetlands":          return new SolidColorBrush(Color.FromArgb(0xff, 0x60, 0x49, 0x7b));  //60497b
                case "Cool Desert":             return new SolidColorBrush(Color.FromArgb(0xff, 0x95, 0x57, 0x35));  //953735
                case "Steppe":                  return new SolidColorBrush(Color.FromArgb(0xff, 0x94, 0x8b, 0x54));  //948b54
                case "Boreal Forest":           return new SolidColorBrush(Color.FromArgb(0xff, 0x9d, 0xb1, 0x95));  //9db195
                case "Temperate Woodlands":      return new SolidColorBrush(Color.FromArgb(0xff, 0xf2, 0xdd, 0xdc));  //f2dddc
                case "Temperate Forest":        return new SolidColorBrush(Color.FromArgb(0xff, 0xdb, 0xee, 0xf3));  //dbeef3
                case "Temperate Wet Forest":    return new SolidColorBrush(Color.FromArgb(0xff, 0x93, 0xcd, 0xdd));  //93cddd
                case "Temperate Wetlands":      return new SolidColorBrush(Color.FromArgb(0xff, 0x31, 0x84, 0x9b));  //31849b
                case "Extreme Desert":          return new SolidColorBrush(Color.FromArgb(0xff, 0xff, 0x50, 0x50));  //ff5050
                case "Desert":                  return new SolidColorBrush(Color.FromArgb(0xff, 0xff, 0x99, 0x00));  //ff9900
                case "Subtropical Scrub":       return new SolidColorBrush(Color.FromArgb(0xff, 0xcc, 0xcc, 0x00));  //cccc00
                case "Subtropical Woodlands":    return new SolidColorBrush(Color.FromArgb(0xff, 0xfc, 0xd5, 0xb4));  //fcd5b4
                case "Mediterranean":           return new SolidColorBrush(Color.FromArgb(0xff, 0xd9, 0x97, 0x95));  //d99795
                case "Subtropical Dry Forest":  return new SolidColorBrush(Color.FromArgb(0xff, 0xd7, 0xe4, 0xbc));  //d7e4bc
                case "Subtropical Forest":      return new SolidColorBrush(Color.FromArgb(0xff, 0x66, 0xff, 0x66));  //66ff66
                case "Subtropical Wet Forest":  return new SolidColorBrush(Color.FromArgb(0xff, 0x00, 0xb0, 0x50));  //00b050   
                case "Subtropical Wetlands":    return new SolidColorBrush(Color.FromArgb(0xff, 0x00, 0x82, 0x3b));  //00823b
                case "Tropical Scrub":          return new SolidColorBrush(Color.FromArgb(0xff, 0xff, 0xff, 0x00));  //ffff00
                case "Tropical Woodlands":      return new SolidColorBrush(Color.FromArgb(0xff, 0xff, 0xfb, 0xc1));  //fffbc1
                case "Tropical Dry Forest":     return new SolidColorBrush(Color.FromArgb(0xff, 0xcc, 0xff, 0x33));  //ccff33
                case "Tropical Wet Forest":     return new SolidColorBrush(Color.FromArgb(0xff, 0x75, 0x92, 0x3c));  //75923c
                case "Tropical Wetlands":       return new SolidColorBrush(Color.FromArgb(0xff, 0x4f, 0x62, 0x28));  //4f6228
                default:                        return new SolidColorBrush(Color.FromArgb(0x00, 0x00, 0x00, 0x00));  //
            }
        }
    }
}
