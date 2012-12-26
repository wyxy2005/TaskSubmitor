using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UIForm.config
{
    /// <summary>
    /// 用户配置
    /// </summary>
    public partial class UserConfig : Form
    {
        public UserConfig()
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
        /// 初始化界面数据
        /// </summary>
        private void InitData()
        {
            txt_Username.Text = sys.Default.username;
            txt_Password.Text = sys.Default.password;
            txt_VssSrc.Text = sys.Default.safeIniSrc;
            txt_VssDoc.Text = sys.Default.safeIniDoc;
        }

        /// <summary>
        /// 确定,写入配置数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_UserOK_Click(object sender, EventArgs e)
        {
            DialogResult responseDialogResult = MessageBox.Show("确实设置？","确定?",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);

            if (responseDialogResult == DialogResult.Yes)
            {
                sys.Default.username = txt_Username.Text.Trim();
                sys.Default.password = txt_Password.Text.Trim();
                sys.Default.safeIniSrc = txt_VssSrc.Text.Trim();
                sys.Default.safeIniDoc = txt_VssDoc.Text.Trim();
                this.Close();
            }
        }

        /// <summary>
        /// 用户配置取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_UserCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
