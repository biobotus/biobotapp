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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pluginPathControl1 = new BioBotApp.View.ModulePluginManager.PluginPathControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.modulePluginLoadedView1 = new BioBotApp.View.ModulePluginManager.ModulePluginLoadedView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.modulePluginPairView1 = new BioBotApp.View.ModulePluginManager.ModulePluginPairView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(68, 21);
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
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pluginPathControl1
            // 
            this.pluginPathControl1.Location = new System.Drawing.Point(6, 6);
            this.pluginPathControl1.Name = "pluginPathControl1";
            this.pluginPathControl1.Size = new System.Drawing.Size(350, 330);
            this.pluginPathControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.modulePluginLoadedView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(364, 391);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // modulePluginLoadedView1
            // 
            this.modulePluginLoadedView1.Location = new System.Drawing.Point(18, 6);
            this.modulePluginLoadedView1.Name = "modulePluginLoadedView1";
            this.modulePluginLoadedView1.Size = new System.Drawing.Size(320, 343);
            this.modulePluginLoadedView1.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.modulePluginPairView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(364, 391);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // modulePluginPairView1
            // 
            this.modulePluginPairView1.Location = new System.Drawing.Point(31, 34);
            this.modulePluginPairView1.Name = "modulePluginPairView1";
            this.modulePluginPairView1.Size = new System.Drawing.Size(314, 307);
            this.modulePluginPairView1.TabIndex = 0;
            // 
            // ModulePluginManagerTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 478);
            this.Controls.Add(this.tabControl1);
            this.Name = "ModulePluginManagerTest";
            this.Text = "ModulePluginManagerTest";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PluginPathControl pluginPathControl1;
        private ModulePluginLoadedView modulePluginLoadedView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private ModulePluginPairView modulePluginPairView1;
    }
}