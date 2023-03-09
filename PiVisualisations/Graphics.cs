using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PiVisualisations
{
    public class Graphics
    {
        Canvas canvas;
        Dictionary<string, string> options;
        public Graphics(Canvas canvas, Dictionary<string, string> options)
        {
            this.canvas = canvas;
            this.options = options;
        }

        public void Draw(SolidColorBrush brush, double xPos, double yPos)
        {
            int rectWidth = Convert.ToInt16(this.options["rectWidth"]);
            int rectHeight = Convert.ToInt16(this.options["rectHeight"]);

            Rectangle rect = new Rectangle
            {
                Width = rectWidth,
                Height = rectHeight,
                Fill = brush
            };

            //set coords of rect and then draw it
            Canvas.SetLeft(rect, xPos);
            Canvas.SetTop(rect, yPos);
            canvas.Children.Add(rect);
        }
    }
}
