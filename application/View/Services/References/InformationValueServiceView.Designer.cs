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
            this.bbtinformationvalueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bioBotDataSets = new BioBotApp.Model.Data.BioBotDataSets();
            this.bbtobjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pkidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fkinformationvalueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fkpropertyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fkobjectDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.informationvalueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bbtobjectbbtinformationvalueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.crudOptions1 = new BioBotApp.Controls.Utils.crudOptions();
            this.bbt_information_valueTableAdapter = new BioBotApp.Model.Data.BioBotDataSetsTableAdapters.bbt_information_valueTableAdapter();
            this.bbtpropertyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bbt_objectTableAdapter = new BioBotApp.Model.Data.BioBotDataSetsTableAdapters.bbt_objectTableAdapter();
            this.bbt_propertyTableAdapter = new BioBotApp.Model.Data.BioBotDataSetsTableAdapters.bbt_propertyTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bbtinformationvalueBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbtobjectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbtobjectbbtinformationvalueBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbtpropertyBindingSource)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bbtinformationvalueBindingSource
            // 
            this.bbtinformationvalueBindingSource.DataMember = "bbt_information_value";
            this.bbtinformationvalueBindingSource.DataSource = this.bioBotDataSets;
            // 
            // bioBotDataSets
            // 
            this.bioBotDataSets.DataSetName = "BioBotDataSets";
            this.bioBotDataSets.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bbtobjectBindingSource
            // 
            this.bbtobjectBindingSource.DataMember = "bbt_object";
            this.bbtobjectBindingSource.DataSource = this.bioBotDataSets;
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
            this.fkinformationvalueDataGridViewTextBoxColumn,
            this.fkpropertyDataGridViewTextBoxColumn,
            this.fkobjectDataGridViewTextBoxColumn,
            this.informationvalueDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bbtobjectbbtinformationvalueBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(283, 391);
            this.dataGridView1.TabIndex = 2;
            // 
            // pkidDataGridViewTextBoxColumn
            // 
            this.pkidDataGridViewTextBoxColumn.DataPropertyName = "pk_id";
            this.pkidDataGridViewTextBoxColumn.HeaderText = "pk_id";
            this.pkidDataGridViewTextBoxColumn.Name = "pkidDataGridViewTextBoxColumn";
            // 
            // fkinformationvalueDataGridViewTextBoxColumn
            // 
            this.fkinformationvalueDataGridViewTextBoxColumn.DataPropertyName = "fk_information_value";
            this.fkinformationvalueDataGridViewTextBoxColumn.HeaderText = "fk_information_value";
            this.fkinformationvalueDataGridViewTextBoxColumn.Name = "fkinformationvalueDataGridViewTextBoxColumn";
            // 
            // fkpropertyDataGridViewTextBoxColumn
            // 
            this.fkpropertyDataGridViewTextBoxColumn.DataPropertyName = "fk_property";
            this.fkpropertyDataGridViewTextBoxColumn.HeaderText = "fk_property";
            this.fkpropertyDataGridViewTextBoxColumn.Name = "fkpropertyDataGridViewTextBoxColumn";
            // 
            // fkobjectDataGridViewTextBoxColumn
            // 
            this.fkobjectDataGridViewTextBoxColumn.DataPropertyName = "fk_object";
            this.fkobjectDataGridViewTextBoxColumn.HeaderText = "fk_object";
            this.fkobjectDataGridViewTextBoxColumn.Name = "fkobjectDataGridViewTextBoxColumn";
            // 
            // informationvalueDataGridViewTextBoxColumn
            // 
            this.informationvalueDataGridViewTextBoxColumn.DataPropertyName = "information_value";
            this.informationvalueDataGridViewTextBoxColumn.HeaderText = "information_value";
            this.informationvalueDataGridViewTextBoxColumn.Name = "informationvalueDataGridViewTextBoxColumn";
            // 
            // bbtobjectbbtinformationvalueBindingSource
            // 
            this.bbtobjectbbtinformationvalueBindingSource.DataMember = "bbt_object_bbt_information_value";
            this.bbtobjectbbtinformationvalueBindingSource.DataSource = this.bbtobjectBindingSource;
            this.bbtobjectbbtinformationvalueBindingSource.Filter = "\"fk_property = null\"";
            // 
            // crudOptions1
            // 
            this.crudOptions1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            // bbt_information_valueTableAdapter
            // 
            this.bbt_information_valueTableAdapter.ClearBeforeFill = true;
            // 
            // bbtpropertyBindingSource
            // 
            this.bbtpropertyBindingSource.DataMember = "bbt_property";
            this.bbtpropertyBindingSource.DataSource = this.bioBotDataSets;
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
            // bbt_objectTableAdapter
            // 
            this.bbt_objectTableAdapter.ClearBeforeFill = true;
            // 
            // bbt_propertyTableAdapter
            // 
            this.bbt_propertyTableAdapter.ClearBeforeFill = true;
            // 
            // InformationValueServiceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Name = "InformationValueServiceView";
            this.Size = new System.Drawing.Size(309, 467);
            ((System.ComponentModel.ISupportInitialize)(this.bbtinformationvalueBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbtobjectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbtobjectbbtinformationvalueBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbtpropertyBindingSource)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Model.Data.BioBotDataSets bioBotDataSets;
        private Controls.Utils.crudOptions crudOptions1;
        private System.Windows.Forms.BindingSource bbtinformationvalueBindingSource;
        private Model.Data.BioBotDataSetsTableAdapters.bbt_information_valueTableAdapter bbt_information_valueTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fkinformationvalueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fkpropertyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fkobjectDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn informationvalueDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bbtobjectBindingSource;
        private System.Windows.Forms.GroupBox groupBox3;
        private Model.Data.BioBotDataSetsTableAdapters.bbt_objectTableAdapter bbt_objectTableAdapter;
        private System.Windows.Forms.BindingSource bbtobjectbbtinformationvalueBindingSource;
        private System.Windows.Forms.BindingSource bbtpropertyBindingSource;
        private Model.Data.BioBotDataSetsTableAdapters.bbt_propertyTableAdapter bbt_propertyTableAdapter;
    }
}
