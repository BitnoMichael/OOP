using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace OOPaint
{

    internal class MyEllipseCreator : IMyShapeCreator
    {
        public MyShape CreateShape(Color brushColor, Color penColor, double penWidth, PointCollection points)
        {
            return new MyEllipse(brushColor, penColor, penWidth, points[0], points[1]);
        }

        public void TransformShape(MyShape shape, PointCollection points, Point endPoint)
        {
            if (shape is MyEllipse ellipse)
            {
                ellipse.Points = new[] { points[0], endPoint };
                ellipse.InvalidateVisual();
            }
        }
    }
}
