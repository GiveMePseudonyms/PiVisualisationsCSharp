using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;

namespace PiVisualisations
{
    internal class BitmapWriter
    {
        Image image;
        WriteableBitmap bitmap;
        Dictionary<string, string> options;
        public BitmapWriter(Image image, Dictionary<string, string> options) 
        {
            this.image = image;
            this.options = options;
            
            bitmap = BitmapFactory.New((int)this.image.ActualWidth, (int)this.image.ActualHeight);
        }

        public void Draw(int xPos, int Ypos, int width, int height, Color colour)
        {
            int x1 = xPos;
            int y1 = Ypos;
            int x2 = x1 + width;
            int y2 = y1 + height;

            bitmap.FillRectangle(x1, y1, x2, y2, colour);
        }

        public void Refresh()
        {
            image.Source = bitmap;
            image.InvalidateVisual();
        }
    }
}
