namespace UIForm
{
    partial class OtsLogin
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
            this.lbl_userName = new System.Windows.Forms.Label();
            this.lbl_pwd = new System.Windows.Forms.Label();
            this.lbl_code = new System.Windows.Forms.Label();
            this.txt_userName = new System.Windows.Forms.TextBox();
            this.txt_pwd = new System.Windows.Forms.TextBox();
            this.txt_code = new System.Windows.Forms.TextBox();
            this.pic_code = new System.Windows.Forms.PictureBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripMsg = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pic_code)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_userName
            // 
            this.lbl_userName.AutoSize = true;
            this.lbl_userName.Location = new System.Drawing.Point(110, 40);
            this.lbl_userName.Name = "lbl_userName";
            this.lbl_userName.Size = new System.Drawing.Size(53, 12);
            this.lbl_userName.TabIndex = 0;
            this.lbl_userName.Text = "username";
            // 
            // lbl_pwd
            // 
            this.lbl_pwd.AutoSize = true;
            this.lbl_pwd.Location = new System.Drawing.Point(108, 81);
            this.lbl_pwd.Name = "lbl_pwd";
            this.lbl_pwd.Size = new System.Drawing.Size(53, 12);
            this.lbl_pwd.TabIndex = 1;
            this.lbl_pwd.Text = "password";
            // 
            // lbl_code
            // 
            this.lbl_code.AutoSize = true;
            this.lbl_code.Location = new System.Drawing.Point(131, 121);
            this.lbl_code.Name = "lbl_code";
            this.lbl_code.Size = new System.Drawing.Size(29, 12);
            this.lbl_code.TabIndex = 2;
            this.lbl_code.Text = "code";
            // 
            // txt_userName
            // 
            this.txt_userName.Location = new System.Drawing.Point(168, 37);
            this.txt_userName.Name = "txt_userName";
            this.txt_userName.Size = new System.Drawing.Size(122, 21);
            this.txt_userName.TabIndex = 1;
            // 
            // txt_pwd
            // 
            this.txt_pwd.Location = new System.Drawing.Point(168, 77);
            this.txt_pwd.Name = "txt_pwd";
            this.txt_pwd.PasswordChar = '*';
            this.txt_pwd.Size = new System.Drawing.Size(122, 21);
            this.txt_pwd.TabIndex = 2;
            // 
            // txt_code
            // 
            this.txt_code.Location = new System.Drawing.Point(168, 116);
            this.txt_code.Name = "txt_code";
            this.txt_code.Size = new System.Drawing.Size(49, 21);
            this.txt_code.TabIndex = 3;
            // 
            // pic_code
            // 
            this.pic_code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_code.Location = new System.Drawing.Point(223, 115);
            this.pic_code.Name = "pic_code";
            this.pic_code.Size = new System.Drawing.Size(67, 23);
            this.pic_code.TabIndex = 6;
            this.pic_code.TabStop = false;
            this.pic_code.Click += new System.EventHandler(this.pic_code_Click);
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(111, 160);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(75, 23);
            this.btn_login.TabIndex = 4;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(218, 160);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 8;
            this.btn_cancel.Text = "Close";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMsg});
            this.toolStrip1.Location = new System.Drawing.Point(0, 242);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(441, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripMsg
            // 
            this.toolStripMsg.Name = "toolStripMsg";
            this.toolStripMsg.Size = new System.Drawing.Size(0, 22);
            // 
            // OtsLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(441, 267);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.pic_code);
            this.Controls.Add(this.txt_code);
            this.Controls.Add(this.txt_pwd);
            this.Controls.Add(this.txt_userName);
            this.Controls.Add(this.lbl_code);
            this.Controls.Add(this.lbl_pwd);
            this.Controls.Add(this.lbl_userName);
            this.Name = "OtsLogin";
            this.Text = "login";
            this.Load += new System.EventHandler(this.OtsLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_code)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_userName;
        private System.Windows.Forms.Label lbl_pwd;
        private System.Windows.Forms.Label lbl_code;
        private System.Windows.Forms.TextBox txt_userName;
        private System.Windows.Forms.TextBox txt_pwd;
        private System.Windows.Forms.TextBox txt_code;
        private System.Windows.Forms.PictureBox pic_code;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripMsg;
    }
}