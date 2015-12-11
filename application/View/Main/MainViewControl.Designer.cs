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
            this.deckView1 = new BioBotApp.View.Deck.DeckView();
            this.ctrlConsole1 = new BioBotApp.View.Utils.Console.ctrlConsole();
            this.protocolStepView2 = new BioBotApp.View.Protocol.ProtocolStepView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.operationReferenceControl1 = new BioBotApp.View.Operation.OperationReference.OperationReferenceControl();
            this.operationControl21 = new BioBotApp.View.Step.OperationControl2();
            this.protocolStepView1 = new BioBotApp.View.Protocol.ProtocolStepView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.optionMainControl1 = new BioBotApp.View.Option.OptionMainControl();
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsObject)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
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
            this.executeView1.Location = new System.Drawing.Point(4, 5);
            this.executeView1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.executeView1.Name = "executeView1";
            this.executeView1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.executeView1.Size = new System.Drawing.Size(375, 617);
            this.executeView1.TabIndex = 3;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtConnectionStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 695);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip.Size = new System.Drawing.Size(1494, 30);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip";
            // 
            // txtConnectionStatus
            // 
            this.txtConnectionStatus.Name = "txtConnectionStatus";
            this.txtConnectionStatus.Size = new System.Drawing.Size(129, 25);
            this.txtConnectionStatus.Text = "Not connected";
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(1494, 35);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConnect,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // btnConnect
            // 
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(162, 30);
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(162, 30);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 35);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1494, 660);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.deckView1);
            this.tabPage1.Controls.Add(this.ctrlConsole1);
            this.tabPage1.Controls.Add(this.protocolStepView2);
            this.tabPage1.Controls.Add(this.executeView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(1486, 627);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Execute";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // deckView1
            // 
            this.deckView1.AllowDrop = true;
            this.deckView1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.deckView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.deckView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deckView1.Location = new System.Drawing.Point(843, 5);
            this.deckView1.Name = "deckView1";
            this.deckView1.NewObject = null;
            this.deckView1.Size = new System.Drawing.Size(639, 329);
            this.deckView1.TabIndex = 6;
            // 
            // ctrlConsole1
            // 
            this.ctrlConsole1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlConsole1.Location = new System.Drawing.Point(843, 334);
            this.ctrlConsole1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlConsole1.Name = "ctrlConsole1";
            this.ctrlConsole1.Size = new System.Drawing.Size(639, 288);
            this.ctrlConsole1.TabIndex = 5;
            // 
            // protocolStepView2
            // 
            this.protocolStepView2.Dock = System.Windows.Forms.DockStyle.Left;
            this.protocolStepView2.Location = new System.Drawing.Point(379, 5);
            this.protocolStepView2.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.protocolStepView2.Name = "protocolStepView2";
            this.protocolStepView2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.protocolStepView2.ShowToolbar = false;
            this.protocolStepView2.Size = new System.Drawing.Size(464, 617);
            this.protocolStepView2.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.operationReferenceControl1);
            this.tabPage2.Controls.Add(this.operationControl21);
            this.tabPage2.Controls.Add(this.protocolStepView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(1486, 627);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Manage protocols";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // operationReferenceControl1
            // 
            this.operationReferenceControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.operationReferenceControl1.Location = new System.Drawing.Point(1066, 5);
            this.operationReferenceControl1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.operationReferenceControl1.Name = "operationReferenceControl1";
            this.operationReferenceControl1.Size = new System.Drawing.Size(388, 617);
            this.operationReferenceControl1.TabIndex = 6;
            // 
            // operationControl21
            // 
            this.operationControl21.Dock = System.Windows.Forms.DockStyle.Left;
            this.operationControl21.Location = new System.Drawing.Point(520, 5);
            this.operationControl21.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.operationControl21.Name = "operationControl21";
            this.operationControl21.Size = new System.Drawing.Size(546, 617);
            this.operationControl21.TabIndex = 1;
            // 
            // protocolStepView1
            // 
            this.protocolStepView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.protocolStepView1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.protocolStepView1.Location = new System.Drawing.Point(4, 5);
            this.protocolStepView1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.protocolStepView1.Name = "protocolStepView1";
            this.protocolStepView1.ShowToolbar = true;
            this.protocolStepView1.Size = new System.Drawing.Size(516, 617);
            this.protocolStepView1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.optionMainControl1);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Size = new System.Drawing.Size(1486, 627);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Manage objects";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // optionMainControl1
            // 
            this.optionMainControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionMainControl1.Location = new System.Drawing.Point(4, 5);
            this.optionMainControl1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.optionMainControl1.Name = "optionMainControl1";
            this.optionMainControl1.Size = new System.Drawing.Size(1478, 617);
            this.optionMainControl1.TabIndex = 0;
            // 
            // MainViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainViewControl";
            this.Size = new System.Drawing.Size(1494, 725);
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsObject)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tabPage3;
        private Option.OptionMainControl optionMainControl1;
        private Utils.Console.ctrlConsole ctrlConsole1;
        private Deck.DeckView deckView1;
    }
}
