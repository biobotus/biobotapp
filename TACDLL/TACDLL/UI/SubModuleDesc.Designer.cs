namespace TACDLL.UI
{
    partial class SubModuleDesc
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
            this.VentilationLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.OpticalDensityLabel = new System.Windows.Forms.Label();
            this.AgitationLabel = new System.Windows.Forms.Label();
            this.currentTempLabel = new System.Windows.Forms.Label();
            this.goalTempLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // VentilationLabel
            // 
            this.VentilationLabel.AutoSize = true;
            this.VentilationLabel.Location = new System.Drawing.Point(127, 62);
            this.VentilationLabel.Name = "VentilationLabel";
            this.VentilationLabel.Size = new System.Drawing.Size(55, 13);
            this.VentilationLabel.TabIndex = 59;
            this.VentilationLabel.Text = "NO DATA";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 58;
            this.label12.Text = "Ventilation";
            // 
            // OpticalDensityLabel
            // 
            this.OpticalDensityLabel.AutoSize = true;
            this.OpticalDensityLabel.Location = new System.Drawing.Point(127, 49);
            this.OpticalDensityLabel.Name = "OpticalDensityLabel";
            this.OpticalDensityLabel.Size = new System.Drawing.Size(55, 13);
            this.OpticalDensityLabel.TabIndex = 57;
            this.OpticalDensityLabel.Text = "NO DATA";
            // 
            // AgitationLabel
            // 
            this.AgitationLabel.AutoSize = true;
            this.AgitationLabel.Location = new System.Drawing.Point(127, 36);
            this.AgitationLabel.Name = "AgitationLabel";
            this.AgitationLabel.Size = new System.Drawing.Size(55, 13);
            this.AgitationLabel.TabIndex = 56;
            this.AgitationLabel.Text = "NO DATA";
            // 
            // currentTempLabel
            // 
            this.currentTempLabel.AutoSize = true;
            this.currentTempLabel.Location = new System.Drawing.Point(127, 23);
            this.currentTempLabel.Name = "currentTempLabel";
            this.currentTempLabel.Size = new System.Drawing.Size(55, 13);
            this.currentTempLabel.TabIndex = 55;
            this.currentTempLabel.Text = "NO DATA";
            // 
            // goalTempLabel
            // 
            this.goalTempLabel.AutoSize = true;
            this.goalTempLabel.Location = new System.Drawing.Point(127, 10);
            this.goalTempLabel.Name = "goalTempLabel";
            this.goalTempLabel.Size = new System.Drawing.Size(55, 13);
            this.goalTempLabel.TabIndex = 54;
            this.goalTempLabel.Text = "NO DATA";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 52;
            this.label6.Text = "Temperature (current)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "Optical density";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Agitation    ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Temperature (goal)";
            // 
            // SubModuleDesc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.VentilationLabel);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.OpticalDensityLabel);
            this.Controls.Add(this.AgitationLabel);
            this.Controls.Add(this.currentTempLabel);
            this.Controls.Add(this.goalTempLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "SubModuleDesc";
            this.Size = new System.Drawing.Size(186, 83);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label VentilationLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label OpticalDensityLabel;
        private System.Windows.Forms.Label AgitationLabel;
        private System.Windows.Forms.Label currentTempLabel;
        private System.Windows.Forms.Label goalTempLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}
