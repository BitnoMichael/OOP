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
    internal class DrawingCanvas : Canvas
    {
        public Color BrushColor = Color.FromRgb(0, 0, 0);
        public Color PenColor = Color.FromRgb(0, 0, 0);
        public double PenWidth = 0;
        public bool IsDrawing = false;
        public Shapes.DrawableShape CurShape = null;
        public Stack<Shapes.DrawableShape> Model = new Stack<Shapes.DrawableShape>();
        public Point startPoint;
        public void AddShape(Shapes.DrawableShape shape)
        {
            MessageBox.Show($"Фигура: {shape.Figure}, Координаты: {Canvas.GetLeft(shape.Figure)} aboba{Canvas.GetTop(shape.Figure)},{shape.Figure.ActualHeight}{shape.Figure.ActualWidth} Видимость: {shape.Figure.Visibility}");
            Children.Add(shape.Figure);
            Model.Push(shape);
        }
        public void Undo()
        {
            if (Model.Count > 0)
            {
                Children.Remove(Model.Pop().Figure);
            }
        }
        public void ValidateView()
        {
            Children.Clear();
            foreach (Shapes.DrawableShape item in Model)
            { 
                Children.Add(item.Figure);
            }
        }
        public void drawShape(Shapes.DrawableShape curShape, Point point)
        {
            MessageBox.Show($"Фигура: {curShape.Figure}, Координаты: {Canvas.GetLeft(curShape.Figure)} aboba{Canvas.GetTop(curShape.Figure)},1:\"{curShape.Figure.Height}\"2:\"{curShape.Figure.Width}\" Видимость: {curShape.Figure.Visibility}");
            curShape.Point1 = startPoint;
            curShape.Point2 = point;
        }
    }
}
