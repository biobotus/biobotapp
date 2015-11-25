namespace BioBotApp.View.Step
{
    partial class StepForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StepForm));
            this.protocolControl1 = new BioBotApp.View.Protocol.ProtocolControl();
            this.SuspendLayout();
            // 
            // protocolControl1
            // 
            this.protocolControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.protocolControl1.Location = new System.Drawing.Point(0, 0);
            this.protocolControl1.Margin = new System.Windows.Forms.Padding(2);
            this.protocolControl1.Name = "protocolControl1";
            this.protocolControl1.Size = new System.Drawing.Size(1014, 438);
            this.protocolControl1.TabIndex = 1;
            // 
            // StepForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 438);
            this.Controls.Add(this.protocolControl1);
            this.Name = "StepForm";
            this.Text = "StepForm";
            this.ResumeLayout(false);

        }

        #endregion
        private Protocol.ProtocolControl protocolControl1;
    }
}