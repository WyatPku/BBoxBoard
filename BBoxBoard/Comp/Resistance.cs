using BBoxBoard.BasicDraw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBoxBoard.Comp
{
    public class Resistance : ElecComp
    {


        public Resistance() : base() { }

        public override void AddShapes()
        {
            //必须重新设置元件大小
            size.X = 60;
            size.Y = 20;
            //结束必须设置
            MyShape line1 = new MyShape(MyShape.Shape_Line);
            line1.GetLine().Stroke = System.Windows.Media.Brushes.Red;
            line1.GetLine().X1 = 0;
            line1.GetLine().Y1 = 10;
            line1.GetLine().X2 = 30;
            line1.GetLine().Y2 = 10;
            line1.GetLine().StrokeThickness = 5;
            shapeSet.AddShape(line1);
            MyShape rectangle = new MyShape(MyShape.Shape_Rectangle);
            rectangle.GetRectangle().Width = 30;
            rectangle.GetRectangle().Height = 30;
            shapeSet.AddShape(rectangle);
        }
    }
}
