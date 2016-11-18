using BBoxBoard.BasicDraw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBoxBoard.Comp
{
    public class Wire : ElecComp
    {
        public Wire() : base() { }

        public override void AddShapes()
        {
            //指定这是电线
            IsWire = true;
            //必须重新设置元件大小
            size.X = 60;
            size.Y = 20;
            //定义外部接口的位置
            IntPoint A = new IntPoint(0, 0);
            IntPoint B = new IntPoint(20, 10);
            RelativeInterface.Add(A); //左端口
            RelativeInterface.Add(A); //右端口
            InitiateWireBetween(A, B);
        }
    }
}
