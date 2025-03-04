using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPaint.Shapes
{
    [Serializable]
    internal class MyRectangle : DrawableShape
    {
        [NonSerialized]
        private Rectangle _rectangle;
        public override Shape Figure { get { return _rectangle;} set { _rectangle = (Rectangle)value; } }

        public MyRectangle(Color brushColor, Color penColor, double penWidth, Point point1, Point point2)
        {
            _rectangle = new Rectangle
            {
                Fill = new SolidColorBrush(brushColor),
                Stroke = new SolidColorBrush(penColor),
                StrokeThickness = penWidth
            };
            Point1 = point1;
            Point2 = point2;
        }

        public override void RefreshSize()
        {
            Canvas.SetLeft(Figure, Math.Min(Point1.X, Point2.X));
            Canvas.SetTop(Figure, Math.Min(Point1.Y, Point2.Y));
            double width = Math.Abs(Point2.X - Point1.X);
            double height = Math.Abs(Point2.Y - Point1.Y);
            _rectangle.Width = width;
            _rectangle.Height = height;
        }
    }
}