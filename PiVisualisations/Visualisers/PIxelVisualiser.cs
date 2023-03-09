using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

            int rectWidth = Convert.ToInt16(this.options["rectWidth"]);
            int rectHeight = Convert.ToInt16(this.options["rectHeight"]);

            Random myRNG = new Random();

            int stepsTaken = 1;
            char direction = 'r';
            int timesTargetHit = 0;

            int edgeSize = 2;

            int offset = rectWidth;

            for (int i = 0; i < 100; i++)
            {
                for (int x = 0; x < edgeSize; x++)
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

                    SolidColorBrush newColour = new SolidColorBrush(Color.FromRgb((byte)myRNG.Next(1, 255), (byte)myRNG.Next(1, 255), (byte)myRNG.Next(1, 255)));
                    this.graphics.Draw(newColour, rectX, rectY);

                    stepsTaken += 1;

                    if (stepsTaken == edgeSize)
                    {
                        switch (direction)
                        {
                            case 'r':
                                direction = 'u';
                                break;
                            case 'u':
                                direction = 'l';
                                break;
                            case 'l':
                                direction = 'd';
                                break;
                            case 'd':
                                direction = 'r';
                                break;
                        }
                        timesTargetHit += 1;
                        stepsTaken = 1;
                    }

                    if (timesTargetHit == edgeSize + 1)
                    {
                        edgeSize += 1;
                        timesTargetHit = 0;
                    }

                    MessageBox.Show("Tick");

                    MessageBox.Show($"Steps taken {stepsTaken}, edge size {edgeSize}, target hit {timesTargetHit}");

                }
            }
        }
    }
}
