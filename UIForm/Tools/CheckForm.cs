using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using GitHelper;
using System.IO;
using System.Threading;

namespace UIForm.Tools
{
    public partial class CheckForm : Form
    {
        public CheckForm()
        {
            InitializeComponent();

            InitData();
            InitUI();
        }

        /// <summary>
        /// 界面初始化设置
        /// </summary>
        private void InitUI()
        {
            cb_VssUrl.Enabled = false;
        }

        /// <summary>
        /// 数据初始化设置
        /// </summary>
        private void InitData()
        {
            //绑定数据
            BindComboxData();
            //初始化数据
            //下拉框默认选中第一个
            cb_VssUrl.SelectedIndex = 0;
            cb_VssDir.SelectedIndex = 0;
            cb_LocalDir.SelectedIndex = 0;
        }

        private void BindComboxData()
        {
            //vss
            cb_VssUrl.Items.Add(sys.Default.safeIniSrc);
            cb_VssUrl.Items.Add(sys.Default.safeIniDoc);

            //vss project
            cb_VssDir.Items.Add(sys.Default.vssProjectG);
            cb_VssDir.Items.Add(sys.Default.vssProjectP);
            cb_VssDir.Items.Add(sys.Default.vssOnlineG);
            cb_VssDir.Items.Add(sys.Default.vssOnlineP);
            
            //local project
            cb_LocalDir.Items.Add(sys.Default.localProjectG);
            cb_LocalDir.Items.Add(sys.Default.localProjectP);
            cb_LocalDir.Items.Add(sys.Default.localOnlineG);
            cb_LocalDir.Items.Add(sys.Default.localOnlineP);
        }


        private void btn_CheckOut_Click(object sender, EventArgs e)
        {
            string msg = "";
            if (ValidateInput(ref msg))
            {
                try
                {
                    CheckOut();
                    MessageBox.Show("检出成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("检出失败，请手动检出\n" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show(msg);
            }
        }

        private bool ValidateInput(ref string msg)
        {
            if (string.IsNullOrEmpty(cb_VssDir.Text.Trim()))
            {
                msg = "请输入vss工作区";
                return false;
            }
            if (string.IsNullOrEmpty(cb_LocalDir.Text.Trim()))
            {
                msg = "请输入本地工作区";
                return false;
            }
            if (string.IsNullOrEmpty(rtb_FileList.Text.Trim()))
            {
                msg = "没有要检出的文件";
                return false;
            }
            if (string.IsNullOrEmpty(txt_comment.Text.Trim()))
            {
                msg = "必须输入注释";
                return false;
            }

            return true;
        }

        private void btn_CheckIn_Click(object sender, EventArgs e)
        {
            string msg = "";
            if (ValidateInput(ref msg))
            {
                try
                {
                    CheckIn();
                    MessageBox.Show("检入成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("检入失败，请手动检入\n" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show(msg);
            }
        }
        
        /// <summary>
        /// 此功能添加到右键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Diff_Click(object sender, EventArgs e)
        {
            string msg = "";
            if(clb_FileList.SelectedItems.Count > 0)
            {
                //原始功能，对于第一个选择的比较,此处会添加至右键
                Diff(clb_FileList.SelectedItems[0].ToString());
                //for (int i = 0; i < clb_FileList.SelectedItems.Count; ++i)
                //{
                //    clb_FileList.SelectedItems[i].ToString();
                //}
            }
            else
            {
                MessageBox.Show("没有选择文件");
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_UndoCheckOut_Click(object sender, EventArgs e)
        {

            string msg = "";
            if (ValidateInput(ref msg))
            {
                try
                {
                    UndoCheckOut();
                    MessageBox.Show("取消检出成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("取消检出失败，请手动取消检出\n" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show(msg);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void CheckOut()
        {
            //从输入获取文件列表
            string text = rtb_FileList.Text.Trim();
            string[] files = text.Split('\n');

            CheckBLL check = new CheckBLL(sys.Default.username, sys.Default.password,
                sys.Default.safeIniSrc, cb_VssDir.Text.Trim(), cb_LocalDir.Text.Trim());
            check.CheckOut(files, txt_comment.Text.Trim());
            
            foreach(string f in files)
                clb_FileList.Items.Add(f);

        }

        /// <summary>
        /// 
        /// </summary>
        private void CheckIn()
        {
            //从输入获取文件列表
            string text = rtb_FileList.Text.Trim();
            string[] files = text.Split('\n');

            CheckBLL check = new CheckBLL(sys.Default.username, sys.Default.password,
                sys.Default.safeIniSrc, cb_VssDir.Text.Trim(), cb_LocalDir.Text.Trim());
            check.CheckIn(files, txt_comment.Text.Trim());


        }

        /// <summary>
        /// 
        /// </summary>
        private void UndoCheckOut()
        {
            //从输入获取文件列表
            string text = rtb_FileList.Text.Trim();
            string[] files = text.Split('\n');
            //string file = files[0];
            CheckBLL check = new CheckBLL(sys.Default.username, sys.Default.password,
                sys.Default.safeIniSrc, cb_VssDir.Text.Trim(), cb_LocalDir.Text.Trim());
            check.UndoCheckOut(files, txt_comment.Text.Trim());
        }

        /// <summary>
        /// 只针对第一个文件
        /// </summary>
        private void Diff(string file)
        {
            //需要重新设计文件列表
            //从输入获取文件列表
            //string text = rtb_FileList.Text.Trim();
            //string[] files = text.Split('\n');
            //string file = files[0];
            //得到服务器文件
            if (!UiUtil.ExistTempDir())
                UiUtil.CreateTempDir();

            CheckBLL check = new CheckBLL(sys.Default.username, sys.Default.password,
                sys.Default.safeIniSrc, cb_VssDir.Text.Trim(), cb_LocalDir.Text.Trim());
            //工作区文件
            string localFilePath = cb_LocalDir.Text.Trim() + @"\" + file;
            //服务器文件版本
            string tempFileName = Guid.NewGuid().ToString();
            string tempFilePath = sys.Default.TempDir + @"\~" + tempFileName;
            check.Get(file, tempFilePath);

            //TODO:这里的调用以后使用异步调用
            //invoke TortoiseMerge
            TortoiseGit tortoise = new TortoiseGit(sys.Default.TortoiseGitRootPath);
            tortoise.Diff(tempFilePath, localFilePath);

            //当前线程暂停5秒，防止临时文件在没有被加载时就删除了
            Thread.Sleep(5000);
            //删除临时文件
            File.Delete(tempFilePath);
        }
    }
}
