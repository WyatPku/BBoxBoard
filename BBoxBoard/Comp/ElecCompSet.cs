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
            for (int i=0; i<elecSet.Count; i++)
            {
                //MessageBox.Show("Founding:" + i + "\nX:" + point.X + "\nY:" + point.Y);
                if (elecSet[i].IfInRegion(point))
                {
                    pressedElecComp = elecSet[i];
                    //MessageBox.Show("pressedElecComp" + pressedElecComp);
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
    }
}
