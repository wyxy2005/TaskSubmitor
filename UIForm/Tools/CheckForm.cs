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
    public partial class CheckForm : Form
    {
        public CheckForm()
        {
            InitializeComponent();

            InitData();
        }

        private void InitData()
        {
            //
            txt_vssUrl.Text = sys.Default.safeIniSrc;
            txt_VssDir.Text = sys.Default.vssProjectG;
            txt_LocalDir.Text = sys.Default.localProjectG;
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
            if (string.IsNullOrEmpty(txt_VssDir.Text.Trim()))
            {
                msg = "请输入vss工作区";
                return false;
            }
            if (string.IsNullOrEmpty(txt_LocalDir.Text.Trim()))
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

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheckOut()
        {
            //从输入获取文件列表
            string text = rtb_FileList.Text.Trim();
            string[] files = text.Split('\n');

            CheckBLL check = new CheckBLL(sys.Default.username, sys.Default.password,
                sys.Default.safeIniSrc, txt_VssDir.Text.Trim(), txt_LocalDir.Text.Trim());
            check.CheckOut(files, txt_comment.Text.Trim());


        }

        private void CheckIn()
        {
            //从输入获取文件列表
            string text = rtb_FileList.Text.Trim();
            string[] files = text.Split('\n');

            CheckBLL check = new CheckBLL(sys.Default.username, sys.Default.password,
                sys.Default.safeIniSrc, txt_VssDir.Text.Trim(), txt_LocalDir.Text.Trim());
            check.CheckIn(files, txt_comment.Text.Trim());


        }
    }
}
