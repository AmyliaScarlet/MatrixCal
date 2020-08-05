using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MatrixCal
{
    public class MatrixUtil
    {
        /// <summary>
        /// 计算矩阵加法
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static Matrix MatrixAdd(Matrix m1, Matrix m2)
        {
            int lc1 = m1.getLineCount;
            int cc1 = m1.getColCount;
            int lc2 = m2.getLineCount;
            int cc2 = m2.getColCount;

            if ((lc1 != lc2) || (cc1 != cc2))
            {
                throw new CalException("数组行列数不符合原则");
            }

            Matrix matrix = new Matrix(lc1, cc1);
            decimal[,] c = matrix.Data;
            decimal[,] a = m1.Data;
            decimal[,] b = m2.Data;

            for (int i = 0; i < lc1; i++)
                for (int j = 0; j < cc1; j++)
                    c[i, j] = a[i, j] + b[i, j];
            return matrix;
        }

        /// <summary>
        /// 计算矩阵减法
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static Matrix MatrixSub(Matrix m1, Matrix m2)
        {
            int lc1 = m1.getLineCount;
            int cc1 = m1.getColCount;
            int lc2 = m2.getLineCount;
            int cc2 = m2.getColCount;
            if ((lc1 != lc2) || (cc1 != cc2))
            {
                throw new CalException("数组行列数不符合原则");
            }
            Matrix Mc = new Matrix(lc1, cc1);
            decimal[,] c = Mc.Data;
            decimal[,] a = m1.Data;
            decimal[,] b = m2.Data;

            for (int i = 0; i < lc1; i++)
                for (int j = 0; j < cc1; j++)
                    c[i, j] = a[i, j] - b[i, j];
            return Mc;
        }

        /// <summary>
        /// 计算矩阵乘法
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static Matrix MatrixMul(Matrix m1, Matrix m2)
        {
            int lc1 = m1.getLineCount;
            int cc1 = m1.getColCount;
            int lc2 = m2.getLineCount;
            int cc2 = m2.getColCount;

            if (cc1 != lc2)
            {
                throw new CalException("数组行列数不符合原则");
            }

            Matrix Mc = new Matrix(lc1, cc2);
            decimal[,] c = Mc.Data;
            decimal[,] a = m1.Data;
            decimal[,] b = m2.Data;

            for (int i = 0; i < lc1; i++)
                for (int j = 0; j < cc2; j++)
                {
                    c[i, j] = 0;
                    for (int k = 0; k < cc1; k++)
                        c[i, j] += a[i, k] * b[k, j];
                }
            return Mc;

        }

        /// <summary>
        /// 计算矩阵数乘
        /// </summary>
        /// <param name="num"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Matrix MatrixNumMul(decimal num, Matrix matrix)
        {
            int lc1 = matrix.getLineCount;
            int cc1 = matrix.getColCount;
            Matrix Mc = new Matrix(lc1, cc1);
            decimal[,] c = Mc.Data;
            decimal[,] a = matrix.Data;

            for (int i = 0; i < lc1; i++)
                for (int j = 0; j < cc1; j++)
                    c[i, j] = a[i, j] * num;
            return Mc;
        }

        /// <summary>
        /// 矩阵行转列
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Matrix MatrixTrans(Matrix matrix)
        {
            int lc1 = matrix.getLineCount;
            int cc1 = matrix.getColCount;
            Matrix matrixNew = new Matrix(cc1, lc1);
            decimal[,] c = matrixNew.Data;
            decimal[,] a = matrix.Data;
            for (int i = 0; i < cc1; i++)
                for (int j = 0; j < lc1; j++)
                    c[i, j] = a[j, i];
            return matrixNew;
        }

        /// <summary>
        /// 矩阵右转
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Matrix MatrixTransRight(Matrix matrix)
        {
            int lc1 = matrix.getLineCount;
            int cc1 = matrix.getColCount;
            Matrix matrixNew = new Matrix(cc1, lc1);
            decimal[,] c = matrixNew.Data;
            decimal[,] a = matrix.Data;
            for (int i = 0; i < cc1; i++)
                for (int j = 0; j < lc1; j++)
                    c[i, lc1-j-1] = a[j, i];
            return matrixNew;
        }

        /// <summary>
        /// 矩阵左转
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Matrix MatrixTransLeft(Matrix matrix)
        {
            int lc1 = matrix.getLineCount;
            int cc1 = matrix.getColCount;
            Matrix matrixNew = new Matrix(cc1, lc1);
            decimal[,] c = matrixNew.Data;
            decimal[,] a = matrix.Data;
            for (int i = 0; i < cc1; i++)
                for (int j = 0; j < lc1; j++)
                    c[cc1-i-1,j] = a[j, i];
            return matrixNew;
        }

        /// <summary>
        /// 矩阵左右镜像
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Matrix MatrixTransMirror(Matrix matrix)
        {
            return MatrixTransLeft(MatrixTransLeft(MatrixTransLeft(MatrixTrans(matrix))));
        }
        

        /// <summary>
        /// 计算逆矩阵
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Matrix MatrixInverse(Matrix matrix)
        {
            Matrix mnm = null;
            decimal d = MatrixDTM(matrix);
            if (d == 0)
            {
                throw new CalException("没有逆矩阵");
            }
            else 
            {
                Matrix mc = MatrixFollow(matrix);
                mnm = MatrixNumMul(1 / d, mc);
            }
            return mnm;
        }

        /// <summary>
        /// 计算矩阵的行列式
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        public static decimal MatrixDTM(Matrix ma)
        {
            decimal d = 0;
            int lc1 = ma.getLineCount;
            int cc1 = ma.getColCount;
            if (lc1 != cc1)
            {
                throw new CalException("行列数不相等");
            }
            else 
            {
                decimal[,] a = ma.Data;
                if (cc1 == 1) return a[0, 0];

                for (int i = 0; i < cc1; i++)
                {
                    d += a[1, i] * MatrixDTM(MatrixSpa(ma, 1, i));
                }
            }
      
            return d;
        }

        /// <summary>
        /// 计算矩阵的伴随矩阵
        /// </summary>
        /// <param name="ma"></param>
        /// <returns></returns>
        public static Matrix MatrixFollow(Matrix ma)
        {
            int lc1 = ma.getLineCount;
            int cc1 = ma.getColCount;
            Matrix m = new Matrix(lc1, cc1);
            decimal[,] c = m.Data;
            decimal[,] a = ma.Data;

            for (int i = 0; i < lc1; i++) {
                for (int j = 0; j < cc1; j++) {
                    c[i, j] = MatrixDTM(MatrixSpa(ma, j, i));
                }
            }
          
            return m;
        }

        /// <summary>
        /// 对应行列式的代数余子式矩阵
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="indexI"></param>
        /// <param name="indexJ"></param>
        /// <returns></returns>
        public static Matrix MatrixSpa(Matrix matrix, int indexI, int indexJ)
        {
            Matrix matrixNew = null;
            int lc1 = matrix.getLineCount;
            int cc1 = matrix.getColCount;
            if (lc1 != cc1)
            {
                throw new CalException("矩阵不是方阵");
            }
            else 
            {
                int cc2 = cc1 - 1;
                matrixNew = new Matrix(cc2, cc2);
                decimal[,] a = matrix.Data;
                decimal[,] b = matrixNew.Data;

                //左上
                for (int i = 0; i < indexI; i++)
                    for (int j = 0; j < indexJ; j++)
                    {
                        b[i, j] = a[i, j];
                    }
                //右下
                for (int i = indexI; i < cc2; i++)
                    for (int j = indexJ; j < cc2; j++)
                    {
                        b[i, j] = a[i + 1, j + 1];
                    }
                //右上
                for (int i = 0; i < indexI; i++)
                    for (int j = indexJ; j < cc2; j++)
                    {
                        b[i, j] = a[i, j + 1];
                    }
                //左下
                for (int i = indexI; i < cc2; i++)
                    for (int j = 0; j < indexJ; j++)
                    {
                        b[i, j] = a[i + 1, j];
                    }
                //符号位
                if ((indexI + indexJ) % 2 != 0)
                {
                    for (int i = 0; i < cc2; i++)
                        b[i, 0] = -b[i, 0];

                }
            }
            return matrixNew;

        }
    }
}
