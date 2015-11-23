namespace BioBotApp.View.Services
{
    partial class ObjectServiceView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.crudOptions1 = new BioBotApp.Controls.Utils.crudOptions();
            this.bioBotDataSets = new BioBotApp.Model.Data.BioBotDataSets();
            this.bbt_object_typeTableAdapter1 = new BioBotApp.Model.Data.BioBotDataSetsTableAdapters.bbt_object_typeTableAdapter();
            this.ObjectTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bbtobjecttypebbtobjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bbt_objectTableAdapter = new BioBotApp.Model.Data.BioBotDataSetsTableAdapters.bbt_objectTableAdapter();
            this.pkidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fkobjecttypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deckxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deckyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rotationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fkobjectDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObjectTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbtobjecttypebbtobjectBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.crudOptions1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 440);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Object";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkidDataGridViewTextBoxColumn,
            this.fkobjecttypeDataGridViewTextBoxColumn,
            this.deckxDataGridViewTextBoxColumn,
            this.deckyDataGridViewTextBoxColumn,
            this.rotationDataGridViewTextBoxColumn,
            this.activatedDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.fkobjectDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bbtobjecttypebbtobjectBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(258, 373);
            this.dataGridView1.TabIndex = 0;
            // 
            // crudOptions1
            // 
            this.crudOptions1.LayoutLeftToRight = System.Windows.Forms.FlowDirection.RightToLeft;
            this.crudOptions1.Location = new System.Drawing.Point(108, 18);
            this.crudOptions1.MinimumSize = new System.Drawing.Size(37, 37);
            this.crudOptions1.Name = "crudOptions1";
            this.crudOptions1.Size = new System.Drawing.Size(156, 37);
            this.crudOptions1.TabIndex = 1;
            // 
            // bioBotDataSets
            // 
            this.bioBotDataSets.DataSetName = "BioBotDataSets";
            this.bioBotDataSets.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bbt_object_typeTableAdapter1
            // 
            this.bbt_object_typeTableAdapter1.ClearBeforeFill = true;
            // 
            // ObjectTypeBindingSource
            // 
            this.ObjectTypeBindingSource.DataMember = "bbt_object_type";
            this.ObjectTypeBindingSource.DataSource = this.bioBotDataSets;
            // 
            // bbtobjecttypebbtobjectBindingSource
            // 
            this.bbtobjecttypebbtobjectBindingSource.DataMember = "bbt_object_type_bbt_object";
            this.bbtobjecttypebbtobjectBindingSource.DataSource = this.ObjectTypeBindingSource;
            // 
            // bbt_objectTableAdapter
            // 
            this.bbt_objectTableAdapter.ClearBeforeFill = true;
            // 
            // pkidDataGridViewTextBoxColumn
            // 
            this.pkidDataGridViewTextBoxColumn.DataPropertyName = "pk_id";
            this.pkidDataGridViewTextBoxColumn.HeaderText = "pk_id";
            this.pkidDataGridViewTextBoxColumn.Name = "pkidDataGridViewTextBoxColumn";
            // 
            // fkobjecttypeDataGridViewTextBoxColumn
            // 
            this.fkobjecttypeDataGridViewTextBoxColumn.DataPropertyName = "fk_object_type";
            this.fkobjecttypeDataGridViewTextBoxColumn.HeaderText = "fk_object_type";
            this.fkobjecttypeDataGridViewTextBoxColumn.Name = "fkobjecttypeDataGridViewTextBoxColumn";
            // 
            // deckxDataGridViewTextBoxColumn
            // 
            this.deckxDataGridViewTextBoxColumn.DataPropertyName = "deck_x";
            this.deckxDataGridViewTextBoxColumn.HeaderText = "deck_x";
            this.deckxDataGridViewTextBoxColumn.Name = "deckxDataGridViewTextBoxColumn";
            // 
            // deckyDataGridViewTextBoxColumn
            // 
            this.deckyDataGridViewTextBoxColumn.DataPropertyName = "deck_y";
            this.deckyDataGridViewTextBoxColumn.HeaderText = "deck_y";
            this.deckyDataGridViewTextBoxColumn.Name = "deckyDataGridViewTextBoxColumn";
            // 
            // rotationDataGridViewTextBoxColumn
            // 
            this.rotationDataGridViewTextBoxColumn.DataPropertyName = "rotation";
            this.rotationDataGridViewTextBoxColumn.HeaderText = "rotation";
            this.rotationDataGridViewTextBoxColumn.Name = "rotationDataGridViewTextBoxColumn";
            // 
            // activatedDataGridViewTextBoxColumn
            // 
            this.activatedDataGridViewTextBoxColumn.DataPropertyName = "activated";
            this.activatedDataGridViewTextBoxColumn.HeaderText = "activated";
            this.activatedDataGridViewTextBoxColumn.Name = "activatedDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // fkobjectDataGridViewTextBoxColumn
            // 
            this.fkobjectDataGridViewTextBoxColumn.DataPropertyName = "fk_object";
            this.fkobjectDataGridViewTextBoxColumn.HeaderText = "fk_object";
            this.fkobjectDataGridViewTextBoxColumn.Name = "fkobjectDataGridViewTextBoxColumn";
            // 
            // ObjectServiceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ObjectServiceView";
            this.Size = new System.Drawing.Size(276, 446);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ObjectTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbtobjecttypebbtobjectBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Controls.Utils.crudOptions crudOptions1;
        private Model.Data.BioBotDataSets bioBotDataSets;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fkobjecttypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deckxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deckyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rotationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn activatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fkobjectDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bbtobjecttypebbtobjectBindingSource;
        private System.Windows.Forms.BindingSource ObjectTypeBindingSource;
        private Model.Data.BioBotDataSetsTableAdapters.bbt_object_typeTableAdapter bbt_object_typeTableAdapter1;
        private Model.Data.BioBotDataSetsTableAdapters.bbt_objectTableAdapter bbt_objectTableAdapter;
    }
}
