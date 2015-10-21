namespace BioBotApp.View.ModulePluginManager
{
    partial class PluginPathControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtNewPath = new System.Windows.Forms.TextBox();
            this.pathBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddToPathList = new System.Windows.Forms.Button();
            this.btnUpdateTextPathList = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpSel = new System.Windows.Forms.Button();
            this.btnDownSel = new System.Windows.Forms.Button();
            this.btnDelLine = new System.Windows.Forms.Button();
            this.pathListView = new System.Windows.Forms.DataGridView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pathListView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Plugin folder";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(309, 20);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBrowse.Size = new System.Drawing.Size(32, 21);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtNewPath
            // 
            this.txtNewPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNewPath.Location = new System.Drawing.Point(3, 20);
            this.txtNewPath.Name = "txtNewPath";
            this.txtNewPath.Size = new System.Drawing.Size(300, 20);
            this.txtNewPath.TabIndex = 2;
            // 
            // pathBrowserDialog
            // 
            this.pathBrowserDialog.ShowNewFolderButton = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.47263F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.52738F));
            this.tableLayoutPanel1.Controls.Add(this.txtNewPath, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnBrowse, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.74074F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.25926F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(347, 44);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btnAddToPathList
            // 
            this.btnAddToPathList.Location = new System.Drawing.Point(6, 50);
            this.btnAddToPathList.Name = "btnAddToPathList";
            this.btnAddToPathList.Size = new System.Drawing.Size(73, 23);
            this.btnAddToPathList.TabIndex = 3;
            this.btnAddToPathList.Text = "Add folder";
            this.btnAddToPathList.UseVisualStyleBackColor = true;
            this.btnAddToPathList.Click += new System.EventHandler(this.btnAddToPathList_Click);
            // 
            // btnUpdateTextPathList
            // 
            this.btnUpdateTextPathList.Location = new System.Drawing.Point(99, 51);
            this.btnUpdateTextPathList.Name = "btnUpdateTextPathList";
            this.btnUpdateTextPathList.Size = new System.Drawing.Size(81, 21);
            this.btnUpdateTextPathList.TabIndex = 4;
            this.btnUpdateTextPathList.Text = "Update";
            this.btnUpdateTextPathList.UseVisualStyleBackColor = true;
            this.btnUpdateTextPathList.Click += new System.EventHandler(this.btnUpdateTextPathList_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Plugin folder";
            // 
            // btnUpSel
            // 
            this.btnUpSel.Location = new System.Drawing.Point(309, 97);
            this.btnUpSel.Name = "btnUpSel";
            this.btnUpSel.Size = new System.Drawing.Size(32, 25);
            this.btnUpSel.TabIndex = 3;
            this.btnUpSel.Text = "up";
            this.btnUpSel.UseVisualStyleBackColor = true;
            this.btnUpSel.Click += new System.EventHandler(this.btnUpSel_Click);
            // 
            // btnDownSel
            // 
            this.btnDownSel.Location = new System.Drawing.Point(309, 128);
            this.btnDownSel.Name = "btnDownSel";
            this.btnDownSel.Size = new System.Drawing.Size(32, 25);
            this.btnDownSel.TabIndex = 6;
            this.btnDownSel.Text = "down";
            this.btnDownSel.UseVisualStyleBackColor = true;
            this.btnDownSel.Click += new System.EventHandler(this.btnDownSel_Click);
            // 
            // btnDelLine
            // 
            this.btnDelLine.Location = new System.Drawing.Point(309, 159);
            this.btnDelLine.Name = "btnDelLine";
            this.btnDelLine.Size = new System.Drawing.Size(32, 25);
            this.btnDelLine.TabIndex = 7;
            this.btnDelLine.Text = "supp";
            this.btnDelLine.UseVisualStyleBackColor = true;
            this.btnDelLine.Click += new System.EventHandler(this.btnDelLine_Click);
            // 
            // pathListView
            // 
            this.pathListView.AllowUserToAddRows = false;
            this.pathListView.AllowUserToDeleteRows = false;
            this.pathListView.AllowUserToResizeColumns = false;
            this.pathListView.AllowUserToResizeRows = false;
            this.pathListView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.pathListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pathListView.ColumnHeadersVisible = false;
            this.pathListView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pathListView.Location = new System.Drawing.Point(5, 97);
            this.pathListView.MultiSelect = false;
            this.pathListView.Name = "pathListView";
            this.pathListView.RowHeadersVisible = false;
            this.pathListView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.pathListView.RowTemplate.ReadOnly = true;
            this.pathListView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.pathListView.Size = new System.Drawing.Size(298, 198);
            this.pathListView.TabIndex = 8;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(99, 302);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(81, 21);
            this.btnLoad.TabIndex = 10;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 301);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // PluginPathControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pathListView);
            this.Controls.Add(this.btnDelLine);
            this.Controls.Add(this.btnDownSel);
            this.Controls.Add(this.btnUpSel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnUpdateTextPathList);
            this.Controls.Add(this.btnAddToPathList);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PluginPathControl";
            this.Size = new System.Drawing.Size(347, 346);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pathListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtNewPath;
        private System.Windows.Forms.FolderBrowserDialog pathBrowserDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnAddToPathList;
        private System.Windows.Forms.Button btnUpdateTextPathList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpSel;
        private System.Windows.Forms.Button btnDownSel;
        private System.Windows.Forms.Button btnDelLine;
        private System.Windows.Forms.DataGridView pathListView;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
    }
}
