namespace BioBotApp.Controls.Option.Options
{
    partial class namedInputTextBox
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
            this.edtInputValue = new System.Windows.Forms.TextBox();
            this.txtInputName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // edtInputValue
            // 
            this.edtInputValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtInputValue.Location = new System.Drawing.Point(164, 5);
            this.edtInputValue.Margin = new System.Windows.Forms.Padding(4);
            this.edtInputValue.Name = "edtInputValue";
            this.edtInputValue.Size = new System.Drawing.Size(261, 22);
            this.edtInputValue.TabIndex = 3;
            // 
            // txtInputName
            // 
            this.txtInputName.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtInputName.Location = new System.Drawing.Point(5, 5);
            this.txtInputName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtInputName.Name = "txtInputName";
            this.txtInputName.Size = new System.Drawing.Size(159, 21);
            this.txtInputName.TabIndex = 2;
            this.txtInputName.Text = "InputName";
            this.txtInputName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // namedInputTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.edtInputValue);
            this.Controls.Add(this.txtInputName);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "namedInputTextBox";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(430, 31);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox edtInputValue;
        private System.Windows.Forms.Label txtInputName;
    }
}
