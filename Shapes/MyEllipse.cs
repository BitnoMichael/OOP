using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPaint.Shapes
{
    [Serializable]
    internal class MyEllipse : DrawableShape
    {
        [NonSerialized]
        private Ellipse _ellipse;
        public override Shape Figure { get { return _ellipse; } set { _ellipse = (Ellipse) value; } }
        public MyEllipse(Color brushColor, Color penColor, double penWidth, Point point1, Point point2)
        {
            _ellipse = new Ellipse
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
            _ellipse.Width = width;
            _ellipse.Height = height;
        }

    }
}