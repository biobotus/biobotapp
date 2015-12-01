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
            // DeckView
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Name = "DeckView";
            this.Size = new System.Drawing.Size(547, 363);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.DeckView_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.DeckView_DragEnter);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DeckView_OnMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DeckView_MouseMove);
            this.Resize += new System.EventHandler(this.DeckView_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.bioBotDataSets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsObject)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Model.Data.BioBotDataSets bioBotDataSets;
        private System.Windows.Forms.BindingSource bsObject;
        private Model.Data.BioBotDataSetsTableAdapters.bbt_objectTableAdapter taObject;
    }
}
