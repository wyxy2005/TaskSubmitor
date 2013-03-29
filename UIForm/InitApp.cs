using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Util;
using log4net;
using System.Reflection;

namespace UIForm
{
    /// <summary>
    /// 系统启动初期需要设置的
    /// 
    /// 作者：ChengNing
    /// 日期：2012-12-14
    /// </summary>
    public class InitApp
    {
        /// <summary>
        /// 初始化应用程序
        /// </summary>
        public void Init()
        {
            InitTemplate();
            InitFolder();
        }

        public void InitTemplate()
        {
            if (!Directory.Exists(@"..\Template"))
                Directory.CreateDirectory(@"..\Template");
            if (!File.Exists(@"data\data.xml"))
            {
                SysUtil.CreateDataFile();
            }
            InitLog();
        }

        private void InitFolder()
        {
            InitFolder(sys.Default.OnlineDir);
            
            InitFolder(sys.Default.CloseTaskDir);
        }

        private void InitFolder(string folder)
        {
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
        }

        private static void InitLog()
        {
            ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            log.Info("启动程序");
        }

    }
}
