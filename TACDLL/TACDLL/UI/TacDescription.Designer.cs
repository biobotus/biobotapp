namespace TACDLL.OptionCtrl
{
    partial class TacDescription
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tacParamGB = new System.Windows.Forms.GroupBox();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.subModulesTab = new System.Windows.Forms.TabControl();
            this.tabSubModule1 = new System.Windows.Forms.TabPage();
            this.tabSubModule2 = new System.Windows.Forms.TabPage();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPlotResultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subModule1Desc = new TACDLL.UI.SubModuleDesc();
            this.subModule2Desc = new TACDLL.UI.SubModuleDesc();
            this.tacParamGB.SuspendLayout();
            this.subModulesTab.SuspendLayout();
            this.tabSubModule1.SuspendLayout();
            this.tabSubModule2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tacParamGB
            // 
            this.tacParamGB.ContextMenuStrip = this.contextMenuStrip1;
            this.tacParamGB.Controls.Add(this.refreshBtn);
            this.tacParamGB.Controls.Add(this.subModulesTab);
            this.tacParamGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tacParamGB.Location = new System.Drawing.Point(0, 0);
            this.tacParamGB.Name = "tacParamGB";
            this.tacParamGB.Size = new System.Drawing.Size(205, 159);
            this.tacParamGB.TabIndex = 0;
            this.tacParamGB.TabStop = false;
            this.tacParamGB.Text = "Tac : XXX";
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(126, 132);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(75, 23);
            this.refreshBtn.TabIndex = 54;
            this.refreshBtn.Text = "refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // subModulesTab
            // 
            this.subModulesTab.Controls.Add(this.tabSubModule1);
            this.subModulesTab.Controls.Add(this.tabSubModule2);
            this.subModulesTab.Location = new System.Drawing.Point(6, 19);
            this.subModulesTab.Name = "subModulesTab";
            this.subModulesTab.SelectedIndex = 0;
            this.subModulesTab.Size = new System.Drawing.Size(199, 111);
            this.subModulesTab.TabIndex = 38;
            // 
            // tabSubModule1
            // 
            this.tabSubModule1.Controls.Add(this.subModule1Desc);
            this.tabSubModule1.Location = new System.Drawing.Point(4, 22);
            this.tabSubModule1.Name = "tabSubModule1";
            this.tabSubModule1.Padding = new System.Windows.Forms.Padding(3);
            this.tabSubModule1.Size = new System.Drawing.Size(191, 85);
            this.tabSubModule1.TabIndex = 0;
            this.tabSubModule1.Text = "Sub-module 1";
            this.tabSubModule1.UseVisualStyleBackColor = true;
            // 
            // tabSubModule2
            // 
            this.tabSubModule2.Controls.Add(this.subModule2Desc);
            this.tabSubModule2.Location = new System.Drawing.Point(4, 22);
            this.tabSubModule2.Name = "tabSubModule2";
            this.tabSubModule2.Padding = new System.Windows.Forms.Padding(3);
            this.tabSubModule2.Size = new System.Drawing.Size(191, 85);
            this.tabSubModule2.TabIndex = 1;
            this.tabSubModule2.Text = "Sub-module 2";
            this.tabSubModule2.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPlotResultToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(160, 26);
            // 
            // showPlotResultToolStripMenuItem
            // 
            this.showPlotResultToolStripMenuItem.Name = "showPlotResultToolStripMenuItem";
            this.showPlotResultToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.showPlotResultToolStripMenuItem.Text = "Show plot result";
            this.showPlotResultToolStripMenuItem.Click += new System.EventHandler(this.showPlotResultToolStripMenuItem_Click);
            // 
            // subModule1Desc
            // 
            this.subModule1Desc.Location = new System.Drawing.Point(0, 0);
            this.subModule1Desc.Name = "subModule1Desc";
            this.subModule1Desc.Size = new System.Drawing.Size(186, 81);
            this.subModule1Desc.TabIndex = 0;
            // 
            // subModule2Desc
            // 
            this.subModule2Desc.Location = new System.Drawing.Point(0, 0);
            this.subModule2Desc.Name = "subModule2Desc";
            this.subModule2Desc.Size = new System.Drawing.Size(186, 83);
            this.subModule2Desc.TabIndex = 0;
            // 
            // TacDescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tacParamGB);
            this.Name = "TacDescription";
            this.Size = new System.Drawing.Size(205, 159);
            this.tacParamGB.ResumeLayout(false);
            this.subModulesTab.ResumeLayout(false);
            this.tabSubModule1.ResumeLayout(false);
            this.tabSubModule2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox tacParamGB;
        private System.Windows.Forms.TabControl subModulesTab;
        private System.Windows.Forms.TabPage tabSubModule1;
        private System.Windows.Forms.TabPage tabSubModule2;
        private UI.SubModuleDesc subModule1Desc;
        private System.Windows.Forms.Button refreshBtn;
        private UI.SubModuleDesc subModule2Desc;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showPlotResultToolStripMenuItem;
    }
}
