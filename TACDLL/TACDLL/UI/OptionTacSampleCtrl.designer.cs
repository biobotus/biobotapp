namespace TACDLL.OptionCtrl
{
    partial class optionTacSampleCtrl
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
            this.components = new System.ComponentModel.Container();
            this.btnStartSample = new System.Windows.Forms.Button();
            this.lblSampleNb = new System.Windows.Forms.Label();
            this.sampleCtrl = new System.Windows.Forms.ProgressBar();
            this.acquisitionTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnStartSample
            // 
            this.btnStartSample.Location = new System.Drawing.Point(3, 8);
            this.btnStartSample.Name = "btnStartSample";
            this.btnStartSample.Size = new System.Drawing.Size(75, 23);
            this.btnStartSample.TabIndex = 0;
            this.btnStartSample.Text = "Start sample";
            this.btnStartSample.UseVisualStyleBackColor = true;
            this.btnStartSample.Click += new System.EventHandler(this.btnStartSample_Click);
            // 
            // lblSampleNb
            // 
            this.lblSampleNb.AutoSize = true;
            this.lblSampleNb.Location = new System.Drawing.Point(84, 13);
            this.lblSampleNb.Name = "lblSampleNb";
            this.lblSampleNb.Size = new System.Drawing.Size(105, 13);
            this.lblSampleNb.TabIndex = 1;
            this.lblSampleNb.Text = "number of sample : 0";
            this.lblSampleNb.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // sampleCtrl
            // 
            this.sampleCtrl.Location = new System.Drawing.Point(212, 8);
            this.sampleCtrl.Name = "sampleCtrl";
            this.sampleCtrl.Size = new System.Drawing.Size(96, 23);
            this.sampleCtrl.TabIndex = 2;
            // 
            // acquisitionTimer
            // 
            this.acquisitionTimer.Interval = 200;
            this.acquisitionTimer.Tick += new System.EventHandler(this.acquisitionTimer_Tick);
            // 
            // optionTacSampleCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sampleCtrl);
            this.Controls.Add(this.lblSampleNb);
            this.Controls.Add(this.btnStartSample);
            this.Name = "optionTacSampleCtrl";
            this.Size = new System.Drawing.Size(311, 37);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartSample;
        private System.Windows.Forms.Label lblSampleNb;
        private System.Windows.Forms.ProgressBar sampleCtrl;
        private System.Windows.Forms.Timer acquisitionTimer;
    }
}
