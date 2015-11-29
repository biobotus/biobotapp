namespace BioBotApp.View.Deck
{
    partial class UserDeckForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Rotation_Box = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.deck_X_Box = new System.Windows.Forms.NumericUpDown();
            this.deck_Y_Box = new System.Windows.Forms.NumericUpDown();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ModuleHeight = new System.Windows.Forms.Label();
            this.ModuleWidth = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ModuleName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.activatedBox = new System.Windows.Forms.RadioButton();
            this.DeactivedBox = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.deck_X_Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deck_Y_Box)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(434, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(434, 202);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(41, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Please, enter the new coordinates of this module :";
            // 
            // Rotation_Box
            // 
            this.Rotation_Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Rotation_Box.FormattingEnabled = true;
            this.Rotation_Box.Items.AddRange(new object[] {
            "0",
            "90",
            "180",
            "270"});
            this.Rotation_Box.Location = new System.Drawing.Point(185, 174);
            this.Rotation_Box.Name = "Rotation_Box";
            this.Rotation_Box.Size = new System.Drawing.Size(121, 21);
            this.Rotation_Box.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "X Coordinates :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Y Coordinates :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Rotation :";
            // 
            // deck_X_Box
            // 
            this.deck_X_Box.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.deck_X_Box.Location = new System.Drawing.Point(185, 91);
            this.deck_X_Box.Name = "deck_X_Box";
            this.deck_X_Box.Size = new System.Drawing.Size(120, 20);
            this.deck_X_Box.TabIndex = 12;
            this.deck_X_Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deck_X_Box_KeyPress);
            // 
            // deck_Y_Box
            // 
            this.deck_Y_Box.Location = new System.Drawing.Point(186, 132);
            this.deck_Y_Box.Name = "deck_Y_Box";
            this.deck_Y_Box.Size = new System.Drawing.Size(120, 20);
            this.deck_Y_Box.TabIndex = 13;
            this.deck_Y_Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deck_Y_Box_KeyPress);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Location = new System.Drawing.Point(95, 56);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(0, 13);
            this.ErrorLabel.TabIndex = 14;
            this.ErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ErrorLabel.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Width :";
            // 
            // ModuleHeight
            // 
            this.ModuleHeight.AutoSize = true;
            this.ModuleHeight.Location = new System.Drawing.Point(78, 49);
            this.ModuleHeight.Name = "ModuleHeight";
            this.ModuleHeight.Size = new System.Drawing.Size(0, 13);
            this.ModuleHeight.TabIndex = 16;
            // 
            // ModuleWidth
            // 
            this.ModuleWidth.AutoSize = true;
            this.ModuleWidth.Location = new System.Drawing.Point(78, 27);
            this.ModuleWidth.Name = "ModuleWidth";
            this.ModuleWidth.Size = new System.Drawing.Size(0, 13);
            this.ModuleWidth.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Height :";
            // 
            // ModuleName
            // 
            this.ModuleName.AutoSize = true;
            this.ModuleName.Location = new System.Drawing.Point(381, 27);
            this.ModuleName.Name = "ModuleName";
            this.ModuleName.Size = new System.Drawing.Size(0, 13);
            this.ModuleName.TabIndex = 19;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ModuleHeight);
            this.groupBox1.Controls.Add(this.ModuleWidth);
            this.groupBox1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.groupBox1.Location = new System.Drawing.Point(384, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 91);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dimensions (x10 mm) :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(95, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Activate :";
            // 
            // activatedBox
            // 
            this.activatedBox.AutoSize = true;
            this.activatedBox.Location = new System.Drawing.Point(19, 8);
            this.activatedBox.Name = "activatedBox";
            this.activatedBox.Size = new System.Drawing.Size(43, 17);
            this.activatedBox.TabIndex = 22;
            this.activatedBox.Text = "Yes";
            this.activatedBox.UseVisualStyleBackColor = true;
            this.activatedBox.CheckedChanged += new System.EventHandler(this.activatedBox_CheckedChanged);
            // 
            // DeactivedBox
            // 
            this.DeactivedBox.AutoSize = true;
            this.DeactivedBox.Location = new System.Drawing.Point(68, 8);
            this.DeactivedBox.Name = "DeactivedBox";
            this.DeactivedBox.Size = new System.Drawing.Size(39, 17);
            this.DeactivedBox.TabIndex = 23;
            this.DeactivedBox.Text = "No";
            this.DeactivedBox.UseVisualStyleBackColor = true;
            this.DeactivedBox.CheckedChanged += new System.EventHandler(this.DeactivedBox_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.activatedBox);
            this.panel1.Controls.Add(this.DeactivedBox);
            this.panel1.Location = new System.Drawing.Point(181, 211);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(124, 38);
            this.panel1.TabIndex = 25;
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.button3.Location = new System.Drawing.Point(12, 213);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 26;
            this.button3.Text = "Deactivate";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // UserDeckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 261);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ModuleName);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.deck_Y_Box);
            this.Controls.Add(this.deck_X_Box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Rotation_Box);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "UserDeckForm";
            this.Text = "New Module Coordinates";
            ((System.ComponentModel.ISupportInitialize)(this.deck_X_Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deck_Y_Box)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Rotation_Box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown deck_X_Box;
        private System.Windows.Forms.NumericUpDown deck_Y_Box;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label ModuleHeight;
        private System.Windows.Forms.Label ModuleWidth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label ModuleName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton activatedBox;
        private System.Windows.Forms.RadioButton DeactivedBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
    }
}