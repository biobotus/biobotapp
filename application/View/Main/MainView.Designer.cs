namespace BioBotApp.View.Main
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.protocolControl1 = new BioBotApp.View.Protocol.ProtocolControl();
            this.stepView21 = new BioBotApp.View.Step.StepView2();
            this.operationControl21 = new BioBotApp.View.Step.OperationControl2();
            this.SuspendLayout();
            // 
            // protocolControl1
            // 
            this.protocolControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.protocolControl1.Location = new System.Drawing.Point(0, 0);
            this.protocolControl1.Margin = new System.Windows.Forms.Padding(2);
            this.protocolControl1.Name = "protocolControl1";
            this.protocolControl1.Padding = new System.Windows.Forms.Padding(3);
            this.protocolControl1.Size = new System.Drawing.Size(293, 471);
            this.protocolControl1.TabIndex = 0;
            // 
            // stepView21
            // 
            this.stepView21.Dock = System.Windows.Forms.DockStyle.Left;
            this.stepView21.Location = new System.Drawing.Point(293, 0);
            this.stepView21.Name = "stepView21";
            this.stepView21.Size = new System.Drawing.Size(342, 471);
            this.stepView21.TabIndex = 1;
            // 
            // operationControl21
            // 
            this.operationControl21.Dock = System.Windows.Forms.DockStyle.Left;
            this.operationControl21.Location = new System.Drawing.Point(635, 0);
            this.operationControl21.Name = "operationControl21";
            this.operationControl21.Size = new System.Drawing.Size(273, 471);
            this.operationControl21.TabIndex = 2;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.operationControl21);
            this.Controls.Add(this.stepView21);
            this.Controls.Add(this.protocolControl1);
            this.Name = "MainView";
            this.Size = new System.Drawing.Size(978, 471);
            this.ResumeLayout(false);

        }

        #endregion

        private Protocol.ProtocolControl protocolControl1;
        private Step.StepView2 stepView21;
        private Step.OperationControl2 operationControl21;
    }
}
