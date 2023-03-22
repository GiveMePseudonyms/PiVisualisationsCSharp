using PiVisualisations.Visualisers;
using System;
using System.Collections.Generic;
using System.Windows;

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
            throw new NotImplementedException();
        }
        public void Draw()
        {
            //Define a settings dictionary to be passed onto the visualiser based upon the options
            //selected by the user
            Dictionary<string, string> options = new Dictionary<string, string>
            {
                { "canvasWidth", image.ActualWidth.ToString() },
                { "canvasHeight", image.ActualHeight.ToString() },
                { "rectWidth", "12" },
                { "rectHeight", "12" }
            };

            PIxelVisualiser pixelVisualiser = new PIxelVisualiser(image, options);
            
            pixelVisualiser.Draw();
        }
    }
}
