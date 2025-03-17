using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace OOPaint
{
    public class MyCanvas : Canvas
    {
        public bool IsDrawing = false;
        public Shape CurShape = null;
        public IShapeCreator CurShapeCreator = null;
        private Stack<Shape> ShapeStack = new Stack<Shape>();
        public PointCollection SettedPoints = new PointCollection();
        public void AddShape(Shape shape)
        {
            Children.Add(shape);
            ShapeStack.Push(shape);
        }
        public void Undo()
        {
            if (ShapeStack.Count > 0)
            {
                Children.Remove(ShapeStack.Pop());
            }
        }
        public void ChangeShape(Shape shape, Point secondPoint)
        {

        }
    }
}
