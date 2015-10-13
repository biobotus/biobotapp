namespace BioBotApp.View.Properties
{
    partial class PropertiesForm
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
            this.propertiesControl1 = new BioBotApp.View.Properties.PropertiesControl();
            this.SuspendLayout();
            // 
            // propertiesControl1
            // 
            this.propertiesControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertiesControl1.Location = new System.Drawing.Point(0, 0);
            this.propertiesControl1.Name = "propertiesControl1";
            this.propertiesControl1.Size = new System.Drawing.Size(1314, 865);
            this.propertiesControl1.TabIndex = 0;
            // 
            // PropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1314, 865);
            this.Controls.Add(this.propertiesControl1);
            this.Name = "PropertiesForm";
            this.Text = "PropertiesForm";
            this.ResumeLayout(false);

        }

        #endregion

        private PropertiesControl propertiesControl1;
    }
}