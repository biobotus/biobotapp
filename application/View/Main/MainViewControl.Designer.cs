namespace BioBotApp.View.Main
{
    partial class MainViewControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainViewControl));
            this.bioBotDataSets = new BioBotApp.Model.Data.BioBotDataSets();
            this.bsObject = new System.Windows.Forms.BindingSource(this.components);
            this.executeView1 = new BioBotApp.View.Execute.ExecuteView();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.txtConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.protocolStepView2 = new BioBotApp.View.Protocol.ProtocolStepView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.operationControl21 = new BioBotApp.View.Step.OperationControl2();
            this.protocolStepView1 = new BioBotApp.View.Protocol.ProtocolStepView();
            this.operationReferenceControl1 = new BioBotApp.View.Operation.OperationReference.OperationReferenceControl();
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsObject)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bioBotDataSets
            // 
            this.bioBotDataSets.DataSetName = "BioBotDataSets";
            this.bioBotDataSets.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bsObject
            // 
            this.bsObject.DataMember = "bbt_object";
            this.bsObject.DataSource = this.bioBotDataSets;
            // 
            // executeView1
            // 
            this.executeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.executeView1.Location = new System.Drawing.Point(3, 3);
            this.executeView1.Name = "executeView1";
            this.executeView1.Padding = new System.Windows.Forms.Padding(3);
            this.executeView1.Size = new System.Drawing.Size(250, 393);
            this.executeView1.TabIndex = 3;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtConnectionStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 449);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(996, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip";
            // 
            // txtConnectionStatus
            // 
            this.txtConnectionStatus.Name = "txtConnectionStatus";
            this.txtConnectionStatus.Size = new System.Drawing.Size(86, 17);
            this.txtConnectionStatus.Text = "Not connected";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(996, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConnect,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // btnConnect
            // 
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(119, 22);
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(996, 425);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.protocolStepView2);
            this.tabPage1.Controls.Add(this.executeView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(988, 399);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // protocolStepView2
            // 
            this.protocolStepView2.Dock = System.Windows.Forms.DockStyle.Left;
            this.protocolStepView2.Location = new System.Drawing.Point(253, 3);
            this.protocolStepView2.Name = "protocolStepView2";
            this.protocolStepView2.Padding = new System.Windows.Forms.Padding(3);
            this.protocolStepView2.ShowToolbar = false;
            this.protocolStepView2.Size = new System.Drawing.Size(309, 393);
            this.protocolStepView2.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.operationReferenceControl1);
            this.tabPage2.Controls.Add(this.operationControl21);
            this.tabPage2.Controls.Add(this.protocolStepView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(988, 399);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // operationControl21
            // 
            this.operationControl21.Dock = System.Windows.Forms.DockStyle.Left;
            this.operationControl21.Location = new System.Drawing.Point(347, 3);
            this.operationControl21.Name = "operationControl21";
            this.operationControl21.Size = new System.Drawing.Size(364, 393);
            this.operationControl21.TabIndex = 1;
            // 
            // protocolStepView1
            // 
            this.protocolStepView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.protocolStepView1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.protocolStepView1.Location = new System.Drawing.Point(3, 3);
            this.protocolStepView1.Name = "protocolStepView1";
            this.protocolStepView1.ShowToolbar = false;
            this.protocolStepView1.Size = new System.Drawing.Size(344, 393);
            this.protocolStepView1.TabIndex = 0;
            // 
            // operationReferenceControl1
            // 
            this.operationReferenceControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.operationReferenceControl1.Location = new System.Drawing.Point(711, 3);
            this.operationReferenceControl1.Name = "operationReferenceControl1";
            this.operationReferenceControl1.Size = new System.Drawing.Size(259, 393);
            this.operationReferenceControl1.TabIndex = 6;
            // 
            // MainViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Name = "MainViewControl";
            this.Size = new System.Drawing.Size(996, 471);
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsObject)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Model.Data.BioBotDataSets bioBotDataSets;
        private System.Windows.Forms.BindingSource bsObject;
        private Execute.ExecuteView executeView1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel txtConnectionStatus;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Protocol.ProtocolStepView protocolStepView1;
        private Protocol.ProtocolStepView protocolStepView2;
        private Step.OperationControl2 operationControl21;
        private System.Windows.Forms.ToolStripMenuItem btnConnect;
        private Operation.OperationReference.OperationReferenceControl operationReferenceControl1;
    }
}
