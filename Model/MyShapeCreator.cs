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
        MyShape createDrawableShape(Color brushColor, Color penColor, double penWidth, Point point1, Point point2);
    }
    internal class MyEllipseCreator : IMyShapeCreator
    {
        public MyShape createDrawableShape(Color brushColor, Color penColor, double penWidth, Point point1, Point point2)
        {
            return new MyEllipse(brushColor, penColor, penWidth, point1, point2);
        }
    }
    internal class MyLineCreator : IMyShapeCreator
    {
        public MyShape createDrawableShape(Color brushColor, Color penColor, double penWidth, Point point1, Point point2)
        {
            return new MyLine(penColor, penWidth, point1, point2);
        }   
    }
    internal class MyRectangleCreator : IMyShapeCreator
    {
        public MyShape createDrawableShape(Color brushColor, Color penColor, double penWidth, Point point1, Point point2)
        {
            return new MyRectangle(brushColor, penColor, penWidth, point1, point2);
        }
    }
    internal class MyIsoscelesTriangleCreator : IMyShapeCreator
    {
        public MyShape createDrawableShape(Color brushColor, Color penColor, double penWidth, Point point1, Point point2)
        {
            return new MyIsoscelesTriangle(brushColor, penColor, penWidth, point1, point2);
        }
    }
}
