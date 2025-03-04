using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPaint.Shapes
{
    [Serializable]
    internal class MyLine : DrawableShape
    {
        [NonSerialized]
        private Line _line;
        public override Shape Figure { get { return _line; } set { _line = (Line) value; } }
        public MyLine(Color strokeColor, double strokeWidth, Point point1, Point point2)
        {
            _line = new Line
            {
                Stroke = new SolidColorBrush(strokeColor),
                StrokeThickness = strokeWidth
            };
            Point1 = point1;
            Point2 = point2;
        }
        public override void RefreshSize()
        {
            _line.X1 = Point1.X;
            _line.Y1 = Point1.Y;
            _line.X2 = Point2.X;
            _line.Y2 = Point2.Y;
        }
    }
}