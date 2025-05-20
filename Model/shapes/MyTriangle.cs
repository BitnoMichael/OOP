using System;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPaint
{
    [Serializable]
    internal class MyIsoscelesTriangle : MyShape
    {
        public MyIsoscelesTriangle(SerializationInfo info, StreamingContext context)
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
        public MyIsoscelesTriangle(Color brushColor, Color penColor, double penWidth, Point point1, Point point2)
        {
            BrushColor = brushColor;
            PenColor = penColor;
            PenWidth = penWidth;
            Points = new Point[2]
            {
                point1,
                point2
            };
        }

        protected override Geometry DefiningGeometry
        {
            get
            {
                if (Points == null || Points.Length < 2)
                    return Geometry.Empty;

                // Calculate the base points and height
                Point basePoint1 = new Point(Points[0].X, Points[1].Y);
                Point basePoint2 = Points[1];
                Point apexPoint = new Point((Points[0].X + Points[1].X) / 2, Points[0].Y);

                // Create the triangle geometry
                PathGeometry triangleGeometry = new PathGeometry();
                PathFigure triangleFigure = new PathFigure();

                // Start at the apex point
                triangleFigure.StartPoint = apexPoint;

                // Add lines to base points
                triangleFigure.Segments.Add(new LineSegment(basePoint1, true));
                triangleFigure.Segments.Add(new LineSegment(basePoint2, true));

                // Close the triangle
                triangleFigure.IsClosed = true;

                triangleGeometry.Figures.Add(triangleFigure);
                return triangleGeometry;
            }
        }

        public override bool isComplex()
        {
            return false;
        }
    }
}