using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CKartta
{
    public struct Crd
    {
        public short x;
        public short y;
        public Crd(short XCoordinate, short YCoordinate)
        {
            x = XCoordinate;
            y = YCoordinate;
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //some colors
        public string blue = "#0000ff";
        public string red = "#ff0000";
        public string green = "#00ff00";
        public string aqua = "#00ffff";
        public string orange = "#ffff00";
        public string purple = "#ff00ff";

        public MainWindow()
        {
            InitializeComponent();

            //create a world
            World mWorld = new World(8,100,75);

            //create continents
            Continent cA = new Continent("A", blue);
            Continent cB = new Continent("B", red);
            Continent cC = new Continent("C", green);
            Continent cD = new Continent("D", aqua);
            Continent cE = new Continent("E", orange);
            Continent cF = new Continent("F", purple);
        }
    }
}
