using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UIForm
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            InitApp initapp = new InitApp();
            initapp.Init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TaskSubmitor());
            
            //多线程用来检查数据备份

        }
    }
}
