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
            this.operationTypeControl1 = new BioBotApp.View.Operation.OperationType.OperationTypeControl();
            this.protocolControl1 = new BioBotApp.View.Protocol.ProtocolControl();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // operationTypeControl1
            // 
            this.operationTypeControl1.dataset = null;
            this.operationTypeControl1.Location = new System.Drawing.Point(71, 34);
            this.operationTypeControl1.Name = "operationTypeControl1";
            this.operationTypeControl1.Size = new System.Drawing.Size(408, 21);
            this.operationTypeControl1.TabIndex = 1;
            // 
            // protocolControl1
            // 
            this.protocolControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.protocolControl1.Location = new System.Drawing.Point(0, 112);
            this.protocolControl1.Margin = new System.Windows.Forms.Padding(1);
            this.protocolControl1.Name = "protocolControl1";
            this.protocolControl1.Size = new System.Drawing.Size(556, 282);
            this.protocolControl1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(343, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProtocolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 394);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.operationTypeControl1);
            this.Controls.Add(this.protocolControl1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ProtocolForm";
            this.Text = "ProtocolForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ProtocolControl protocolControl1;
        private Operation.OperationType.OperationTypeControl operationTypeControl1;
        private System.Windows.Forms.Button button1;
    }
}