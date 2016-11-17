using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace BBoxBoard.BasicDraw
{
    public class DrawLine
    {
        public DrawLine(Canvas canvas)
        {
            Line line = new Line();
            line.Stroke = System.Windows.Media.Brushes.Red;
            line.X1 = 0;
            line.Y1 = 0;
            line.X2 = MainWindow.CanvasWidth;
            line.Y2 = MainWindow.CanvasHeight;
            line.StrokeThickness = 5;
            canvas.Children.Add(line);
        }
    }
}
