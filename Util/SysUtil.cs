using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Util
{
    /// <summary>
    /// 系统工具，针对系统级操作
    /// 
    /// 作者:ChengNing
    /// 日期：2012-12-14
    /// 
    /// </summary>
    public static class SysUtil
    {
        /// <summary>
        /// 打开目录
        /// </summary>
        /// <param name="path"></param>
        public static void OpenDir(string path)
        {
            System.Diagnostics.Process.Start("explorer.exe", path);
        }
    }
}
