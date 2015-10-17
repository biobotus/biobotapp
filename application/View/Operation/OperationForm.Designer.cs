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
            this.operationControl1 = new BioBotApp.View.Operation.OperationControl();
            this.bioBotDataSets = new BioBotApp.Model.Data.BioBotDataSets();
            this.bbt_operationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bbt_operationDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbt_operationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbt_operationDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // operationControl1
            // 
            this.operationControl1.Location = new System.Drawing.Point(446, 141);
            this.operationControl1.Name = "operationControl1";
            this.operationControl1.Size = new System.Drawing.Size(777, 531);
            this.operationControl1.TabIndex = 0;
            // 
            // bioBotDataSets
            // 
            this.bioBotDataSets.DataSetName = "BioBotDataSets";
            this.bioBotDataSets.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.bbt_operationDataGridView.DataSource = this.bbt_operationBindingSource;
            this.bbt_operationDataGridView.Location = new System.Drawing.Point(54, 289);
            this.bbt_operationDataGridView.Name = "bbt_operationDataGridView";
            this.bbt_operationDataGridView.RowTemplate.Height = 28;
            this.bbt_operationDataGridView.Size = new System.Drawing.Size(300, 220);
            this.bbt_operationDataGridView.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "fk_operation_type";
            this.dataGridViewTextBoxColumn1.HeaderText = "fk_operation_type";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "fk_step";
            this.dataGridViewTextBoxColumn2.HeaderText = "fk_step";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "pk_id";
            this.dataGridViewTextBoxColumn3.HeaderText = "pk_id";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // OperationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1404, 859);
            this.Controls.Add(this.bbt_operationDataGridView);
            this.Controls.Add(this.operationControl1);
            this.Name = "OperationForm";
            this.Text = "OperationForm";
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbt_operationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbt_operationDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OperationControl operationControl1;
        private Model.Data.BioBotDataSets bioBotDataSets;
        private System.Windows.Forms.BindingSource bbt_operationBindingSource;
        private System.Windows.Forms.DataGridView bbt_operationDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}