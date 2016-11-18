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
    public class ElecCompSet
    {
        List<ElecComp> elecSet;
        public ElecComp pressedElecComp;

        public ElecCompSet()
        {
            elecSet = new List<ElecComp>();
            pressedElecComp = null;
        }

        public bool FoundPressedElecComp(IntPoint point)
        {
            foreach (ElecComp elecComp in elecSet)
            {
                if (elecComp.IfInRegion(point))
                {
                    pressedElecComp = elecComp;
                    return true;
                }
            }
            return true;
        }
        public void ReleaseElecComp()
        {
            pressedElecComp = null;
        }
        
        public void AddComp(ElecComp elecComp)
        {
            elecSet.Add(elecComp);
        }

        public void ShowAll(Canvas canvas)
        {
            foreach (ElecComp elecComp in elecSet)
            {
                elecComp.ShowIn(canvas);
            }
        }
    }
}
