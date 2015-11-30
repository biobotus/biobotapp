namespace BioBotApp.View.Operation.OperationTypeObjectType
{
    partial class OperationTypeObjectTypeView
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
            this.fkobjecttypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fkoperationtypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bbtoperationtypeobjecttypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bioBotDataSets = new BioBotApp.Model.Data.BioBotDataSets();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.crudOptions1 = new BioBotApp.Controls.Utils.crudOptions();
            this.bbt_operation_type_object_typeTableAdapter = new BioBotApp.Model.Data.BioBotDataSetsTableAdapters.bbt_operation_type_object_typeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbtoperationtypeobjecttypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.fkobjecttypeDataGridViewTextBoxColumn,
            this.fkoperationtypeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bbtoperationtypeobjecttypeBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(243, 339);
            this.dataGridView1.TabIndex = 0;
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
            // fkoperationtypeDataGridViewTextBoxColumn
            // 
            this.fkoperationtypeDataGridViewTextBoxColumn.DataPropertyName = "fk_operation_type";
            this.fkoperationtypeDataGridViewTextBoxColumn.HeaderText = "fk_operation_type";
            this.fkoperationtypeDataGridViewTextBoxColumn.Name = "fkoperationtypeDataGridViewTextBoxColumn";
            // 
            // bbtoperationtypeobjecttypeBindingSource
            // 
            this.bbtoperationtypeobjecttypeBindingSource.DataMember = "bbt_operation_type_object_type";
            this.bbtoperationtypeobjecttypeBindingSource.DataSource = this.bioBotDataSets;
            // 
            // bioBotDataSets
            // 
            this.bioBotDataSets.DataSetName = "BioBotDataSets";
            this.bioBotDataSets.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.crudOptions1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 405);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operation Type - Object Type";
            // 
            // crudOptions1
            // 
            this.crudOptions1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.crudOptions1.ButtonRefreshVisible = false;
            this.crudOptions1.LayoutLeftToRight = System.Windows.Forms.FlowDirection.RightToLeft;
            this.crudOptions1.Location = new System.Drawing.Point(90, 17);
            this.crudOptions1.MinimumSize = new System.Drawing.Size(37, 37);
            this.crudOptions1.Name = "crudOptions1";
            this.crudOptions1.Size = new System.Drawing.Size(159, 37);
            this.crudOptions1.TabIndex = 1;
            this.crudOptions1.AddClickHandler += new System.EventHandler(this.AddOperationTypeObjectType);
            this.crudOptions1.DeleteClickHandler += new System.EventHandler(this.DeleteOperationTypeObjectType);
            this.crudOptions1.ModifyClickHandler += new System.EventHandler(this.ModifyOperationTypeObjectType);
            // 
            // bbt_operation_type_object_typeTableAdapter
            // 
            this.bbt_operation_type_object_typeTableAdapter.ClearBeforeFill = true;
            // 
            // OperationTypeObjectTypeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "OperationTypeObjectTypeView";
            this.Size = new System.Drawing.Size(255, 405);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbtoperationtypeobjecttypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private Model.Data.BioBotDataSets bioBotDataSets;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.Utils.crudOptions crudOptions1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fkobjecttypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fkoperationtypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bbtoperationtypeobjecttypeBindingSource;
        private Model.Data.BioBotDataSetsTableAdapters.bbt_operation_type_object_typeTableAdapter bbt_operation_type_object_typeTableAdapter;
    }
}
