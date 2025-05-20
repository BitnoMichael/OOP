using System;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPaint
{
    [Serializable]
    internal class MyRectangle : MyShape
    {
        public MyRectangle(SerializationInfo info, StreamingContext context)
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

        public MyRectangle(Color brushColor, Color penColor, double penWidth, Point point1, Point point2)
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

                // Calculate rectangle parameters
                double x = Math.Min(Points[0].X, Points[1].X);
                double y = Math.Min(Points[0].Y, Points[1].Y);
                double width = Math.Abs(Points[1].X - Points[0].X);
                double height = Math.Abs(Points[1].Y - Points[0].Y);

                // Create rectangle geometry
                RectangleGeometry rectangleGeometry = new RectangleGeometry(new Rect(x, y, width, height));
                return rectangleGeometry;
            }
        }

        public override bool isComplex()
        {
            return false;
        }
    }
}