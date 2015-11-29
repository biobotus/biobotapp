namespace BioBotApp.View.Option
{
    partial class OptionServicesObjectView
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.objectServiceView1 = new BioBotApp.View.Services.ObjectServiceView();
            this.objectTypeServiceView1 = new BioBotApp.View.Services.ObjectTypeServiceView();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.objectServiceView1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.objectTypeServiceView1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(650, 409);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // objectServiceView1
            // 
            this.objectServiceView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.objectServiceView1.Location = new System.Drawing.Point(263, 15);
            this.objectServiceView1.Name = "objectServiceView1";
            this.objectServiceView1.Size = new System.Drawing.Size(254, 391);
            this.objectServiceView1.TabIndex = 1;
            // 
            // objectTypeServiceView1
            // 
            this.objectTypeServiceView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectTypeServiceView1.Location = new System.Drawing.Point(3, 3);
            this.objectTypeServiceView1.Name = "objectTypeServiceView1";
            this.objectTypeServiceView1.Size = new System.Drawing.Size(254, 403);
            this.objectTypeServiceView1.TabIndex = 0;
            // 
            // OptionServicesObjectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OptionServicesObjectView";
            this.Size = new System.Drawing.Size(650, 409);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Services.ObjectTypeServiceView objectTypeServiceView1;
        private Services.ObjectServiceView objectServiceView1;
    }
}
