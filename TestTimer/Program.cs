using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTimer
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler((sender, e) =>
            {
                MessageBox.Show(e.Exception.ToString(), "例外発生");
                Application.Exit();
            });
            System.Threading.Thread.GetDomain().UnhandledException += new UnhandledExceptionEventHandler((sender, e) =>
            {
                Exception exception = e.ExceptionObject as Exception;
                if (exception != null)
                {
                    MessageBox.Show(exception.ToString(), "例外発生");
                    Application.Exit();
                }
            });
            Application.Run(new MainForm());
        }
    }
}
