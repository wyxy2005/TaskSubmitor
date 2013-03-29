using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using BLL;

namespace UIForm.Tools
{
    public partial class CopyForm : Form
    {
        public CopyForm()
        {
            //系统初始化
            InitializeComponent();

            //个性初始化
            InitData();
        }

        #region init

        /// <summary>
        /// 初始化界面数据
        /// </summary>
        private void InitData()
        {
            BindComboxData();
            // init ui data
            cb_SourceDir.SelectedIndex = 0;
            cb_DestDir.SelectedIndex = 0;
        }

        private void BindComboxData()
        {
            //bind data
            cb_SourceDir.Items.Add(sys.Default.localProjectG);
            cb_SourceDir.Items.Add(sys.Default.localProjectP);

            cb_DestDir.Items.Add(sys.Default.localOnlineG);
            cb_DestDir.Items.Add(sys.Default.localOnlineP);
        }


        #endregion

        private void btn_OK_Click(object sender, EventArgs e)
        {
            string msg = "";
            if (ValidateInput(ref msg))
            {
                try
                {
                    CopyFile();
                    MessageBox.Show("复制成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("复制失败，请手动复制\n" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show(msg);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 检验输入
        /// </summary>
        private bool ValidateInput(ref string msg)
        {
            if (string.IsNullOrEmpty(cb_SourceDir.Text.Trim()))
            {
                msg = "请输入源工作区";
                return false;
            }
            if (!Directory.Exists(cb_SourceDir.Text.Trim()))
            {
                msg = "源工作区目录不存在";
                return false;
            }
            if (string.IsNullOrEmpty(cb_DestDir.Text.Trim()))
            {
                msg = "请输入目的工作区";
                return false;
            }
            if (!Directory.Exists(cb_DestDir.Text.Trim()))
            {
                msg = "目的工作区目录不存在";
                return false;
            }
            if (string.IsNullOrEmpty(rtb_FileList.Text.Trim()))
            {
                msg = "没有要复制的文件";
                return false;
            }

            return true;
        }

        private void CopyFile()
        {
            //从输入获取文件列表
            ToOnline copyer = new ToOnline(cb_SourceDir.Text.Trim(), cb_DestDir.Text.Trim());
            string text = rtb_FileList.Text.Trim();
            //修改为使用正则表达式的\s截断,空字符截断，这样即可排除每行多余的空格tab等
            string[] files = text.Split('\n');
            copyer.CopyFile(files);
        }
    }
}
