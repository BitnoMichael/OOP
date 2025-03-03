using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace OOPaint
{
    internal class DrawingCanvas : Canvas
    {
        public Color BrushColor { get; set; } = Color.FromRgb(0, 0, 0);
        public Color PenColor { get; set; } = Color.FromRgb(0, 0, 0);
        public double PenWidth { get; set; } = 1;
        public bool IsDrawing { get; set; } = false;
        public Shape CurShape { get; set; } = null;
        public Point startPoint;

        private void drawRectangle(Rectangle rectangle, Point point)
        {
            if (startPoint.X <= point.X)
                Canvas.SetLeft(rectangle, startPoint.X);
            else
                Canvas.SetLeft(rectangle, point.X);
            if (startPoint.Y <= point.Y)
                Canvas.SetTop(rectangle, startPoint.Y);
            else
                Canvas.SetTop(rectangle, point.Y);

            rectangle.Width = Math.Abs(point.X - startPoint.X);
            rectangle.Height = Math.Abs(point.Y - startPoint.Y);
        }
        private void drawEllipse(Ellipse ellipse, Point point)
        {
            if (startPoint.X <= point.X)
                Canvas.SetLeft(ellipse, startPoint.X);
            else
                Canvas.SetLeft(ellipse, point.X);
            if (startPoint.Y <= point.Y)
                Canvas.SetTop(ellipse, startPoint.Y);
            else
                Canvas.SetTop(ellipse, point.Y);

            ellipse.Width = Math.Abs(point.X - startPoint.X);
            ellipse.Height = Math.Abs(point.Y - startPoint.Y);
        }
        private void drawLine(Line line, Point point)
        {
            line.X2 = point.X;
            line.Y2 = point.Y;
        }
        private void drawTriangle(Polygon triangle, Point point)
        {
            triangle.Points[0] = startPoint;
            triangle.Points[1] = new Point((startPoint.X + point.X) / 2, point.Y);
            triangle.Points[2] = new Point(point.X, startPoint.Y);
        }
        public void drawShape(Shape curShape, Point point)
        {
            switch (curShape)
            {
                case Rectangle rectangle:
                    drawRectangle(rectangle, point);
                    break;
                case Ellipse ellipse:
                    drawEllipse(ellipse, point);
                    break;
                case Line line:
                    drawLine(line, point);
                    break;
                case Polygon triangle:
                    drawTriangle(triangle, point);
                    break;
                default: return;
            }
        }
    }
}
