using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace BBoxBoard.BasicDraw
{
    public class DrawEllipse
    {
        Canvas canvas;

        public DrawEllipse(Canvas canvas_)
        {
            canvas = canvas_;
        }
        public void Draw(int x, int y, int R = 40)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Fill = System.Windows.Media.Brushes.Black;
            ellipse.StrokeThickness = 4;
            ellipse.Stroke = System.Windows.Media.Brushes.LightGoldenrodYellow;
            ellipse.Width = 2*R;
            ellipse.Height = 2*R;
            Canvas.SetLeft(ellipse, x - R);
            Canvas.SetTop(ellipse, y - R);
            canvas.Children.Add(ellipse);
        }
    }
}
