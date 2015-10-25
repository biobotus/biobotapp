namespace BioBotApp.View.ModulePluginManager
{
    partial class ModulePluginManagerTest
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("TestDeRacine");
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.modulePluginPairView1 = new BioBotApp.View.ModulePluginManager.ModulePluginPairView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.pluginPathControl1 = new BioBotApp.View.ModulePluginManager.PluginPathControl();
            this.modulePluginLoadedView1 = new BioBotApp.View.ModulePluginManager.ModulePluginLoadedView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 44);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(372, 417);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pluginPathControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(364, 391);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "PathTest";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.modulePluginLoadedView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(364, 391);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "LoadedTest";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.modulePluginPairView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(364, 391);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "PairingTest";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // modulePluginPairView1
            // 
            this.modulePluginPairView1.Location = new System.Drawing.Point(31, 34);
            this.modulePluginPairView1.Name = "modulePluginPairView1";
            this.modulePluginPairView1.Size = new System.Drawing.Size(314, 307);
            this.modulePluginPairView1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.mainPanel);
            this.tabPage4.Controls.Add(this.treeView1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(364, 391);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "TreeNodeTest";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(140, 18);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(221, 184);
            this.mainPanel.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(16, 18);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Outils";
            treeNode1.Text = "TestDeRacine";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(118, 184);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // pluginPathControl1
            // 
            this.pluginPathControl1.Location = new System.Drawing.Point(11, 21);
            this.pluginPathControl1.Name = "pluginPathControl1";
            this.pluginPathControl1.Size = new System.Drawing.Size(347, 346);
            this.pluginPathControl1.TabIndex = 0;
            // 
            // modulePluginLoadedView1
            // 
            this.modulePluginLoadedView1.Location = new System.Drawing.Point(18, 16);
            this.modulePluginLoadedView1.Name = "modulePluginLoadedView1";
            this.modulePluginLoadedView1.Size = new System.Drawing.Size(320, 356);
            this.modulePluginLoadedView1.TabIndex = 0;
            // 
            // ModulePluginManagerTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 473);
            this.Controls.Add(this.tabControl1);
            this.Name = "ModulePluginManagerTest";
            this.Text = "ModulePluginManagerTest";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private ModulePluginPairView modulePluginPairView1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel mainPanel;
        private PluginPathControl pluginPathControl1;
        private ModulePluginLoadedView modulePluginLoadedView1;
    }
}