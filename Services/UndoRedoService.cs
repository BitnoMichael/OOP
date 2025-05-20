using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace OOPaint
{
    internal class UndoRedoService
    {
        private UIElementCollection _shapesDI;
        private readonly Stack<Shape> undoStack = new Stack<Shape>();
        private readonly Stack<Shape> redoStack = new Stack<Shape>();
        private void PushToStack(object sender, EventArgs e)
        {
            Shape shapeToPush = (e as MyCanvasOnAddEventArgs).AddedShape;
            redoStack.Push(shapeToPush);
        }
        public void Add(Shape shape)
        {
            _shapesDI.Add(shape);
            undoStack.Push(shape);
            redoStack.Clear();
        }
        public void Undo()
        {
            if (undoStack.Count == 0)
                return;

            var undoShape = undoStack.Pop();
            redoStack.Push(undoShape);
            _shapesDI.Remove(undoShape);
        }
        public void Redo()
        {
            if (redoStack.Count == 0)
                return;

            var redoShape = redoStack.Pop();
            undoStack.Push(redoShape);
            _shapesDI.Add(redoShape);
        }
        public UndoRedoService(UIElementCollection shapes)
        {
            this._shapesDI = shapes;
        }
    }
}
