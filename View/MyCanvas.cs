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
        public bool IsDrawing { get; set; } = false;
        public MyShape CurShape { get; set; } = null;
        public IMyShapeCreator CurShapeCreator { get; set; } = null;
        private Stack<MyShape> ShapeStack = new Stack<MyShape>();
        public PointCollection SettedPoints { get; set; } = new PointCollection();
        public void AddShape(MyShape shape)
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
    }
}
