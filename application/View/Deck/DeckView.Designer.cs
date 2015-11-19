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
            this.bioBotDataSets = new BioBotApp.Model.Data.BioBotDataSets();
            this.bsObject = new System.Windows.Forms.BindingSource(this.components);
            this.taObject = new BioBotApp.Model.Data.BioBotDataSetsTableAdapters.bbt_objectTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsObject)).BeginInit();
            this.SuspendLayout();
            // 
            // bioBotDataSets
            // 
            this.bioBotDataSets.DataSetName = "BioBotDataSets";
            this.bioBotDataSets.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bsObject
            // 
            this.bsObject.DataMember = "bbt_object";
            this.bsObject.DataSource = this.bioBotDataSets;
            // 
            // taObject
            // 
            this.taObject.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(352, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // DeckView
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.button1);
            this.Name = "DeckView";
            this.Size = new System.Drawing.Size(547, 363);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.DeckView_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.DeckView_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsObject)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Model.Data.BioBotDataSets bioBotDataSets;
        private System.Windows.Forms.BindingSource bsObject;
        private Model.Data.BioBotDataSetsTableAdapters.bbt_objectTableAdapter taObject;
        private System.Windows.Forms.Button button1;
    }
}
