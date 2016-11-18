using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace BBoxBoard.BasicDraw
{
    public class MyShape
    {
        public const int Shape_Line = 1;
        public const int Shape_Rectangle = 2;

        Shape shape;
        int WHAT;

        public MyShape(int WHAT_)
        {
            WHAT = WHAT_;
            switch (WHAT)
            {
                case Shape_Line:
                    shape = new Line();
                    break;
                case Shape_Rectangle:
                    shape = new Rectangle();
                    break;
            }
        }

        public Line GetLine()
        {
            if (WHAT == Shape_Line) return (Line)shape;
            return null;
        }

        public Rectangle GetRectangle()
        {
            if (WHAT == Shape_Rectangle) return (Rectangle)shape;
            return null;
        }

        public void ShowAt(Canvas canvas, IntPoint point)
        {
            switch (WHAT)
            {
                case Shape_Line:
                    Line line = (Line)shape;
                    line.X1 += point.X;
                    line.X2 += point.X;
                    line.Y1 += point.Y;
                    line.Y2 += point.Y;
                    canvas.Children.Add(line);
                    break;
                case Shape_Rectangle:
                    Rectangle rectangle = (Rectangle)shape;
                    Canvas.SetLeft(rectangle, point.X);
                    Canvas.SetTop(rectangle, point.Y);
                    canvas.Children.Add(rectangle);
                    break;
            }
        }

        public void Move(int deltaX, int deltaY)
        {
            switch (WHAT)
            {
                case Shape_Line:
                    Line line = (Line)shape;
                    line.X1 += deltaX;
                    line.X2 += deltaX;
                    line.Y1 += deltaY;
                    line.Y2 += deltaY;
                    break;
                case Shape_Rectangle:
                    Rectangle rectangle = (Rectangle)shape;
                    double X = Canvas.GetLeft(rectangle);
                    double Y = Canvas.GetTop(rectangle);
                    Canvas.SetLeft(rectangle, X);
                    Canvas.SetTop(rectangle, Y);
                    break;
            }
        }
    }
}
