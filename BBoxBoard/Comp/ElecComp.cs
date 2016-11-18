using BBoxBoard.BasicDraw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BBoxBoard.Comp
{
    public abstract class ElecComp
    {
        protected ShapeSet shapeSet;

        public ElecComp()
        {
            shapeSet = new ShapeSet();
            AddShapes();
        }

        public virtual void AddShapes() { }
        public void ShowAt(Canvas canvas, Point point)
        {
            foreach (MyShape myShape in shapeSet.arr) {
                myShape.ShowAt(canvas, point);
            }
        }
    }
}
