namespace BioBotCommunication.Serial.Movement
{
    partial class SerialCommControl
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ddlPortName = new System.Windows.Forms.ComboBox();
            this.btnResfresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ddlBaud = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ddlDataBits = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ddlParity = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ddlStopBits = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.Controls.Add(this.panel5);
            this.flowLayoutPanel1.Controls.Add(this.btnConnect);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(734, 327);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.ddlPortName);
            this.panel1.Controls.Add(this.btnResfresh);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.MinimumSize = new System.Drawing.Size(259, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(259, 28);
            this.panel1.TabIndex = 0;
            // 
            // ddlPortName
            // 
            this.ddlPortName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ddlPortName.FormattingEnabled = true;
            this.ddlPortName.Location = new System.Drawing.Point(122, 0);
            this.ddlPortName.Name = "ddlPortName";
            this.ddlPortName.Size = new System.Drawing.Size(109, 28);
            this.ddlPortName.TabIndex = 1;
            // 
            // btnResfresh
            // 
            this.btnResfresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnResfresh.Image = global::BioBotCommunication.Properties.Resources.arrow_rotate_clockwise;
            this.btnResfresh.Location = new System.Drawing.Point(231, 0);
            this.btnResfresh.MinimumSize = new System.Drawing.Size(28, 28);
            this.btnResfresh.Name = "btnResfresh";
            this.btnResfresh.Size = new System.Drawing.Size(28, 28);
            this.btnResfresh.TabIndex = 2;
            this.btnResfresh.UseVisualStyleBackColor = true;
            this.btnResfresh.Click += new System.EventHandler(this.btnResfresh_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.ddlBaud);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 37);
            this.panel2.MinimumSize = new System.Drawing.Size(259, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(259, 28);
            this.panel2.TabIndex = 1;
            // 
            // ddlBaud
            // 
            this.ddlBaud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ddlBaud.FormattingEnabled = true;
            this.ddlBaud.Location = new System.Drawing.Point(122, 0);
            this.ddlBaud.Name = "ddlBaud";
            this.ddlBaud.Size = new System.Drawing.Size(137, 28);
            this.ddlBaud.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Baud:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Controls.Add(this.ddlDataBits);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(3, 71);
            this.panel3.MinimumSize = new System.Drawing.Size(259, 28);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(259, 28);
            this.panel3.TabIndex = 2;
            // 
            // ddlDataBits
            // 
            this.ddlDataBits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ddlDataBits.FormattingEnabled = true;
            this.ddlDataBits.Location = new System.Drawing.Point(122, 0);
            this.ddlDataBits.Name = "ddlDataBits";
            this.ddlDataBits.Size = new System.Drawing.Size(137, 28);
            this.ddlDataBits.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Data bits:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4.Controls.Add(this.ddlParity);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(3, 105);
            this.panel4.MinimumSize = new System.Drawing.Size(259, 28);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(259, 28);
            this.panel4.TabIndex = 3;
            // 
            // ddlParity
            // 
            this.ddlParity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ddlParity.FormattingEnabled = true;
            this.ddlParity.Location = new System.Drawing.Point(122, 0);
            this.ddlParity.Name = "ddlParity";
            this.ddlParity.Size = new System.Drawing.Size(137, 28);
            this.ddlParity.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 28);
            this.label4.TabIndex = 0;
            this.label4.Text = "Parity:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel5.Controls.Add(this.ddlStopBits);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(3, 139);
            this.panel5.MinimumSize = new System.Drawing.Size(259, 28);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(259, 28);
            this.panel5.TabIndex = 4;
            // 
            // ddlStopBits
            // 
            this.ddlStopBits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ddlStopBits.FormattingEnabled = true;
            this.ddlStopBits.Location = new System.Drawing.Point(122, 0);
            this.ddlStopBits.Name = "ddlStopBits";
            this.ddlStopBits.Size = new System.Drawing.Size(137, 28);
            this.ddlStopBits.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 28);
            this.label5.TabIndex = 0;
            this.label5.Text = "Stop bits:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(3, 173);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(104, 34);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // ArduinoSerialCommControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ArduinoSerialCommControl";
            this.Size = new System.Drawing.Size(734, 327);
            this.Load += new System.EventHandler(this.ArduinoSerialCommControl_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox ddlPortName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox ddlBaud;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox ddlDataBits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox ddlParity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox ddlStopBits;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnResfresh;
        private System.Windows.Forms.Button btnConnect;
    }
}
