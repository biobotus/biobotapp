namespace BioBotApp.View.Services
{
    partial class InformationServiceView
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
            this.fkinformationtypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bbtinformationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bioBotDataSets = new BioBotApp.Model.Data.BioBotDataSets();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.crudOptions1 = new BioBotApp.Controls.Utils.crudOptions();
            this.bbt_informationTableAdapter = new BioBotApp.Model.Data.BioBotDataSetsTableAdapters.bbt_informationTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbtinformationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkidDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.fkinformationtypeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bbtinformationBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(257, 329);
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
            // fkinformationtypeDataGridViewTextBoxColumn
            // 
            this.fkinformationtypeDataGridViewTextBoxColumn.DataPropertyName = "fk_information_type";
            this.fkinformationtypeDataGridViewTextBoxColumn.HeaderText = "fk_information_type";
            this.fkinformationtypeDataGridViewTextBoxColumn.Name = "fkinformationtypeDataGridViewTextBoxColumn";
            // 
            // bbtinformationBindingSource
            // 
            this.bbtinformationBindingSource.DataMember = "bbt_information";
            this.bbtinformationBindingSource.DataSource = this.bioBotDataSets;
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
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 405);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // crudOptions1
            // 
            this.crudOptions1.LayoutLeftToRight = System.Windows.Forms.FlowDirection.RightToLeft;
            this.crudOptions1.Location = new System.Drawing.Point(107, 19);
            this.crudOptions1.MinimumSize = new System.Drawing.Size(37, 37);
            this.crudOptions1.Name = "crudOptions1";
            this.crudOptions1.Size = new System.Drawing.Size(156, 37);
            this.crudOptions1.TabIndex = 1;
            this.crudOptions1.AddClickHandler += new System.EventHandler(this.Add_Click);
            this.crudOptions1.DeleteClickHandler += new System.EventHandler(this.Delete_Click);
            this.crudOptions1.ModifyClickHandler += new System.EventHandler(this.Modify_Click);
            // 
            // bbt_informationTableAdapter
            // 
            this.bbt_informationTableAdapter.ClearBeforeFill = true;
            // 
            // InformationServiceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "InformationServiceView";
            this.Size = new System.Drawing.Size(301, 411);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbtinformationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fkinformationtypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bbtinformationBindingSource;
        private Model.Data.BioBotDataSets bioBotDataSets;
        private Controls.Utils.crudOptions crudOptions1;
        private Model.Data.BioBotDataSetsTableAdapters.bbt_informationTableAdapter bbt_informationTableAdapter;
    }
}
