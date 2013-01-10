using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace GitHelper
{
    /// <summary>
    /// 说明：基于只有Msysgit软件下所提供的服务
    /// 作者：ChengNing
    /// 日期：2012-12-27
    /// </summary>
    public class MSysGit
    {
        private const string GIT_EXE = @"D:\Program Files\Git\cmd\git.exe";
        private string repoWorkPath;

        public MSysGit(string repoWorkPath)
        {
            this.repoWorkPath = repoWorkPath;
        }
        /// <summary>
        /// 执行GIT程序,调用msysgit
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private string ExeGit(string arg)
        {
            string result = "";
            Process tmerger = new Process();
            //try
            //{
            tmerger.StartInfo.FileName = GIT_EXE;
            tmerger.StartInfo.Arguments = arg;
            tmerger.StartInfo.RedirectStandardOutput = true;//允许重定向输出
            tmerger.StartInfo.RedirectStandardError = true;
            tmerger.StartInfo.UseShellExecute = false;
            tmerger.StartInfo.WorkingDirectory = this.repoWorkPath;
            tmerger.Start();
            result = tmerger.StandardOutput.ReadToEnd();
            tmerger.WaitForExit();
            //}
            //catch (Exception ex)
            //{
            //result = ex.TargetSite.Name + "error";
            //}
            //finally
            //{
            tmerger.Close();
            //}
            return result;
        }

        public string Init()
        {
            string result = "";
            if (string.IsNullOrEmpty(this.repoWorkPath))
                result = "没有指定版本库目录";
            else if (!Directory.Exists(this.repoWorkPath))
                Directory.CreateDirectory(this.repoWorkPath);
            result = ExeGit(@"init");
            return result;
        }

        public string Commit(string comment)
        {
            string result = "";
            result = ExeGit(@"commit -m '" + comment + "'");
            return result;
        }


        public string Add()
        {
            return "";
        }

        public string Diff(string file)
        {
            return ExeGit("diff " + file);
        }

        public string DiffFileList()
        {
            return ExeGit("diff --stat");
        }
    }
}
