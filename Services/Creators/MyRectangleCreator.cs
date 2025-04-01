using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace OOPaint
{

    internal class MyRectangleCreator : IMyShapeCreator
    {
        public MyShape CreateShape(Color brushColor, Color penColor, double penWidth, PointCollection points)
        {
            return new MyRectangle(brushColor, penColor, penWidth, points[0], points[1]);
        }

        public void TransformShape(MyShape shape, PointCollection points, Point endPoint)
        {
            if (shape is MyRectangle rect)
            {
                rect.Points = new[] { points[0], endPoint };
                rect.InvalidateVisual();
            }
        }
    }
}
