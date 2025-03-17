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
        private Stack<IShape> shapes;
        public IShape GetLast()
        {
            return shapes.Peek();
        }
        public IShape PollLast()
        {
            return shapes.Pop();
        }
        public void Add(IShape shape)
        {
            shapes.Push(shape);
        }
        public List<IShape> getShapesAsList()
        {
            return new List<IShape>(shapes.ToList());
        }
        public ShapeModel(ICollection<IShape> shapes)
        {
            this.shapes = new Stack<IShape>(shapes);
        }
        public ShapeModel()
        {
            this.shapes = new Stack<IShape>();
        }
    }
}
