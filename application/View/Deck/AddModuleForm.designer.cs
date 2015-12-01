namespace BioBotApp.View.Deck
{
    partial class AddModuleForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.RotationBox = new System.Windows.Forms.ComboBox();
            this.fkObjectBox = new System.Windows.Forms.ComboBox();
            this.fkObjectTypeBox = new System.Windows.Forms.ComboBox();
            this.deck_x = new System.Windows.Forms.NumericUpDown();
            this.deck_y = new System.Windows.Forms.NumericUpDown();
            this.deck_z = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.SupportBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ModuleName = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deck_x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deck_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deck_z)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "X Coord :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Y Coord :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Z Coord :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Object Linked :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Type of Object :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Rotation : ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.deck_z);
            this.groupBox1.Controls.Add(this.deck_y);
            this.groupBox1.Controls.Add(this.deck_x);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(24, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 118);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Location :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SupportBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.fkObjectTypeBox);
            this.groupBox2.Controls.Add(this.fkObjectBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 223);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(204, 124);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reference :";
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(222, 364);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 9;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(222, 398);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // RotationBox
            // 
            this.RotationBox.FormattingEnabled = true;
            this.RotationBox.Items.AddRange(new object[] {
            "0",
            "90",
            "180",
            "270"});
            this.RotationBox.Location = new System.Drawing.Point(100, 186);
            this.RotationBox.Name = "RotationBox";
            this.RotationBox.Size = new System.Drawing.Size(100, 21);
            this.RotationBox.TabIndex = 11;
            // 
            // fkObjectBox
            // 
            this.fkObjectBox.FormattingEnabled = true;
            this.fkObjectBox.Location = new System.Drawing.Point(88, 23);
            this.fkObjectBox.Name = "fkObjectBox";
            this.fkObjectBox.Size = new System.Drawing.Size(110, 21);
            this.fkObjectBox.TabIndex = 12;
            // 
            // fkObjectTypeBox
            // 
            this.fkObjectTypeBox.FormattingEnabled = true;
            this.fkObjectTypeBox.Location = new System.Drawing.Point(88, 52);
            this.fkObjectTypeBox.Name = "fkObjectTypeBox";
            this.fkObjectTypeBox.Size = new System.Drawing.Size(110, 21);
            this.fkObjectTypeBox.TabIndex = 13;
            // 
            // deck_x
            // 
            this.deck_x.Location = new System.Drawing.Point(72, 29);
            this.deck_x.Name = "deck_x";
            this.deck_x.Size = new System.Drawing.Size(87, 20);
            this.deck_x.TabIndex = 4;
            // 
            // deck_y
            // 
            this.deck_y.Location = new System.Drawing.Point(72, 55);
            this.deck_y.Name = "deck_y";
            this.deck_y.Size = new System.Drawing.Size(87, 20);
            this.deck_y.TabIndex = 5;
            // 
            // deck_z
            // 
            this.deck_z.Location = new System.Drawing.Point(72, 87);
            this.deck_z.Name = "deck_z";
            this.deck_z.Size = new System.Drawing.Size(87, 20);
            this.deck_z.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Support Linked :";
            // 
            // SupportBox
            // 
            this.SupportBox.FormattingEnabled = true;
            this.SupportBox.Location = new System.Drawing.Point(88, 84);
            this.SupportBox.Name = "SupportBox";
            this.SupportBox.Size = new System.Drawing.Size(110, 21);
            this.SupportBox.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Module Name :";
            // 
            // ModuleName
            // 
            this.ModuleName.Location = new System.Drawing.Point(109, 25);
            this.ModuleName.Name = "ModuleName";
            this.ModuleName.Size = new System.Drawing.Size(100, 20);
            this.ModuleName.TabIndex = 13;
            // 
            // AddModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 433);
            this.Controls.Add(this.ModuleName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.RotationBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Name = "AddModuleForm";
            this.Text = "New Module Properties";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deck_x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deck_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deck_z)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown deck_x;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox fkObjectTypeBox;
        private System.Windows.Forms.ComboBox fkObjectBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.ComboBox RotationBox;
        private System.Windows.Forms.NumericUpDown deck_z;
        private System.Windows.Forms.NumericUpDown deck_y;
        private System.Windows.Forms.ComboBox SupportBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ModuleName;
    }
}