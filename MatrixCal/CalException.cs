using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MatrixCal
{
    public class CalException : Exception
    {
        public override string ToString()
        {
            return base.Message + "\n" + base.StackTrace; ;
        }

        public CalException(String str)
        {
            MessageBox.Show(str);
        }

    }
}
