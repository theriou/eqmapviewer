using System;
using System.IO;
using System.Text.RegularExpressions;

namespace eqmaps
{
    internal class MapLimits
    {
        public static double[] FindMapLimits(string loadFile)
        {
            double minYLine = 0,
                minXLine = 0,
                maxYLine = 0,
                maxXLine = 0,
                yLineGet1 = 0,
                xLineGet1 = 0,
                yLineGet2 = 0,
                xLineGet2 = 0;
            var mapLines = File.ReadAllLines(loadFile);

            for (int i = 0; i < mapLines.Length; i++)
            {
                var mapFields = mapLines[i].Split(',');

                yLineGet1 = Double.Parse(Regex.Replace(mapFields[1], "[^-0-9.]", ""));
                xLineGet1 = Double.Parse(Regex.Replace(mapFields[0], "[^-0-9.]", ""));

                if (mapFields[0].Contains('P'))
                {
                    yLineGet2 = Double.Parse(Regex.Replace(mapFields[1], "[^-0-9.]", ""));
                    xLineGet2 = Double.Parse(Regex.Replace(mapFields[0], "[^-0-9.]", ""));
                }
                else if (mapFields[0].Contains('L'))
                {
                    yLineGet2 = Double.Parse(Regex.Replace(mapFields[4], "[^-0-9.]", ""));
                    xLineGet2 = Double.Parse(Regex.Replace(mapFields[3], "[^-0-9.]", ""));
                }

                if (i == 0)
                {
                    maxYLine = yLineGet1;
                    minYLine = yLineGet2;
                    maxXLine = xLineGet1;
                    minXLine = xLineGet2;
                }

                if (xLineGet1 > maxXLine)
                {
                    maxXLine = xLineGet1;
                }
                if (xLineGet2 > maxXLine)
                {
                    maxXLine = xLineGet2;
                }
                if (xLineGet1 < minXLine)
                {
                    minXLine = xLineGet1;
                }
                if (xLineGet2 < minXLine)
                {
                    minXLine = xLineGet2;
                }
                if (yLineGet1 > maxYLine)
                {
                    maxYLine = yLineGet1;
                }
                if (yLineGet2 > maxYLine)
                {
                    maxYLine = yLineGet2;
                }
                if (yLineGet1 < minYLine)
                {
                    minYLine = yLineGet1;
                }
                if (yLineGet2 < minYLine)
                {
                    minYLine = yLineGet2;
                }
            }

            double lineYTotal = Math.Abs(maxYLine) + Math.Abs(minYLine);
            double lineXTotal = Math.Abs(maxXLine) + Math.Abs(minXLine);

            return new[] { lineYTotal, lineXTotal, minYLine, minXLine, maxYLine, maxXLine };
        }
    }
}
