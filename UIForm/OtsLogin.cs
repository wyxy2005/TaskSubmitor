using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace UIForm
{
    public partial class OtsLogin : Form
    {
        private OtsAuto ots;
        private bool isLogin = false;

        public OtsLogin()
        {
            InitializeComponent();
        }

        private void OtsLogin_Load(object sender, EventArgs e)
        {
            InitLogin();
        }

        private void pic_code_Click(object sender, EventArgs e)
        {
            LoadCode();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string username = txt_userName.Text.Trim();
            string pwd = txt_pwd.Text.Trim();
            string code = txt_code.Text.Trim();
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(pwd))
            {
                this.toolStripMsg.Text = "正在登录......";
                string msg = "";
                if (ots.Login(username, pwd, code,out msg))
                {
                    //MessageBox.Show("登录成功");
                    OpenMainForm();
                }
                else
                {
                    this.toolStripMsg.Text = msg;
                }
            }
        }


        private void InitLogin()
        {
            ots = new OtsAuto();
            if (!isLogin)
            {
                ots.SetSession();
                //if(!isLogin)
            }
            LoadCode();
        }

        private void LoadCode()
        {
            this.toolStripMsg.Text = "加载验证码......";
            this.pic_code.Image = ots.GetRandImage();
            this.toolStripMsg.Text = "验证码加载完成";
        }

        private void ValidateInput()
        { 
        }

        private void Login()
        { 
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {

        }

        private void OpenMainForm()
        {
            this.Close();
            OTS newOts = new OTS(this.ots);
            newOts.ShowDialog();//非模态显示
        }


    }
}
