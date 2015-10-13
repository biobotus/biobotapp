namespace BioBotApp.View.Communication
{
    partial class CommunicationTestForm
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
            this.canConnectorControl1 = new PCAN.CanConnectorControl();
            this.btnConnectArduino = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // canConnectorControl1
            // 
            this.canConnectorControl1.Location = new System.Drawing.Point(13, 14);
            this.canConnectorControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.canConnectorControl1.Name = "canConnectorControl1";
            this.canConnectorControl1.Size = new System.Drawing.Size(458, 313);
            this.canConnectorControl1.TabIndex = 0;
            this.canConnectorControl1.Tag = "Can communication";
            // 
            // btnConnectArduino
            // 
            this.btnConnectArduino.Location = new System.Drawing.Point(330, 376);
            this.btnConnectArduino.Name = "btnConnectArduino";
            this.btnConnectArduino.Size = new System.Drawing.Size(172, 50);
            this.btnConnectArduino.TabIndex = 1;
            this.btnConnectArduino.Text = "Connect Arduino";
            this.btnConnectArduino.UseVisualStyleBackColor = true;
            this.btnConnectArduino.Click += new System.EventHandler(this.btnConnectArduino_Click);
            // 
            // CommunicationTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 602);
            this.Controls.Add(this.btnConnectArduino);
            this.Controls.Add(this.canConnectorControl1);
            this.Name = "CommunicationTestForm";
            this.Text = "CommunicationTestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private PCAN.CanConnectorControl canConnectorControl1;
        private System.Windows.Forms.Button btnConnectArduino;
    }
}