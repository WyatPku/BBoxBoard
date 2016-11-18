using BBoxBoard.BasicDraw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace BBoxBoard.Comp
{
    public abstract class ElecComp
    {
        public const int State_Move = 0;
        public const int State_AdjRight = 1;

        protected ShapeSet shapeSet;
        protected IntPoint XYPoint;
        protected IntPoint size;
        protected Canvas canvas;
        protected List<IntPoint> RelativeInterface;
        protected int RotatedState = 0;
        public bool IsWire;
        public int State;

        public ElecComp()
        {
            shapeSet = new ShapeSet();
            XYPoint = new IntPoint(0, 0);
            size = new IntPoint(MainWindow.GridLen, MainWindow.GridLen);
            RelativeInterface = new List<IntPoint>();
            State = State_Move;
            IsWire = false;
            AddShapes();
        }

        public virtual void AddShapes() { }
        public void ShowIn(Canvas canvas_)
        {
            canvas = canvas_;
            foreach (MyShape myShape in shapeSet.arr) {
                myShape.ShowAt(canvas, XYPoint);
            }
        }
        public void SetPosition(int X, int Y)
        {
            XYPoint.X = X;
            XYPoint.Y = Y;
        }
        public void Move(int deltaX, int deltaY)
        {
            switch (State)
            {
                case State_Move:
                    XYPoint.X += deltaX;
                    XYPoint.Y += deltaY;
                    MoveShapeSet(deltaX, deltaY);
                    break;
                case State_AdjRight:
                    AdjRight(deltaX, deltaY);
                    break;
            }
        }
        private void MoveShapeSet(int deltaX, int deltaY)
        {
            foreach (MyShape myShape in shapeSet.arr)
            {
                myShape.Move(deltaX, deltaY);
            }
        }
        public virtual void AdjRight(int deltaX, int deltaY)
        {
            //do nothing
        }
        public bool IfInRegion(IntPoint P0)
        {
            if (size.X > 0)
            {
                if (P0.X < XYPoint.X || P0.X > XYPoint.X + size.X) return false;
            }
            else
            {
                if (P0.X > XYPoint.X || P0.X < XYPoint.X + size.X) return false;
            }
            if (size.Y > 0)
            {
                if (P0.Y < XYPoint.Y || P0.Y > XYPoint.Y + size.Y) return false;
            }
            else
            {
                if (P0.Y > XYPoint.Y || P0.Y < XYPoint.Y + size.Y) return false;
            }
            return true;
        }
        public void RemoveAllFrom(Canvas canvas)
        {
            shapeSet.RemoveAllFrom(canvas);
        }
        public void RotateLeft()
        {
            RotatedState++;
            RotatedState %= 4;
            shapeSet.RotateLeftAround(XYPoint);
            foreach (IntPoint intPoint in RelativeInterface)
            {
                RotatePointAround(intPoint, XYPoint);
            }
            int sizeX = size.X;
            int sizeY = size.Y;
            size.X = sizeY;
            size.Y = -sizeX;
        }
        private void RotatePointAround(IntPoint itface, IntPoint center)
        {
            int deltaX = itface.X - center.X;
            int deltaY = itface.Y - center.Y;
            itface.X = center.X + deltaY;
            itface.Y = center.Y - deltaX;
        }
        protected void InitiateWireBetween(IntPoint A, IntPoint B)
        {
            //左边的导线
            MyShape line1 = new MyShape(MyShape.Shape_Line);
            line1.GetLine().Stroke = System.Windows.Media.Brushes.Red;
            line1.GetLine().X1 = A.X;
            line1.GetLine().Y1 = A.Y;
            line1.GetLine().X2 = 0;
            line1.GetLine().Y2 = 0;
            line1.GetLine().StrokeThickness = 5;
            shapeSet.AddShape(line1);
            //右边的导线
            MyShape line2 = new MyShape(MyShape.Shape_Line);
            line2.GetLine().Stroke = System.Windows.Media.Brushes.Red;
            line2.GetLine().X1 = 0;
            line2.GetLine().Y1 = 0;
            line2.GetLine().X2 = B.X;
            line2.GetLine().Y2 = B.Y;
            line2.GetLine().StrokeThickness = 5;
            shapeSet.AddShape(line2);
            //按照折线标准绘图
            DrawBetween(A, B);
        }
        private void DrawBetween(IntPoint A, IntPoint B)
        {
            if (shapeSet.IsPossibleWire())
            {
                Line line1 = shapeSet.arr[0].GetLine();
                Line line2 = shapeSet.arr[1].GetLine();
                Ellipse point1 = shapeSet.arr[2].GetEllipse();
                Ellipse point2 = shapeSet.arr[3].GetEllipse();
                IntPoint C = new IntPoint(); //用来记录中间转折点的信息
                int deltaX = B.X - A.X;
                int deltaY = B.Y - A.Y;
                if (Math.Abs(deltaX) == Math.Abs(deltaY))
                {
                    //在一条斜线上，不需要中间转折
                    line1.X1 = A.X;
                    line1.Y1 = A.Y;
                    line1.X2 = A.X;
                    line1.Y2 = A.Y;
                    Canvas.SetLeft(point1, A.X - point1.Width / 2);
                    Canvas.SetTop(point1, A.Y - point1.Height / 2);
                    Canvas.SetLeft(point2, B.X - point2.Width / 2);
                    Canvas.SetTop(point2, B.Y - point2.Height / 2);
                    return;
                }
            }
        }
    }
}
