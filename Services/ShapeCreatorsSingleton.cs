using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPaint.Services
{
    internal class ShapeCreatorsSingleton
    {
        private static List<IShapeCreator> _shapeCreatorsToTools =
            new List<IShapeCreator>()
            {
                {new RectangleCreator() },
                {new LineCreator() },
                {new EllipseCreator() },
                {new TriangleCreator() }
            };

        private static Dictionary<Type, IShapeCreator> _shapeCreatorsToMyShapesTypes =
            new Dictionary<Type, IShapeCreator>()
            {
                { typeof(MyRectangle), new RectangleCreator() },
                { typeof(MyLine), new LineCreator() },
                { typeof(MyEllipse), new EllipseCreator() },
                { typeof(MyIsoscelesTriangle), new TriangleCreator() }
            };
        private ShapeCreatorsSingleton() { }
        public static IShapeCreator GetInstance(int index)
        {
            if (_shapeCreatorsToTools.Count <= index)
                return null;
            return _shapeCreatorsToTools[index];
        }
        public static IShapeCreator GetInstance(Type type)
        {
            if (_shapeCreatorsToMyShapesTypes.TryGetValue(type, out var shapeCreator))
                return shapeCreator;
            else
                return null;
        }
        public static void AddCreator(IShapeCreator shapeCreator, Type myShapeType)
        {
            _shapeCreatorsToTools.Add(shapeCreator);
            _shapeCreatorsToMyShapesTypes.Add(myShapeType.GetType(), shapeCreator);
        }
    }
}
