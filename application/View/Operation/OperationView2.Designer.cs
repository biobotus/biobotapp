namespace BioBotApp.View.Step
{
    partial class OperationControl2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvOperations = new System.Windows.Forms.DataGridView();
            this.bsOperationType = new System.Windows.Forms.BindingSource(this.components);
            this.bioBotDataSet = new BioBotApp.Model.Data.BioBotDataSets();
            this.bsStep = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.bsObjectType = new System.Windows.Forms.BindingSource(this.components);
            this.pkidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fkoperationtypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.fkstepDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indexColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsOperation = new System.Windows.Forms.BindingSource(this.components);
            this.bsStepOperation = new System.Windows.Forms.BindingSource(this.components);
            this.bsObjectTypeOperationType = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOperationType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStep)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsObjectType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOperation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStepOperation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsObjectTypeOperationType)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panel1.Size = new System.Drawing.Size(658, 51);
            this.panel1.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(7, 6);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(644, 45);
            this.panel5.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(644, 45);
            this.label3.TabIndex = 1;
            this.label3.Text = "Operations";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvOperations);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 51);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(658, 444);
            this.panel2.TabIndex = 5;
            // 
            // dgvOperations
            // 
            this.dgvOperations.AllowUserToAddRows = false;
            this.dgvOperations.AllowUserToDeleteRows = false;
            this.dgvOperations.AutoGenerateColumns = false;
            this.dgvOperations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOperations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkidDataGridViewTextBoxColumn,
            this.fkoperationtypeDataGridViewTextBoxColumn,
            this.fkstepDataGridViewTextBoxColumn,
            this.indexColumn,
            this.valueDataGridViewTextBoxColumn});
            this.dgvOperations.DataSource = this.bsOperation;
            this.dgvOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOperations.Location = new System.Drawing.Point(3, 3);
            this.dgvOperations.Name = "dgvOperations";
            this.dgvOperations.ReadOnly = true;
            this.dgvOperations.RowHeadersVisible = false;
            this.dgvOperations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOperations.Size = new System.Drawing.Size(606, 438);
            this.dgvOperations.TabIndex = 3;
            this.dgvOperations.SelectionChanged += new System.EventHandler(this.dgvOperations_SelectionChanged);
            // 
            // bsOperationType
            // 
            this.bsOperationType.DataMember = "bbt_operation_type";
            this.bsOperationType.DataSource = this.bioBotDataSet;
            // 
            // bioBotDataSet
            // 
            this.bioBotDataSet.DataSetName = "BioBotDataSets";
            this.bioBotDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bsStep
            // 
            this.bsStep.DataMember = "bbt_step";
            this.bsStep.DataSource = this.bioBotDataSet;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Controls.Add(this.btnEdit);
            this.flowLayoutPanel1.Controls.Add(this.btnDelete);
            this.flowLayoutPanel1.Controls.Add(this.btnUp);
            this.flowLayoutPanel1.Controls.Add(this.btnDown);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(609, 3);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(46, 438);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(2, 2);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(43, 42);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(2, 48);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(43, 42);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(2, 94);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(43, 42);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(2, 140);
            this.btnUp.Margin = new System.Windows.Forms.Padding(2);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(43, 42);
            this.btnUp.TabIndex = 6;
            this.btnUp.Text = "up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(2, 186);
            this.btnDown.Margin = new System.Windows.Forms.Padding(2);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(43, 42);
            this.btnDown.TabIndex = 7;
            this.btnDown.Text = "down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // bsObjectType
            // 
            this.bsObjectType.DataMember = "bbt_object_type";
            this.bsObjectType.DataSource = this.bioBotDataSet;
            // 
            // pkidDataGridViewTextBoxColumn
            // 
            this.pkidDataGridViewTextBoxColumn.DataPropertyName = "pk_id";
            this.pkidDataGridViewTextBoxColumn.HeaderText = "pk_id";
            this.pkidDataGridViewTextBoxColumn.Name = "pkidDataGridViewTextBoxColumn";
            this.pkidDataGridViewTextBoxColumn.ReadOnly = true;
            this.pkidDataGridViewTextBoxColumn.Visible = false;
            // 
            // fkoperationtypeDataGridViewTextBoxColumn
            // 
            this.fkoperationtypeDataGridViewTextBoxColumn.DataPropertyName = "fk_operation_type";
            this.fkoperationtypeDataGridViewTextBoxColumn.DataSource = this.bsOperationType;
            this.fkoperationtypeDataGridViewTextBoxColumn.DisplayMember = "description";
            this.fkoperationtypeDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.fkoperationtypeDataGridViewTextBoxColumn.HeaderText = "Operation type";
            this.fkoperationtypeDataGridViewTextBoxColumn.Name = "fkoperationtypeDataGridViewTextBoxColumn";
            this.fkoperationtypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.fkoperationtypeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.fkoperationtypeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.fkoperationtypeDataGridViewTextBoxColumn.ValueMember = "pk_id";
            // 
            // fkstepDataGridViewTextBoxColumn
            // 
            this.fkstepDataGridViewTextBoxColumn.DataPropertyName = "fk_step";
            this.fkstepDataGridViewTextBoxColumn.HeaderText = "fk_step";
            this.fkstepDataGridViewTextBoxColumn.Name = "fkstepDataGridViewTextBoxColumn";
            this.fkstepDataGridViewTextBoxColumn.ReadOnly = true;
            this.fkstepDataGridViewTextBoxColumn.Visible = false;
            // 
            // indexColumn
            // 
            this.indexColumn.DataPropertyName = "index";
            this.indexColumn.HeaderText = "index";
            this.indexColumn.Name = "indexColumn";
            this.indexColumn.ReadOnly = true;
            this.indexColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.indexColumn.Visible = false;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsOperation
            // 
            this.bsOperation.DataSource = this.bsStepOperation;
            this.bsOperation.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsOperation_ListChanged);
            // 
            // bsStepOperation
            // 
            this.bsStepOperation.DataMember = "bbt_step_bbt_operation";
            this.bsStepOperation.DataSource = this.bsStep;
            // 
            // bsObjectTypeOperationType
            // 
            this.bsObjectTypeOperationType.DataMember = "bbt_object_type_bbt_operation_type_object_type";
            this.bsObjectTypeOperationType.DataSource = this.bsObjectType;
            // 
            // OperationControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "OperationControl2";
            this.Size = new System.Drawing.Size(658, 495);
            this.Load += new System.EventHandler(this.StepView2_Load);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOperationType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStep)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsObjectType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOperation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStepOperation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsObjectTypeOperationType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Model.Data.BioBotDataSets bioBotDataSet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.BindingSource bsStep;
        private System.Windows.Forms.BindingSource bsStepOperation;
        private System.Windows.Forms.BindingSource bsOperation;
        private System.Windows.Forms.DataGridView dgvOperations;
        private System.Windows.Forms.BindingSource bsObjectType;
        private System.Windows.Forms.BindingSource bsObjectTypeOperationType;
        private System.Windows.Forms.BindingSource bsOperationType;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn fkoperationtypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fkstepDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indexColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
    }
}
