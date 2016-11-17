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

        public MainWindow()
        {
            InitializeComponent();
            DrawLine drawLine = new DrawLine(Mycanvas);
            DrawEllipse drawEllipse = new DrawEllipse(Mycanvas);
            drawEllipse.Draw(0, 0);
            drawEllipse.Draw(CanvasWidth, CanvasHeight);
            UpdateList();
        }
        private void UpdateList()
        {
            this.listView.Items.Clear();
        }
    }
}
