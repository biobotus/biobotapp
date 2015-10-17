namespace BioBotApp.View.ModulePluginManager
{
    partial class ModulePluginLoadedView
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
            this.loadedModuleGridView = new System.Windows.Forms.DataGridView();
            this.btnReload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.loadedModuleGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // loadedModuleGridView
            // 
            this.loadedModuleGridView.AllowUserToAddRows = false;
            this.loadedModuleGridView.AllowUserToDeleteRows = false;
            this.loadedModuleGridView.AllowUserToResizeColumns = false;
            this.loadedModuleGridView.AllowUserToResizeRows = false;
            this.loadedModuleGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.loadedModuleGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.loadedModuleGridView.ColumnHeadersVisible = false;
            this.loadedModuleGridView.Enabled = false;
            this.loadedModuleGridView.Location = new System.Drawing.Point(22, 81);
            this.loadedModuleGridView.Name = "loadedModuleGridView";
            this.loadedModuleGridView.RowHeadersVisible = false;
            this.loadedModuleGridView.Size = new System.Drawing.Size(253, 215);
            this.loadedModuleGridView.TabIndex = 0;
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(200, 52);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 1;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "List of loaded module plugin";
            // 
            // ModulePluginLoadedView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.loadedModuleGridView);
            this.Name = "ModulePluginLoadedView";
            this.Size = new System.Drawing.Size(320, 356);
            ((System.ComponentModel.ISupportInitialize)(this.loadedModuleGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView loadedModuleGridView;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Label label1;
    }
}
