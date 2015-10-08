namespace BioBotApp.View.Protocol
{
    partial class ProtocolControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtProtocolName = new System.Windows.Forms.TextBox();
            this.btnSendToPresenter = new System.Windows.Forms.Button();
            this.txtSendToPresenter = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtProtocolName
            // 
            this.txtProtocolName.Location = new System.Drawing.Point(56, 164);
            this.txtProtocolName.Name = "txtProtocolName";
            this.txtProtocolName.Size = new System.Drawing.Size(100, 26);
            this.txtProtocolName.TabIndex = 0;
            // 
            // btnSendToPresenter
            // 
            this.btnSendToPresenter.Location = new System.Drawing.Point(189, 164);
            this.btnSendToPresenter.Name = "btnSendToPresenter";
            this.btnSendToPresenter.Size = new System.Drawing.Size(182, 37);
            this.btnSendToPresenter.TabIndex = 1;
            this.btnSendToPresenter.Text = "Send to presenter";
            this.btnSendToPresenter.UseVisualStyleBackColor = true;
            this.btnSendToPresenter.Click += new System.EventHandler(this.btnSendToPresenter_Click_1);
            // 
            // txtSendToPresenter
            // 
            this.txtSendToPresenter.Location = new System.Drawing.Point(56, 63);
            this.txtSendToPresenter.Name = "txtSendToPresenter";
            this.txtSendToPresenter.Size = new System.Drawing.Size(516, 26);
            this.txtSendToPresenter.TabIndex = 2;
            // 
            // ProtocolControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSendToPresenter);
            this.Controls.Add(this.btnSendToPresenter);
            this.Controls.Add(this.txtProtocolName);
            this.Name = "ProtocolControl";
            this.Size = new System.Drawing.Size(648, 560);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProtocolName;
        private System.Windows.Forms.Button btnSendToPresenter;
        private System.Windows.Forms.TextBox txtSendToPresenter;
    }
}
