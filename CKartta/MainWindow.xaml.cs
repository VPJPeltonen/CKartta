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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int GWidth = 88;
        public int GHeight = 88;

        public MainWindow()
        {
            InitializeComponent();

            //create a world
            World mWorld = new World(8, GWidth, GHeight);

            //get list of grid places
            List<Node> freeNodes = mWorld.GetList();

            //get neighbours for nodes
            foreach(Node node in freeNodes) { node.SetNeighbours(freeNodes); }

            //create continents
            List<object> continents = new List<object>(); //continentlist
            continents.Add(new Continent(Brushes.Blue, freeNodes, GWidth, GHeight));
            continents.Add(new Continent(Brushes.Red, freeNodes, GWidth, GHeight));
            continents.Add(new Continent(Brushes.Green, freeNodes, GWidth, GHeight));
            continents.Add(new Continent(Brushes.Yellow, freeNodes, GWidth, GHeight));
            continents.Add(new Continent(Brushes.Orange, freeNodes, GWidth, GHeight));
            continents.Add(new Continent(Brushes.Purple, freeNodes, GWidth, GHeight));
            continents.Add(new Continent(Brushes.Black, freeNodes, GWidth, GHeight));
            continents.Add(new Continent(Brushes.Aqua, freeNodes, GWidth, GHeight));
            continents.Add(new Continent(Brushes.Salmon, freeNodes, GWidth, GHeight));
            continents.Add(new Continent(Brushes.DeepSkyBlue, freeNodes, GWidth, GHeight));

            var mainCanvas = new Canvas();
            mainCanvas.Background = Brushes.Black;
            

            main.Content = mainCanvas; //attach  the grid to the window
            
            //spread continents
            for (int i = 0; i <10000; i++)
            {
                foreach(Continent continent in continents){continent.Spread(GWidth, freeNodes);}
                bool isEmpty = !freeNodes.Any();
                if (isEmpty) { break; }
            }

            //set waterlevels
            mWorld.WaterLevels(continents);

            //draw all continents
            mWorld.DrawWorld(mainCanvas);
        }

    }

}
