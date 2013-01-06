namespace UIForm.UI
{
    partial class ToDATForm
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
            this.toDatCtrl1 = new UIForm.Control.ToDatCtrl();
            this.SuspendLayout();
            // 
            // toDatCtrl1
            // 
            this.toDatCtrl1.Location = new System.Drawing.Point(25, 7);
            this.toDatCtrl1.Name = "toDatCtrl1";
            this.toDatCtrl1.Size = new System.Drawing.Size(550, 436);
            this.toDatCtrl1.TabIndex = 0;
            this.toDatCtrl1.TaskNo = 0;
            // 
            // ToDATForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 455);
            this.Controls.Add(this.toDatCtrl1);
            this.Name = "ToDATForm";
            this.Text = "提交DAT";
            this.ResumeLayout(false);

        }

        #endregion

        private Control.ToDatCtrl toDatCtrl1;
    }
}