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
        public List<Brush> colors = new List<Brush>();
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
        }
    }
}
