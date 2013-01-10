using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UIForm.UI
{
    public partial class ToDATForm : Form
    {
        private string taskDir;

        public string TaskDir
        {
            get { return this.taskDir; }
            set { this.taskDir = value; }
        }

        public ToDATForm()
        {
            InitializeComponent();
        }

        public void InitData()
        {
            //设置需要dat的任务
            ctrl_ToDat.TaskDir = this.TaskDir;
            ctrl_ToDat.InitData();
        }

    }
}
