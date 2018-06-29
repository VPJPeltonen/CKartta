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

        public int GWidth = 100;
        public int GHeight = 75;

        public MainWindow()
        {
            InitializeComponent();

            //create a world
            World mWorld = new World(8, GWidth, GHeight);

            //get list of grid places
            List<Crd> freelist = mWorld.GetList();

            //create continents
            List<object> continents = new List<object>(); //continentlist
            continents.Add(new Continent("A", "#0000ff", freelist, GWidth, GHeight));
            continents.Add(new Continent("B", red, freelist, GWidth, GHeight));
            continents.Add(new Continent("C", green, freelist, GWidth, GHeight));
            continents.Add(new Continent("D", aqua, freelist, GWidth, GHeight));
            continents.Add(new Continent("E", orange, freelist, GWidth, GHeight));
            continents.Add(new Continent("F", purple, freelist, GWidth, GHeight));

            //grid stuff
            Grid mapGrid = new Grid();
            int[] scores = new int[10];

            // Define the Columns
            for (int i = 0; i < GWidth; ++i)
                mapGrid.ColumnDefinitions.Add(new ColumnDefinition());

            // Define the Rows
            for (int i = 0; i < GHeight; ++i)
                mapGrid.RowDefinitions.Add(new RowDefinition());

            main.Content = mapGrid;

            //draw all continents
            foreach (Continent continent in continents)
            {
                continent.drawSelf(mapGrid);
            }
        }

    }

}
