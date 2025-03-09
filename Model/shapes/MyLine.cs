using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPaint
{
    [Serializable]
    internal class MyLine : MyShape
    {
        public MyLine(Color strokeColor, double strokeWidth, Point point1, Point point2)
        {
            BrushColor = strokeColor;
            PenWidth = strokeWidth;

            OuterPoint1 = point1;
            OuterPoint2 = point2;
        }
    }
}