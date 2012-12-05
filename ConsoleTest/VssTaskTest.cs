using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VssTask;

namespace ConsoleTest
{
    class VssTaskTest
    {
        /// <summary>
        /// 静态测试入口
        /// </summary>
        public static void Test()
        {
            //连接文件   
            //string vsssrc = @"\\10.10.134.71\lisvss_src\srcsafe.ini";
            string vssdoc = @"\\10.10.134.71\lisvss_doc\srcsafe.ini";
            string username = "chengning";
            string password = "chengning";
            
            //创建一个vss连接器,vss操作者拥有一个连接器
            VssOperator vssOperator = new VssOperator(vssdoc, username, password);

            //提交任务测试
            SubmitTest(vssOperator);

            VssOperatorTest(vssOperator);
            
        }

        /// <summary>
        /// SubmitVss测试
        /// </summary>
        /// <param name="vssOperator"></param>
        private static void SubmitTest(VssOperator vssOperator)
        {
            //任务提交器需要加载vss的操作者
            SubmitVssTemplate realSubmitor = new SubmitVssConcrete(vssOperator);
            realSubmitor.DesignDocLocalPath = @"D:\Work\Task\ABLREQUEST-1396-团险添加投保率不足0.75的控制提示\ABLREQUEST-1396-团险添加投保率不足0.75的控制提示-设计说明书20121204.doc";
            realSubmitor.TestDocLocalPath = @"D:\Work\Task\ABLREQUEST-1396-团险添加投保率不足0.75的控制提示\ABLREQUEST-1396-团险添加投保率不足0.75的控制提示-自测试报告20121204.doc";
            realSubmitor.DocVssFolder = @"$/LIS－CM－AB/05-项目任务/B-契约模块/ABLREQUEST-1396-团险添加投保率不足0.75的控制提示";
            //创建一个任务提交代理
            ISubmitVss submitProxy = new SubmitVssProxy(realSubmitor);
            //使用代理提交任务
            submitProxy.Submit();
        }


        /// <summary>
        /// VssOperator类测试
        /// </summary>
        /// <param name="vssOperator"></param>
        private static void VssOperatorTest(VssOperator vssOperator)
        {
            //done
            //vssOperator.NewProject(@"$/LIS－CM－AB/05-项目任务/B-契约模块/ABLREQUEST-test/test", "test");
            //done
            //vssOperator.Get(@"$/AB-G-devlis/ui/appgrp/ContPolSave.jsp", @"C:\ContPolSave.jsp");
        }
    }
}
