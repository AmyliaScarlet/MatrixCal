using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace MatrixCal
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Init();
        }
        private void Init()
        {
            BottomLabel.Content += DateTime.Now.Year.ToString(); 



        }
        private void Left_Click(object sender, RoutedEventArgs e)
        {
            Console.Out.WriteLine(sender);

            Matrix matrix = Util.StrToMatrix(tbM.Text);

            matrix = MatrixUtil.MatrixTransLeft(matrix);

            Util.MatrixToStr(matrix, tbC);

        }
        private void Right_Click(object sender, RoutedEventArgs e)
        {
            Console.Out.WriteLine(sender);

            Matrix matrix = Util.StrToMatrix(tbM.Text);

            matrix = MatrixUtil.MatrixTransRight(matrix);

            Util.MatrixToStr(matrix, tbC);
        }
        private void LtoC_Click(object sender, RoutedEventArgs e)
        {
            Console.Out.WriteLine(sender);

            Matrix matrix = Util.StrToMatrix(tbM.Text);

            matrix = MatrixUtil.MatrixTrans(matrix);

            Util.MatrixToStr(matrix, tbC);
        }
        private void Mirro_Click(object sender, RoutedEventArgs e)
        {
            Console.Out.WriteLine(sender);

            Matrix matrix = Util.StrToMatrix(tbM.Text);

            matrix = MatrixUtil.MatrixTransMirror(matrix);

            Util.MatrixToStr(matrix, tbC);
        }
        private void Un_Click(object sender, RoutedEventArgs e)
        {
            Console.Out.WriteLine(sender);

            Matrix matrix = Util.StrToMatrix(tbM.Text);

            matrix = MatrixUtil.MatrixInverse(matrix);

            Util.MatrixToStr(matrix, tbC);
        }
        private void LC_Click(object sender, RoutedEventArgs e)
        {
            Console.Out.WriteLine(sender);

            Matrix matrix = Util.StrToMatrix(tbM.Text);

            tbC.Text = MatrixUtil.MatrixDTM(matrix).ToString();
        }
        private void Follow_Click(object sender, RoutedEventArgs e)
        {
            Console.Out.WriteLine(sender);

            Matrix matrix = Util.StrToMatrix(tbM.Text);

            matrix = MatrixUtil.MatrixFollow(matrix);

            Util.MatrixToStr(matrix, tbC);
        }
        private void Spa_Click(object sender, RoutedEventArgs e)
        {
            Console.Out.WriteLine(sender);

            Matrix matrix = Util.StrToMatrix(tbM.Text);

            var xy = tbM2.Text.Split(',');
            matrix = MatrixUtil.MatrixSpa(matrix, int.Parse(xy[0]), int.Parse(xy[1]));

            Util.MatrixToStr(matrix, tbC);
        }
        private void addRB_Checked(object sender, RoutedEventArgs e)
        {
            Console.Out.WriteLine(sender);
            Constants.rbType = Enum.RbType.add;
        }
        private void deRB_Checked(object sender, RoutedEventArgs e)
        {
            Console.Out.WriteLine(sender);
            Constants.rbType = Enum.RbType.de;
        }
        private void mulRB_Checked(object sender, RoutedEventArgs e)
        {
            Console.Out.WriteLine(sender);
            Constants.rbType = Enum.RbType.mul;
        }
        private void nummulRB_Checked(object sender, RoutedEventArgs e)
        {
            Console.Out.WriteLine(sender);
            Constants.rbType = Enum.RbType.nummul;
        }

        private void Cal_Click(object sender, RoutedEventArgs e)
        {
            Console.Out.WriteLine(sender);
            Matrix matrix = null;
            switch (Constants.rbType) 
            {
                case Enum.RbType.add:
                    matrix = MatrixUtil.MatrixAdd(Util.StrToMatrix(tbM.Text), Util.StrToMatrix(tbM2.Text));
                    break;
                case Enum.RbType.de:
                    matrix = MatrixUtil.MatrixSub(Util.StrToMatrix(tbM.Text), Util.StrToMatrix(tbM2.Text));
                    break;
                case Enum.RbType.mul:
                    matrix = MatrixUtil.MatrixMul(Util.StrToMatrix(tbM.Text), Util.StrToMatrix(tbM2.Text));
                    break;
                case Enum.RbType.nummul:
                    decimal k = 0;
                    try {
                        k = int.Parse(tbM2.Text);
                    }
                    catch {
                        MessageBox.Show("数乘时右边输入数字");
                        return;
                    }
                    matrix = MatrixUtil.MatrixNumMul(k, Util.StrToMatrix(tbM.Text));
                    break;
                default:
                    MessageBox.Show("请选择运算方式");
                    return;

            }
            Util.MatrixToStr(matrix, tbC);

        }

        private void helpLab_MouseDown(object sender, MouseButtonEventArgs e)
        {
            String s = @"
                1.本软件上方两个为输入框，左侧主输入框，右侧副输入框，下方为输出框，计算遵循矩阵计算基本原则。
                2.请默认使用主输入框，只需单对象输入的及多对象输入的第一个矩阵对象用主输入框。（例：数乘时矩阵用主，数字用副；行列式求值用主；余子式矩阵矩阵用主，坐标用副）。
                3.矩阵数字用英文逗号隔开，矩阵最后不用换行。
                4.余子式矩阵要选择的元素的坐标（从0起）写在副输入框，英文逗号隔开（例：1,2）。
                ";
            MessageBox.Show(s);

        }


    }
}
