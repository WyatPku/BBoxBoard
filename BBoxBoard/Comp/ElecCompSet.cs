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
        private int pressedIndex;

        public ElecCompSet()
        {
            elecSet = new List<ElecComp>();
            pressedElecComp = null;
        }

        public bool FoundPressedElecComp(IntPoint point)
        {
            for (int i=0; i<elecSet.Count; i++)
            {
                if (elecSet[i].IfInRegion(point))
                {
                    pressedElecComp = elecSet[i];
                    pressedIndex = i;
                    return true;
                }
            }
            return false;
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

        public void DeleteNowPressed(Canvas canvas)
        {
            if (pressedElecComp != null)
            {
                pressedElecComp.RemoveAllFrom(canvas);
                elecSet.Remove(pressedElecComp);
            }
        }
    }
}
