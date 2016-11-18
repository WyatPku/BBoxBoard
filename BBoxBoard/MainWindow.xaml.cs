﻿using BBoxBoard.BasicDraw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BBoxBoard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const int CanvasWidth = 985;
        public const int CanvasHeight = 715;
        Point targetPoint;

        public MainWindow()
        {
            InitializeComponent();
            DrawLine drawLine = new DrawLine(Mycanvas);
            DrawEllipse drawEllipse = new DrawEllipse(Mycanvas);
            drawEllipse.Draw(0, 0);
            drawEllipse.Draw(CanvasWidth, CanvasHeight);
            UpdateList();
            this.Mycanvas.MouseDown += Mycanvas_MouseDown;
            this.Mycanvas.MouseUp += Mycanvas_MouseUp;
            this.Mycanvas.MouseMove += Mycanvas_MouseMove;
        }

        private void Mycanvas_MouseMove(object sender, MouseEventArgs e)
        {
            var targetElement = Mouse.Captured as UIElement;
            if (e.LeftButton == MouseButtonState.Pressed && targetElement != null)
            {
                Point pCanvas = e.GetPosition(Mycanvas);
                textBox.Text = "X:" + pCanvas.X + "\nY:" + pCanvas.Y;
            }
        }

        private void Mycanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(null);
            //取消正在移动的东西，并刷新电路网格
        }

        private void Mycanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var targetElement = e.Source as IInputElement;
            if (targetElement != null)
            {
                targetElement.CaptureMouse();
                /*
                 * 点下的时候判断有没有选中某一个电子元件
                 * 如果选中了，记录状态，记录初始位置和初始光标位置
                 * Move的时候一直跟着动，但是位置不是鼠标的位置，而是贴合位置
                 * 这和第一次放上去元件是一样的，只能放在格点上
                 */
            }
        }

        private void UpdateList()
        {
            this.listView.Items.Clear();
        }
    }
}
