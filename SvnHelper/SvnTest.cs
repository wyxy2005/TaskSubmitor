using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SharpSvn;
using System.IO;
using System.Net;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace SvnHelper
{
    public class SvnTest
    {
        private const string REPO_URL = @"https://lg4n.googlecode.com/svn/trunk/";
        private const string WORKSPACE = @"F:\svn\lg4n\";

        private const string USERNAME = @"";
        private const string PASSWORD = @"";

        private const string DIFF_TOOLS = @"D:\Program Files\TortoiseSVN\bin\TortoiseMerge.exe";


        public static void Test()
        {
            SvnTest test = new SvnTest();
            test.Diff();
        }

        private void Diff(string file, string diffToolPath)
        {
            using (SvnClient client = new SvnClient())
            {
                string filePath = REPO_URL + @"test\test.txt";
                string temp = @"F:\svn";
                client.Export(new SvnUriTarget(new Uri(filePath), SvnRevision.Head), temp);
            }
        }

        private void Diff()
        {
            using (SvnClient client = new SvnClient())
            {
                
                string filePath = REPO_URL + @"test\test.txt";
                string temp = @"F:\svn";
                SvnExportArgs args = new SvnExportArgs();
                args.Overwrite = true;
                client.Export(new SvnUriTarget(new Uri(filePath), SvnRevision.Head), temp, args);


                string argu = WORKSPACE + @"test\test.txt" + " " + temp + @"\test.txt";
                Process tmerger = new Process();
                tmerger.StartInfo.FileName = DIFF_TOOLS;
                tmerger.StartInfo.Arguments = argu;
                tmerger.Start();
            }
        }



    }
}
