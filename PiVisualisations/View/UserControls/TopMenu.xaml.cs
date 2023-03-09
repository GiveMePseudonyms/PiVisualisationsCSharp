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

namespace PiVisualisations.View.UserControls
{
    /// <summary>
    /// Interaction logic for TopMenu.xaml
    /// </summary>
    public partial class TopMenu : UserControl
    {
        public TopMenu()
        {
            InitializeComponent();
        }

        private void TopMenu_Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void TopMenu_Refresh_Click(object sender, RoutedEventArgs e)
        {
            //testing
            MessageBox.Show("Refresh clicked");
        }

        private void Draw_Click(object sender, RoutedEventArgs e)
        {
            // get the window as window obj so we can invoke commands in it.
            MainWindow window = Window.GetWindow(this) as MainWindow;
            window.Draw();
        }

        private void Background_White_Click(object sender, RoutedEventArgs e)
        {
            // get the window as window obj so we can invoke commands in it.
            MainWindow window = Window.GetWindow(this) as MainWindow;
            //window.Canvas.Background = new SolidColorBrush(Colors.White);
        }

        private void Background_Black_Click(object sender, RoutedEventArgs e)
        {
            // get the window as window obj so we can invoke commands in it.
            MainWindow window = Window.GetWindow(this) as MainWindow;
            //window.Canvas.Background = new SolidColorBrush(Colors.Black);
        }
        private void Background_Grey_Click(object sender, RoutedEventArgs e)
        {
            // get the window as window obj so we can invoke commands in it.
            MainWindow window = Window.GetWindow(this) as MainWindow;
            //window.Canvas.Background = new SolidColorBrush(Colors.Gray);
        }

        private void Pixel_Click(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void Turtle_Click(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void Spiral_Click(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void Waveform_Click(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void Sandpile_Click(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void Web_Click(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void test_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
