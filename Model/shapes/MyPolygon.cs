using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPaint
{
    [Serializable]
    internal class MyPolygon : MyShape
    {
        public MyPolygon(SerializationInfo info, StreamingContext context)
        {
            var points = (Point[])info.GetValue("points", typeof(Point[]));

            var brushR = info.GetByte("brushColorR");
            var brushG = info.GetByte("brushColorG");
            var brushB = info.GetByte("brushColorB");

            var penR = info.GetByte("penColorR");
            var penG = info.GetByte("penColorG");
            var penB = info.GetByte("penColorB");

            var penWidth = info.GetDouble("penWidth");

            PenWidth = penWidth;
            PenColor = Color.FromRgb(penR, penG, penB);
            BrushColor = Color.FromRgb(brushR, brushG, brushB);
            Points = points;
        }
        public MyPolygon(Color brushColor, Color penColor, double penWidth, PointCollection points)
        {
            BrushColor = brushColor;
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

                // Start from the first point
                figure.StartPoint = Points[0];

                // Add line segments for all other points
                for (int i = 1; i < Points.Length; i++)
                {
                    figure.Segments.Add(new LineSegment(Points[i], true));
                }

                // Close the polygon by connecting back to the first point
                figure.IsClosed = true;

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