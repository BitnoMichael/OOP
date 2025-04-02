using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace OOPaint
{
    internal class SettingsModel
    {
        public Color BrushColor { get; set; }
        public Color PenColor { get; set; }
        public double PenWidth { get; set; }
        public int curToolIndex { get; set; } 
        public SettingsModel(Color brushColor, Color penColor, double penWidth, int curToolIndex)
        {
            BrushColor = brushColor;
            PenColor = penColor;
            PenWidth = penWidth;
            this.curToolIndex = curToolIndex;
        }
    }
}
