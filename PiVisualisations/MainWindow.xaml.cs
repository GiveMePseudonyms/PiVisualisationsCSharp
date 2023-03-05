using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace PiVisualisations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Draw()
        {
            Random myRNG = new Random();

            SolidColorBrush newColour = new SolidColorBrush(Color.FromRgb((byte)myRNG.Next(1, 255), (byte)myRNG.Next(1, 255), (byte)myRNG.Next(1, 255)));
            Rectangle myRect = new Rectangle
            {
                Width = 100,
                Height = 100,
                Fill = newColour,
                StrokeThickness = 3,
                Stroke = Brushes.Black
            };

            Canvas.SetLeft(myRect, 0);
            Canvas.SetTop(myRect, 0);
            Canvas.Children.Add(myRect);
        }
    }
}
