﻿using BBoxBoard.BasicDraw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBoxBoard.BasicDraw
{
    public class ShapeSet
    {
        public List<MyShape> arr;

        public ShapeSet()
        {
            arr = new List<MyShape>();
        }

        public void AddShape(MyShape myShape)
        {
            arr.Add(myShape);
        }
    }
}