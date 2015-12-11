namespace BioBotApp.View.Utils.Console
{
    partial class ctrlConsole
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
            this.edtCmdWindow = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.edtSendCmd = new System.Windows.Forms.TextBox();
            this.btnSendCmbToRemote = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // edtCmdWindow
            // 
            this.edtCmdWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtCmdWindow.Location = new System.Drawing.Point(6, 6);
            this.edtCmdWindow.Multiline = true;
            this.edtCmdWindow.Name = "edtCmdWindow";
            this.edtCmdWindow.ReadOnly = true;
            this.edtCmdWindow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.edtCmdWindow.Size = new System.Drawing.Size(812, 453);
            this.edtCmdWindow.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel4.Size = new System.Drawing.Size(832, 582);
            this.panel4.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.edtCmdWindow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 34);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Size = new System.Drawing.Size(824, 465);
            this.panel1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(824, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Console";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.edtSendCmd);
            this.panel5.Controls.Add(this.btnSendCmbToRemote);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(4, 499);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel5.Size = new System.Drawing.Size(824, 78);
            this.panel5.TabIndex = 5;
            // 
            // edtSendCmd
            // 
            this.edtSendCmd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtSendCmd.Location = new System.Drawing.Point(6, 6);
            this.edtSendCmd.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.edtSendCmd.Name = "edtSendCmd";
            this.edtSendCmd.Size = new System.Drawing.Size(812, 26);
            this.edtSendCmd.TabIndex = 3;
            // 
            // btnSendCmbToRemote
            // 
            this.btnSendCmbToRemote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendCmbToRemote.Location = new System.Drawing.Point(711, 38);
            this.btnSendCmbToRemote.Name = "btnSendCmbToRemote";
            this.btnSendCmbToRemote.Size = new System.Drawing.Size(108, 37);
            this.btnSendCmbToRemote.TabIndex = 4;
            this.btnSendCmbToRemote.Text = "Send";
            this.btnSendCmbToRemote.UseVisualStyleBackColor = true;
            this.btnSendCmbToRemote.Click += new System.EventHandler(this.btnSendCmbToRemote_Click);
            // 
            // ctrlConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ctrlConsole";
            this.Size = new System.Drawing.Size(832, 582);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox edtCmdWindow;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox edtSendCmd;
        private System.Windows.Forms.Button btnSendCmbToRemote;
        private System.Windows.Forms.Panel panel1;
    }
}
