using System;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPaint
{
    [Serializable]
    internal class MyLine : MyShape
    {
        public MyLine(SerializationInfo info, StreamingContext context)
        {
            var points = (Point[])info.GetValue("points", typeof(Point[]));

            var penR = info.GetByte("penColorR");
            var penG = info.GetByte("penColorG");
            var penB = info.GetByte("penColorB");

            var penWidth = info.GetDouble("penWidth");

            PenWidth = penWidth;
            PenColor = Color.FromRgb(penR, penG, penB);
            Points = points;
        }
        public MyLine(Color strokeColor, double strokeWidth, Point point1, Point point2)
        {
            BrushColor = strokeColor;
            PenColor = strokeColor;  // Для линии цвет обводки и заливки обычно одинаковый
            PenWidth = strokeWidth;

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

                // Создаем геометрию линии между двумя точками
                LineGeometry lineGeometry = new LineGeometry(Points[0], Points[1]);
                return lineGeometry;
            }
        }

        public override bool isComplex()
        {
            return false;
        }
    }
}