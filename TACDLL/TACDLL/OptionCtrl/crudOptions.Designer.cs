namespace TACDLL.OptionCtrl
{
    partial class crudOptions
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
            this.layoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.layoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutPanel
            // 
            this.layoutPanel.Controls.Add(this.btnAdd);
            this.layoutPanel.Controls.Add(this.btnDelete);
            this.layoutPanel.Controls.Add(this.btnModify);
            this.layoutPanel.Controls.Add(this.btnRefresh);
            this.layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.layoutPanel.Location = new System.Drawing.Point(0, 0);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.Size = new System.Drawing.Size(317, 37);
            this.layoutPanel.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::TACDLL.Properties.Resources.add;
            this.btnAdd.Location = new System.Drawing.Point(282, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(32, 32);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAddClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::TACDLL.Properties.Resources.delete;
            this.btnDelete.Location = new System.Drawing.Point(244, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(32, 32);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDeleteClick);
            // 
            // btnModify
            // 
            this.btnModify.Image = global::TACDLL.Properties.Resources.modify;
            this.btnModify.Location = new System.Drawing.Point(206, 3);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(32, 32);
            this.btnModify.TabIndex = 2;
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModifyClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::TACDLL.Properties.Resources.arrow_refresh;
            this.btnRefresh.Location = new System.Drawing.Point(168, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(32, 32);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // crudOptions
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.layoutPanel);
            this.MinimumSize = new System.Drawing.Size(37, 37);
            this.Name = "crudOptions";
            this.Size = new System.Drawing.Size(317, 37);
            this.layoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel layoutPanel;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;


    }
}
