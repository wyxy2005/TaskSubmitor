using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace GitHelper
{
    /// <summary>
    /// 说明:基于系统已经安装的TortoiseGIT来提供服务。
    /// 作者：ChengNing
    /// 日期：2012-12-27
    /// </summary>
    public class TortoiseGit
    {

        private string tortoiseMerge; //=  @"D:\Program Files\TortoiseGit\bin\TortoiseMerge.exe";
        
        public TortoiseGit(string tortoiseGitRootPath)
        { 
            this.tortoiseMerge = tortoiseGitRootPath + @"\bin\TortoiseMerge.exe";
        }

        public void Diff(string fileAPath,string fileBPath)
        {
            string argu = fileAPath + " " + fileBPath;
            Process tmerger = new Process();
            tmerger.StartInfo.FileName = this.tortoiseMerge;
            tmerger.StartInfo.Arguments = argu;
            tmerger.Start();
        }
    }
}
