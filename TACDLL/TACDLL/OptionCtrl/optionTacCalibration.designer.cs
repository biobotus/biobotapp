namespace TACDLL.OptionCtrl
{
    partial class optionTacCalibration
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
            this.btnValidation = new System.Windows.Forms.Button();
            this.dgvTacCalibrationDataView = new System.Windows.Forms.DataGridView();
            this.cmbTacSelector = new System.Windows.Forms.ComboBox();
            this.crudOptions1 = new TACDLL.OptionCtrl.crudOptions();
            this.dsTacCalibration1 = new TACDLL.DataSets.dsTacCalibration();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTacCalibrationDataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTacCalibration1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnValidation
            // 
            this.btnValidation.Location = new System.Drawing.Point(164, 3);
            this.btnValidation.Name = "btnValidation";
            this.btnValidation.Size = new System.Drawing.Size(67, 31);
            this.btnValidation.TabIndex = 0;
            this.btnValidation.Text = "validate";
            this.btnValidation.UseVisualStyleBackColor = true;
            this.btnValidation.Click += new System.EventHandler(this.btnValidation_Click);
            // 
            // dgvTacCalibrationDataView
            // 
            this.dgvTacCalibrationDataView.AllowUserToAddRows = false;
            this.dgvTacCalibrationDataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTacCalibrationDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTacCalibrationDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTacCalibrationDataView.Location = new System.Drawing.Point(0, 37);
            this.dgvTacCalibrationDataView.Name = "dgvTacCalibrationDataView";
            this.dgvTacCalibrationDataView.ReadOnly = true;
            this.dgvTacCalibrationDataView.RowHeadersVisible = false;
            this.dgvTacCalibrationDataView.Size = new System.Drawing.Size(347, 256);
            this.dgvTacCalibrationDataView.TabIndex = 2;
            // 
            // cmbTacSelector
            // 
            this.cmbTacSelector.FormattingEnabled = true;
            this.cmbTacSelector.Location = new System.Drawing.Point(12, 10);
            this.cmbTacSelector.Name = "cmbTacSelector";
            this.cmbTacSelector.Size = new System.Drawing.Size(146, 21);
            this.cmbTacSelector.TabIndex = 3;
            // 
            // crudOptions1
            // 
            this.crudOptions1.ButtonRefreshVisible = false;
            this.crudOptions1.Dock = System.Windows.Forms.DockStyle.Top;
            this.crudOptions1.LayoutLeftToRight = System.Windows.Forms.FlowDirection.RightToLeft;
            this.crudOptions1.Location = new System.Drawing.Point(0, 0);
            this.crudOptions1.MinimumSize = new System.Drawing.Size(37, 37);
            this.crudOptions1.Name = "crudOptions1";
            this.crudOptions1.Size = new System.Drawing.Size(347, 37);
            this.crudOptions1.TabIndex = 0;
            this.crudOptions1.AddClickHandler += new System.EventHandler(this.crudOptions_AddClickHandler);
            // 
            // dsTacCalibration1
            // 
            this.dsTacCalibration1.DataSetName = "dsModuleStructure2";
            this.dsTacCalibration1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // optionTacCalibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnValidation);
            this.Controls.Add(this.cmbTacSelector);
            this.Controls.Add(this.dgvTacCalibrationDataView);
            this.Controls.Add(this.crudOptions1);
            this.Name = "optionTacCalibration";
            this.Size = new System.Drawing.Size(347, 293);
            this.Tag = "Tac calibration";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTacCalibrationDataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTacCalibration1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OptionCtrl.crudOptions crudOptions1;
        private System.Windows.Forms.DataGridView dgvTacCalibrationDataView;
        private System.Windows.Forms.Button btnValidation;
        private System.Windows.Forms.ComboBox cmbTacSelector;
        private DataSets.dsTacCalibration dsModuleStructure;
        private DataSets.dsTacCalibration dsTacCalibration1;
    }
}
