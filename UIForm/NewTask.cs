using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using Util;
using BLL;
using Model.Enum;

namespace UIForm
{
    /// <summary>
    /// 创建任务
    /// </summary>
    public partial class NewTask : Form
    {
        //
        private string taskContent;

        /// <summary>
        /// FORM初始化
        /// </summary>
        public NewTask()
        {
            InitializeComponent();

            InitUI();
            InitData();
        }

        /// <summary>
        /// 初始化界面显示
        /// </summary>
        private void InitUI()
        { 
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            lbl_Workspace.Text = sys.Default.localWorkspace;
            txt_Prefix.Text = sys.Default.TaskPrex;
        }

        /// <summary>
        /// 创建按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.taskContent = txt_Prefix.Text.Trim() + "-" + 
                txt_No.Text.Trim() + "-" + txt_Name.Text.Trim();

            string msg = taskContent + "\n确定创建问题?";
            DialogResult diaRe = MessageBox.Show(msg, "确认", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (diaRe == DialogResult.Yes)
            {
                //创建问题
                CreateTask();
                //打开资源管理器，显示到问题
                OpenTaskDir();
            }
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 校验输入
        /// </summary>
        private void ValidateInput()
        {
            //任务编号不为空且是整数
            //任务名称不为空
        }

        /// <summary>
        /// 创建任务
        /// </summary>
        private void CreateTask()
        {
            Task task = new Task();
            task.Prefix = txt_Prefix.Text.Trim();
            task.No = int.Parse(txt_No.Text.Trim());
            task.Name = txt_Name.Text.Trim();
            //需要创建的文档
            IList<TaskFileEnum> files = GetTaskFiles();
            task.Files = files;
            NewTaskBLL newTask = new NewTaskBLL(task, sys.Default.localWorkspace, sys.Default.Author);
            newTask.Create();
        }

        private IList<TaskFileEnum> GetTaskFiles()
        {
            IList<TaskFileEnum> files = new List<TaskFileEnum>();
            if (cbx_DesignDoc.Checked)
                files.Add(TaskFileEnum.Design);
            if (cbx_TestDoc.Checked)
                files.Add(TaskFileEnum.Test);
            if (cbx_RecordXls.Checked)
                files.Add(TaskFileEnum.Xls);
            if (cbx_DevSql.Checked)
                files.Add(TaskFileEnum.DevSql);
            if (cbx_DmlSql.Checked)
                files.Add(TaskFileEnum.DML);
            return files;
        }

        /// <summary>
        /// 打开任务工作区
        /// </summary>
        private void OpenTaskDir()
        {
            string path = sys.Default.localWorkspace.Trim('\\') + @"\" + this.taskContent;
            SysUtil.OpenDir(path);
        }
    }
}
