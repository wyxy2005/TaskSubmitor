using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            txt_SourceDir.Text = sys.Default.localProjectG;
            txt_DestDir.Text = sys.Default.localOnlineG;
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
            if (string.IsNullOrEmpty(txt_SourceDir.Text.Trim()))
            {
                msg = "请输入源工作区";
                return false;
            }
            if (string.IsNullOrEmpty(txt_DestDir.Text.Trim()))
            {
                msg = "请输入目的工作区";
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
            ToOnline copyer = new ToOnline(txt_SourceDir.Text.Trim(), txt_DestDir.Text.Trim());
            string text = rtb_FileList.Text.Trim();
            string[] files = text.Split('\n');
            copyer.CopyFile(files);
        }
    }
}
