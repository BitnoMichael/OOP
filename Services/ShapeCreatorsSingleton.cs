using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOPaint.Services
{
    internal class ShapeCreatorsSingleton
    {
        private static ShapeCreatorsSingleton _instance = new ShapeCreatorsSingleton();
        private List<IShapeCreator> _shapeCreatorsToTools =
            new List<IShapeCreator>()
            {
                {new RectangleCreator() },
                {new LineCreator() },
                {new EllipseCreator() },
                {new TriangleCreator() },
                {new BrokenLineCreator() },
                {new PolygonCreator() }
            };

        private Dictionary<Type, IShapeCreator> _shapeCreatorsToMyShapesTypes =
            new Dictionary<Type, IShapeCreator>()
            {
                { typeof(MyRectangle), new RectangleCreator() },
                { typeof(MyLine), new LineCreator() },
                { typeof(MyEllipse), new EllipseCreator() },
                { typeof(MyIsoscelesTriangle), new TriangleCreator() },
                { typeof(MyBrokenLineCreator), new BrokenLineCreator() },
                { typeof(MyPolygon), new PolygonCreator() }
            };
        private ShapeCreatorsSingleton() { }
        public static ShapeCreatorsSingleton GetInstance()
        {
            return _instance;
        }
        public IShapeCreator GetCreator(int index)
        {
            if (_shapeCreatorsToTools.Count <= index)
                return null;
            return _shapeCreatorsToTools[index];
        }
        public IShapeCreator GetCreator(Type type)
        {
            if (_shapeCreatorsToMyShapesTypes.TryGetValue(type, out var shapeCreator))
                return shapeCreator;
            else
                return null;
        }
        public void AddCreator(IShapeCreator shapeCreator, Type myShapeType)
        {
            _shapeCreatorsToTools.Add(shapeCreator);
            _shapeCreatorsToMyShapesTypes.Add(myShapeType.GetType(), shapeCreator);
        }
    }
}
