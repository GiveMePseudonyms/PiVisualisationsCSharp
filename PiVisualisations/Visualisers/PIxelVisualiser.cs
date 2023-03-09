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
            double centreX = this.canvas.ActualWidth / 2;
            double centreY = this.canvas.ActualHeight / 2;

            double rectX = centreX;
            double rectY = centreY;

            int offset = Convert.ToInt16(this.options["rectWidth"]);

            Random myRNG = new Random();

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

                    SolidColorBrush newColour = new SolidColorBrush(Color.FromRgb((byte)myRNG.Next(1, 255), (byte)myRNG.Next(1, 255), (byte)myRNG.Next(1, 255)));
                    this.graphics.Draw(newColour, rectX, rectY);
                }

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
