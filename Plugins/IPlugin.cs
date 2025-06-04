using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace OOPaint
{
    public interface IPlugin
    {
        IMyShapeCreator MyShapeCreator { get; }
        string Name { get; }
    }
}
