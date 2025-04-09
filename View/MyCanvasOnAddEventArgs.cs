using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace OOPaint
{
    internal class MyCanvasOnAddEventArgs : EventArgs
    {
        public Shape AddedShape {get;set;}
        public MyCanvasOnAddEventArgs(Shape shape) 
        {  
            AddedShape = shape;
        }
    }
}
