using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            //vss项目操作测试
            VssTaskTest.Test();

            //
            //OfficeHelperTest.Test();




            //==============================================
            Console.WriteLine("Please enter any key to continue!");
            Console.ReadKey();
        }
    }
}
