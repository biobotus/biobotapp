namespace BioBotApp.View.Properties
{
    partial class PropertiesControl
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
            this.dsBioBot = new BioBotApp.Model.Data.BioBotDataSets();
            this.bsObjectProperty = new System.Windows.Forms.BindingSource(this.components);
            this.bbt_object_propertyDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtObjectType = new System.Windows.Forms.TextBox();
            this.txtProperties = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dsBioBot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsObjectProperty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbt_object_propertyDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dsBioBot
            // 
            this.dsBioBot.DataSetName = "BioBotDataSets";
            this.dsBioBot.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bsObjectProperty
            // 
            this.bsObjectProperty.DataMember = "bbt_object_property";
            this.bsObjectProperty.DataSource = this.dsBioBot;
            // 
            // bbt_object_propertyDataGridView
            // 
            this.bbt_object_propertyDataGridView.AutoGenerateColumns = false;
            this.bbt_object_propertyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bbt_object_propertyDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.bbt_object_propertyDataGridView.DataSource = this.bsObjectProperty;
            this.bbt_object_propertyDataGridView.Location = new System.Drawing.Point(139, 87);
            this.bbt_object_propertyDataGridView.Name = "bbt_object_propertyDataGridView";
            this.bbt_object_propertyDataGridView.RowTemplate.Height = 28;
            this.bbt_object_propertyDataGridView.Size = new System.Drawing.Size(300, 220);
            this.bbt_object_propertyDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "fk_object_type_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "fk_object_type_id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "fk_properties_id";
            this.dataGridViewTextBoxColumn2.HeaderText = "fk_properties_id";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "value";
            this.dataGridViewTextBoxColumn3.HeaderText = "value";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(579, 225);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 53);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtObjectType
            // 
            this.txtObjectType.Location = new System.Drawing.Point(579, 114);
            this.txtObjectType.Name = "txtObjectType";
            this.txtObjectType.Size = new System.Drawing.Size(100, 26);
            this.txtObjectType.TabIndex = 3;
            // 
            // txtProperties
            // 
            this.txtProperties.Location = new System.Drawing.Point(579, 146);
            this.txtProperties.Name = "txtProperties";
            this.txtProperties.Size = new System.Drawing.Size(100, 26);
            this.txtProperties.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(484, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Object type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(493, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "properties";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(579, 178);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(100, 26);
            this.txtValue.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(493, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "value";
            // 
            // PropertiesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtProperties);
            this.Controls.Add(this.txtObjectType);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.bbt_object_propertyDataGridView);
            this.Name = "PropertiesControl";
            this.Size = new System.Drawing.Size(795, 416);
            ((System.ComponentModel.ISupportInitialize)(this.dsBioBot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsObjectProperty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbt_object_propertyDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Model.Data.BioBotDataSets dsBioBot;
        private System.Windows.Forms.BindingSource bsObjectProperty;
        private System.Windows.Forms.DataGridView bbt_object_propertyDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtObjectType;
        private System.Windows.Forms.TextBox txtProperties;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label3;
    }
}
