namespace BioBotCommunicationTest
{
    partial class BioBotCommTest
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
            this.arduinoSerialCommControl1 = new BioBotCommunication.Serial.Movement.ArduinoSerialCommControl();
            this.btnStartWorker = new System.Windows.Forms.Button();
            this.btnStopWorker = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // canConnectorControl1
            // 
            this.canConnectorControl1.Location = new System.Drawing.Point(88, 35);
            this.canConnectorControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.canConnectorControl1.Name = "canConnectorControl1";
            this.canConnectorControl1.Size = new System.Drawing.Size(458, 313);
            this.canConnectorControl1.TabIndex = 0;
            this.canConnectorControl1.Tag = "Can communication";
            // 
            // arduinoSerialCommControl1
            // 
            this.arduinoSerialCommControl1.Location = new System.Drawing.Point(570, 208);
            this.arduinoSerialCommControl1.Name = "arduinoSerialCommControl1";
            this.arduinoSerialCommControl1.Size = new System.Drawing.Size(327, 327);
            this.arduinoSerialCommControl1.TabIndex = 1;
            // 
            // btnStartWorker
            // 
            this.btnStartWorker.Location = new System.Drawing.Point(955, 214);
            this.btnStartWorker.Name = "btnStartWorker";
            this.btnStartWorker.Size = new System.Drawing.Size(163, 36);
            this.btnStartWorker.TabIndex = 2;
            this.btnStartWorker.Text = "Start worker";
            this.btnStartWorker.UseVisualStyleBackColor = true;
            this.btnStartWorker.Click += new System.EventHandler(this.btnStartWorker_Click);
            // 
            // btnStopWorker
            // 
            this.btnStopWorker.Location = new System.Drawing.Point(955, 256);
            this.btnStopWorker.Name = "btnStopWorker";
            this.btnStopWorker.Size = new System.Drawing.Size(163, 36);
            this.btnStopWorker.TabIndex = 3;
            this.btnStopWorker.Text = "Stop worker";
            this.btnStopWorker.UseVisualStyleBackColor = true;
            this.btnStopWorker.Click += new System.EventHandler(this.btnStopWorker_Click);
            // 
            // BioBotCommTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 632);
            this.Controls.Add(this.btnStopWorker);
            this.Controls.Add(this.btnStartWorker);
            this.Controls.Add(this.arduinoSerialCommControl1);
            this.Controls.Add(this.canConnectorControl1);
            this.Name = "BioBotCommTest";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private PCAN.CanConnectorControl canConnectorControl1;
        private BioBotCommunication.Serial.Movement.ArduinoSerialCommControl arduinoSerialCommControl1;
        private System.Windows.Forms.Button btnStartWorker;
        private System.Windows.Forms.Button btnStopWorker;
    }
}

