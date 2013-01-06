using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;

namespace UIForm
{
    public partial class ToOnlineCtrl : UserControl
    {
        public ToOnlineCtrl()
        {
            InitializeComponent();
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            //FileDialog 
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = @"打开（Open）";
            openFileDialog.Filter = @"Excel文件(*.xls)|*.xlsx";
            openFileDialog.ValidateNames = true;     //文件有效性验证ValidateNames，验证用户输入是否是一个有效的Windows文件名
            openFileDialog.CheckFileExists = true;  //验证路径有效性
            openFileDialog.CheckPathExists = true; //验证文件有效性
            openFileDialog.FileOk += new CancelEventHandler(OpenFileDialog_FileOk);
            openFileDialog.ShowDialog();
            
        }

        public void OpenFileDialog_FileOk(object sender, EventArgs e)
        { 
            
        }
        /// <summary>
        /// 上线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Online_Click(object sender, EventArgs e)
        {
            //读取文件列表
            //checkout正式机目录
            //从开发目录复制文件到上线目录
        }

    }
}
