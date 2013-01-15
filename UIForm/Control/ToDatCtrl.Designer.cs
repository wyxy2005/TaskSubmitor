namespace UIForm.Control
{
    partial class ToDatCtrl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.rtx_ConfigData = new System.Windows.Forms.RichTextBox();
            this.txt_task = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbx_RecordAll = new System.Windows.Forms.CheckBox();
            this.cbx_Record = new System.Windows.Forms.CheckBox();
            this.cbx_CheckIn = new System.Windows.Forms.CheckBox();
            this.cbx_CheckOut = new System.Windows.Forms.CheckBox();
            this.cbx_SQL = new System.Windows.Forms.CheckBox();
            this.cbx_DevDoc = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_TaskID = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(336, 433);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 0;
            this.btn_Ok.Text = "提交";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(437, 433);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // rtx_ConfigData
            // 
            this.rtx_ConfigData.Location = new System.Drawing.Point(8, 19);
            this.rtx_ConfigData.Name = "rtx_ConfigData";
            this.rtx_ConfigData.Size = new System.Drawing.Size(482, 212);
            this.rtx_ConfigData.TabIndex = 3;
            this.rtx_ConfigData.Text = "";
            // 
            // txt_task
            // 
            this.txt_task.Location = new System.Drawing.Point(84, 70);
            this.txt_task.Name = "txt_task";
            this.txt_task.Size = new System.Drawing.Size(433, 21);
            this.txt_task.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbx_RecordAll);
            this.groupBox1.Controls.Add(this.cbx_Record);
            this.groupBox1.Controls.Add(this.cbx_CheckIn);
            this.groupBox1.Controls.Add(this.cbx_CheckOut);
            this.groupBox1.Controls.Add(this.cbx_SQL);
            this.groupBox1.Controls.Add(this.cbx_DevDoc);
            this.groupBox1.Location = new System.Drawing.Point(22, 341);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 71);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "执行操作";
            // 
            // cbx_RecordAll
            // 
            this.cbx_RecordAll.AutoSize = true;
            this.cbx_RecordAll.Location = new System.Drawing.Point(319, 40);
            this.cbx_RecordAll.Name = "cbx_RecordAll";
            this.cbx_RecordAll.Size = new System.Drawing.Size(138, 16);
            this.cbx_RecordAll.TabIndex = 5;
            this.cbx_RecordAll.Text = "填写更新记录表_总表";
            this.cbx_RecordAll.UseVisualStyleBackColor = true;
            // 
            // cbx_Record
            // 
            this.cbx_Record.AutoSize = true;
            this.cbx_Record.Location = new System.Drawing.Point(319, 17);
            this.cbx_Record.Name = "cbx_Record";
            this.cbx_Record.Size = new System.Drawing.Size(108, 16);
            this.cbx_Record.TabIndex = 4;
            this.cbx_Record.Text = "填写更新记录表";
            this.cbx_Record.UseVisualStyleBackColor = true;
            // 
            // cbx_CheckIn
            // 
            this.cbx_CheckIn.AutoSize = true;
            this.cbx_CheckIn.Location = new System.Drawing.Point(146, 41);
            this.cbx_CheckIn.Name = "cbx_CheckIn";
            this.cbx_CheckIn.Size = new System.Drawing.Size(114, 16);
            this.cbx_CheckIn.TabIndex = 3;
            this.cbx_CheckIn.Text = "CheckIn修改代码";
            this.cbx_CheckIn.UseVisualStyleBackColor = true;
            // 
            // cbx_CheckOut
            // 
            this.cbx_CheckOut.AutoSize = true;
            this.cbx_CheckOut.Location = new System.Drawing.Point(146, 19);
            this.cbx_CheckOut.Name = "cbx_CheckOut";
            this.cbx_CheckOut.Size = new System.Drawing.Size(120, 16);
            this.cbx_CheckOut.TabIndex = 2;
            this.cbx_CheckOut.Text = "CheckOut修改代码";
            this.cbx_CheckOut.UseVisualStyleBackColor = true;
            // 
            // cbx_SQL
            // 
            this.cbx_SQL.AutoSize = true;
            this.cbx_SQL.Location = new System.Drawing.Point(14, 41);
            this.cbx_SQL.Name = "cbx_SQL";
            this.cbx_SQL.Size = new System.Drawing.Size(90, 16);
            this.cbx_SQL.TabIndex = 1;
            this.cbx_SQL.Text = "上传SQL文件";
            this.cbx_SQL.UseVisualStyleBackColor = true;
            // 
            // cbx_DevDoc
            // 
            this.cbx_DevDoc.AutoSize = true;
            this.cbx_DevDoc.Location = new System.Drawing.Point(14, 19);
            this.cbx_DevDoc.Name = "cbx_DevDoc";
            this.cbx_DevDoc.Size = new System.Drawing.Size(96, 16);
            this.cbx_DevDoc.TabIndex = 0;
            this.cbx_DevDoc.Text = "上传开发文档";
            this.cbx_DevDoc.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtx_ConfigData);
            this.groupBox2.Location = new System.Drawing.Point(21, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(496, 237);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "提交参数显示";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "任务工作区";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "任务号";
            // 
            // txt_TaskID
            // 
            this.txt_TaskID.Location = new System.Drawing.Point(85, 30);
            this.txt_TaskID.Name = "txt_TaskID";
            this.txt_TaskID.Size = new System.Drawing.Size(433, 21);
            this.txt_TaskID.TabIndex = 8;
            // 
            // ToDatCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_TaskID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_task);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Ok);
            this.Name = "ToDatCtrl";
            this.Size = new System.Drawing.Size(556, 477);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.RichTextBox rtx_ConfigData;
        private System.Windows.Forms.TextBox txt_task;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbx_DevDoc;
        private System.Windows.Forms.CheckBox cbx_SQL;
        private System.Windows.Forms.CheckBox cbx_CheckOut;
        private System.Windows.Forms.CheckBox cbx_CheckIn;
        private System.Windows.Forms.CheckBox cbx_Record;
        private System.Windows.Forms.CheckBox cbx_RecordAll;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_TaskID;
    }
}
