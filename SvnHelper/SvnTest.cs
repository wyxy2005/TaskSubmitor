using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SharpSvn;

namespace SvnHelper
{
    public class SvnTest
    {
        public static void Test()
        {
            SvnTest test = new SvnTest();
        }

        private void SvnHello()
        {
            using (SvnClient client = new SvnClient())
            {
                string repoURL = @"http://localhost:8080/svn/test";
                string workspace = @"D:\svntest\";
                SvnInfoEventArgs info;
                client.GetInfo(new Uri(repoURL),out info);
                Console.WriteLine(info.Revision.ToString());

                SvnImportArgs import = new SvnImportArgs();
                import.LogMessage = "import test";
                client.Import(workspace + "test.txt",new Uri(repoURL),import);

                client.Update(workspace);
            }
 
        }
    }
}
