using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPaint.Services
{

    internal class MyShapeCreatorsSingleton
    {
        private static MyShapeCreatorsSingleton _instance = null;
        private static readonly object syncRoot = new object();

        private List<IMyShapeCreator> _myShapeCreatorsToTools =
            new List<IMyShapeCreator>()
            {
                { new MyRectangleCreator() },
                { new MyLineCreator() },
                { new MyEllipseCreator() },
                { new MyIsoscelesTriangleCreator() },
                { new MyBrokenLineCreator()},
                { new MyPolygonCreator()}
            };
        private MyShapeCreatorsSingleton() { }
        public static MyShapeCreatorsSingleton GetInstance()
        {
            if (_instance == null)
                lock (syncRoot)
                    _instance = new MyShapeCreatorsSingleton();
            return _instance;
        }

        public IMyShapeCreator GetCreator(int index)
        {
            if (_myShapeCreatorsToTools.Count <= index)
                return null;
            return _myShapeCreatorsToTools[index];
        }
        public bool IsComplexShapeCreator(int index)
        {
            return _instance._myShapeCreatorsToTools[index].CreateShape
                (
                    new System.Windows.Media.Color(),
                    new System.Windows.Media.Color(),
                    0,
                    new System.Windows.Media.PointCollection(
                        new System.Windows.Point[]
                        {
                            new System.Windows.Point(),
                            new System.Windows.Point()
                        }
                    )
                ).isComplex();
        }
        public void AddCreator(IMyShapeCreator myShapeCreator)
        {
            _myShapeCreatorsToTools.Add(myShapeCreator);
        }
    }
}
