using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LibGit2Sharp;
using LibGit2Sharp.Core;
using System.Diagnostics;
namespace GitHelper
{
   
    public class GitTest
    {
        public static void Test()
        {
            Repository repo = new Repository(@"F:\git\libgit2sharp");


            TreeChanges changes = repo.Diff.Compare(repo.Head.Tip.Tree,
                DiffTargets.WorkingDirectory);

            var expected = new StringBuilder()
                .Append("diff --git a/file.txt b/file.txt\n")
                .Append("index ce01362..4f125e3 100644\n")
                .Append("--- a/file.txt\n")
                .Append("+++ b/file.txt\n")
                .Append("@@ -1 +1,3 @@\n")
                .Append(" hello\n")
                .Append("+world\n")
                .Append("+!!!\n");

            //Assert.Equal(expected.ToString(), changes.Patch);
            Console.WriteLine(changes.Patch);

        }

        public static void TestDiff()
        {
            Process tmerger = new Process();
            tmerger.StartInfo.FileName = @"D:\Program Files\TortoiseGit\bin\TortoiseMerge.exe";
            tmerger.StartInfo.Arguments = @"D:\AB-G-Pro\src\TestOra.java D:\AB-G-Pro\src\FileControl.java";
            tmerger.Start();
        }
    }
}
