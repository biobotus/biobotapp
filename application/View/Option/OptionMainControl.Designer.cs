namespace BioBotApp.View.Option
{
    partial class OptionMainControl
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Property");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Object");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Services", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tlvServices = new System.Windows.Forms.TreeView();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tlvServices, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mainPanel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1044, 565);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tlvServices
            // 
            this.tlvServices.Dock = System.Windows.Forms.DockStyle.Left;
            this.tlvServices.Location = new System.Drawing.Point(3, 3);
            this.tlvServices.Name = "tlvServices";
            treeNode1.Name = "PropertyNode";
            treeNode1.Text = "Property";
            treeNode2.Name = "ObjectNode";
            treeNode2.Text = "Object";
            treeNode3.Name = "ServicesNode0";
            treeNode3.Text = "Services";
            this.tlvServices.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.tlvServices.Size = new System.Drawing.Size(150, 559);
            this.tlvServices.TabIndex = 0;
            this.tlvServices.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tlvServices_AfterSelect);
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(159, 3);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(882, 559);
            this.mainPanel.TabIndex = 1;
            // 
            // OptionMainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OptionMainControl";
            this.Size = new System.Drawing.Size(1044, 565);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView tlvServices;
        private System.Windows.Forms.Panel mainPanel;
    }
}
