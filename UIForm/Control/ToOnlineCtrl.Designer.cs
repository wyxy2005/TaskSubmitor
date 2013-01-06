namespace UIForm
{
    partial class ToOnlineCtrl
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Online = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(118, 80);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(363, 21);
            this.textBox1.TabIndex = 0;
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(487, 78);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(75, 23);
            this.btn_Browse.TabIndex = 1;
            this.btn_Browse.Text = "浏览";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "更新记录";
            // 
            // btn_Online
            // 
            this.btn_Online.Location = new System.Drawing.Point(474, 493);
            this.btn_Online.Name = "btn_Online";
            this.btn_Online.Size = new System.Drawing.Size(75, 23);
            this.btn_Online.TabIndex = 3;
            this.btn_Online.Text = "上线";
            this.btn_Online.UseVisualStyleBackColor = true;
            this.btn_Online.Click += new System.EventHandler(this.btn_Online_Click);
            // 
            // ToOnlineCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Online);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.textBox1);
            this.Name = "ToOnlineCtrl";
            this.Size = new System.Drawing.Size(671, 543);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Online;

    }
}
