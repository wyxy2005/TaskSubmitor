using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UIForm
{
    public class UiUtil
    {
        /// <summary>
        /// 判断所需要的临时文件是否存在
        /// </summary>
        /// <returns></returns>
        public static bool ExistTempDir()
        {
            if (Directory.Exists(sys.Default.TempDir))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 创建临时目录。判断如果不存在sys.Default.TempDir的处理方案
        /// </summary>
        public static void CreateTempDir()
        {
            if (ExistTempDir())
                return;
            else 
            {
                try
                {
                    Directory.CreateDirectory(sys.Default.TempDir);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
