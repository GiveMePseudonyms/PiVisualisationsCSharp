using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

        private void Show_Pixel_Options()
        {

        }
        public void Draw()
        {
            double centreX = 500;
            double centreY = 500;

            double rectX;
            double rectY;
            int rectWidth = 20;
            int rectHeight = 20;

            Random myRNG = new Random();

            int stepsTaken = 0;
            int stepTarget = 1;
            char direction = 'r';
            int timesTargetHit = 0;

            double xIndex = 0;
            double yIndex = 0;

            int offset = 10;

            for(int i = 0 ; i <= 1000; i++)
            {
                if (stepsTaken != stepTarget)
                {
                    stepsTaken += 1;
                    switch (direction)
                    {
                        case 'r':
                            xIndex += offset;
                            break;
                        case 'u':
                            yIndex -= offset;
                            break;
                        case 'l':
                            xIndex -= offset;
                            break;
                        case 'd':
                            yIndex += offset;
                            break;
                    }
                }
                else
                {
                    if (timesTargetHit != 2)
                    {
                        timesTargetHit += 1;
                        stepsTaken = 0;
                    }
                    else if (timesTargetHit == 2)
                    {
                        stepsTaken = 0;
                        stepTarget += 1;
                        timesTargetHit = 1;
                    }

                    switch (direction)
                    {
                        case 'r':
                            xIndex += offset;
                            direction = 'u';
                            break;
                        case 'u':
                            yIndex -= offset;
                            direction = 'l';
                            break;
                        case 'l':
                            xIndex -= offset;
                            direction = 'd';
                            break;
                        case 'd':
                            yIndex += offset;
                            direction = 'r';
                            break;
                }
                rectX = centreX + xIndex;
                rectY = centreY + yIndex;

                SolidColorBrush newColour = new SolidColorBrush(Color.FromRgb((byte)myRNG.Next(1, 255), (byte)myRNG.Next(1, 255), (byte)myRNG.Next(1, 255)));
                Rectangle myRect = new Rectangle
                {
                    Width = rectWidth,
                    Height = rectHeight,
                    Fill = newColour,
                };
                Canvas.SetLeft(myRect, rectX);
                Canvas.SetTop(myRect, rectY - (rectWidth /2));
                Canvas.Children.Add(myRect);

                MessageBox.Show("Tick");
                }

            }
        }
    }
}
