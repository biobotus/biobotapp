namespace BioBotApp.View.Main
{
    partial class MainTestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainTestForm));
            this.protocolStepView1 = new BioBotApp.View.Protocol.ProtocolStepView();
            this.protocolEditControl1 = new BioBotApp.View.Main.ProtocolEditControl();
            this.SuspendLayout();
            // 
            // protocolStepView1
            // 
            this.protocolStepView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.protocolStepView1.Location = new System.Drawing.Point(0, 0);
            this.protocolStepView1.Name = "protocolStepView1";
            this.protocolStepView1.Size = new System.Drawing.Size(412, 490);
            this.protocolStepView1.TabIndex = 0;
            // 
            // protocolEditControl1
            // 
            this.protocolEditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.protocolEditControl1.Location = new System.Drawing.Point(412, 0);
            this.protocolEditControl1.Name = "protocolEditControl1";
            this.protocolEditControl1.Size = new System.Drawing.Size(1004, 490);
            this.protocolEditControl1.TabIndex = 1;
            // 
            // MainTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 490);
            this.Controls.Add(this.protocolEditControl1);
            this.Controls.Add(this.protocolStepView1);
            this.Name = "MainTestForm";
            this.Text = "MainTestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Protocol.ProtocolStepView protocolStepView1;
        private ProtocolEditControl protocolEditControl1;
    }
}