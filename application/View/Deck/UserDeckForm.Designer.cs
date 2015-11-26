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
            ((System.ComponentModel.ISupportInitialize)(this.deck_X_Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deck_Y_Box)).BeginInit();
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
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.label1.Size = new System.Drawing.Size(333, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Veuillez entrer les dimensions du nouveau module :";
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
            this.label3.Click += new System.EventHandler(this.label3_Click);
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
            this.deck_X_Box.ValueChanged += new System.EventHandler(this.deck_X_Box_ValueChanged);
            // 
            // deck_Y_Box
            // 
            this.deck_Y_Box.Location = new System.Drawing.Point(186, 132);
            this.deck_Y_Box.Name = "deck_Y_Box";
            this.deck_Y_Box.Size = new System.Drawing.Size(120, 20);
            this.deck_Y_Box.TabIndex = 13;
            this.deck_Y_Box.ValueChanged += new System.EventHandler(this.deck_Y_Box_ValueChanged);
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
            // UserDeckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 261);
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
    }
}