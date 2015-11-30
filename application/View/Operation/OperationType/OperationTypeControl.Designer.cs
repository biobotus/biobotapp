namespace BioBotApp.View.Operation.OperationType
{
    partial class OperationTypeControl
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
            this.cmbOperationType = new System.Windows.Forms.ComboBox();
            this.bsOperationType = new System.Windows.Forms.BindingSource(this.components);
            this.bioBotDataSets = new BioBotApp.Model.Data.BioBotDataSets();
            this.txtInputName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsOperationType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbOperationType
            // 
            this.cmbOperationType.DataSource = this.bsOperationType;
            this.cmbOperationType.DisplayMember = "description";
            this.cmbOperationType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbOperationType.FormattingEnabled = true;
            this.cmbOperationType.Location = new System.Drawing.Point(122, 3);
            this.cmbOperationType.Name = "cmbOperationType";
            this.cmbOperationType.Size = new System.Drawing.Size(283, 21);
            this.cmbOperationType.TabIndex = 0;
            this.cmbOperationType.ValueMember = "pk_id";
            // 
            // bsOperationType
            // 
            this.bsOperationType.DataMember = "bbt_operation_type";
            this.bsOperationType.DataSource = this.bioBotDataSets;
            // 
            // bioBotDataSets
            // 
            this.bioBotDataSets.DataSetName = "BioBotDataSets";
            this.bioBotDataSets.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtInputName
            // 
            this.txtInputName.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtInputName.Location = new System.Drawing.Point(3, 3);
            this.txtInputName.Name = "txtInputName";
            this.txtInputName.Size = new System.Drawing.Size(119, 20);
            this.txtInputName.TabIndex = 3;
            this.txtInputName.Text = "OperationType:";
            this.txtInputName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OperationTypeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbOperationType);
            this.Controls.Add(this.txtInputName);
            this.Name = "OperationTypeControl";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(408, 26);
            ((System.ComponentModel.ISupportInitialize)(this.bsOperationType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbOperationType;
        private System.Windows.Forms.BindingSource bsOperationType;
        private Model.Data.BioBotDataSets bioBotDataSets;
        private System.Windows.Forms.Label txtInputName;
    }
}
