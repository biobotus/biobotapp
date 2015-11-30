namespace BioBotApp.View.Operation
{
    partial class OperationForm
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
            this.components = new System.ComponentModel.Container();
            this.bioBotDataSets = new BioBotApp.Model.Data.BioBotDataSets();
            this.bbt_stepBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bbt_stepDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bbtobjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.operationControl1 = new BioBotApp.View.Operation.OperationControl();
            this.bbt_operationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bbt_operationDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bbtstepbbtoperationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbt_stepBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbt_stepDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbtobjectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbt_operationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbt_operationDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbtstepbbtoperationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bioBotDataSets
            // 
            this.bioBotDataSets.DataSetName = "BioBotDataSets";
            this.bioBotDataSets.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bbt_stepBindingSource
            // 
            this.bbt_stepBindingSource.DataMember = "bbt_step";
            this.bbt_stepBindingSource.DataSource = this.bioBotDataSets;
            this.bbt_stepBindingSource.CurrentChanged += new System.EventHandler(this.bbt_stepBindingSource_CurrentChanged);
            // 
            // bbt_stepDataGridView
            // 
            this.bbt_stepDataGridView.AutoGenerateColumns = false;
            this.bbt_stepDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bbt_stepDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5});
            this.bbt_stepDataGridView.DataSource = this.bbt_stepBindingSource;
            this.bbt_stepDataGridView.Dock = System.Windows.Forms.DockStyle.Left;
            this.bbt_stepDataGridView.Location = new System.Drawing.Point(0, 0);
            this.bbt_stepDataGridView.Name = "bbt_stepDataGridView";
            this.bbt_stepDataGridView.RowTemplate.Height = 28;
            this.bbt_stepDataGridView.Size = new System.Drawing.Size(605, 859);
            this.bbt_stepDataGridView.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "pk_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "pk_id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "fk_protocol";
            this.dataGridViewTextBoxColumn2.HeaderText = "fk_protocol";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "description";
            this.dataGridViewTextBoxColumn3.HeaderText = "description";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "fk_object";
            this.dataGridViewTextBoxColumn5.DataSource = this.bbtobjectBindingSource;
            this.dataGridViewTextBoxColumn5.DisplayMember = "description";
            this.dataGridViewTextBoxColumn5.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewTextBoxColumn5.HeaderText = "fk_object";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn5.ValueMember = "pk_id";
            // 
            // bbtobjectBindingSource
            // 
            this.bbtobjectBindingSource.DataMember = "bbt_object";
            this.bbtobjectBindingSource.DataSource = this.bioBotDataSets;
            // 
            // operationControl1
            // 
            this.operationControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.operationControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.operationControl1.Location = new System.Drawing.Point(1198, 0);
            this.operationControl1.Name = "operationControl1";
            this.operationControl1.Size = new System.Drawing.Size(339, 859);
            this.operationControl1.TabIndex = 0;
            // 
            // bbt_operationBindingSource
            // 
            this.bbt_operationBindingSource.DataMember = "bbt_operation";
            this.bbt_operationBindingSource.DataSource = this.bioBotDataSets;
            // 
            // bbt_operationDataGridView
            // 
            this.bbt_operationDataGridView.AutoGenerateColumns = false;
            this.bbt_operationDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bbt_operationDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.bbt_operationDataGridView.DataSource = this.bbtstepbbtoperationBindingSource;
            this.bbt_operationDataGridView.Dock = System.Windows.Forms.DockStyle.Left;
            this.bbt_operationDataGridView.Location = new System.Drawing.Point(605, 0);
            this.bbt_operationDataGridView.Name = "bbt_operationDataGridView";
            this.bbt_operationDataGridView.RowTemplate.Height = 28;
            this.bbt_operationDataGridView.Size = new System.Drawing.Size(460, 859);
            this.bbt_operationDataGridView.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "fk_operation_type";
            this.dataGridViewTextBoxColumn6.HeaderText = "fk_operation_type";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "fk_step";
            this.dataGridViewTextBoxColumn7.HeaderText = "fk_step";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "pk_id";
            this.dataGridViewTextBoxColumn8.HeaderText = "pk_id";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "value";
            this.dataGridViewTextBoxColumn9.HeaderText = "value";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // bbtstepbbtoperationBindingSource
            // 
            this.bbtstepbbtoperationBindingSource.DataMember = "bbt_step_bbt_operation";
            this.bbtstepbbtoperationBindingSource.DataSource = this.bbt_stepBindingSource;
            this.bbtstepbbtoperationBindingSource.CurrentChanged += new System.EventHandler(this.bbtstepbbtoperationBindingSource_CurrentChanged);
            // 
            // OperationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1537, 859);
            this.Controls.Add(this.bbt_operationDataGridView);
            this.Controls.Add(this.bbt_stepDataGridView);
            this.Controls.Add(this.operationControl1);
            this.Name = "OperationForm";
            this.Text = "OperationForm";
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbt_stepBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbt_stepDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbtobjectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbt_operationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbt_operationDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbtstepbbtoperationBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OperationControl operationControl1;
        private Model.Data.BioBotDataSets bioBotDataSets;
        private System.Windows.Forms.BindingSource bbt_stepBindingSource;
        private System.Windows.Forms.DataGridView bbt_stepDataGridView;
        private System.Windows.Forms.BindingSource bbtobjectBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.BindingSource bbt_operationBindingSource;
        private System.Windows.Forms.DataGridView bbt_operationDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.BindingSource bbtstepbbtoperationBindingSource;
    }
}