using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Net;

namespace OOPaint
{
    public interface IShapeCreator
    {
        Shape CreateShape(Color brushColor, Color penColor, double penWidth, PointCollection points);
        void TransformShape(Shape shape, PointCollection points, Point endPoint);
    }

    internal class EllipseCreator : IShapeCreator
    {
        public Shape CreateShape(Color brushColor, Color penColor, double penWidth, PointCollection points)
        {
            var point1 = points[0];
            var point2 = points[1];
            Ellipse ellipse = new Ellipse
            {
                Width = Math.Abs(point2.X - point1.X),
                Height = Math.Abs(point2.Y - point1.Y),
                Fill = new SolidColorBrush(brushColor),
                Stroke = new SolidColorBrush(penColor),
                StrokeThickness = penWidth
            };
            Canvas.SetLeft(ellipse, Math.Min(point1.X, point2.X));
            Canvas.SetTop(ellipse, Math.Min(point1.Y, point2.Y));
            return ellipse;
        }

        public void TransformShape(Shape shape, PointCollection points, Point endPoint)
        {
            var point1 = points[0];
            var point2 = endPoint;
            if (shape is Ellipse ellipse)
            {
                ellipse.Width = Math.Abs(point2.X - point1.X);
                ellipse.Height = Math.Abs(point2.Y - point1.Y);
                Canvas.SetLeft(ellipse, Math.Min(point1.X, point2.X));
                Canvas.SetTop(ellipse, Math.Min(point1.Y, point2.Y));
            }
        }
    }

    internal class LineCreator : IShapeCreator
    {
        public Shape CreateShape(Color brushColor, Color penColor, double penWidth, PointCollection points)
        {
            var point1 = points[0];
            var point2 = points[1];
            Line line = new Line
            {
                X1 = point1.X,
                Y1 = point1.Y,
                X2 = point2.X,
                Y2 = point2.Y,
                Stroke = new SolidColorBrush(penColor),
                StrokeThickness = penWidth
            };
            return line;
        }

        public void TransformShape(Shape shape, PointCollection points, Point endPoint)
        {
            var point1 = points[0];
            var point2 = endPoint;
            if (shape is Line line)
            {
                line.X1 = point1.X;
                line.Y1 = point1.Y;
                line.X2 = point2.X;
                line.Y2 = point2.Y;
            }
        }
    }

    internal class RectangleCreator : IShapeCreator
    {
        public Shape CreateShape(Color brushColor, Color penColor, double penWidth, PointCollection points)
        {
            var point1 = points[0];
            var point2 = points[1];
            Rectangle rect = new Rectangle
            {
                Width = Math.Abs(point2.X - point1.X),
                Height = Math.Abs(point2.Y - point1.Y),
                Fill = new SolidColorBrush(brushColor),
                Stroke = new SolidColorBrush(penColor),
                StrokeThickness = penWidth
            };
            Canvas.SetLeft(rect, Math.Min(point1.X, point2.X));
            Canvas.SetTop(rect, Math.Min(point1.Y, point2.Y));
            return rect;
        }

        public void TransformShape(Shape shape, PointCollection points, Point endPoint)
        {
            var point1 = points[0];
            var point2 = endPoint;
            if (shape is Rectangle rect)
            {
                rect.Width = Math.Abs(point2.X - point1.X);
                rect.Height = Math.Abs(point2.Y - point1.Y);
                Canvas.SetLeft(rect, Math.Min(point1.X, point2.X));
                Canvas.SetTop(rect, Math.Min(point1.Y, point2.Y));
            }
        }
    }

    internal class TriangleCreator : IShapeCreator
    {
        public Shape CreateShape(Color brushColor, Color penColor, double penWidth, PointCollection points)
        {
            var point1 = points[0];
            var point2 = points[1];
            Polygon triangle = new Polygon
            {
                Fill = new SolidColorBrush(brushColor),
                Stroke = new SolidColorBrush(penColor),
                StrokeThickness = penWidth
            };
            PointCollection pointCollection = new PointCollection
            {
                new Point(point1.X, point1.Y),
                new Point(point2.X, point1.Y),
                new Point((point1.X + point2.X) / 2, point2.Y)
            };
            triangle.Points = pointCollection;
            return triangle;
        }

        public void TransformShape(Shape shape, PointCollection points, Point endPoint)
        {
            var point1 = points[0];
            var point2 = endPoint;
            if (shape is Polygon triangle)
            {
                PointCollection pointCollection = new PointCollection
                {
                    new Point(point1.X, point1.Y),
                    new Point(point2.X, point1.Y),
                    new Point((point1.X + point2.X) / 2, point2.Y)
                };
                triangle.Points = pointCollection;
            }
        }
    }
    internal class BrokenLineCreator : IShapeCreator
    {
        public Shape CreateShape(Color brushColor, Color penColor, double penWidth, PointCollection points)
        {
            var shape = new Polyline
            {
                Stroke = new SolidColorBrush(brushColor),
                StrokeThickness = penWidth,
                Points = points
            };

            return shape;
        }

        public void TransformShape(Shape shape, PointCollection points, Point endPoint)
        {
            if (shape is Polyline polyline)
            {
                polyline.Points = new PointCollection(points);
                polyline.Points.Add(endPoint);
            }
        }
    }
    internal class PolygonCreator : IShapeCreator
    {
        public Shape CreateShape(Color brushColor, Color penColor, double penWidth, PointCollection points)
        {
            return new Polygon
            { 
                Stroke = new SolidColorBrush(penColor),
                StrokeThickness = penWidth,
                Points = points,
                Fill = new SolidColorBrush(brushColor)
            };

        }
        public void TransformShape(Shape shape, PointCollection points, Point endPoint)
        {
            if (shape is Polygon polygon)
            {
                polygon.Points = new PointCollection(points);
                polygon.Points.Add(endPoint);
            }
        }
    }
}