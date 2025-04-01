using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace OOPaint
{
    internal class ShapeModel
    {
        private Stack<MyShape> shapes;
        public MyShape GetLast()
        {
            return shapes.Peek();
        }
        public MyShape PollLast()
        {
            return shapes.Pop();
        }
        public void Add(MyShape shape)
        {
            shapes.Push(shape);
        }
        public List<MyShape> getShapesAsList()
        {
            return new List<MyShape>(shapes.ToList());
        }
        public ShapeModel(ICollection<MyShape> shapes)
        {
            this.shapes = new Stack<MyShape>(shapes);
        }
        public ShapeModel()
        {
            this.shapes = new Stack<MyShape>();
        }
    }
}
