using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup.Localizer;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace PiVisualisations.Visualisers
{
    public class PIxelVisualiser
    {
        Dictionary<string, string> options;
        Image image;
        BitmapWriter bitmapWriter;
        public PIxelVisualiser(Image image, Dictionary<string, string> options)
        {
            this.options = options;
            this.image = image;
            //graphics = new Graphics(canvas, options);

            this.bitmapWriter = new BitmapWriter(image, this.options);
        }

        public void Draw()
        {
            
            //might be better to store this in the settings dictionary and pass it in via
            //the constructor, allowing user to choose canvas size.
            int centreX = (int)this.image.ActualWidth / 2;
            int centreY = (int)this.image.ActualHeight / 2;

            //starting points for rects.
            int rectX = centreX;
            int rectY = centreY;

            // rect W/H
            int rectWidth = Convert.ToInt16(this.options["rectWidth"]);
            int rectHeight = Convert.ToInt16(this.options["rectHeight"]);

            //how much we move the rect coords (should be equal to rect size to prevent overlap).
            int offset = Convert.ToInt16(this.options["rectWidth"]);

            //used for random colour generation right now. Switch to colour dictionary based on digit of pi later.
            Random myRNG = new Random();

            /*
             * Based on the current direction of travel, take a step by offset amount
             */
            int stepsTaken = 0;
            char direction = 'r';

            int stepTarget = 1;

            for (int totalSteps = 0; totalSteps <= 100; totalSteps++)
            {
                for (int x =  0; x < stepTarget; x++)
                {
                    switch (direction)
                    {
                        case 'r':
                            rectX += offset;
                            break;
                        case 'u':
                            rectY -= offset;
                            break;
                        case 'l':
                            rectX -= offset;
                            break;
                        case 'd':
                            rectY += offset;
                            break;
                    }
                    stepsTaken++;

                    //define colour and draw rect using graphics obj
                    Color theColour = Color.FromRgb((byte)myRNG.Next(1, 255), (byte)myRNG.Next(1, 255), (byte)myRNG.Next(1, 255));
                    bitmapWriter.Draw(rectX, rectY, rectWidth, rectHeight, theColour);
                }

                //once we've done the above for the entire side length, change direction
                //if we're facing up or right, increase side length target by 1
                switch(direction)
                {
                    case 'r':
                        direction = 'u';
                        break;
                    case 'u':
                        direction = 'l';
                        stepTarget++;
                        break;
                    case 'l':
                        direction = 'd';
                        break;
                    case 'd':
                        direction = 'r';
                        stepTarget++;
                        break;
                }
                stepsTaken = 0;
            }
            bitmapWriter.Refresh();
        }
    }
}
