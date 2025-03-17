﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace OOPaint
{
    internal class MyBrokenLine: ComplexShape
    {
        public MyBrokenLine(Color brushColor, Color penColor, double penWidth, PointCollection points)
        {
            BrushColor = brushColor;
            PenWidth = penWidth;
            PenColor = penColor;
            Points = points;
        }
    }
}
