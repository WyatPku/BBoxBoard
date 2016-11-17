using BBoxBoard.BasicDraw;
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
                var pCanvas = e.GetPosition(Mycanvas);
                Canvas.SetLeft(targetElement, pCanvas.X - targetPoint.X);
                Canvas.SetTop(targetElement, pCanvas.Y - targetPoint.Y);
            }
        }

        private void Mycanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(null);
        }

        private void Mycanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var targetElement = e.Source as IInputElement;
            if (targetElement != null)
            {
                targetPoint = e.GetPosition(targetElement);
                targetElement.CaptureMouse();
            }
        }

        private void UpdateList()
        {
            this.listView.Items.Clear();
        }
    }
}
