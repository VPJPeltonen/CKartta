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
        public int GWidth = 88;
        public int GHeight = 88;

        public MainWindow()
        {
            InitializeComponent();

            //create a world
            World mWorld = new World(8, GWidth, GHeight);

            //get list of grid places
            List<Crd> freelist = mWorld.GetList();

            //create continents
            List<object> continents = new List<object>(); //continentlist
            continents.Add(new Continent(Brushes.Blue, freelist, GWidth, GHeight));
            continents.Add(new Continent(Brushes.Red, freelist, GWidth, GHeight));
            continents.Add(new Continent(Brushes.Green, freelist, GWidth, GHeight));
            continents.Add(new Continent(Brushes.Yellow, freelist, GWidth, GHeight));
            continents.Add(new Continent(Brushes.Orange, freelist, GWidth, GHeight));
            continents.Add(new Continent(Brushes.Purple, freelist, GWidth, GHeight));
            continents.Add(new Continent(Brushes.Black, freelist, GWidth, GHeight));
            continents.Add(new Continent(Brushes.Aqua, freelist, GWidth, GHeight));
            continents.Add(new Continent(Brushes.Salmon, freelist, GWidth, GHeight));
            continents.Add(new Continent(Brushes.DeepSkyBlue, freelist, GWidth, GHeight));

            var mainCanvas = new Canvas();
            mainCanvas.Background = Brushes.Black;
            
            //grid stuff
            //Grid mapGrid = new Grid();
            //mapGrid.ShowGridLines = false;
            //int[] scores = new int[10];

            // Define the Columns
            //for (int i = 0; i < GWidth; ++i)
            //    mapGrid.ColumnDefinitions.Add(new ColumnDefinition());

            // Define the Rows
            //for (int i = 0; i < GHeight; ++i)
            //    mapGrid.RowDefinitions.Add(new RowDefinition());

            main.Content = mainCanvas; //attach the grid to the window
            
            //spread continents
            for (int i = 0; i <100; i++)
            {
                foreach(Continent continent in continents){continent.Spread(GWidth, freelist);}
                bool isEmpty = !freelist.Any();
                if (isEmpty) { break; }
            }

            //set waterlevels
            mWorld.WaterLevels(continents);

            //draw all continents
            foreach (Continent continent in continents){continent.drawSelf(mainCanvas);}

            /*
            Rectangle rect = new Rectangle
            {
                Stroke = Brushes.Red,
                StrokeThickness = 10
            };
            Canvas.SetLeft(rect, 10);
            Canvas.SetTop(rect, 10);
            mainCanvas.Children.Add(rect);

            Rectangle rect2 = new Rectangle
            {
                Stroke = Brushes.Red,
                StrokeThickness = 10
            };
            Canvas.SetLeft(rect2, 0);
            Canvas.SetTop(rect2, 0);
            mainCanvas.Children.Add(rect2);*/
        }

    }

}
