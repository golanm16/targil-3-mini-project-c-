using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dotnetwpf_03_8585_5779b
{
    public class PrinterEventArgs : EventArgs
    {
        readonly public bool crit;
        readonly public DateTime errDT;
        readonly public string errtxt;
        readonly public string printerName;
        public PrinterEventArgs(bool f, DateTime dt, string errt, string pname)
        {
            crit = f;
            errDT = dt;
            errtxt = errt;
            printerName = pname;
        }
        public override string ToString()
        {
            string str=null;
            str += "Time: " + this.errDT + "\n";
            str += "Printer: " + this.printerName + "\n" ;
            str += "Error: " + this.errtxt + "\n";
            if (crit)
                str += "Critical Error!";
            else
                str += "non-Critical Error.";
            return str;
        }
    }
}
