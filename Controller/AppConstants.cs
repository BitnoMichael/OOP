using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace OOPaint
{
    public class AppConstants
    {
        public static Dictionary<int, IShapeCreator> shapeCreatorsToTools =
            new Dictionary<int, IShapeCreator>()
            {
                { 0, new RectangleCreator() },
                { 1, new LineCreator() },
                { 2, new EllipseCreator() },
                { 3, new TriangleCreator() }
            };
        public static Dictionary<int, IMyShapeCreator> myShapeCreatorsToTools =
            new Dictionary<int, IMyShapeCreator>()
            {
                { 0, new MyRectangleCreator() },
                { 1, new MyLineCreator() },
                { 2, new MyEllipseCreator() },
                { 3, new MyIsoscelesTriangleCreator() }
            };
        public static Dictionary<Type, IShapeCreator> shapeCreatorsToMyShapesTypes =
            new Dictionary<Type, IShapeCreator>()
            {
                { typeof(MyRectangle), new RectangleCreator() },
                { typeof(MyLine), new LineCreator() },
                { typeof(MyEllipse), new EllipseCreator() },
                { typeof(MyIsoscelesTriangle), new TriangleCreator() }
            };
    }
}
