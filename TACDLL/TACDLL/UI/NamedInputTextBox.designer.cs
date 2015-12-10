namespace TACDLL.OptionCtrl
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
            this.edtInputValue.Location = new System.Drawing.Point(123, 4);
            this.edtInputValue.Name = "edtInputValue";
            this.edtInputValue.Size = new System.Drawing.Size(195, 20);
            this.edtInputValue.TabIndex = 3;
            // 
            // txtInputName
            // 
            this.txtInputName.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtInputName.Location = new System.Drawing.Point(4, 4);
            this.txtInputName.Name = "txtInputName";
            this.txtInputName.Size = new System.Drawing.Size(119, 17);
            this.txtInputName.TabIndex = 2;
            this.txtInputName.Text = "InputName";
            this.txtInputName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // namedInputTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.edtInputValue);
            this.Controls.Add(this.txtInputName);
            this.Name = "namedInputTextBox";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(322, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox edtInputValue;
        private System.Windows.Forms.Label txtInputName;
    }
}
