namespace SimpleTacClient
{
    partial class MainForm
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.tempTB = new System.Windows.Forms.TextBox();
            this.agitPct = new System.Windows.Forms.TrackBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.ventilCb = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.tacDescriptionPanel = new System.Windows.Forms.Panel();
            this.sub1RB = new System.Windows.Forms.RadioButton();
            this.sub2RB = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.VentPct = new System.Windows.Forms.TrackBar();
            this.agitationCb = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.agitPct)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VentPct)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Temperature";
            // 
            // tempTB
            // 
            this.tempTB.Location = new System.Drawing.Point(103, 155);
            this.tempTB.Name = "tempTB";
            this.tempTB.Size = new System.Drawing.Size(59, 20);
            this.tempTB.TabIndex = 4;
            this.tempTB.Text = "0.00";
            this.tempTB.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // agitPct
            // 
            this.agitPct.Location = new System.Drawing.Point(112, 76);
            this.agitPct.Name = "agitPct";
            this.agitPct.Size = new System.Drawing.Size(148, 45);
            this.agitPct.TabIndex = 5;
            this.agitPct.Value = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(270, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionToolStripMenuItem.Text = "Option";
            this.optionToolStripMenuItem.Click += new System.EventHandler(this.optionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ventilCb
            // 
            this.ventilCb.AutoSize = true;
            this.ventilCb.Location = new System.Drawing.Point(13, 106);
            this.ventilCb.Name = "ventilCb";
            this.ventilCb.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ventilCb.Size = new System.Drawing.Size(75, 17);
            this.ventilCb.TabIndex = 10;
            this.ventilCb.Text = "Ventilation";
            this.ventilCb.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(23, 190);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "Auto Calibration";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tacDescriptionPanel
            // 
            this.tacDescriptionPanel.Location = new System.Drawing.Point(13, 220);
            this.tacDescriptionPanel.Name = "tacDescriptionPanel";
            this.tacDescriptionPanel.Size = new System.Drawing.Size(245, 157);
            this.tacDescriptionPanel.TabIndex = 17;
            // 
            // sub1RB
            // 
            this.sub1RB.AutoSize = true;
            this.sub1RB.Checked = true;
            this.sub1RB.Location = new System.Drawing.Point(170, 29);
            this.sub1RB.Name = "sub1RB";
            this.sub1RB.Size = new System.Drawing.Size(90, 17);
            this.sub1RB.TabIndex = 18;
            this.sub1RB.TabStop = true;
            this.sub1RB.Text = "Sub-module 1";
            this.sub1RB.UseVisualStyleBackColor = true;
            // 
            // sub2RB
            // 
            this.sub2RB.AutoSize = true;
            this.sub2RB.Location = new System.Drawing.Point(170, 52);
            this.sub2RB.Name = "sub2RB";
            this.sub2RB.Size = new System.Drawing.Size(90, 17);
            this.sub2RB.TabIndex = 19;
            this.sub2RB.Text = "Sub-module 2";
            this.sub2RB.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(85, 40);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(77, 21);
            this.comboBox1.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Tac Module";
            // 
            // VentPct
            // 
            this.VentPct.Location = new System.Drawing.Point(112, 106);
            this.VentPct.Name = "VentPct";
            this.VentPct.Size = new System.Drawing.Size(148, 45);
            this.VentPct.TabIndex = 22;
            this.VentPct.Value = 5;
            // 
            // agitationCb
            // 
            this.agitationCb.AutoSize = true;
            this.agitationCb.Location = new System.Drawing.Point(13, 76);
            this.agitationCb.Name = "agitationCb";
            this.agitationCb.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.agitationCb.Size = new System.Drawing.Size(67, 17);
            this.agitationCb.TabIndex = 23;
            this.agitationCb.Text = "Agitation";
            this.agitationCb.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 389);
            this.Controls.Add(this.agitationCb);
            this.Controls.Add(this.VentPct);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.sub2RB);
            this.Controls.Add(this.sub1RB);
            this.Controls.Add(this.tacDescriptionPanel);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ventilCb);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.agitPct);
            this.Controls.Add(this.tempTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Simple Tac Client";
            ((System.ComponentModel.ISupportInitialize)(this.agitPct)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VentPct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tempTB;
        private System.Windows.Forms.TrackBar agitPct;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox ventilCb;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel tacDescriptionPanel;
        private System.Windows.Forms.RadioButton sub1RB;
        private System.Windows.Forms.RadioButton sub2RB;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar VentPct;
        private System.Windows.Forms.CheckBox agitationCb;
    }
}

