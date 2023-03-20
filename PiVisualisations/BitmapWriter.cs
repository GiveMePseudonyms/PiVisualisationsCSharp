using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

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
            image.Source = bitmap;
            //bitmap = new WriteableBitmap(1, 1, 10, 10, PixelFormats.Pbgra32, null);
        }

        public void Draw(int xPos, int Ypos, int width, int height, Color colour)
        {
            /*
            int x1 = xPos;
            int y1 = Ypos;
            int x2 = x1 + width;
            int y2 = y1 + height;
            */

            int x1 = 10;
            int x2 = 100;
            int y1 = 10;
            int y2 = 100;

            bitmap.DrawRectangle(x1, y1, x2, y2, colour);

            /*
            bitmap.Lock();
            for (int column = x1; column < x2; column++)
            {
                for (int row = y1; row < y2; row++)
                {
                    bitmap.SetPixel(column, row, colour);
                }
            }
            bitmap.Unlock();
            */
        }

        internal void Refresh()
        {
            image.Source = bitmap;
        }

    }
}