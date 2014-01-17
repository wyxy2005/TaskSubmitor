using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Model;
using GitHelper;
using SvnHelper;
using BLL;
using System.Globalization;

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
            string s = (Convert.ToDateTime(DateTime.Now).ToString("ddd MMM dd yyy ", DateTimeFormatInfo.InvariantInfo) +
　　DateTime.Now.ToString("HH:mm:ss").Replace(":", "%3A") + " GMT%2B0800 (China Standard Time)").Replace(' ', '+');
            ///ddd, d MMM yyyy HH:mm:ss GMT
            DateTime trainDate = Convert.ToDateTime("2014-01-04" + " " + DateTime.Now.ToLongTimeString());
            //DateTime.ParseExact(this.date, "ddd MMM dd HH:mm:ss UTC+0800  yyyy", CultureInfo.InvariantCulture);
            string trainDateStr = trainDate.ToString("ddd MMM dd HH:mm:ss UTC+0800 yyyy", CultureInfo.InvariantCulture);

            //SvnTest.Test();
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
            //TestWeb();

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

        private static void TestWeb()
        {
            //string taskUrl = @"http://jira.abic.com/browse/ABLREQUEST-2150";
            //WebBll web = new WebBll(taskUrl);
            //string html = web.Browser();
            ////string xpath = @"/html[1]/body[1]/div[4]/div[1]/div[1]/div[1]/div[6]/div[1]/form[1]";
            ////string xpath = @"//form[@id='add_comment']";
            //string xpath = @"//input[@name='id']";
            //string taskUid = web.HtmlInputValue(html, xpath);
            string watchAjaxUrl = "http://jira.abic.com/rest/api/1.0/issues/210970/watchers";//@"http://jira.abic.com/rest/api/1.0/issues/" + taskUid + @"/watchers";

            WebBll web = new WebBll(watchAjaxUrl);
            //bool sucess = web.Watch(watchAjaxUrl);
            bool sucess = web.UnWatch(watchAjaxUrl);

         }
    }
}
