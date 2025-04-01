using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace OOPaint
{
    internal class MyIsoscelesTriangleCreator : IMyShapeCreator
    {
        public MyShape CreateShape(Color brushColor, Color penColor, double penWidth, PointCollection points)
        {
            return new MyIsoscelesTriangle(brushColor, penColor, penWidth, points[0], points[1]);
        }

        public void TransformShape(MyShape shape, PointCollection points, Point endPoint)
        {
            if (shape is MyIsoscelesTriangle triangle)
            {
                triangle.Points = new[] { points[0], endPoint };
                triangle.InvalidateVisual();
            }
        }
    }
}
