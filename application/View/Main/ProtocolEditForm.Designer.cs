namespace BioBotApp.View.Main
{
    partial class ProtocolEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProtocolEditForm));
            this.protocolEditControl1 = new BioBotApp.View.Main.ProtocolEditControl();
            this.SuspendLayout();
            // 
            // protocolEditControl1
            // 
            this.protocolEditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.protocolEditControl1.Location = new System.Drawing.Point(0, 0);
            this.protocolEditControl1.Name = "protocolEditControl1";
            this.protocolEditControl1.Size = new System.Drawing.Size(981, 501);
            this.protocolEditControl1.TabIndex = 0;
            // 
            // ProtocolEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 501);
            this.Controls.Add(this.protocolEditControl1);
            this.Name = "ProtocolEditForm";
            this.Text = "ProtocolEditForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ProtocolEditControl protocolEditControl1;
    }
}