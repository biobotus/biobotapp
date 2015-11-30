namespace BioBotApp.View.Utils.Controls
{
    partial class NamedCheckBox
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
            this.txtInputName = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtInputName
            // 
            this.txtInputName.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtInputName.Location = new System.Drawing.Point(0, 0);
            this.txtInputName.Name = "txtInputName";
            this.txtInputName.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.txtInputName.Size = new System.Drawing.Size(123, 25);
            this.txtInputName.TabIndex = 3;
            this.txtInputName.Text = "InputName";
            this.txtInputName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox1.Location = new System.Drawing.Point(123, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(106, 25);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // NamedCheckBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txtInputName);
            this.Name = "NamedCheckBox";
            this.Size = new System.Drawing.Size(229, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtInputName;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
