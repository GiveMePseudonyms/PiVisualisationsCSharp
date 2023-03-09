using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup.Localizer;
using System.Windows.Media;

namespace PiVisualisations.Visualisers
{
    public class PIxelVisualiser
    {
        Dictionary<string, string> options;
        Canvas canvas;
        Graphics graphics;
        public PIxelVisualiser(Canvas canvas, Dictionary<string, string> options)
        {
            this.options = options;
            this.canvas = canvas;
            this.graphics = new Graphics(canvas, options);
        }

        public void Draw()
        {
            //might be better to store this in the settings dictionary and pass it in via
            //the constructor, allowing user to choose canvas size.
            double centreX = this.canvas.ActualWidth / 2;
            double centreY = this.canvas.ActualHeight / 2;

            //starting points for rects.
            double rectX = centreX;
            double rectY = centreY;

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

            int totalSteps = 0;

            for (totalSteps = 0; totalSteps <= 400; totalSteps++)
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
                    SolidColorBrush newColour = new SolidColorBrush(Color.FromRgb((byte)myRNG.Next(1, 255), (byte)myRNG.Next(1, 255), (byte)myRNG.Next(1, 255)));
                    this.graphics.Draw(newColour, rectX, rectY);
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
        }
    }
}
