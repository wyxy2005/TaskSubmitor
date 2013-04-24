using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Model;
using GitHelper;
using SvnHelper;

namespace ConsoleTest
{
    /// <summary>
    /// 自建控制台测试项目,不同于系统的UnitTest Project
    /// 2012-12-03
    /// </summary>
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SvnTest.Test();
            //TestCopy();
            //GitTest.Test();
            //string templatePath = AppDomain.CurrentDomain.BaseDirectory + SysData.FileName.TEMPLATE_PATH;
            ////设计文档
            //File.Copy(templatePath + SysData.FileName.DESIGN,
            //    @"C:\" + SysData.FileName.DESIGN);

            //vss项目操作测试
           // VssTaskTest.Test();

            //
            //OfficeHelperTest.Test();




            //==============================================
            Console.WriteLine("Please enter any key to continue!");
            Console.ReadKey();
        }

        private static void TestCopy()
        {
            FileInfo file = new FileInfo(@"D:\Work\Dev\Workspace\AB-P-devlis\ui\sys\GrpPolDetailQuery.js");
            //file.
            file.CopyTo(@"D:\AB-P-Pro\ui\sys\GrpPolDetailQuery.js", true);
        }
    }
}
