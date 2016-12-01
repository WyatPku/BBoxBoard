using BBoxBoard.Comp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace BBoxBoard.Equipment
{
    /// <summary>
    /// Interaction logic for Ohmmeter.xaml
    /// </summary>
    public partial class Ohmmeter : Window
    {
        private OhmMeter ohmmterClass;
        public ShowingData showingData;

        public Ohmmeter(OhmMeter ohmmterClass_)
        {
            InitializeComponent();
            ohmmterClass = ohmmterClass_;
            showingData = ohmmterClass.showingData;
            this.textBlock.DataContext = showingData;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            //必须通过拖动来关闭窗口
            if (ohmmterClass.CanbeClosed)
            {
                base.OnClosing(e);
            }
            else
            {
                showingData.SimpleData = "huhuhu";
                e.Cancel = true;
            }
        }
    }
    
}
