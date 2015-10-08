namespace BioBotApp.View.Protocol
{
    partial class ProtocolForm
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
            this.protocolControl1 = new BioBotApp.View.Protocol.ProtocolControl();
            this.SuspendLayout();
            // 
            // protocolControl1
            // 
            this.protocolControl1.Location = new System.Drawing.Point(48, 31);
            this.protocolControl1.Name = "protocolControl1";
            this.protocolControl1.Size = new System.Drawing.Size(648, 560);
            this.protocolControl1.TabIndex = 0;
            // 
            // ProtocolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 619);
            this.Controls.Add(this.protocolControl1);
            this.Name = "ProtocolForm";
            this.Text = "ProtocolForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ProtocolControl protocolControl1;
    }
}