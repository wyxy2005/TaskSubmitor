namespace UIForm
{
    partial class NewTask
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
            this.btn_OK = new System.Windows.Forms.Button();
            this.txt_Prefix = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Workspace = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_No = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.cbx_RecordXls = new System.Windows.Forms.CheckBox();
            this.cbx_DmlSql = new System.Windows.Forms.CheckBox();
            this.cbx_DevSql = new System.Windows.Forms.CheckBox();
            this.cbx_TestDoc = new System.Windows.Forms.CheckBox();
            this.cbx_DesignDoc = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "任务标识";
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(283, 376);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "创 建";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // txt_Prefix
            // 
            this.txt_Prefix.Location = new System.Drawing.Point(139, 64);
            this.txt_Prefix.Name = "txt_Prefix";
            this.txt_Prefix.Size = new System.Drawing.Size(104, 21);
            this.txt_Prefix.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "本地目录";
            // 
            // lbl_Workspace
            // 
            this.lbl_Workspace.AutoSize = true;
            this.lbl_Workspace.Location = new System.Drawing.Point(139, 20);
            this.lbl_Workspace.Name = "lbl_Workspace";
            this.lbl_Workspace.Size = new System.Drawing.Size(59, 12);
            this.lbl_Workspace.TabIndex = 4;
            this.lbl_Workspace.Text = "workspace";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "任务编号";
            // 
            // txt_No
            // 
            this.txt_No.Location = new System.Drawing.Point(139, 101);
            this.txt_No.Name = "txt_No";
            this.txt_No.Size = new System.Drawing.Size(104, 21);
            this.txt_No.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "任务名称";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(139, 140);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(382, 21);
            this.txt_Name.TabIndex = 8;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(395, 374);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 9;
            this.btn_Cancel.Text = "取 消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox7);
            this.groupBox1.Controls.Add(this.checkBox6);
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Controls.Add(this.cbx_RecordXls);
            this.groupBox1.Controls.Add(this.cbx_DmlSql);
            this.groupBox1.Controls.Add(this.cbx_DevSql);
            this.groupBox1.Controls.Add(this.cbx_TestDoc);
            this.groupBox1.Controls.Add(this.cbx_DesignDoc);
            this.groupBox1.Location = new System.Drawing.Point(63, 186);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 143);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "创建选项";
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(324, 87);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(78, 16);
            this.checkBox7.TabIndex = 7;
            this.checkBox7.Text = "数据表PDM";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(324, 51);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(96, 16);
            this.checkBox6.TabIndex = 6;
            this.checkBox6.Text = "表变更审批表";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(324, 18);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(66, 16);
            this.checkBox5.TabIndex = 5;
            this.checkBox5.Text = "DDL-SQL";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // cbx_RecordXls
            // 
            this.cbx_RecordXls.AutoSize = true;
            this.cbx_RecordXls.Location = new System.Drawing.Point(31, 90);
            this.cbx_RecordXls.Name = "cbx_RecordXls";
            this.cbx_RecordXls.Size = new System.Drawing.Size(72, 16);
            this.cbx_RecordXls.TabIndex = 4;
            this.cbx_RecordXls.Text = "修改列表";
            this.cbx_RecordXls.UseVisualStyleBackColor = true;
            // 
            // cbx_DmlSql
            // 
            this.cbx_DmlSql.AutoSize = true;
            this.cbx_DmlSql.Location = new System.Drawing.Point(187, 53);
            this.cbx_DmlSql.Name = "cbx_DmlSql";
            this.cbx_DmlSql.Size = new System.Drawing.Size(66, 16);
            this.cbx_DmlSql.TabIndex = 3;
            this.cbx_DmlSql.Text = "DML-SQL";
            this.cbx_DmlSql.UseVisualStyleBackColor = true;
            // 
            // cbx_DevSql
            // 
            this.cbx_DevSql.AutoSize = true;
            this.cbx_DevSql.Location = new System.Drawing.Point(188, 21);
            this.cbx_DevSql.Name = "cbx_DevSql";
            this.cbx_DevSql.Size = new System.Drawing.Size(66, 16);
            this.cbx_DevSql.TabIndex = 2;
            this.cbx_DevSql.Text = "DEV-SQL";
            this.cbx_DevSql.UseVisualStyleBackColor = true;
            // 
            // cbx_TestDoc
            // 
            this.cbx_TestDoc.AutoSize = true;
            this.cbx_TestDoc.Location = new System.Drawing.Point(31, 56);
            this.cbx_TestDoc.Name = "cbx_TestDoc";
            this.cbx_TestDoc.Size = new System.Drawing.Size(72, 16);
            this.cbx_TestDoc.TabIndex = 1;
            this.cbx_TestDoc.Text = "自测报告";
            this.cbx_TestDoc.UseVisualStyleBackColor = true;
            // 
            // cbx_DesignDoc
            // 
            this.cbx_DesignDoc.AutoSize = true;
            this.cbx_DesignDoc.Location = new System.Drawing.Point(31, 22);
            this.cbx_DesignDoc.Name = "cbx_DesignDoc";
            this.cbx_DesignDoc.Size = new System.Drawing.Size(72, 16);
            this.cbx_DesignDoc.TabIndex = 0;
            this.cbx_DesignDoc.Text = "设计文档";
            this.cbx_DesignDoc.UseVisualStyleBackColor = true;
            // 
            // NewTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 426);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_No);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_Workspace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Prefix);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.label1);
            this.Name = "NewTask";
            this.Text = "创建任务";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.TextBox txt_Prefix;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Workspace;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_No;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbx_DesignDoc;
        private System.Windows.Forms.CheckBox cbx_RecordXls;
        private System.Windows.Forms.CheckBox cbx_DmlSql;
        private System.Windows.Forms.CheckBox cbx_DevSql;
        private System.Windows.Forms.CheckBox cbx_TestDoc;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
    }
}