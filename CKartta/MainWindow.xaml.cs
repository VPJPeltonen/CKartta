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
    public partial class MainWindow : Window
    {
        public int GWidth = 100;
        public int GHeight = 80;

        //ui info
        public string text1 { get; set; }
        public string text2 { get; set; }
        public string text3 { get; set; }

        World mWorld = new World();
        public string state = "none";
        List<Continent> continents = new List<Continent>(); //continentlist

        Canvas mainCanvas = new Canvas();
        ColorsStorage color = new ColorsStorage();

        public MainWindow()
        {
            InitializeComponent();

            //ui text
            text1 = "Width: " + GWidth;
            text2 = "Height: " + GHeight;
            text3 = "Width: " + GWidth;
            panel.DataContext = this;
            elevation.DataContext = this;

            //create random & colorstorage
            Random Rnd = new Random();
            ColorsStorage cStorage = new ColorsStorage();

            //create a world
            mWorld.WorldInit(8, GWidth, GHeight,Rnd, mainCanvas);

            //get list of grid places
            List<Node> freeNodes = mWorld.GetList();

            /*/get neighbours for nodes
            foreach(Node node in freeNodes) { node.SetNeighbours(freeNodes,GWidth,GHeight); }
            */

            //create continents    
            continents = mWorld.createContinents(12, freeNodes, GWidth, GHeight, Rnd, color);

            mainCanvas.Background = Brushes.Black;
            
            main.Content = mainCanvas; //attach  the grid to the window
            
            //spread continents---Slow and need to find out a better way!
            while (freeNodes.Count != 0){
                foreach(Continent continent in continents){
                    continent.Spread(GWidth, freeNodes);
                }
            }

            //clean some lists
            foreach(Continent continent in continents){continent.finishList();}

            //generate nature of the world
            mWorld.formWorld(color);

            //draw all continents
            mWorld.show("temperature");

            //add ui elements
            mainCanvas.Children.Add(uigrid);
        }

        private void elevation_Click(object sender, RoutedEventArgs e)
        {
            mWorld.show("elevation");
        }
        private void continent_Click(object sender, RoutedEventArgs e)
        {
            //show continents
            mWorld.show("continents");
        }
        
        private void conflict_Click(object sender, RoutedEventArgs e)
        {
            //show border areas of continents
            mWorld.show("edges");
        }      
        
        private void temperature_Click(object sender, RoutedEventArgs e)
        {
            mWorld.show("temperature");
        } 
    }
}