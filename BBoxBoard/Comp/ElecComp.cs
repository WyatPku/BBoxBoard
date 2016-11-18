﻿using BBoxBoard.BasicDraw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BBoxBoard.Comp
{
    public abstract class ElecComp
    {
        protected ShapeSet shapeSet;
        protected IntPoint XYPoint;
        protected IntPoint size;
        protected Canvas canvas;

        public ElecComp()
        {
            shapeSet = new ShapeSet();
            XYPoint = new IntPoint(0, 0);
            size = new IntPoint(MainWindow.GridLen, MainWindow.GridLen);
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
            XYPoint.X += deltaX;
            XYPoint.Y += deltaY;
            MoveShapeSet(deltaX, deltaY);
        }
        private void MoveShapeSet(int deltaX, int deltaY)
        {
            foreach (MyShape myShape in shapeSet.arr)
            {
                myShape.Move(deltaX, deltaY);
            }
        }
        public bool IfInRegion(IntPoint P0)
        {
            if (XYPoint.X > P0.X || XYPoint.X < P0.X - size.X) return false;
            if (XYPoint.Y > P0.Y || XYPoint.Y < P0.Y - size.Y) return false;
            return true;
        }
        public void RemoveAllFrom(Canvas canvas)
        {
            shapeSet.RemoveAllFrom(canvas);
        }
    }
}
