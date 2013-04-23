using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SharpSvn;

namespace SvnHelper
{
    public class SvnTest
    {
        private const string REPO_URL = @"https://lg4n.googlecode.com/svn/trunk/";
        private const string WORKSPACE = @"E:\Project\svn\lg4n";

        private const string USERNAME = @"";
        private const string PASSWORD = @"";


        public static void Test()
        {
            SvnTest test = new SvnTest();
            string testfile = WORKSPACE + @"\test";
            test.Add(testfile);
        }

        private void SvnHello()
        {
            using (SvnClient client = new SvnClient())
            {
                string repoURL = REPO_URL;
                string workspace = WORKSPACE;
                SvnInfoEventArgs info;
                client.GetInfo(new Uri(repoURL),out info);
                Console.WriteLine(info.Revision.ToString());

                SvnImportArgs import = new SvnImportArgs();
                import.LogMessage = "import test";
                client.Import(workspace + "test.txt",new Uri(repoURL),import);

                client.Update(workspace);
            }
 
        }

        /// <summary>
        /// 不能添加多层次文件，必须先添加文件夹，在添加指定的文件
        /// </summary>
        /// <param name="path"></param>
        private void Add(string path)
        {
            using (SvnClient client = new SvnClient())
            {
                SvnAddArgs args = new SvnAddArgs();
                args.Force = true;
                args.Depth = SvnDepth.Infinity;
                client.Add(path,args);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {
            using (SvnClient client = new SvnClient())
            {
                client.Update(WORKSPACE);
            }
        }

        private void Commit(string file,string message)
        {
            using (SvnClient client = new SvnClient())
            {
                SvnCommitArgs args = new SvnCommitArgs();
                args.LogMessage = message;
                client.Commit(file, args);
            }
        }

        /// <summary>
        /// 整个版本库
        /// </summary>
        /// <returns></returns>
        private IList<string> Diff()
        {
            IList<string> diffFiles = new List<string>();
            using (SvnClient client = new SvnClient())
            {
                client.Status(WORKSPACE, new SvnStatusArgs
                {
                    Depth = SvnDepth.Infinity,
                    ThrowOnError = true,
                    RetrieveRemoteStatus = true,
                    Revision = SvnRevision.Head
                }, new EventHandler<SvnStatusEventArgs>(
                    delegate(object s, SvnStatusEventArgs e) {
                        switch (e.LocalContentStatus)
                        {
                            case SvnStatus.Normal: break;
                            case SvnStatus.None: break;
                            case SvnStatus.NotVersioned: break;
                            case SvnStatus.Added: break;
                            case SvnStatus.Missing: break;
                            case SvnStatus.Modified: break;
                            case SvnStatus.Conflicted: break;
                            default: break;
                        }
                        switch (e.RemoteContentStatus)
                        {
                            case SvnStatus.Normal: break;
                            case SvnStatus.None: break;
                            case SvnStatus.NotVersioned: break;
                            case SvnStatus.Added: break;
                            case SvnStatus.Missing: break;
                            case SvnStatus.Modified: break;
                            case SvnStatus.Conflicted: break;
                            default: break;
                        }
                    }));
                
            }
            return diffFiles;
        }


        /// <summary>
        /// 某个文件或者目录
        /// </summary>
        /// <param name="path"></param>
        private IList<string> Diff(string path)
        {
            IList<string> diffFiles = new List<string>();
            using (SvnClient client = new SvnClient())
            {
                //SvnTarget svnTarget = 
                //client.Diff()
            }
            return diffFiles;
        }

        /// <summary>
        /// check for modification
        /// </summary>
        /// <returns></returns>
        private IList<string> Modify()
        {
            IList<string> diffFiles = new List<string>();
            using (SvnClient client = new SvnClient())
            {
                SvnCommitArgs cm = new SvnCommitArgs();
                SvnChangeListCollection list = cm.ChangeLists;
                foreach( string item in list )
                {
                    Console.WriteLine(item);
                }
            }
            return diffFiles;
        }

        /// <summary>
        /// 整个版本库的日志
        /// </summary>
        private void Log()
        { 
        }

        /// <summary>
        /// 指定某个目录或者文件的日志
        /// </summary>
        /// <param name="path"></param>
        private void Log(string path)
        { 
        }
    }
}
