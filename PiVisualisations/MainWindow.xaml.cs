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

            double centre_x = 500;
            double centre_y = 500;

            double rect_x;
            double rect_y;
            int rect_width = 10;
            int rect_height = 10;


            Random myRNG = new Random();

            int steps_taken = 0;
            int step_target = 1;
            char direction = 'r';
            int timesTargetHit = 0;

            double x_index = 0;
            double y_index = 0;

            int offset = 5;

            for(int i = 0 ; i <= 100; i++)
            {
                if (steps_taken != step_target)
                {
                    steps_taken += 1;
                    switch (direction)
                    {
                        case 'r':
                            x_index += offset;
                            break;
                        case 'u':
                            y_index -= offset;
                            break;
                        case 'l':
                            x_index -= offset;
                            break;
                        case 'd':
                            y_index += offset;
                            break;
                    }
                }
                else
                {
                    if (timesTargetHit != 2)
                    {
                        timesTargetHit += 1;
                        steps_taken = 0;
                    }
                    else if (timesTargetHit == 2)
                    {
                        steps_taken = 0;
                        step_target += 1;
                        timesTargetHit = 1;
                    }
                    switch (direction)
                    {
                        case 'r':
                            x_index += offset;
                            direction = 'u';
                            break;
                        case 'u':
                            y_index -= offset;
                            direction = 'l';
                            break;
                        case 'l':
                            x_index -= offset;
                            direction = 'd';
                            break;
                        case 'd':
                            y_index += offset;
                            direction = 'r';
                            break;
                    }
                    rect_x = centre_x + x_index;
                    
                    rect_y = centre_y + y_index;

                    SolidColorBrush newColour = new SolidColorBrush(Color.FromRgb((byte)myRNG.Next(1, 255), (byte)myRNG.Next(1, 255), (byte)myRNG.Next(1, 255)));
                    Rectangle myRect = new Rectangle
                    {
                        Width = rect_width,
                        Height = rect_height,
                        Fill = newColour,
                    };
                    Canvas.SetLeft(myRect, rect_x);
                    Canvas.SetTop(myRect, rect_y);
                    Canvas.Children.Add(myRect);
                }

            }
        }
    }
}
