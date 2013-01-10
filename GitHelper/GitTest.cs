using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using NGit.Api;
using NGit;
using System.IO;
using Sharpen;

namespace GitHelper
{
   
    public class GitTest
    {
        public static void Test()
        {
            MSysGit git = new MSysGit(@"D:\test");
            string re = git.Init();
            Console.WriteLine(re);
        }

        public static void TestNGit()
        {
            //FilePath directory = new FilePath(@"F:\git\test");
            //Repository repo = new 
            //InitCommand command = new InitCommand();
            //command.SetDirectory(directory);
            //Git git = command.Call();
            //git.
            //Git.Init();
        }

        public static void Init(string path)
        {
            Process tmerger = new Process();
            tmerger.StartInfo.FileName = @"D:\Program Files\Git\cmd\git.exe";
            tmerger.StartInfo.Arguments = @"init " + path;
            tmerger.StartInfo.RedirectStandardOutput = true;//允许重定向输出
            tmerger.StartInfo.RedirectStandardError = true;
            tmerger.StartInfo.UseShellExecute = false;
            tmerger.Start();
            string result = tmerger.StandardOutput.ReadToEnd();
            tmerger.WaitForExit();
            tmerger.Close();
            Console.WriteLine(result);
        }

        public static void TestTortoiseDiff()
        {
            Process tmerger = new Process();
            tmerger.StartInfo.FileName = @"D:\Program Files\TortoiseGit\bin\TortoiseMerge.exe";
            tmerger.StartInfo.Arguments = @"D:\AB-G-Pro\src\TestOra.java D:\AB-G-Pro\src\FileControl.java";
            tmerger.Start();
        }

        private static void Testlibgit2sharp()
        {

            //Repository repo = new Repository(@"F:\git\libgit2sharp");


            //TreeChanges changes = repo.Diff.Compare(repo.Head.Tip.Tree,
            //    DiffTargets.WorkingDirectory);

            //var expected = new StringBuilder()
            //    .Append("diff --git a/file.txt b/file.txt\n")
            //    .Append("index ce01362..4f125e3 100644\n")
            //    .Append("--- a/file.txt\n")
            //    .Append("+++ b/file.txt\n")
            //    .Append("@@ -1 +1,3 @@\n")
            //    .Append(" hello\n")
            //    .Append("+world\n")
            //    .Append("+!!!\n");

            ////Assert.Equal(expected.ToString(), changes.Patch);
            //Console.WriteLine(changes.Patch);
        }
    }
}
