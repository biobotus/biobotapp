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
            this.pluginPathControl1 = new BioBotApp.View.ModulePluginManager.PluginPathControl();
            this.SuspendLayout();
            // 
            // pluginPathControl1
            // 
            this.pluginPathControl1.Location = new System.Drawing.Point(81, 12);
            this.pluginPathControl1.Name = "pluginPathControl1";
            this.pluginPathControl1.Size = new System.Drawing.Size(347, 343);
            this.pluginPathControl1.TabIndex = 0;
            // 
            // ModulePluginManagerTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 390);
            this.Controls.Add(this.pluginPathControl1);
            this.Name = "ModulePluginManagerTest";
            this.Text = "ModulePluginManagerTest";
            this.ResumeLayout(false);

        }

        #endregion

        private PluginPathControl pluginPathControl1;
    }
}