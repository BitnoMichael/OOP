using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace OOPaint
{
    internal class MyBrokenLineCreator : IMyShapeCreator
    {
        public MyShape CreateShape(Color brushColor, Color penColor, double penWidth, PointCollection points)
        {
            return new MyBrokenLine(penColor, penWidth, points);
        }

        public void TransformShape(MyShape shape, PointCollection points, Point endPoint)
        {
            if (shape is MyBrokenLine brokenLine)
            {
                var newPoints = new PointCollection(points) { endPoint };
                brokenLine.Points = newPoints.ToArray();
                brokenLine.InvalidateVisual();
            }
        }
    }
}
