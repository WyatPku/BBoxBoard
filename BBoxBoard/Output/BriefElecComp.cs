using BBoxBoard.BasicDraw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BBoxBoard.Output
{
    public class BriefElecComp
    {
        public const int Comp_Wire = 0;
        public const int Comp_Resistance = 1;
        public const int Comp_Capacity = 2;

        public int Comp;
        public List<IntPoint> Interfaces; //这个列表是按顺序来的，对于二极管这种，是有正负极先后顺序的

        public BriefElecComp(int Comp_, List<IntPoint> Interfaces_)
        {
            Comp = Comp_;
            Interfaces = Interfaces_;
        }

        public override string ToString()
        {
            String A = "";
            switch (Comp)
            {
                case Comp_Wire:
                    A += "Wire:";
                    break;
                case Comp_Resistance:
                    A += "Resistance:";
                    break;
                case Comp_Capacity:
                    A += "Capacity:";
                    break;
                default:
                    return "UNKNOWN";
            }
            foreach (IntPoint intPoint in Interfaces)
            {
                A += "(" + intPoint.X + "," + intPoint.Y + ")";
            }
            return A;
        }
    }
}
