using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixCal
{
    public class Matrix
    {
        int lineCount, colCount;
        decimal[,] data;
        public Matrix()
        {
          
        }
        public Matrix(int lCount, int cCount)
        {
            lineCount = lCount;
            colCount = cCount;
            data = new decimal[lineCount, colCount];
        }
        public int getLineCount
        {
            get { return lineCount; }
        }
        public int getColCount
        {
            get { return colCount; }
        }
        public decimal[,] Data
        {
            get { return data; }
            set { data = value; }
        }


    }

}
