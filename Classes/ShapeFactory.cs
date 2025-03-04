using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using OOPaint.Shapes;

namespace OOPaint
{
    internal static class ShapeFactory
    {
        public static DrawableShape СreateDrawableShape(Tool curTool, Color brushColor, Color penColor, double penWidth, Point curPoint)
        {
            switch (curTool)
            {
                case Tool.TOOL_SQUARE:
                    return new MyRectangle(brushColor, penColor, penWidth, curPoint, curPoint);
                case Tool.TOOL_LINE:
                    return new MyLine(penColor, penWidth, curPoint, curPoint);
                case Tool.TOOL_ELLIPSE:
                    return new MyEllipse(brushColor, penColor, penWidth, curPoint, curPoint);
                case Tool.TOOL_TRIANGLE:
                    return new MyIsoscelesTriangle(brushColor, penColor, penWidth, curPoint, curPoint);
                default:
                    return null;
            }
        }
        public static DrawableShape CreateDrawableShape(Type type, Color brushColor, Color penColor, double penWidth, Point curPoint)
        {
            if (type == typeof(MyRectangle))
            {
                return new MyRectangle(brushColor, penColor, penWidth, curPoint, curPoint);
            }
            else if (type == typeof(MyLine))
            {
                return new MyLine(penColor, penWidth, curPoint, curPoint);
            }
            else if (type == typeof(MyEllipse))
            {
                return new MyEllipse(brushColor, penColor, penWidth, curPoint, curPoint);
            }
            else if (type == typeof(MyIsoscelesTriangle))
            {
                return new MyIsoscelesTriangle(brushColor, penColor, penWidth, curPoint, curPoint);
            }
            else
            {
                throw new ArgumentException("Unknown shape type");
            }
        }
        public static Shape CreateShape(Type type, Color brushColor, Color penColor, double penWidth, Point curPoint)
        {
            Shape shape;
            if (type == typeof(MyRectangle))
            {
                shape = new Rectangle
                {
                    Fill = new SolidColorBrush(brushColor),
                    Stroke = new SolidColorBrush(penColor),
                    StrokeThickness = penWidth
                };
            }
            else if (type == typeof(MyLine))
            {
                shape = new Line
                {
                    Stroke = new SolidColorBrush(penColor),
                    StrokeThickness = penWidth
                };
            }
            else if (type == typeof(MyEllipse))
            {
                shape = new Ellipse
                {
                    Fill = new SolidColorBrush(brushColor),
                    Stroke = new SolidColorBrush(penColor),
                    StrokeThickness = penWidth
                };
            }
            else if (type == typeof(MyIsoscelesTriangle))
            {
                shape = new Polygon
                {
                    Fill = new SolidColorBrush(brushColor),
                    Stroke = new SolidColorBrush(penColor),
                    StrokeThickness = penWidth,
                    Points = new PointCollection { new Point(), new Point(), new Point() }
                };
            }
            else
            {
                throw new ArgumentException("Unknown shape type");
            }
            return shape;
        }
    }
}
