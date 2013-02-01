using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UIForm.config;
using Util;
using UIForm.Tools;
using log4net;
using System.Reflection;
using System.Threading;
using log4net.Core;
using UIForm.UI;
using BLL;
using Model;
using System.IO;

namespace UIForm
{
    public partial class TaskSubmitor : Form
    {
        private int childFormNumber = 0;
        private ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private bool logWatching = true;
        private log4net.Appender.MemoryAppender logger;
        private Thread logWatcher;


        public TaskSubmitor()
        {

            InitializeComponent();

            //日志功能
            //FormClosing += TaskSubmitor_FormClosing;

            //logger = new log4net.Appender.MemoryAppender();

            //log4net.Config.BasicConfigurator.Configure(logger);

            //logWatcher = new Thread(new ThreadStart(LogWatcher));
            //logWatcher.Start();


            InitUI();
            InitData();



        }

        private void InitUI()
        {
            log.Info("InitUI");
            //TreeNode node = new TreeNode();
            //node.Name = "颜色说明";
            //node.Nodes.Add("红色表示正在开发");
            //node.Nodes.Add("绿色表示已经上线");
            //node.Nodes.Add("其他表示测试阶段");
            //node.Nodes[0].ForeColor = Color.Red;
            //node.Nodes[1].ForeColor = Color.Green;
            //tv_TaskList.Nodes.Add(node);
            
        }

        private void InitData()
        {
            BindTreeNode();
        }

        /// <summary>
        /// 
        /// </summary>
        private void BindTreeNode()
        {
            //清空遗留数据
            tv_TaskList.Nodes.Clear();
            //读取数据绑定树节点
            TaskBLL taskBll = new TaskBLL();
            IList<Task> tasks = taskBll.GetTaskList();
            ////lambda
            //var sortedTask = tasks.OrderBy(x => x.Phase).ThenByDescending(x => x.No).ToList();
            //linq sort
            var sortedTask = from t in tasks
                             orderby t.Phase ascending, t.No descending
                             select t;
            foreach (Task t in sortedTask)
            {
                TreeNode node = new TreeNode();
                node.Name = t.No.ToString();
                node.ForeColor = TaskBLL.GetTaskColor(t);
                node.Text = t.Description;
                //添加右键菜单
                node.ContextMenuStrip = this.treeNodeRightKeyMenu;
                tv_TaskList.Nodes.Add(node);
            }
        }


        #region 系统生成


        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "窗口 " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }


        #endregion

        #region 程序框架Form

        private void TaskSubmitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            //logWatching = false;
            //logWatcher.Join();
        }
        private void TaskSubmitor_FormClosed(object sender, FormClosedEventArgs e)
        {
            log.Info("退出程序");
        }


        #endregion

        #region 菜单栏任务栏


        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.Show();
        }

        /// <summary>
        /// 用户配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu_UserCfg_Click(object sender, EventArgs e)
        {
            UserConfig userCfg = new UserConfig();
            userCfg.Show();
        }

        /// <summary>
        /// 工作区配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu_WorkSpaceCfg_Click(object sender, EventArgs e)
        {
            WorkSpaceConfig wsCfg = new WorkSpaceConfig();
            wsCfg.Show();
        }

        private void menu_NewTask_Click(object sender, EventArgs e)
        {
            NewTask();
        }

        private void menu_Tool_NewTask_Click(object sender, EventArgs e)
        {
            NewTask();
        }

        private void NewTask()
        {
            NewTask newTask = new NewTask();
            newTask.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_goto_Click(object sender, EventArgs e)
        {
            GotoJira(txt_JiraNo.Text.Trim());
        }

        /// <summary>
        /// 输入框按下enter健之后自动执行btn_goto_Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_JiraNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_goto_Click(sender, e);
        }

        #endregion 

        #region TreeNode_TaskList任务树

        private void tv_TaskList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //设置选中的节点为当前节点，右键菜单需要
            this.tv_TaskList.SelectedNode = e.Node;

            TaskBLL taskBll = new TaskBLL();
            Task t = taskBll.GetTask(int.Parse(e.Node.Name));
            //Task t = 
            Bind_clb_FileList(t);
            Bind_clb_srcList(t);
            //设置工作区目录
            if ( t.Channel == Model.Enum.ChannelEnum.P)
                lbl_Workspace.Text = sys.Default.localProjectP;
            else if (t.Channel == Model.Enum.ChannelEnum.G)
                lbl_Workspace.Text = sys.Default.localProjectG;
            else
                lbl_Workspace.Text = "...";
        }

        private void tnMenu_Open_Click(object sender, EventArgs e)
        {
            string xpath = sys.Default.localWorkspace + @"\" + this.tv_TaskList.SelectedNode.Text;
            SysUtil.BrowseURL(xpath);
        }

        /// <summary>
        /// 右键菜单“上线”触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tnMenu_ToOnline_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = this.tv_TaskList.SelectedNode;
            //需要上线的任务编号
            string taskNo = currentNode.Name;
            TaskBLL bll = new TaskBLL();
            Task currentTask = bll.GetTask(int.Parse(taskNo));
            currentTask.Phase = Model.Enum.PhaseEnum.RUN;
            //移动工作区进入已上线
            string destDir = sys.Default.OnlineDir + @"\" + currentTask.Description;
            string msg = "";
            if (bll.MoveTaskDir(currentTask, destDir))
            {
                currentTask.Dir = destDir;
                int ire = bll.Update(currentTask);
                if (ire > 0)
                {
                    currentNode.ForeColor = TaskBLL.GetTaskColor(currentTask);
                    BindTreeNode();
                    msg = @"更改任务为上线成功";
                }
                else
                    msg = @"更改任务为上线失败,请手动";
            }
            else
            {
                msg = @"更改任务为上线失败,请手动";
            }

            //反馈结果
            MessageBox.Show(msg);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tnMenu_ToDAT_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = this.tv_TaskList.SelectedNode;
            //需要上线的任务编号
            string taskNo = currentNode.Name;
            TaskBLL bll = new TaskBLL();
            Task currentTask = bll.GetTask(int.Parse(taskNo));

            //调用用户控件进行处理
            ToDATForm toDatForm = new ToDATForm();
            toDatForm.CurrentTask = currentTask;
            toDatForm.InitData();
            toDatForm.ShowDialog();
        }


        private void tnMenu_Refresh_Click(object sender, EventArgs e)
        {
            BindTreeNode();
        }


        #endregion

        #region CheckListBox_FileList

        private void clb_FileList_DoubleClick(object sender, EventArgs e)
        {
            
            MessageBox.Show("打开文件");
        }




        #endregion

        #region 个人工具箱


        /// <summary>
        /// 上线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CopyToOnline_Click(object sender, EventArgs e)
        {
            Online onlineForm = new Online();
            onlineForm.ShowDialog();
            //this.ShowDialog(Online);
        }

        private void btn_checkout_Click(object sender, EventArgs e)
        {
            CheckForm checkForm = new CheckForm();
            checkForm.Show();//非模态单独窗口，需要和其他窗口交互
            //checkForm.ShowInTaskbar = false;
            //checkForm.ShowDialog();
        }

        private void btn_Copy_Click(object sender, EventArgs e)
        {
            CopyForm copyForm = new CopyForm();
            copyForm.Show();//非模态单独窗口
            //copyForm.ShowInTaskbar = false;
            //copyForm.ShowDialog();
        }

        private void btn_NewTask_Click(object sender, EventArgs e)
        {
            NewTask newTaskForm = new NewTask();
            newTaskForm.ShowDialog();//模态显示
        }

        private void btn_ToDat_Click(object sender, EventArgs e)
        {
            ToDATForm datForm = new ToDATForm();
            datForm.ShowInTaskbar = false;
            datForm.ShowDialog();
        }

        #endregion 

        #region 日志显示功能


        delegate void delOneStr(string log);

        /// <summary>
        /// 监听log4net事件
        /// </summary>
        private void LogWatcher()
        {
            while (logWatching)
            {
                try
                {
                    LoggingEvent[] events = logger.GetEvents();
                    if (events != null && events.Length > 0)
                    {
                        logger.Clear();
                        foreach (LoggingEvent ev in events)
                        {
                            string line = ev.LoggerName + ": " + ev.RenderedMessage + Environment.NewLine;
                            AppendLog(line);
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_log"></param>
        void AppendLog(string _log)
        {
            if (rtx_logOutput.InvokeRequired)
            {
                delOneStr dd = new delOneStr(AppendLog);
                rtx_logOutput.Invoke(dd, new object[] { _log });
            }
            else
            {
                StringBuilder builder;
                if (rtx_logOutput.Lines.Length > 99)
                {
                    builder = new StringBuilder(rtx_logOutput.Text);
                    builder.Remove(0, rtx_logOutput.Text.IndexOf('\r', 3000) + 2);
                    builder.Append(_log);
                    rtx_logOutput.Clear();
                    rtx_logOutput.AppendText(builder.ToString());
                }
                else
                {
                    rtx_logOutput.AppendText(_log);
                }
                rtx_logOutput.ScrollToCaret();
            }
        }


        #endregion

        private void cbx_RecordAll_Click(object sender, EventArgs e)
        {

        }

        private void Bind_clb_srcList(Task task)
        { 
            //从gitlog中获取当前的编号的文件

        }

        private void Bind_clb_FileList(Task task)
        {
            string xpath = task.Dir;
            if (Directory.Exists(xpath))
            {
                DirectoryInfo dir = Directory.CreateDirectory(xpath);
                FileInfo[] fileList = dir.GetFiles();
                clb_FileList.DataSource = fileList;
                clb_FileList.DisplayMember = "文件";
                clb_FileList.ValueMember = "Name";
            }
            else
            {
                MessageBox.Show("此任务对应的目录不存在于" + xpath);
            }
        }

        private void tnMenu_GotoJira_Click(object sender, EventArgs e)
        {
            TreeNode currentNode = this.tv_TaskList.SelectedNode;
            //需要上线的任务编号
            string taskNo = currentNode.Name;
            GotoJira(taskNo);
        }






        /// <summary>
        /// goto jira
        /// </summary>
        /// <param name="jiraId"></param>
        private void GotoJira(string jiraId)
        {
            log.Info("打开浏览器转到jira");
            string url = sys.Default.JiraUrl + sys.Default.TaskPrex + "-" + jiraId;
            //调用浏览器打开
            SysUtil.BrowseURL(url);
        }







    }
}
