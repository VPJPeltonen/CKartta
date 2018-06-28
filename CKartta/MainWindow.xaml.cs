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
            Continent cA = new Continent("A", "#0000ff", freelist, GWidth, GHeight);
            Continent cB = new Continent("B", red, freelist, GWidth, GHeight);
            Continent cC = new Continent("C", green, freelist, GWidth, GHeight);
            Continent cD = new Continent("D", aqua, freelist, GWidth, GHeight);
            Continent cE = new Continent("E", orange, freelist, GWidth, GHeight);
            Continent cF = new Continent("F", purple, freelist, GWidth, GHeight);

            //grid stuff
            Grid B = new Grid();
            int[] scores = new int[10];

            // Define the Columns
            for (int i = 0; i < GWidth; ++i)
                B.ColumnDefinitions.Add(new ColumnDefinition());

            // Define the Rows
            for (int i = 0; i < GHeight; ++i)
                B.RowDefinitions.Add(new RowDefinition());

            main.Content = B;
            /*
            while (true){

            }

            / Add the first text cell to the Grid
            TextBlock txt1 = new TextBlock();
            txt1.Text = "testing";
            txt1.FontSize = 20;
            txt1.FontWeight = FontWeights.Bold;
            Grid.SetRow(txt1, 0);
            Grid.SetColumn(txt1, 1);
           
            B.Children.Add(txt1);

            // initialize button object
            Button button = new Button();
            // set properties
            button.Width = 160;
            button.Height = 72;
            button.Content = "Click Me";
            // Attach it to the visual tree, specifically as a child of a Grid object (named 'ContentPanel') that already exists. 
            // In other words, position the button in the UI.
            B.Children.Add(button);
             */
        }

    }

}
