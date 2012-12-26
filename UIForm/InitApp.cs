using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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
        public static void Init()
        {
            InitTemplate();
        }

        public static void InitTemplate()
        {
            if (!Directory.Exists(@"..\Template"))
                Directory.CreateDirectory(@"..\Template");
        }
    }
}
