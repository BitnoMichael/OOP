using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPaint
{
    [Serializable]
    internal class MyIsoscelesTriangle : MyShape
    {
        public MyIsoscelesTriangle(Color brushColor, Color penColor, double penWidth, Point point1, Point point2)
        {
            BrushColor = brushColor;
            PenColor = penColor;
            PenWidth = penWidth;
            OuterPoint1 = point1;
            OuterPoint2 = point2;
        }
        public PointCollection Points
        {
            get
            {
                PointCollection points = new PointCollection();
                points.Add(new Point(OuterPoint1.X, OuterPoint1.Y));
                points.Add(new Point(OuterPoint2.X, OuterPoint1.Y));
                points.Add(new Point((OuterPoint1.X + OuterPoint2.X) / 2, OuterPoint2.Y));
                return points;
            }
        }
    }

}