namespace BioBotApp.View.ModulePluginManager
{
    partial class ModulePluginPairView
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
            this.pairView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pairView)).BeginInit();
            this.SuspendLayout();
            // 
            // pairView
            // 
            this.pairView.AllowUserToAddRows = false;
            this.pairView.AllowUserToDeleteRows = false;
            this.pairView.AllowUserToResizeColumns = false;
            this.pairView.AllowUserToResizeRows = false;
            this.pairView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.pairView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.pairView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pairView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.pairView.Location = new System.Drawing.Point(15, 40);
            this.pairView.Name = "pairView";
            this.pairView.RowHeadersVisible = false;
            this.pairView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.pairView.Size = new System.Drawing.Size(268, 312);
            this.pairView.TabIndex = 0;
            // 
            // ModulePluginPairView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pairView);
            this.Name = "ModulePluginPairView";
            this.Size = new System.Drawing.Size(296, 366);
            ((System.ComponentModel.ISupportInitialize)(this.pairView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView pairView;
    }
}
