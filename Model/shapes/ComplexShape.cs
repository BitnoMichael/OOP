using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace OOPaint
{
    [Serializable]
    public class ComplexShape: IShape
    {
        private PointCollection _points;
        public PointCollection Points { get { return _points;} set { _points = value; } }
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
            set { _penWidth = value; }
        }
    }
}
