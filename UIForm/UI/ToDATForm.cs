using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;

namespace UIForm.UI
{
    public partial class ToDATForm : Form
    {
        private Task task;

        public Task CurrentTask
        {
            get { return this.task; }
            set { this.task = value; }
        }

        public ToDATForm()
        {
            InitializeComponent();
        }

        public void InitData()
        {
            //设置需要dat的任务
            ctrl_ToDat.CurrentTask = this.task;
            ctrl_ToDat.InitData();
        }

    }
}
