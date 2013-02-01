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
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clb_FileList = new System.Windows.Forms.CheckedListBox();
            this.rtb_FileList = new System.Windows.Forms.RichTextBox();
            this.btn_CheckOut = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_CheckIn = new System.Windows.Forms.Button();
            this.txt_comment = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Diff = new System.Windows.Forms.Button();
            this.btn_UndoCheckOut = new System.Windows.Forms.Button();
            this.cb_VssUrl = new System.Windows.Forms.ComboBox();
            this.cb_VssDir = new System.Windows.Forms.ComboBox();
            this.cb_LocalDir = new System.Windows.Forms.ComboBox();
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "本地工作区";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clb_FileList);
            this.groupBox1.Controls.Add(this.rtb_FileList);
            this.groupBox1.Location = new System.Drawing.Point(14, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(646, 362);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文件列表";
            // 
            // clb_FileList
            // 
            this.clb_FileList.CheckOnClick = true;
            this.clb_FileList.FormattingEnabled = true;
            this.clb_FileList.Location = new System.Drawing.Point(6, 223);
            this.clb_FileList.Name = "clb_FileList";
            this.clb_FileList.Size = new System.Drawing.Size(634, 132);
            this.clb_FileList.TabIndex = 1;
            // 
            // rtb_FileList
            // 
            this.rtb_FileList.Location = new System.Drawing.Point(7, 16);
            this.rtb_FileList.Name = "rtb_FileList";
            this.rtb_FileList.Size = new System.Drawing.Size(633, 186);
            this.rtb_FileList.TabIndex = 0;
            this.rtb_FileList.Text = "";
            // 
            // btn_CheckOut
            // 
            this.btn_CheckOut.Location = new System.Drawing.Point(98, 567);
            this.btn_CheckOut.Name = "btn_CheckOut";
            this.btn_CheckOut.Size = new System.Drawing.Size(61, 23);
            this.btn_CheckOut.TabIndex = 6;
            this.btn_CheckOut.Text = "CheckOut";
            this.btn_CheckOut.UseVisualStyleBackColor = true;
            this.btn_CheckOut.Click += new System.EventHandler(this.btn_CheckOut_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(600, 566);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(54, 23);
            this.btn_Cancel.TabIndex = 7;
            this.btn_Cancel.Text = "关闭";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_CheckIn
            // 
            this.btn_CheckIn.Location = new System.Drawing.Point(480, 567);
            this.btn_CheckIn.Name = "btn_CheckIn";
            this.btn_CheckIn.Size = new System.Drawing.Size(58, 23);
            this.btn_CheckIn.TabIndex = 8;
            this.btn_CheckIn.Text = "CheckIn";
            this.btn_CheckIn.UseVisualStyleBackColor = true;
            this.btn_CheckIn.Click += new System.EventHandler(this.btn_CheckIn_Click);
            // 
            // txt_comment
            // 
            this.txt_comment.Location = new System.Drawing.Point(7, 20);
            this.txt_comment.Multiline = true;
            this.txt_comment.Name = "txt_comment";
            this.txt_comment.Size = new System.Drawing.Size(633, 44);
            this.txt_comment.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_comment);
            this.groupBox2.Location = new System.Drawing.Point(14, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(646, 73);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "注释";
            // 
            // btn_Diff
            // 
            this.btn_Diff.Location = new System.Drawing.Point(355, 567);
            this.btn_Diff.Name = "btn_Diff";
            this.btn_Diff.Size = new System.Drawing.Size(61, 23);
            this.btn_Diff.TabIndex = 12;
            this.btn_Diff.Text = "Diff";
            this.btn_Diff.UseVisualStyleBackColor = true;
            this.btn_Diff.Click += new System.EventHandler(this.btn_Diff_Click);
            // 
            // btn_UndoCheckOut
            // 
            this.btn_UndoCheckOut.Location = new System.Drawing.Point(203, 568);
            this.btn_UndoCheckOut.Name = "btn_UndoCheckOut";
            this.btn_UndoCheckOut.Size = new System.Drawing.Size(97, 23);
            this.btn_UndoCheckOut.TabIndex = 13;
            this.btn_UndoCheckOut.Text = "Undo CheckOut";
            this.btn_UndoCheckOut.UseVisualStyleBackColor = true;
            this.btn_UndoCheckOut.Click += new System.EventHandler(this.btn_UndoCheckOut_Click);
            // 
            // cb_VssUrl
            // 
            this.cb_VssUrl.FormattingEnabled = true;
            this.cb_VssUrl.Location = new System.Drawing.Point(85, 12);
            this.cb_VssUrl.Name = "cb_VssUrl";
            this.cb_VssUrl.Size = new System.Drawing.Size(524, 20);
            this.cb_VssUrl.TabIndex = 14;
            // 
            // cb_VssDir
            // 
            this.cb_VssDir.FormattingEnabled = true;
            this.cb_VssDir.Location = new System.Drawing.Point(85, 47);
            this.cb_VssDir.Name = "cb_VssDir";
            this.cb_VssDir.Size = new System.Drawing.Size(524, 20);
            this.cb_VssDir.TabIndex = 15;
            // 
            // cb_LocalDir
            // 
            this.cb_LocalDir.FormattingEnabled = true;
            this.cb_LocalDir.Location = new System.Drawing.Point(84, 86);
            this.cb_LocalDir.Name = "cb_LocalDir";
            this.cb_LocalDir.Size = new System.Drawing.Size(524, 20);
            this.cb_LocalDir.TabIndex = 16;
            // 
            // CheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 598);
            this.Controls.Add(this.cb_LocalDir);
            this.Controls.Add(this.cb_VssDir);
            this.Controls.Add(this.cb_VssUrl);
            this.Controls.Add(this.btn_UndoCheckOut);
            this.Controls.Add(this.btn_Diff);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_CheckIn);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_CheckOut);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtb_FileList;
        private System.Windows.Forms.Button btn_CheckOut;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_CheckIn;
        private System.Windows.Forms.TextBox txt_comment;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Diff;
        private System.Windows.Forms.Button btn_UndoCheckOut;
        private System.Windows.Forms.CheckedListBox clb_FileList;
        private System.Windows.Forms.ComboBox cb_VssUrl;
        private System.Windows.Forms.ComboBox cb_VssDir;
        private System.Windows.Forms.ComboBox cb_LocalDir;
    }
}