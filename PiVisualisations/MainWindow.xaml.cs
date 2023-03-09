using PiVisualisations.Visualisers;
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
            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("rectWidth", "20");
            options.Add("rectHeight", "20");
            PIxelVisualiser pixelVisualiser = new PIxelVisualiser(Canvas, options);

            pixelVisualiser.Draw();

        }
    }
}
