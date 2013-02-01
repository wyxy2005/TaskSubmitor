namespace UIForm.Tools
{
    partial class CopyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtb_FileList = new System.Windows.Forms.RichTextBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_SourceDir = new System.Windows.Forms.ComboBox();
            this.cb_DestDir = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtb_FileList);
            this.groupBox1.Location = new System.Drawing.Point(16, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 275);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文件列表";
            // 
            // rtb_FileList
            // 
            this.rtb_FileList.Location = new System.Drawing.Point(6, 15);
            this.rtb_FileList.Name = "rtb_FileList";
            this.rtb_FileList.Size = new System.Drawing.Size(509, 254);
            this.rtb_FileList.TabIndex = 0;
            this.rtb_FileList.Text = "";
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(269, 392);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(377, 392);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "关闭";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "源工作区";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "目的工作区";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(24, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(479, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "请确保对需要复制的文件具有读写权限，如果目的文件是vss控制文件，请先checkout文件";
            // 
            // cb_SourceDir
            // 
            this.cb_SourceDir.FormattingEnabled = true;
            this.cb_SourceDir.Location = new System.Drawing.Point(96, 16);
            this.cb_SourceDir.Name = "cb_SourceDir";
            this.cb_SourceDir.Size = new System.Drawing.Size(435, 20);
            this.cb_SourceDir.TabIndex = 15;
            // 
            // cb_DestDir
            // 
            this.cb_DestDir.FormattingEnabled = true;
            this.cb_DestDir.Location = new System.Drawing.Point(96, 49);
            this.cb_DestDir.Name = "cb_DestDir";
            this.cb_DestDir.Size = new System.Drawing.Size(435, 20);
            this.cb_DestDir.TabIndex = 16;
            // 
            // CopyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 434);
            this.Controls.Add(this.cb_DestDir);
            this.Controls.Add(this.cb_SourceDir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.groupBox1);
            this.Name = "CopyForm";
            this.Text = "批量复制";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.RichTextBox rtb_FileList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_SourceDir;
        private System.Windows.Forms.ComboBox cb_DestDir;
    }
}