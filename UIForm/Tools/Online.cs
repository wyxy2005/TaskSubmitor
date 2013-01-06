using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;

namespace UIForm.Tools
{
    public partial class Online : Form
    {
        private ILog log = LogManager.GetLogger(typeof(Online));
        public Online()
        {
            InitializeComponent();
        }

        private void toOnlineCtrl1_Load(object sender, EventArgs e)
        {
            log.Info("测试日志");
        }
    }
}
