namespace BioBotApp.View.Services
{
    partial class InformationValueServiceView
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
            this.bioBotDataSets = new BioBotApp.Model.Data.BioBotDataSets();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pkidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fkinformationvalueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fkpropertyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fkobjectDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.informationvalueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InformationValueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.crudOptions1 = new BioBotApp.Controls.Utils.crudOptions();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bbt_information_valueTableAdapter = new BioBotApp.Model.Data.BioBotDataSetsTableAdapters.bbt_information_valueTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InformationValueBindingSource)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bioBotDataSets
            // 
            this.bioBotDataSets.DataSetName = "BioBotDataSets";
            this.bioBotDataSets.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkidDataGridViewTextBoxColumn,
            this.fkinformationvalueDataGridViewTextBoxColumn,
            this.fkpropertyDataGridViewTextBoxColumn,
            this.fkobjectDataGridViewTextBoxColumn,
            this.informationvalueDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.InformationValueBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(283, 391);
            this.dataGridView1.TabIndex = 2;
            // 
            // pkidDataGridViewTextBoxColumn
            // 
            this.pkidDataGridViewTextBoxColumn.DataPropertyName = "pk_id";
            this.pkidDataGridViewTextBoxColumn.FillWeight = 50F;
            this.pkidDataGridViewTextBoxColumn.HeaderText = "pk_id";
            this.pkidDataGridViewTextBoxColumn.Name = "pkidDataGridViewTextBoxColumn";
            this.pkidDataGridViewTextBoxColumn.Width = 50;
            // 
            // fkinformationvalueDataGridViewTextBoxColumn
            // 
            this.fkinformationvalueDataGridViewTextBoxColumn.DataPropertyName = "fk_information_value";
            this.fkinformationvalueDataGridViewTextBoxColumn.FillWeight = 75F;
            this.fkinformationvalueDataGridViewTextBoxColumn.HeaderText = "fk_information_value";
            this.fkinformationvalueDataGridViewTextBoxColumn.Name = "fkinformationvalueDataGridViewTextBoxColumn";
            this.fkinformationvalueDataGridViewTextBoxColumn.Width = 75;
            // 
            // fkpropertyDataGridViewTextBoxColumn
            // 
            this.fkpropertyDataGridViewTextBoxColumn.DataPropertyName = "fk_property";
            this.fkpropertyDataGridViewTextBoxColumn.FillWeight = 75F;
            this.fkpropertyDataGridViewTextBoxColumn.HeaderText = "fk_property";
            this.fkpropertyDataGridViewTextBoxColumn.Name = "fkpropertyDataGridViewTextBoxColumn";
            this.fkpropertyDataGridViewTextBoxColumn.Width = 75;
            // 
            // fkobjectDataGridViewTextBoxColumn
            // 
            this.fkobjectDataGridViewTextBoxColumn.DataPropertyName = "fk_object";
            this.fkobjectDataGridViewTextBoxColumn.FillWeight = 75F;
            this.fkobjectDataGridViewTextBoxColumn.HeaderText = "fk_object";
            this.fkobjectDataGridViewTextBoxColumn.Name = "fkobjectDataGridViewTextBoxColumn";
            this.fkobjectDataGridViewTextBoxColumn.Width = 75;
            // 
            // informationvalueDataGridViewTextBoxColumn
            // 
            this.informationvalueDataGridViewTextBoxColumn.DataPropertyName = "information_value";
            this.informationvalueDataGridViewTextBoxColumn.HeaderText = "information_value";
            this.informationvalueDataGridViewTextBoxColumn.Name = "informationvalueDataGridViewTextBoxColumn";
            // 
            // InformationValueBindingSource
            // 
            this.InformationValueBindingSource.DataMember = "bbt_information_value";
            this.InformationValueBindingSource.DataSource = this.bioBotDataSets;
            // 
            // crudOptions1
            // 
            this.crudOptions1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.crudOptions1.ButtonRefreshVisible = false;
            this.crudOptions1.LayoutLeftToRight = System.Windows.Forms.FlowDirection.RightToLeft;
            this.crudOptions1.Location = new System.Drawing.Point(132, 19);
            this.crudOptions1.MinimumSize = new System.Drawing.Size(37, 37);
            this.crudOptions1.Name = "crudOptions1";
            this.crudOptions1.Size = new System.Drawing.Size(157, 37);
            this.crudOptions1.TabIndex = 1;
            this.crudOptions1.AddClickHandler += new System.EventHandler(this.Add_Click);
            this.crudOptions1.DeleteClickHandler += new System.EventHandler(this.Delete_Click);
            this.crudOptions1.ModifyClickHandler += new System.EventHandler(this.Modify_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.crudOptions1);
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Location = new System.Drawing.Point(6, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(295, 464);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Information Value";
            // 
            // bbt_information_valueTableAdapter
            // 
            this.bbt_information_valueTableAdapter.ClearBeforeFill = true;
            // 
            // InformationValueServiceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Name = "InformationValueServiceView";
            this.Size = new System.Drawing.Size(309, 467);
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InformationValueBindingSource)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Model.Data.BioBotDataSets bioBotDataSets;
        private Controls.Utils.crudOptions crudOptions1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fkinformationvalueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fkpropertyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fkobjectDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn informationvalueDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource InformationValueBindingSource;
        private Model.Data.BioBotDataSetsTableAdapters.bbt_information_valueTableAdapter bbt_information_valueTableAdapter;
    }
}
