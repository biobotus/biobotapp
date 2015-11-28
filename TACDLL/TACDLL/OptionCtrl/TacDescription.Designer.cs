namespace TACDLL.OptionCtrl
{
    partial class TacDescription
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.VentilationLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.OpticalDensityLabel = new System.Windows.Forms.Label();
            this.AgitationLabel = new System.Windows.Forms.Label();
            this.currentTempLabel = new System.Windows.Forms.Label();
            this.goalTempLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.VentilationLabel);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.OpticalDensityLabel);
            this.groupBox1.Controls.Add(this.AgitationLabel);
            this.groupBox1.Controls.Add(this.currentTempLabel);
            this.groupBox1.Controls.Add(this.goalTempLabel);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 112);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tac : 123456";
            // 
            // VentilationLabel
            // 
            this.VentilationLabel.AutoSize = true;
            this.VentilationLabel.Location = new System.Drawing.Point(158, 68);
            this.VentilationLabel.Name = "VentilationLabel";
            this.VentilationLabel.Size = new System.Drawing.Size(55, 13);
            this.VentilationLabel.TabIndex = 37;
            this.VentilationLabel.Text = "NO DATA";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 36;
            this.label12.Text = "Ventilation";
            // 
            // OpticalDensityLabel
            // 
            this.OpticalDensityLabel.AutoSize = true;
            this.OpticalDensityLabel.Location = new System.Drawing.Point(158, 55);
            this.OpticalDensityLabel.Name = "OpticalDensityLabel";
            this.OpticalDensityLabel.Size = new System.Drawing.Size(55, 13);
            this.OpticalDensityLabel.TabIndex = 35;
            this.OpticalDensityLabel.Text = "NO DATA";
            // 
            // AgitationLabel
            // 
            this.AgitationLabel.AutoSize = true;
            this.AgitationLabel.Location = new System.Drawing.Point(158, 42);
            this.AgitationLabel.Name = "AgitationLabel";
            this.AgitationLabel.Size = new System.Drawing.Size(55, 13);
            this.AgitationLabel.TabIndex = 34;
            this.AgitationLabel.Text = "NO DATA";
            // 
            // currentTempLabel
            // 
            this.currentTempLabel.AutoSize = true;
            this.currentTempLabel.Location = new System.Drawing.Point(158, 29);
            this.currentTempLabel.Name = "currentTempLabel";
            this.currentTempLabel.Size = new System.Drawing.Size(55, 13);
            this.currentTempLabel.TabIndex = 33;
            this.currentTempLabel.Text = "NO DATA";
            // 
            // goalTempLabel
            // 
            this.goalTempLabel.AutoSize = true;
            this.goalTempLabel.Location = new System.Drawing.Point(158, 16);
            this.goalTempLabel.Name = "goalTempLabel";
            this.goalTempLabel.Size = new System.Drawing.Size(55, 13);
            this.goalTempLabel.TabIndex = 32;
            this.goalTempLabel.Text = "NO DATA";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(150, 86);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 31;
            this.button2.Text = "refresh";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Temperature (current)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Optical density";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Agitation    ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Temperature (goal)";
            // 
            // TacDescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "TacDescription";
            this.Size = new System.Drawing.Size(232, 112);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label VentilationLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label OpticalDensityLabel;
        private System.Windows.Forms.Label AgitationLabel;
        private System.Windows.Forms.Label currentTempLabel;
        private System.Windows.Forms.Label goalTempLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}
