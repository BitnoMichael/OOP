using System;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace OOPaint.Shapes
{
    [Serializable]
    internal abstract class DrawableShape
    {
        private Point _point1;
        public Point Point1
        {
            get { return _point1; }
            set
            {
                _point1 = value;
                RefreshSize();
            }
        }
        private Point _point2;
        public Point Point2
        {
            get { return _point2; }
            set
            {
                _point2 = value;
                RefreshSize();
            }
        }
        private byte _brushColorA;
        private byte _brushColorR;
        private byte _brushColorG;
        private byte _brushColorB;
        public Color BrushColor
        {
            get { return Color.FromArgb(_brushColorA, _brushColorR, _brushColorG, _brushColorB); }
            set
            {
                _brushColorA = value.A;
                _brushColorR = value.R;
                _brushColorG = value.G;
                _brushColorB = value.B;
                Figure.Fill = new SolidColorBrush(BrushColor);
            }
        }

        private byte _penColorA;
        private byte _penColorR;
        private byte _penColorG;
        private byte _penColorB;
        public Color PenColor
        {
            get { return Color.FromArgb(_penColorA, _penColorR, _penColorG, _penColorB); }
            set
            {
                _penColorA = value.A;
                _penColorR = value.R;
                _penColorG = value.G;
                _penColorB = value.B;
                Figure.Fill = new SolidColorBrush(BrushColor);
            }
        }

        private double _penWidth;
        public double PenWidth
        {
            get { return _penWidth; }
            set
            {
                _penWidth = value;
                Figure.StrokeThickness = _penWidth;
            }
        }
        public abstract void RefreshSize();
        public void ValidateView()
        {
            if (Figure == null)
                Figure = ShapeFactory.CreateShape(this.GetType(), BrushColor, PenColor, PenWidth, Point1);
            BrushColor = BrushColor;
            PenColor = PenColor;
            PenWidth = PenWidth;
            RefreshSize();
        }
        public abstract Shape Figure { get; set; }
    }
}