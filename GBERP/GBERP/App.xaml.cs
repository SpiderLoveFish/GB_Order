using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GBERP
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainWindow RootWindow;
        public static Action<string> Alert;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CN");
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("zh-CN");
            Alert = new Action<string>((msg) => { MessageBox.Show(msg); });
            RootWindow = new MainWindow();
            RootWindow.Show();

        }
    }
}
