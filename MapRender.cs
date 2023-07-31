using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace eqmaps
{
    internal static class MapRender
    {
        public static void LoadMapData(this Canvas myCanvas, string loadFile)
        {
            double mapX, 
                mapY,
                mapX1,
                mapX2,
                mapY1,
                mapY2;
            int r,
                g,
                b;
            string textLabels = string.Empty;
            var mapLines = File.ReadAllLines(loadFile);

            for (int i = 0; i < mapLines.Length; i++)
            {
                var mapFields = mapLines[i].Split(',');

                if (mapFields[0].Contains('P'))
                {
                    textLabels = Regex.Replace(mapFields[7], "[^0-9A-Za-z_()~/]", "").Replace('_', ' ');
                    mapX = (((Double.Parse(Regex.Replace(mapFields[0], "[^-0-9.]", "")) + MapProcess.minXLine) / MapProcess.divnum) + 5) - (textLabels.Length * 2.5);
                    mapY = (((Double.Parse(Regex.Replace(mapFields[1], "[^-0-9.]", "")) + MapProcess.minYLine) / MapProcess.divnum) + 5) - 6;
                    r = Int32.Parse(Regex.Replace(mapFields[3], "[^-0-9.]", ""));
                    g = Int32.Parse(Regex.Replace(mapFields[4], "[^-0-9.]", ""));
                    b = Int32.Parse(Regex.Replace(mapFields[5], "[^-0-9.]", ""));
                    var myText = new TextBlock()
                    {
                        Foreground = new SolidColorBrush(Color.FromArgb(255, (byte)r, (byte)g, (byte)b)),
                        Text = textLabels,
                    };
                    if ((mapX - textLabels.Length * 2.5) < 0)
                    {
                        mapX += (textLabels.Length * 2.5);
                    }
                    if ((mapX + textLabels.Length * 2.5) > (myCanvas.ActualWidth - 20))
                    {
                        mapX += (textLabels.Length * 2.5);
                    }
                    if (mapY - 6 < 0)
                    {
                        mapY += 6;
                    }
                    if ((mapY + 6) > (myCanvas.ActualHeight - 20))
                    {
                        mapY -= 6;
                    }
                    Canvas.SetLeft(myText, mapX);
                    Canvas.SetTop(myText, mapY);
                    myCanvas.Children.Add(myText);
                }
                else if (mapFields[0].Contains('L'))
                {
                    mapX1 = ((Double.Parse(Regex.Replace(mapFields[0], "[^-0-9.]", "")) + MapProcess.minXLine) / MapProcess.divnum) + 5;
                    mapX2 = ((Double.Parse(Regex.Replace(mapFields[3], "[^-0-9.]", "")) + MapProcess.minXLine) / MapProcess.divnum) + 5;
                    mapY1 = ((Double.Parse(Regex.Replace(mapFields[1], "[^-0-9.]", "")) + MapProcess.minYLine) / MapProcess.divnum) + 5;
                    mapY2 = ((Double.Parse(Regex.Replace(mapFields[4], "[^-0-9.]", "")) + MapProcess.minYLine) / MapProcess.divnum) + 5;
                    r = Int32.Parse(Regex.Replace(mapFields[6], "[^-0-9.]", ""));
                    g = Int32.Parse(Regex.Replace(mapFields[7], "[^-0-9.]", ""));
                    b = Int32.Parse(Regex.Replace(mapFields[8], "[^-0-9.]", ""));
                    Line myLine = new()
                    {
                        Stroke = new SolidColorBrush(Color.FromArgb(255, (byte)r, (byte)g, (byte)b)),
                        X1 = mapX1,
                        X2 = mapX2,
                        Y1 = mapY1,
                        Y2 = mapY2,
                        StrokeThickness = 1
                    };
                    myCanvas.Children.Add(myLine);
                }
            }
        }
    }
}
