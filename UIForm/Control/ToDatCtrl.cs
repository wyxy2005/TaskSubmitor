using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Model;
using BLL;

namespace UIForm.Control
{
    public partial class ToDatCtrl : UserControl
    {
        private int taskNo;
        private string taskDir;
        //private Task task;
        /// <summary>
        /// 需要提交的任务编号
        /// </summary>
        public int TaskNo
        {
            get { return this.taskNo; }
            set { this.taskNo = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TaskDir
        {
            get { return this.taskDir; }
            set { this.taskDir = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public ToDatCtrl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 显示界面初始化相关数据
        /// </summary>
        public void InitData()
        {
            txt_task.Text = this.taskDir;
        }

        /// <summary>
        /// 执行上线活动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            string msg = "";
            if (ValidateInput(ref msg))
            {
                try
                {
                    //执行提交操作
                    //SubmitDAT();
                    //MessageBox.Show("提交成功");
                    MessageBox.Show("此功能未开放");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("提交失败" + ex.Message);
                }
            }
            else
                MessageBox.Show(msg);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        /// <summary>
        /// 输入合法性验证
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private bool ValidateInput(ref string msg)
        {
            if (string.IsNullOrEmpty(txt_task.Text.Trim()))
            {
                msg = "没有任务工作区";
                return false;
            }
            if (!Directory.Exists(txt_task.Text.Trim()))
            {
                msg = "任务工作区目录不存在,程序找不到，请检查";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 提交DAT,模板操作
        /// </summary>
        private void SubmitDAT()
        {
            TaskBLL bll = new TaskBLL();
            Task task = bll.GetTask(this.taskNo);
            BLL.SubmitDAT datSubmitor = new BLL.SubmitDAT(task);

            ////TODO：输入太多，考虑输入jira号之后，由软件自动生成相关文件模板，用户修改添加即可，这样多数路径又软件智能提取
            ////任务提交器
            //SubmitVssTemplate realSubmitor = new SubmitVssConcrete();
            ////输入
            //realSubmitor.DesignDocLocalPath = @"D:\Work\Task\已经上线\ABLREQUEST-1083-银保通签发保单之后发送承保短信\ddd.doc";
            ////输入
            //realSubmitor.TestDocLocalPath = @"D:\Work\Task\ABLREQUEST-1396-团险添加投保率不足0.75的控制提示\ABLREQUEST-1396-团险添加投保率不足0.75的控制提示-自测试报告20121204.doc";
            ////输入
            //realSubmitor.DocVssFolder = @"$/LIS－CM－AB/05-项目任务/B-契约模块/ABLREQUEST-1396-团险添加投保率不足0.75的控制提示";
            ////输入
            //realSubmitor.SqlDocLocalFolder = @"D:\Work\Task\已经上线\ABLREQUEST-1083-银保通签发保单之后发送承保短信";
            ////配置默认
            //realSubmitor.SqlDocVssFolder = @"$/B-更新目录/03-数据更新/01核心/201212";
            ////环境配置
            //realSubmitor.CodeRootPathVss = @"$/AB-G-devlis";
            ////环境配置
            //realSubmitor.CodeRootPathLocal = @"D:\Work\Dev\Workspace\AB-G-devlis";
            ////输入
            //realSubmitor.RecordLocalPath = @"D:\Work\Task\test更新列表.xls";
            ////环境配置
            //realSubmitor.RecordTempRoot = @"D:\Temp\vss更新";
            ////环境配置
            //realSubmitor.RecordVssRoot = @"$/B-更新目录/01-应用更新";

            ////创建一个任务提交代理
            //ISubmitVss submitProxy = new SubmitVssProxy(realSubmitor);
            ////使用代理提交任务
            //submitProxy.Submit();

            if (cbx_DevDoc.Checked)
            {
                SubmitDevDoc(datSubmitor);
            }
            if (cbx_SQL.Checked)
            {
                SubmitSQL(datSubmitor);
            }
            if (cbx_CheckOut.Checked)
            {
                CheckOutSrc(datSubmitor);
            }
            if (cbx_CheckIn.Checked)
            {
                CheckInSrc(datSubmitor);
            }
            if (cbx_Record.Checked)
            {
                ModifyRecords(datSubmitor);
            }
            if (cbx_RecordAll.Checked)
            {
                ModifyRecordAll(datSubmitor);
            }
        }

        /// <summary>
        /// 创建项目文档路径在vss上，并且添加项目
        /// </summary>
        private void SubmitDevDoc(BLL.SubmitDAT datSubmitor)
        {
            datSubmitor.SubmitDevDoc();
        }

        private void SubmitSQL(BLL.SubmitDAT datSubmitor)
        { 
        }

        private void CheckOutSrc(BLL.SubmitDAT datSubmitor)
        { 
        }

        private void CheckInSrc(BLL.SubmitDAT datSubmitor)
        { 
        }

        private void ModifyRecords(BLL.SubmitDAT datSubmitor)
        { 
        }

        private void ModifyRecordAll(BLL.SubmitDAT datSubmitor)
        { 
        }
    }
}
