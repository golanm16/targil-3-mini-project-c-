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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Queue<PrinterUserControl> queue;
        PrinterUserControl Currentprinter;
        public MainWindow()
        {
            InitializeComponent();
            
            queue = new Queue<PrinterUserControl>();

            foreach (Control item in PrinterGrid.Children)
            {
                if (item is PrinterUserControl)
                {
                    
                    Currentprinter = item as PrinterUserControl;
                    Currentprinter.PageMissing += onitempagesmissing;
                    Currentprinter.InkEmpty += oniteminkempty;
                    queue.Enqueue(Currentprinter);
                }
            }
        }

        public void onitempagesmissing(object obj,PrinterEventArgs e)
        {
            MessageBox.Show(e.ToString(), "Error");
            Currentprinter.AddPages();
            queue.Enqueue(queue.Dequeue());
        }
        public void oniteminkempty(object obj, PrinterEventArgs e)
        {
            if (e.crit)
               // Currentprinter.AddInk();
            if (e.crit)
            {
                queue.Enqueue(queue.Dequeue());
            }
            MessageBox.Show(e.ToString(), "Error");
            
            
        }

        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            Currentprinter = queue.Peek();
            Currentprinter.Print();
            if (Currentprinter.InkCount < 1 ) //Temporary!!!
                Currentprinter.AddInk();
            }
    }
   
}
