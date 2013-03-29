using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BLL
{
    /// <summary>
    /// 上线操作的业务逻辑操作
    /// 作者：ChengNing
    /// 日期：2013-01-05
    /// </summary>
    public class ToOnline
    {
        private string onlineDir;
        private string devDir;

        public ToOnline() { }

        public ToOnline(string devDir,string onlineDir)
        {
            this.devDir = devDir;
            this.onlineDir = onlineDir;
        }

        /// <summary>
        /// 复制单个文件
        /// </summary>
        /// <param name="fileFullName">从工作区开始的文件名称，带有路径</param>
        public void CopyFile(string fileFullName)
        {
            FileInfo file = new FileInfo(this.devDir + @"\" + fileFullName);
            file.CopyTo(this.onlineDir + @"\" + fileFullName, true);
        }

        /// <summary>
        /// 复制一个文件列表
        /// </summary>
        /// <param name="fileFullNameList"></param>
        public void CopyFile(string[] fileFullNameList)
        {
            foreach (string filename in fileFullNameList)
            {
                CopyFile(filename.Trim());
            }
        }
    }
}
