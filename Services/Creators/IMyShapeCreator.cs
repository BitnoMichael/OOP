using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
namespace OOPaint
{
    public interface IMyShapeCreator
    {
        MyShape CreateShape(Color brushColor, Color penColor, double penWidth, PointCollection points);
        void TransformShape(MyShape shape, PointCollection points, Point endPoint);
    }
}
