using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace OOPaint
{
    internal class MyPolygonCreator : IMyShapeCreator
    {
        public MyShape CreateShape(Color brushColor, Color penColor, double penWidth, PointCollection points)
        {
            return new MyPolygon(brushColor, penColor, penWidth, points);
        }

        public void TransformShape(MyShape shape, PointCollection points, Point endPoint)
        {
            if (shape is MyPolygon polygon)
            {
                var newPoints = new PointCollection(points) { endPoint };
                polygon.Points = newPoints.ToArray();
                polygon.InvalidateVisual();
            }
        }
    }

}
