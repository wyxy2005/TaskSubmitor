using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace UIForm
{
    public partial class OTS : Form
    {
        private OtsAuto ots;
        private bool isLogin = false;
        private int inteval = 5;
        private bool refresh = false;
        private static string AUTO = "auto";
        private static string STOP = "stop";

        public OTS()
        {
            InitializeComponent();
            InitUI();
            ots = new OtsAuto();
            if (!isLogin)
            {
                ots.SetSession();
                //if(!isLogin)
            }
        }

        private void InitUI() 
        {
            txt_inteval.Text = this.inteval.ToString();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (ots.Login("truecn", this.txt_pwd.Text, this.txt_LoginRand.Text))
            {
                MessageBox.Show("登录成功");
            }
            else {
                MessageBox.Show("登录失败");
            }
            this.btn_Login.Enabled = false;
            this.isLogin = true;
        }

        private void pic_loginRand_Click(object sender, EventArgs e)
        {
            this.pic_loginRand.Image = ots.GetRandImage();
        }

        private void btn_query_Click(object sender, EventArgs e)
        {
            query();
        }

        private void query() 
        {
            String json = ots.Query();
            JObject jObj = JObject.Parse(json);
            StringBuilder result = new StringBuilder();
            JArray jData = JArray.Parse(jObj["data"].ToString());
            foreach (string train in OtsAuto.tickets)
            {
                foreach (JObject item in jData)
                {
                    if (train == item["queryLeftNewDTO"]["station_train_code"].ToString() && item["buttonTextInfo"].ToString() == "预订")
                    {
                        result.Append(item["queryLeftNewDTO"]["station_train_code"].ToString() + "\n");
                        //提交订单
                        ots.Order();
                    }
                }
            }

            rtb.Text = result.ToString();
        }

        private void btn_autoQuery_Click(object sender, EventArgs e)
        {
            this.inteval = int.Parse(txt_inteval.Text);
            if (btn_autoQuery.Text == AUTO)
            {
                btn_autoQuery.Text = STOP;
                this.refresh = true;
            }
            else
            {
                btn_autoQuery.Text = AUTO;
                this.refresh = false;

            }
            Thread queryThread = new Thread(new ThreadStart(Refresh));
            queryThread.IsBackground = true;
            queryThread.Start();

        }

        private void Refresh()
        {
            int time = 0;
            while (this.refresh)
            {
                time++;
                //query();
                SetRefresh(time.ToString());
                Thread.Sleep(this.inteval * 1000);
            }
        }




        /// <summary>
        /// 线程间调用设置的委托
        /// </summary>
        /// <param name="text"></param>
        private delegate void SetRefreshCallBack(string text);

        private void SetRefresh(string text)
        {
            if (this.lbl_refreshTime.InvokeRequired)
            {
                this.Invoke(new SetRefreshCallBack(this.SetRefresh), new object[] { text });
            }
            else
            {
                this.lbl_refreshTime.Text = text;
            }
        }
    }
}
