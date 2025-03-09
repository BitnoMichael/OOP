using System;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace OOPaint
{
    [Serializable]
    public abstract class MyShape
    {
        private Point _point1;
        public Point OuterPoint1
        {
            get { return _point1; }
            set { _point1 = value; }
        }
        private Point _point2;
        public Point OuterPoint2
        {
            get { return _point2; }
            set { _point2 = value; }
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
            }
        }

        private double _penWidth;
        public double PenWidth
        {
            get { return _penWidth; }
            set { _penWidth = value;}
        }
    }
}