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
        public int x;
        public int y;
        public Crd(int XCoordinate, int YCoordinate)
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
            continents.Add(new Continent("A", Colors.Blue, freelist, GWidth, GHeight));
            continents.Add(new Continent("B", Colors.Red, freelist, GWidth, GHeight));
            continents.Add(new Continent("C", Colors.Green, freelist, GWidth, GHeight));
            continents.Add(new Continent("D", Colors.Yellow, freelist, GWidth, GHeight));
            continents.Add(new Continent("E", Colors.Orange, freelist, GWidth, GHeight));
            continents.Add(new Continent("F", Colors.Purple, freelist, GWidth, GHeight));

            //grid stuff
            Grid mapGrid = new Grid();
            int[] scores = new int[10];

            // Define the Columns
            for (int i = 0; i < GWidth; ++i)
                mapGrid.ColumnDefinitions.Add(new ColumnDefinition());

            // Define the Rows
            for (int i = 0; i < GHeight; ++i)
                mapGrid.RowDefinitions.Add(new RowDefinition());

            main.Content = mapGrid; //attach the grid to the window

            for (int i = 0; i <100; i++)
            {
                foreach(Continent continent in continents)
                {
                    continent.Spread(GWidth, freelist);
                }
                bool isEmpty = !freelist.Any();
                if (isEmpty)
                {
                    break;
                }

            }

            //draw all continents
            foreach (Continent continent in continents)
            {
                continent.drawSelf(mapGrid);
            }
        }

    }

}
