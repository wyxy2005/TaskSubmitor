using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UIForm
{
    public partial class TaskSubmitor : Form
    {
        public TaskSubmitor()
        {
            InitializeComponent();
        }

        private void about_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.Show();
        }

    }
}
