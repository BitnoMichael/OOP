using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPaint.Shapes
{
    [Serializable]
    internal class MyIsoscelesTriangle : DrawableShape
    {
        [NonSerialized]
        private Polygon _triangle;
        public override Shape Figure { get { return _triangle; } set { _triangle = (Polygon)value; } }

        public MyIsoscelesTriangle(Color brushColor, Color penColor, double penWidth, Point vertex, Point basePoint)
        {
            _triangle = new Polygon
            {
                Fill = new SolidColorBrush(brushColor),
                Stroke = new SolidColorBrush(penColor),
                StrokeThickness = penWidth,
                Points = new PointCollection { new Point(), new Point(), new Point() }
            };
            Point1 = vertex;
            Point2 = basePoint;
        }

        public override void RefreshSize()
        {
            double minY = Math.Min(Point1.Y, Point2.Y);
            double minX = Math.Min(Point1.X, Point2.X);
            double maxY = Math.Max(Point1.Y, Point2.Y);
            double maxX = Math.Max(Point1.X, Point2.X);
            Point p1 = new Point(minX, maxY); 
            Point p2 = new Point(maxX, maxY); 
            Point p3 = new Point( (maxX + minX) / 2, minY);

            _triangle.Points[0] = p1;
            _triangle.Points[1] = p2;
            _triangle.Points[2] = p3;
        }
    }
}