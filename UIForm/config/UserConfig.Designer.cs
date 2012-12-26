namespace UIForm.config
{
    partial class UserConfig
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
            this.txt_Username = new System.Windows.Forms.TextBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.txt_VssSrc = new System.Windows.Forms.TextBox();
            this.btn_UserOK = new System.Windows.Forms.Button();
            this.btn_UserCancel = new System.Windows.Forms.Button();
            this.txt_VssDoc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "vss用户";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "vss密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "vss路径src";
            // 
            // txt_Username
            // 
            this.txt_Username.Location = new System.Drawing.Point(149, 45);
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.Size = new System.Drawing.Size(111, 21);
            this.txt_Username.TabIndex = 3;
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(149, 90);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(111, 21);
            this.txt_Password.TabIndex = 4;
            // 
            // txt_VssSrc
            // 
            this.txt_VssSrc.Location = new System.Drawing.Point(149, 136);
            this.txt_VssSrc.Name = "txt_VssSrc";
            this.txt_VssSrc.Size = new System.Drawing.Size(413, 21);
            this.txt_VssSrc.TabIndex = 5;
            // 
            // btn_UserOK
            // 
            this.btn_UserOK.Location = new System.Drawing.Point(317, 433);
            this.btn_UserOK.Name = "btn_UserOK";
            this.btn_UserOK.Size = new System.Drawing.Size(75, 23);
            this.btn_UserOK.TabIndex = 7;
            this.btn_UserOK.Text = "确定";
            this.btn_UserOK.UseVisualStyleBackColor = true;
            this.btn_UserOK.Click += new System.EventHandler(this.btn_UserOK_Click);
            // 
            // btn_UserCancel
            // 
            this.btn_UserCancel.Location = new System.Drawing.Point(460, 433);
            this.btn_UserCancel.Name = "btn_UserCancel";
            this.btn_UserCancel.Size = new System.Drawing.Size(75, 23);
            this.btn_UserCancel.TabIndex = 8;
            this.btn_UserCancel.Text = "取消";
            this.btn_UserCancel.UseVisualStyleBackColor = true;
            this.btn_UserCancel.Click += new System.EventHandler(this.btn_UserCancel_Click);
            // 
            // txt_VssDoc
            // 
            this.txt_VssDoc.Location = new System.Drawing.Point(149, 190);
            this.txt_VssDoc.Name = "txt_VssDoc";
            this.txt_VssDoc.Size = new System.Drawing.Size(413, 21);
            this.txt_VssDoc.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "vss路径src";
            // 
            // UserConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 486);
            this.Controls.Add(this.txt_VssDoc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_UserCancel);
            this.Controls.Add(this.btn_UserOK);
            this.Controls.Add(this.txt_VssSrc);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.txt_Username);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UserConfig";
            this.Text = "用户配置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Username;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.TextBox txt_VssSrc;
        private System.Windows.Forms.Button btn_UserOK;
        private System.Windows.Forms.Button btn_UserCancel;
        private System.Windows.Forms.TextBox txt_VssDoc;
        private System.Windows.Forms.Label label4;
    }
}