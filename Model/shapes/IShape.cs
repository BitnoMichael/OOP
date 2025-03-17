using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows;
using System.Windows.Media;

namespace OOPaint
{
    public interface IShape
    {
        Color BrushColor
        {
            get; set;
        }
        Color PenColor
        {
            get; set;
        }
        double PenWidth
        {
            get; set;
        }
    }
}
