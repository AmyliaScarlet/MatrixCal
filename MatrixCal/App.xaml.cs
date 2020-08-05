using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace MatrixCal
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
             base.OnStartup(e);
             //注册Application_Error
             this.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);
         }

  
         void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
         {
            //MessageBox.Show(e.Exception.Message + "\n" + e.Exception.StackTrace);
            e.Handled = true;
         }
    }
}
