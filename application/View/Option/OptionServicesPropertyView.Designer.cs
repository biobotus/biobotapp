

namespace BioBotApp.View.Option
{
    partial class OptionServicesPropertyView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionServicesPropertyView));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.propertyTypeServiceView1 = new BioBotApp.View.Services.PropertyTypeServiceView();
            this.propertyServiceView1 = new BioBotApp.View.Services.PropertyServiceView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.informationValueServiceView1 = new BioBotApp.View.Services.InformationValueServiceView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.objectPropertyServiceView1 = new BioBotApp.View.Services.ObjectPropertyServiceView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.propertyTypeServiceView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.propertyServiceView1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(786, 521);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // propertyTypeServiceView1
            // 
            this.propertyTypeServiceView1.Location = new System.Drawing.Point(3, 3);
            this.propertyTypeServiceView1.Name = "propertyTypeServiceView1";
            this.propertyTypeServiceView1.Size = new System.Drawing.Size(255, 515);
            this.propertyTypeServiceView1.TabIndex = 0;
            // 
            // propertyServiceView1
            // 
            this.propertyServiceView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyServiceView1.Location = new System.Drawing.Point(265, 38);
            this.propertyServiceView1.Name = "propertyServiceView1";
            this.propertyServiceView1.Size = new System.Drawing.Size(256, 480);
            this.propertyServiceView1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(527, 38);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(256, 480);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.informationValueServiceView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(248, 454);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Information";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // informationValueServiceView1
            // 
            this.informationValueServiceView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.informationValueServiceView1.Location = new System.Drawing.Point(3, 3);
            this.informationValueServiceView1.Name = "informationValueServiceView1";
            this.informationValueServiceView1.Size = new System.Drawing.Size(242, 448);
            this.informationValueServiceView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.objectPropertyServiceView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(248, 454);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Object";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(248, 454);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Operation";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // objectPropertyServiceView1
            // 
            this.objectPropertyServiceView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectPropertyServiceView1.Location = new System.Drawing.Point(3, 3);
            this.objectPropertyServiceView1.Name = "objectPropertyServiceView1";
            this.objectPropertyServiceView1.Size = new System.Drawing.Size(242, 448);
            this.objectPropertyServiceView1.TabIndex = 0;
            // 
            // OptionServicesPropertyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OptionServicesPropertyView";
            this.Size = new System.Drawing.Size(792, 527);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private Services.PropertyTypeServiceView propertyTypeServiceView1;
        private Services.InformationValueServiceView informationValueServiceView1;
        private Services.PropertyServiceView propertyServiceView1;
        private Services.ObjectPropertyServiceView objectPropertyServiceView1;
    }
}
