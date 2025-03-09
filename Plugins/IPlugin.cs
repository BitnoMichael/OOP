using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace OOPaint
{
    internal interface IPlugin
    {
        IShapeCreator ShapeCreator { get; }
        IMyShapeCreator MyShapeCreator { get; }
        Shape Shape { get; }
        string Name { get; }
    }
}
