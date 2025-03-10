using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPaint.Services
{

    internal class MyShapeCreatorsSingleton
    {
        private static List<IMyShapeCreator> _myShapeCreatorsToTools =
            new List<IMyShapeCreator>()
            {
                { new MyRectangleCreator() },
                { new MyLineCreator() },
                { new MyEllipseCreator() },
                { new MyIsoscelesTriangleCreator() }
            };
        private MyShapeCreatorsSingleton() { }
        public static IMyShapeCreator GetInstance(int index)
        {
            if (_myShapeCreatorsToTools.Count <= index)
                return null;
            return _myShapeCreatorsToTools[index];
        }
        public static void AddCreator(IMyShapeCreator myShapeCreator)
        {
            _myShapeCreatorsToTools.Add(myShapeCreator);
        }
    }
}
