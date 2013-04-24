using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpSvn;
using System.Collections.ObjectModel;

namespace SvnHelper
{
    /// <summary>
    /// 封装SVN操作
    /// </summary>
    public class Svn
    {
        private string repoUrl;
        private string workspace;

        private const string REPO_URL = @"https://lg4n.googlecode.com/svn/trunk/";
        private const string WORKSPACE = @"E:\Project\svn\lg4n";

        private const string USERNAME = @"";
        private const string PASSWORD = @"";

        public Svn()
        { 
        }

        public Svn(string workspace)
        {
            this.workspace = workspace;
        }

        public Svn(string workspace, string repoUrl)
        {
            this.workspace = workspace;
            this.repoUrl = repoUrl;
        }


        /// <summary>
        /// 不能添加多层次文件，必须先添加文件夹，在添加指定的文件
        /// svn add
        /// </summary>
        /// <param name="path">需要添加的目录或者文件</param>
        public void Add(string path)
        {
            using (SvnClient client = new SvnClient())
            {
                SvnAddArgs args = new SvnAddArgs();
                args.Force = true;
                args.Depth = SvnDepth.Infinity;
                client.Add(path, args);
            }
        }


        /// <summary>
        /// svn update
        /// </summary>
        public void Update()
        {
            using (SvnClient client = new SvnClient())
            {
                client.Update(this.workspace);
            }
        }

        /// <summary>
        /// svn commit
        /// 提交工作区中的改变到版本库
        /// </summary>
        /// <param name="path">需要提交的目录或者文件</param>
        /// <param name="message">提交说明</param>
        private void Commit(string path, string message)
        {
            using (SvnClient client = new SvnClient())
            {
                SvnCommitArgs args = new SvnCommitArgs();
                args.LogMessage = message;
                client.Commit(path, args);
            }
        }


        /// <summary>
        /// svn log
        /// 整个版本库的日志
        /// </summary>
        private void Log()
        {
            using (SvnClient client = new SvnClient())
            {

                System.Collections.ObjectModel.Collection<SvnLogEventArgs> logEventArgs;

                client.GetLog(WORKSPACE, out logEventArgs);
                foreach (var log in logEventArgs)
                {
                    Console.WriteLine(log.Revision + "  " + log.Author + "  " + log.Time + "  " + log.LogMessage);
                    //Console.WriteLine(log.ChangedPaths)
                    foreach (var p in log.ChangedPaths)
                    {
                        Console.WriteLine(p.Path + "  " + p.NodeKind.ToString() + "  " + p.RepositoryPath);
                    }
                }

            }
        }


        /// <summary>
        /// 工作区与版本库之间修改列表
        /// </summary>
        private void ChangeList()
        {
            using (SvnClient client = new SvnClient())
            {
                Collection<SvnStatusEventArgs> statuslist = new Collection<SvnStatusEventArgs>();

                SvnStatusArgs args = new SvnStatusArgs();
                args.Depth = SvnDepth.Infinity;

                client.GetStatus(WORKSPACE, out statuslist);

                foreach (var item in statuslist)
                {
                    Console.WriteLine(item.Path + "  " + item.LocalNodeStatus);
                }

            }
        }


        /// <summary>
        /// 两个版本之间的不同
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        private void deff(string from, string to)
        {
            using (SvnClient client = new SvnClient())
            {
                SvnPathTarget path1 = new SvnPathTarget(WORKSPACE, SvnRevision.One);
                SvnUriTarget path2 = new SvnUriTarget(WORKSPACE, SvnRevision.Head);
                Collection<SvnDiffSummaryEventArgs> diffEvents = new Collection<SvnDiffSummaryEventArgs>();

                client.GetDiffSummary(path1, path2, out diffEvents);

                foreach (var item in diffEvents)
                {
                    Console.WriteLine(item.Path + " " + item.NodeKind + " " + item.DiffKind);
                }

            }
        }

    }
}
