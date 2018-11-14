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

namespace Dotnetwpf_03_8585_5779b
{

    /// <summary>
    /// Interaction logic for PrinterUserControl.xaml
    /// </summary>
    //public delegate void PrinterEventHandler(object obj, PrinterEventArgs e);
    public partial class PrinterUserControl : UserControl
    {
        static Random r = new Random();
        static public int printerNum = 1;
        const double MAX_INK = 100;
        const double MIN_ADD_INK = MAX_INK / 10.0;
        const double MAX_PRINT_INK = 14.5;
        const int MAX_PAGES = 400;
        const int MIN_ADD_PAGES = MAX_PAGES / 10;
        const int MAX_PRINT_PAGES = 55;
        public PrinterUserControl()
        {
            InitializeComponent();
            this.PrinterNameLabel.Content = "Printer " + printerNum++;
            inkCountProgressBar.Value = r.Next((int)MIN_ADD_INK, (int)MAX_INK);
            pageCountSlider.Value = r.Next(MIN_ADD_PAGES, MAX_PAGES);
        }
        private void PrinterNameLabel_MouseEnter(object sender, MouseEventArgs e)
        {
            PrinterNameLabel.FontSize += 10;
        }
        private void PrinterNameLabel_MouseLeave(object sender, MouseEventArgs e)
        {
            PrinterNameLabel.FontSize -= 10;
        }
        public void Print()
        {
            PageCount -= r.Next(MAX_PRINT_PAGES);
            InkCount -= r.Next((int)MAX_PRINT_INK);
        }
        //public event PrinterEventHandler PageMissing;
        //public event PrinterEventHandler InkEmpty;
        public event EventHandler<PrinterEventArgs> PageMissing;
        public event EventHandler<PrinterEventArgs> InkEmpty;
        protected virtual void OnInkEmpty(bool crit,double ink)
        {
            if (InkEmpty != null)
                InkEmpty(this, new PrinterEventArgs(crit, DateTime.Now, "Ink remaining: " + ink, this.PrinterName));
        }
        protected virtual void OnPageMissing(int a)
        {
            pageLabel.Foreground = Brushes.Red;
            if (PageMissing!=null)
                PageMissing(this, new PrinterEventArgs(true, DateTime.Now, "Pages missing: "+a, this.PrinterName));
        }
        public string PrinterName
        {
            get=> (string)PrinterNameLabel.Content;
            private set=> PrinterNameLabel.Content = value;
        }
        public int PageCount
        {
            get=>(int)pageCountSlider.Value;
            private set
            {
                if (value < 0)
                {
                    OnPageMissing(value*(-1));
                }
                else
                    pageCountSlider.Value = value;
            }
        }
        public double InkCount
        {
            get=>inkCountProgressBar.Value;
            private set
            {
                if (value < 15 && value >= 10)
                {
                    OnInkEmpty(false, value);
                    inkCountProgressBar.Foreground = Brushes.Yellow;
                    inkCountProgressBar.Value = value;
                }
                else if (value < 10 && value >= 1)
                {
                    OnInkEmpty(false, value);
                    inkCountProgressBar.Foreground = Brushes.Orange;
                    inkCountProgressBar.Value = value;
                }
                else if (value <1)
                {
                    if(value<0)
                        OnInkEmpty(true, 0);
                    else
                        OnInkEmpty(true, value);
                    inkCountProgressBar.Foreground = Brushes.Red;
                    inkCountProgressBar.Value = value;
                }
                else 
                    inkCountProgressBar.Value = value;
            }
        }
        public void AddPages()
        {
            pageCountSlider.Value += r.Next(MIN_ADD_PAGES, MAX_PAGES);
            pageLabel.Foreground = Brushes.Black;
        }
        public void AddInk()
        {
            inkCountProgressBar.Value += r.Next((int)MIN_ADD_INK, (int)MAX_INK);
            if(InkCount<15&&InkCount>=10)
                inkCountProgressBar.Foreground = Brushes.Yellow;
            else if (InkCount < 10 && InkCount >= 1)
                inkCountProgressBar.Foreground = Brushes.Orange;
            else if (InkCount < 1)
                inkCountProgressBar.Foreground = Brushes.Red;
            else
                inkCountProgressBar.Foreground = Brushes.LimeGreen;
        }
        public static double MaxPages
        {
            get=> MAX_PAGES;
        }
    }
}
