namespace UIForm.Tools
{
    partial class Online
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
            this.toOnlineCtrl1 = new UIForm.ToOnlineCtrl();
            this.SuspendLayout();
            // 
            // toOnlineCtrl1
            // 
            this.toOnlineCtrl1.Location = new System.Drawing.Point(12, 12);
            this.toOnlineCtrl1.Name = "toOnlineCtrl1";
            this.toOnlineCtrl1.Size = new System.Drawing.Size(717, 534);
            this.toOnlineCtrl1.TabIndex = 0;
            this.toOnlineCtrl1.Load += new System.EventHandler(this.toOnlineCtrl1_Load);
            // 
            // Online
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 558);
            this.Controls.Add(this.toOnlineCtrl1);
            this.Name = "Online";
            this.Text = "上线工具箱";
            this.ResumeLayout(false);

        }

        #endregion

        private ToOnlineCtrl toOnlineCtrl1;
    }
}