using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Controls;

namespace eqmaps
{
    internal static class MapProcess
    {
        public static double minYLine, 
            minXLine, 
            divnum;
        public static void ProcessMapData(this Canvas myCanvas, string loadFile)
        {
            double[]? mapLimits;
            List<double> lineYTotals = new(),
                lineXTotals = new(),
                minYLines = new(),
                minXLines = new();

            loadFile = loadFile.Replace("_1", "").Replace("_2", "").Replace("_3", "");
            string loadFile1 = loadFile.Insert(loadFile.IndexOf(".txt"), "_1");
            string loadFile2 = loadFile.Insert(loadFile.IndexOf(".txt"), "_2");
            string loadFile3 = loadFile.Insert(loadFile.IndexOf(".txt"), "_3");
            if (File.Exists(loadFile) && new FileInfo(loadFile).Length > 50)
            {
                mapLimits = MapLimits.FindMapLimits(loadFile);
                lineYTotals.Add(mapLimits[0]);
                lineXTotals.Add(mapLimits[1]);
                minYLines.Add(mapLimits[2]);
                minXLines.Add(mapLimits[3]);
            }
            if (File.Exists(loadFile1) && new FileInfo(loadFile1).Length > 50)
            {
                mapLimits = MapLimits.FindMapLimits(loadFile1);
                lineYTotals.Add(mapLimits[0]);
                lineXTotals.Add(mapLimits[1]);
                minYLines.Add(mapLimits[2]);
                minXLines.Add(mapLimits[3]);
            }
            if (File.Exists(loadFile2) && new FileInfo(loadFile2).Length > 50)
            {
                mapLimits = MapLimits.FindMapLimits(loadFile2);
                lineYTotals.Add(mapLimits[0]);
                lineXTotals.Add(mapLimits[1]);
                minYLines.Add(mapLimits[2]);
                minXLines.Add(mapLimits[3]);
            }
            if (File.Exists(loadFile3) && new FileInfo(loadFile3).Length > 50)
            {
                mapLimits = MapLimits.FindMapLimits(loadFile3);
                lineYTotals.Add(mapLimits[0]);
                lineXTotals.Add(mapLimits[1]);
                minYLines.Add(mapLimits[2]);
                minXLines.Add(mapLimits[3]);
            }

            minYLine = Math.Abs(minYLines.Min());
            minXLine = Math.Abs(minXLines.Min());

            divnum = lineXTotals.Max() / (myCanvas.ActualWidth - 20);
            if ((lineYTotals.Max() / divnum) > (myCanvas.ActualHeight - 20))
            {
                divnum = lineYTotals.Max() / (myCanvas.ActualHeight - 20);
            }

            if (File.Exists(loadFile) && new FileInfo(loadFile).Length > 50)
            {
                MapRender.LoadMapData(myCanvas, loadFile);
            }
            if (File.Exists(loadFile1) && new FileInfo(loadFile1).Length > 50)
            {
                MapRender.LoadMapData(myCanvas, loadFile1);
            }
            if (File.Exists(loadFile2) && new FileInfo(loadFile2).Length > 50)
            {
                MapRender.LoadMapData(myCanvas, loadFile2);
            }
            if (File.Exists(loadFile3) && new FileInfo(loadFile3).Length > 50)
            {
                MapRender.LoadMapData(myCanvas, loadFile3);
            }
        }
    }
}
