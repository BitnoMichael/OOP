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
    public interface IMyShapeCreator
    {
        IShape createDrawableShape(Color brushColor, Color penColor, double penWidth, PointCollection points);
    }

    internal class MyEllipseCreator : IMyShapeCreator
    {
        public IShape createDrawableShape(Color brushColor, Color penColor, double penWidth, PointCollection points)
        {
            // Здесь можно использовать points[0] и points[1] для определения размеров
            return new MyEllipse(brushColor, penColor, penWidth, points[0], points[1]);
        }
    }

    internal class MyLineCreator : IMyShapeCreator
    {
        public IShape createDrawableShape(Color brushColor, Color penColor, double penWidth, PointCollection points)
        {
            return new MyLine(penColor, penWidth, points[0], points[1]);
        }
    }

    internal class MyRectangleCreator : IMyShapeCreator
    {
        public IShape createDrawableShape(Color brushColor, Color penColor, double penWidth, PointCollection points)
        {
            return new MyRectangle(brushColor, penColor, penWidth, points[0], points[1]);
        }
    }

    internal class MyIsoscelesTriangleCreator : IMyShapeCreator
    {
        public IShape createDrawableShape(Color brushColor, Color penColor, double penWidth, PointCollection points)
        {
            return new MyIsoscelesTriangle(brushColor, penColor, penWidth, points[0], points[1]);
        }
    }

    internal class MyBrokenLineCreator : IMyShapeCreator
    {
        public IShape createDrawableShape(Color brushColor, Color penColor, double penWidth, PointCollection points)
        {
            return new MyBrokenLine(brushColor, penColor, penWidth, points);
        }
    }
    internal class MyPolygonCreator : IMyShapeCreator
    {
        public IShape createDrawableShape(Color brushColor, Color penColor, double penWidth, PointCollection points)
        {
            return new MyPolygon(brushColor, penColor, penWidth, points);
        }
    }
}
