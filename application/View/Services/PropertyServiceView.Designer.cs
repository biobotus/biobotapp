namespace BioBotApp.View.Services
{
    partial class PropertyServiceView
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
            this.pkidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fkpropertytypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bbtpropertytypebbtpropertyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PropertyTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bioBotDataSets = new BioBotApp.Model.Data.BioBotDataSets();
            this.crudOptions1 = new BioBotApp.Controls.Utils.crudOptions();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bbt_property_typeTableAdapter = new BioBotApp.Model.Data.BioBotDataSetsTableAdapters.bbt_property_typeTableAdapter();
            this.bbt_propertyTableAdapter = new BioBotApp.Model.Data.BioBotDataSetsTableAdapters.bbt_propertyTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbtpropertytypebbtpropertyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PropertyTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.pkidDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.fkpropertytypeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bbtpropertytypebbtpropertyBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(287, 386);
            this.dataGridView1.TabIndex = 0;
            // 
            // pkidDataGridViewTextBoxColumn
            // 
            this.pkidDataGridViewTextBoxColumn.DataPropertyName = "pk_id";
            this.pkidDataGridViewTextBoxColumn.HeaderText = "pk_id";
            this.pkidDataGridViewTextBoxColumn.Name = "pkidDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // fkpropertytypeDataGridViewTextBoxColumn
            // 
            this.fkpropertytypeDataGridViewTextBoxColumn.DataPropertyName = "fk_property_type";
            this.fkpropertytypeDataGridViewTextBoxColumn.HeaderText = "fk_property_type";
            this.fkpropertytypeDataGridViewTextBoxColumn.Name = "fkpropertytypeDataGridViewTextBoxColumn";
            // 
            // bbtpropertytypebbtpropertyBindingSource
            // 
            this.bbtpropertytypebbtpropertyBindingSource.DataMember = "bbt_property_type_bbt_property";
            this.bbtpropertytypebbtpropertyBindingSource.DataSource = this.PropertyTypeBindingSource;
            // 
            // PropertyTypeBindingSource
            // 
            this.PropertyTypeBindingSource.DataMember = "bbt_property_type";
            this.PropertyTypeBindingSource.DataSource = this.bioBotDataSets;
            // 
            // bioBotDataSets
            // 
            this.bioBotDataSets.DataSetName = "BioBotDataSets";
            this.bioBotDataSets.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // crudOptions1
            // 
            this.crudOptions1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.crudOptions1.LayoutLeftToRight = System.Windows.Forms.FlowDirection.RightToLeft;
            this.crudOptions1.Location = new System.Drawing.Point(133, 19);
            this.crudOptions1.MinimumSize = new System.Drawing.Size(37, 37);
            this.crudOptions1.Name = "crudOptions1";
            this.crudOptions1.Size = new System.Drawing.Size(160, 37);
            this.crudOptions1.TabIndex = 1;
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
            this.groupBox1.Size = new System.Drawing.Size(299, 454);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Property";
            // 
            // bbt_property_typeTableAdapter
            // 
            this.bbt_property_typeTableAdapter.ClearBeforeFill = true;
            // 
            // bbt_propertyTableAdapter
            // 
            this.bbt_propertyTableAdapter.ClearBeforeFill = true;
            // 
            // PropertyServiceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "PropertyServiceView";
            this.Size = new System.Drawing.Size(305, 460);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbtpropertytypebbtpropertyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PropertyTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fkpropertytypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bbtpropertytypebbtpropertyBindingSource;
        private System.Windows.Forms.BindingSource PropertyTypeBindingSource;
        private Model.Data.BioBotDataSets bioBotDataSets;
        private Controls.Utils.crudOptions crudOptions1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Model.Data.BioBotDataSetsTableAdapters.bbt_property_typeTableAdapter bbt_property_typeTableAdapter;
        private Model.Data.BioBotDataSetsTableAdapters.bbt_propertyTableAdapter bbt_propertyTableAdapter;
    }
}
