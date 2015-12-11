namespace BioBotApp.View.Main
{
    partial class MainViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainViewForm));
            this.mainView1 = new BioBotApp.View.Main.MainViewControl();
            this.SuspendLayout();
            // 
            // mainView1
            // 
            this.mainView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainView1.Location = new System.Drawing.Point(0, 0);
            this.mainView1.Name = "mainView1";
            this.mainView1.Size = new System.Drawing.Size(915, 422);
            this.mainView1.TabIndex = 0;
            this.mainView1.Load += new System.EventHandler(this.mainView1_Load);
            // 
            // MainViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 422);
            this.Controls.Add(this.mainView1);
            this.Name = "MainViewForm";
            this.Text = "Biobot application";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainViewForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private MainViewControl mainView1;
    }
}