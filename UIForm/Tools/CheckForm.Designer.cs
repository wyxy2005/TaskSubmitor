namespace UIForm.Tools
{
    partial class CheckForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_VssDir = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_LocalDir = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtb_FileList = new System.Windows.Forms.RichTextBox();
            this.btn_CheckOut = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_CheckIn = new System.Windows.Forms.Button();
            this.txt_vssUrl = new System.Windows.Forms.TextBox();
            this.txt_comment = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "vss服务";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "vss工作区";
            // 
            // txt_VssDir
            // 
            this.txt_VssDir.Location = new System.Drawing.Point(85, 46);
            this.txt_VssDir.Name = "txt_VssDir";
            this.txt_VssDir.Size = new System.Drawing.Size(525, 21);
            this.txt_VssDir.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "本地工作区";
            // 
            // txt_LocalDir
            // 
            this.txt_LocalDir.Location = new System.Drawing.Point(84, 86);
            this.txt_LocalDir.Name = "txt_LocalDir";
            this.txt_LocalDir.Size = new System.Drawing.Size(525, 21);
            this.txt_LocalDir.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtb_FileList);
            this.groupBox1.Location = new System.Drawing.Point(14, 213);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(646, 343);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文件列表";
            // 
            // rtb_FileList
            // 
            this.rtb_FileList.Location = new System.Drawing.Point(7, 16);
            this.rtb_FileList.Name = "rtb_FileList";
            this.rtb_FileList.Size = new System.Drawing.Size(633, 321);
            this.rtb_FileList.TabIndex = 0;
            this.rtb_FileList.Text = "";
            // 
            // btn_CheckOut
            // 
            this.btn_CheckOut.Location = new System.Drawing.Point(383, 565);
            this.btn_CheckOut.Name = "btn_CheckOut";
            this.btn_CheckOut.Size = new System.Drawing.Size(61, 23);
            this.btn_CheckOut.TabIndex = 6;
            this.btn_CheckOut.Text = "CheckOut";
            this.btn_CheckOut.UseVisualStyleBackColor = true;
            this.btn_CheckOut.Click += new System.EventHandler(this.btn_CheckOut_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(600, 564);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(54, 23);
            this.btn_Cancel.TabIndex = 7;
            this.btn_Cancel.Text = "关闭";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_CheckIn
            // 
            this.btn_CheckIn.Location = new System.Drawing.Point(493, 565);
            this.btn_CheckIn.Name = "btn_CheckIn";
            this.btn_CheckIn.Size = new System.Drawing.Size(58, 23);
            this.btn_CheckIn.TabIndex = 8;
            this.btn_CheckIn.Text = "CheckIn";
            this.btn_CheckIn.UseVisualStyleBackColor = true;
            this.btn_CheckIn.Click += new System.EventHandler(this.btn_CheckIn_Click);
            // 
            // txt_vssUrl
            // 
            this.txt_vssUrl.Location = new System.Drawing.Point(85, 11);
            this.txt_vssUrl.Name = "txt_vssUrl";
            this.txt_vssUrl.ReadOnly = true;
            this.txt_vssUrl.Size = new System.Drawing.Size(525, 21);
            this.txt_vssUrl.TabIndex = 9;
            // 
            // txt_comment
            // 
            this.txt_comment.Location = new System.Drawing.Point(7, 20);
            this.txt_comment.Multiline = true;
            this.txt_comment.Name = "txt_comment";
            this.txt_comment.Size = new System.Drawing.Size(633, 62);
            this.txt_comment.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_comment);
            this.groupBox2.Location = new System.Drawing.Point(14, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(646, 94);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "注释";
            // 
            // CheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 598);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txt_vssUrl);
            this.Controls.Add(this.btn_CheckIn);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_CheckOut);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_LocalDir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_VssDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CheckForm";
            this.Text = "CheckForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_VssDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_LocalDir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtb_FileList;
        private System.Windows.Forms.Button btn_CheckOut;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_CheckIn;
        private System.Windows.Forms.TextBox txt_vssUrl;
        private System.Windows.Forms.TextBox txt_comment;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}