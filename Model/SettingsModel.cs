using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace OOPaint.Model
{
    internal class SettingsModel
    {
        public Color BrushColor = Color.FromRgb(0, 0, 0);
        public Color PenColor = Color.FromRgb(0, 0, 0);
        public double PenWidth = 0;
        public int curToolIndex = 0;
    }
}
