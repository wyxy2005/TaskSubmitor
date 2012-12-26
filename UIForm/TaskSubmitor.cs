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

namespace UIForm
{
    public partial class TaskSubmitor : Form
    {
        private int childFormNumber = 0;

        public TaskSubmitor()
        {
            InitializeComponent();
            InitUI();
            InitData();
        }

        private void InitUI()
        { 
        }

        private void InitData()
        {

            tv_TaskList.Nodes.Add("1","已上线");
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

        private void btn_goto_Click(object sender, EventArgs e)
        {
            string url = sys.Default.JiraUrl + sys.Default.TaskPrex + "-" + txt_JiraNo.Text.Trim();
            //调用浏览器打开
            SysUtil.BrowseURL(url);
            //MessageBox.Show(url);
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

    }
}
