namespace BioBotApp.View.Protocol
{
    partial class ProtocolStepView
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
            this.tlvProtocols = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolbarPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAddProtocol = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddStep = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolbarPanel.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlvProtocols
            // 
            this.tlvProtocols.AllowDrop = true;
            this.tlvProtocols.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlvProtocols.Location = new System.Drawing.Point(0, 0);
            this.tlvProtocols.Margin = new System.Windows.Forms.Padding(2);
            this.tlvProtocols.Name = "tlvProtocols";
            this.tlvProtocols.Size = new System.Drawing.Size(646, 417);
            this.tlvProtocols.TabIndex = 0;
            this.tlvProtocols.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tlvProtocols_ItemDrag);
            this.tlvProtocols.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tlvProtocols_AfterSelect);
            this.tlvProtocols.DragDrop += new System.Windows.Forms.DragEventHandler(this.tlvProtocols_DragDrop);
            this.tlvProtocols.DragEnter += new System.Windows.Forms.DragEventHandler(this.tlvProtocols_DragEnter);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(693, 65);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(693, 65);
            this.label1.TabIndex = 0;
            this.label1.Text = "Protocol";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tlvProtocols);
            this.panel2.Controls.Add(this.toolbarPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 65);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(693, 417);
            this.panel2.TabIndex = 6;
            // 
            // toolbarPanel
            // 
            this.toolbarPanel.Controls.Add(this.btnAdd);
            this.toolbarPanel.Controls.Add(this.btnEdit);
            this.toolbarPanel.Controls.Add(this.btnDelete);
            this.toolbarPanel.Controls.Add(this.btnUp);
            this.toolbarPanel.Controls.Add(this.btnDown);
            this.toolbarPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolbarPanel.Location = new System.Drawing.Point(646, 0);
            this.toolbarPanel.Margin = new System.Windows.Forms.Padding(2);
            this.toolbarPanel.Name = "toolbarPanel";
            this.toolbarPanel.Size = new System.Drawing.Size(47, 417);
            this.toolbarPanel.TabIndex = 1;
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
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
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
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddProtocol,
            this.btnAddStep});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(145, 48);
            // 
            // btnAddProtocol
            // 
            this.btnAddProtocol.Name = "btnAddProtocol";
            this.btnAddProtocol.Size = new System.Drawing.Size(144, 22);
            this.btnAddProtocol.Text = "Add protocol";
            this.btnAddProtocol.Click += new System.EventHandler(this.btnAddProtocol_Click);
            // 
            // btnAddStep
            // 
            this.btnAddStep.Name = "btnAddStep";
            this.btnAddStep.Size = new System.Drawing.Size(144, 22);
            this.btnAddStep.Text = "Add step";
            this.btnAddStep.Click += new System.EventHandler(this.btnAddStep_Click);
            // 
            // ProtocolStepView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ProtocolStepView";
            this.Size = new System.Drawing.Size(693, 482);
            this.Load += new System.EventHandler(this.ProtocolStepView_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.toolbarPanel.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tlvProtocols;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel toolbarPanel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnAddProtocol;
        private System.Windows.Forms.ToolStripMenuItem btnAddStep;
    }
}
