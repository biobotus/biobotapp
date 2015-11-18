namespace BioBotApp.View.Deck
{
    partial class DeckView
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
            this.deck = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pkidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fkobjecttypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deckxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deckyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rotationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fkobjectDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsBiobot = new System.Windows.Forms.BindingSource(this.components);
            this.bioBotDataSets = new BioBotApp.Model.Data.BioBotDataSets();
            this.taObject = new BioBotApp.Model.Data.BioBotDataSetsTableAdapters.bbt_objectTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBiobot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).BeginInit();
            this.SuspendLayout();
            // 
            // deck
            // 
            this.deck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.deck.Location = new System.Drawing.Point(46, 48);
            this.deck.Name = "deck";
            this.deck.Size = new System.Drawing.Size(317, 234);
            this.deck.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkidDataGridViewTextBoxColumn,
            this.fkobjecttypeDataGridViewTextBoxColumn,
            this.deckxDataGridViewTextBoxColumn,
            this.deckyDataGridViewTextBoxColumn,
            this.rotationDataGridViewTextBoxColumn,
            this.activatedDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.fkobjectDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bsBiobot;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridView1.Location = new System.Drawing.Point(466, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(404, 365);
            this.dataGridView1.TabIndex = 1;
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
            // deckxDataGridViewTextBoxColumn
            // 
            this.deckxDataGridViewTextBoxColumn.DataPropertyName = "deck_x";
            this.deckxDataGridViewTextBoxColumn.HeaderText = "deck_x";
            this.deckxDataGridViewTextBoxColumn.Name = "deckxDataGridViewTextBoxColumn";
            // 
            // deckyDataGridViewTextBoxColumn
            // 
            this.deckyDataGridViewTextBoxColumn.DataPropertyName = "deck_y";
            this.deckyDataGridViewTextBoxColumn.HeaderText = "deck_y";
            this.deckyDataGridViewTextBoxColumn.Name = "deckyDataGridViewTextBoxColumn";
            // 
            // rotationDataGridViewTextBoxColumn
            // 
            this.rotationDataGridViewTextBoxColumn.DataPropertyName = "rotation";
            this.rotationDataGridViewTextBoxColumn.HeaderText = "rotation";
            this.rotationDataGridViewTextBoxColumn.Name = "rotationDataGridViewTextBoxColumn";
            // 
            // activatedDataGridViewTextBoxColumn
            // 
            this.activatedDataGridViewTextBoxColumn.DataPropertyName = "activated";
            this.activatedDataGridViewTextBoxColumn.HeaderText = "activated";
            this.activatedDataGridViewTextBoxColumn.Name = "activatedDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // fkobjectDataGridViewTextBoxColumn
            // 
            this.fkobjectDataGridViewTextBoxColumn.DataPropertyName = "fk_object";
            this.fkobjectDataGridViewTextBoxColumn.HeaderText = "fk_object";
            this.fkobjectDataGridViewTextBoxColumn.Name = "fkobjectDataGridViewTextBoxColumn";
            // 
            // bsBiobot
            // 
            this.bsBiobot.DataMember = "bbt_object";
            this.bsBiobot.DataSource = this.bioBotDataSets;
            // 
            // bioBotDataSets
            // 
            this.bioBotDataSets.DataSetName = "BioBotDataSets";
            this.bioBotDataSets.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taObject
            // 
            this.taObject.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(288, 304);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(404, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DeckView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.deck);
            this.Name = "DeckView";
            this.Size = new System.Drawing.Size(870, 365);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBiobot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel deck;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fkobjecttypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deckxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deckyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rotationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn activatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fkobjectDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsBiobot;
        private Model.Data.BioBotDataSets bioBotDataSets;
        private Model.Data.BioBotDataSetsTableAdapters.bbt_objectTableAdapter taObject;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}
