using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;


namespace OOPaint
{
    [Serializable]
    internal class MyBrokenLine : MyShape
    {
        public MyBrokenLine(Color penColor, double penWidth, PointCollection points)
        {
            PenWidth = penWidth;
            PenColor = penColor;
            Points = points.ToArray<Point>();
        }



        protected override Geometry DefiningGeometry
        {
            get
            {
                if (Points == null || Points.Length < 2)
                    return Geometry.Empty;

                PathGeometry geometry = new PathGeometry();
                PathFigure figure = new PathFigure();

                figure.StartPoint = Points[0];

                for (int i = 1; i < Points.Length; i++)
                {
                    figure.Segments.Add(new LineSegment(Points[i], true));
                }

                geometry.Figures.Add(figure);
                return geometry;
            }
        }

        public override bool isComplex()
        {
            return true;
        }
    }
}
