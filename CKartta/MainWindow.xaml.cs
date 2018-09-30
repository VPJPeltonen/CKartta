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
        public int GWidth = 100;
        public int GHeight = 75;

        //ui info
        public string text1 { get; set; }
        public string text2 { get; set; }
        public string text3 { get; set; }

        World mWorld = new World();
        public string state = "none";
        List<object> continents = new List<object>(); //continentlist
        Canvas mainCanvas = new Canvas();

        public MainWindow()
        {
            InitializeComponent();

            //ui text
            text1 = "Width: " + GWidth;
            text2 = "Height: " + GHeight;
            text3 = "Width: " + GWidth;
            panel.DataContext = this;
            elevation.DataContext = this;

            //create random
            Random Rnd = new Random();

            //create a world
            mWorld.WorldInit(8, GWidth, GHeight,Rnd);

            //get list of grid places
            List<Node> freeNodes = mWorld.GetList();

            //get neighbours for nodes
            foreach(Node node in freeNodes) { node.SetNeighbours(freeNodes); }

            //create continents           
            continents.Add(new Continent(Brushes.Blue, freeNodes, GWidth, GHeight,Rnd));
            continents.Add(new Continent(Brushes.Red, freeNodes, GWidth, GHeight, Rnd));
            continents.Add(new Continent(Brushes.Green, freeNodes, GWidth, GHeight, Rnd));
            continents.Add(new Continent(Brushes.Yellow, freeNodes, GWidth, GHeight, Rnd));
            continents.Add(new Continent(Brushes.Orange, freeNodes, GWidth, GHeight, Rnd));
            continents.Add(new Continent(Brushes.Purple, freeNodes, GWidth, GHeight, Rnd));
            continents.Add(new Continent(Brushes.Black, freeNodes, GWidth, GHeight, Rnd));
            continents.Add(new Continent(Brushes.Aqua, freeNodes, GWidth, GHeight, Rnd));
            continents.Add(new Continent(Brushes.Salmon, freeNodes, GWidth, GHeight, Rnd));
            continents.Add(new Continent(Brushes.DeepSkyBlue, freeNodes, GWidth, GHeight, Rnd));
           
            mainCanvas.Background = Brushes.Black;
            
            main.Content = mainCanvas; //attach  the grid to the window
            
            //spread continents---Slow and need to find out a better way!
            while(true){
                foreach(Continent continent in continents){continent.Spread(GWidth, freeNodes);}
                bool isEmpty = !freeNodes.Any();
                if (isEmpty) { break; }
            }
            //clean some lists
            foreach(Continent continent in continents){continent.finishList();}

            //smooth
            mWorld.Smooth(1);

            //draw all continents
            mWorld.DrawWorld(mainCanvas);

            //add ui elements
            mainCanvas.Children.Add(uigrid);

        }

        private void elevation_Click(object sender, RoutedEventArgs e)
        {
            //set waterlevels
            mWorld.WaterLevels(continents);

            //draw all continents
            mWorld.DrawWorld(mainCanvas);
        }
        private void continent_Click(object sender, RoutedEventArgs e)
        {
            //set waterlevels
            mWorld.ShowContinents(continents);

            //draw all continents
            mWorld.DrawWorld(mainCanvas);
        }

    }

}
