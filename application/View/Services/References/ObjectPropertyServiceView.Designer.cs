namespace BioBotApp.View.Services
{
    partial class ObjectPropertyServiceView
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.crudOptions1 = new BioBotApp.Controls.Utils.crudOptions();
            this.bioBotDataSets = new BioBotApp.Model.Data.BioBotDataSets();
            this.bbtobjectpropertyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bbt_object_propertyTableAdapter = new BioBotApp.Model.Data.BioBotDataSetsTableAdapters.bbt_object_propertyTableAdapter();
            this.fkobjecttypeidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fkpropertiesidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbtobjectpropertyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fkobjecttypeidDataGridViewTextBoxColumn,
            this.fkpropertiesidDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bbtobjectpropertyBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(277, 371);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.crudOptions1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 437);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Object Property";
            // 
            // crudOptions1
            // 
            this.crudOptions1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.crudOptions1.LayoutLeftToRight = System.Windows.Forms.FlowDirection.RightToLeft;
            this.crudOptions1.Location = new System.Drawing.Point(124, 17);
            this.crudOptions1.MinimumSize = new System.Drawing.Size(37, 37);
            this.crudOptions1.Name = "crudOptions1";
            this.crudOptions1.Size = new System.Drawing.Size(159, 37);
            this.crudOptions1.TabIndex = 1;
            // 
            // bioBotDataSets
            // 
            this.bioBotDataSets.DataSetName = "BioBotDataSets";
            this.bioBotDataSets.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bbtobjectpropertyBindingSource
            // 
            this.bbtobjectpropertyBindingSource.DataMember = "bbt_object_property";
            this.bbtobjectpropertyBindingSource.DataSource = this.bioBotDataSets;
            // 
            // bbt_object_propertyTableAdapter
            // 
            this.bbt_object_propertyTableAdapter.ClearBeforeFill = true;
            // 
            // fkobjecttypeidDataGridViewTextBoxColumn
            // 
            this.fkobjecttypeidDataGridViewTextBoxColumn.DataPropertyName = "fk_object_type_id";
            this.fkobjecttypeidDataGridViewTextBoxColumn.HeaderText = "fk_object_type_id";
            this.fkobjecttypeidDataGridViewTextBoxColumn.Name = "fkobjecttypeidDataGridViewTextBoxColumn";
            // 
            // fkpropertiesidDataGridViewTextBoxColumn
            // 
            this.fkpropertiesidDataGridViewTextBoxColumn.DataPropertyName = "fk_properties_id";
            this.fkpropertiesidDataGridViewTextBoxColumn.HeaderText = "fk_properties_id";
            this.fkpropertiesidDataGridViewTextBoxColumn.Name = "fkpropertiesidDataGridViewTextBoxColumn";
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            // 
            // ObjectPropertyServiceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ObjectPropertyServiceView";
            this.Size = new System.Drawing.Size(297, 443);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbtobjectpropertyBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.Utils.crudOptions crudOptions1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fkobjecttypeidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fkpropertiesidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bbtobjectpropertyBindingSource;
        private Model.Data.BioBotDataSets bioBotDataSets;
        private Model.Data.BioBotDataSetsTableAdapters.bbt_object_propertyTableAdapter bbt_object_propertyTableAdapter;
    }
}
