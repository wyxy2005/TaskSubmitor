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
            FormClosing += TaskSubmitor_FormClosing;

            logger = new log4net.Appender.MemoryAppender();

            log4net.Config.BasicConfigurator.Configure(logger);

            logWatcher = new Thread(new ThreadStart(LogWatcher));
            logWatcher.Start();


            InitUI();
            InitData();



        }

        private void InitUI()
        {
            log.Info("InitUI");
        }

        private void InitData()
        {

            tv_TaskList.Nodes.Add("1", "已上线");
            tv_TaskList.Nodes[0].Nodes.Add("1111", "ABLREQUEST-1103-工行网银");

            tv_TaskList.Nodes.Add("1", "ABLREQUEST-1199-团险核保分级授权");
            tv_TaskList.Nodes.Add("2", "ABLREQUEST-1362-变更团险地址录入");
            tv_TaskList.Nodes.Add("3", "ABLREQUEST-1365-针对团险录入需做出控制");
            tv_TaskList.Nodes.Add("4", "以上线");
            tv_TaskList.Nodes.Add("5", "以上线");
            tv_TaskList.Nodes.Add("6", "以上线");
        }

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
            log.Info("打开浏览器转到jira");
            string url = sys.Default.JiraUrl + sys.Default.TaskPrex + "-" + txt_JiraNo.Text.Trim();
            //调用浏览器打开
            SysUtil.BrowseURL(url);
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


        private void TaskSubmitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            logWatching = false;
            logWatcher.Join();
        }
        private void TaskSubmitor_FormClosed(object sender, FormClosedEventArgs e)
        {
            log.Info("退出程序");
        }

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
            checkForm.ShowInTaskbar = false;
            checkForm.ShowDialog();
        }

        private void btn_Copy_Click(object sender, EventArgs e)
        {
            CopyForm copyForm = new CopyForm();
            copyForm.ShowInTaskbar = false;
            copyForm.ShowDialog();
        }



    }
}
