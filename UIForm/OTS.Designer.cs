namespace UIForm
{
    partial class OTS
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
            this.pic_loginRand = new System.Windows.Forms.PictureBox();
            this.txt_LoginRand = new System.Windows.Forms.TextBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.txt_pwd = new System.Windows.Forms.TextBox();
            this.btn_query = new System.Windows.Forms.Button();
            this.rtb = new System.Windows.Forms.RichTextBox();
            this.txt_inteval = new System.Windows.Forms.TextBox();
            this.btn_autoQuery = new System.Windows.Forms.Button();
            this.lbl_refreshTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_loginRand)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_loginRand
            // 
            this.pic_loginRand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_loginRand.Location = new System.Drawing.Point(186, 58);
            this.pic_loginRand.Name = "pic_loginRand";
            this.pic_loginRand.Size = new System.Drawing.Size(86, 37);
            this.pic_loginRand.TabIndex = 0;
            this.pic_loginRand.TabStop = false;
            this.pic_loginRand.Click += new System.EventHandler(this.pic_loginRand_Click);
            // 
            // txt_LoginRand
            // 
            this.txt_LoginRand.Location = new System.Drawing.Point(80, 65);
            this.txt_LoginRand.Name = "txt_LoginRand";
            this.txt_LoginRand.Size = new System.Drawing.Size(100, 21);
            this.txt_LoginRand.TabIndex = 1;
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(278, 63);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(75, 23);
            this.btn_Login.TabIndex = 2;
            this.btn_Login.Text = "login";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // txt_pwd
            // 
            this.txt_pwd.Location = new System.Drawing.Point(80, 27);
            this.txt_pwd.Name = "txt_pwd";
            this.txt_pwd.PasswordChar = '*';
            this.txt_pwd.Size = new System.Drawing.Size(100, 21);
            this.txt_pwd.TabIndex = 3;
            // 
            // btn_query
            // 
            this.btn_query.Location = new System.Drawing.Point(386, 63);
            this.btn_query.Name = "btn_query";
            this.btn_query.Size = new System.Drawing.Size(75, 23);
            this.btn_query.TabIndex = 4;
            this.btn_query.Text = "query";
            this.btn_query.UseVisualStyleBackColor = true;
            this.btn_query.Click += new System.EventHandler(this.btn_query_Click);
            // 
            // rtb
            // 
            this.rtb.Location = new System.Drawing.Point(49, 188);
            this.rtb.Name = "rtb";
            this.rtb.Size = new System.Drawing.Size(615, 237);
            this.rtb.TabIndex = 6;
            this.rtb.Text = "";
            // 
            // txt_inteval
            // 
            this.txt_inteval.Location = new System.Drawing.Point(550, 65);
            this.txt_inteval.Name = "txt_inteval";
            this.txt_inteval.Size = new System.Drawing.Size(45, 21);
            this.txt_inteval.TabIndex = 7;
            // 
            // btn_autoQuery
            // 
            this.btn_autoQuery.Location = new System.Drawing.Point(601, 63);
            this.btn_autoQuery.Name = "btn_autoQuery";
            this.btn_autoQuery.Size = new System.Drawing.Size(75, 23);
            this.btn_autoQuery.TabIndex = 8;
            this.btn_autoQuery.Text = "auto";
            this.btn_autoQuery.UseVisualStyleBackColor = true;
            this.btn_autoQuery.Click += new System.EventHandler(this.btn_autoQuery_Click);
            // 
            // lbl_refreshTime
            // 
            this.lbl_refreshTime.AutoSize = true;
            this.lbl_refreshTime.Location = new System.Drawing.Point(682, 68);
            this.lbl_refreshTime.Name = "lbl_refreshTime";
            this.lbl_refreshTime.Size = new System.Drawing.Size(11, 12);
            this.lbl_refreshTime.TabIndex = 9;
            this.lbl_refreshTime.Text = "0";
            // 
            // OTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 510);
            this.Controls.Add(this.lbl_refreshTime);
            this.Controls.Add(this.btn_autoQuery);
            this.Controls.Add(this.txt_inteval);
            this.Controls.Add(this.rtb);
            this.Controls.Add(this.btn_query);
            this.Controls.Add(this.txt_pwd);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.txt_LoginRand);
            this.Controls.Add(this.pic_loginRand);
            this.Name = "OTS";
            this.Text = "OTS";
            ((System.ComponentModel.ISupportInitialize)(this.pic_loginRand)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_loginRand;
        private System.Windows.Forms.TextBox txt_LoginRand;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.TextBox txt_pwd;
        private System.Windows.Forms.Button btn_query;
        private System.Windows.Forms.RichTextBox rtb;
        private System.Windows.Forms.TextBox txt_inteval;
        private System.Windows.Forms.Button btn_autoQuery;
        private System.Windows.Forms.Label lbl_refreshTime;
    }
}