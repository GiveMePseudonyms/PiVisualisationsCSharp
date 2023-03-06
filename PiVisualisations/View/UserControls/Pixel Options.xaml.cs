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
    /// Interaction logic for Pixel_Options.xaml
    /// </summary>
    public partial class Pixel_Options : UserControl
    {
        public Pixel_Options()
        {
            InitializeComponent();
        }

        private void TestClick(object sender, RoutedEventArgs e)
        {
            string selected = cbPointSize.Text;
            MessageBox.Show($"Clicked {selected}");
        }
    }
}
