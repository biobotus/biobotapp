namespace SimpleTacClient
{
    partial class SmallProtDialog
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
            this.tempHighTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.doThresholdTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tempLowTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(252, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "run";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(333, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "heat to ";
            // 
            // tempHighTxt
            // 
            this.tempHighTxt.Location = new System.Drawing.Point(52, 6);
            this.tempHighTxt.Name = "tempHighTxt";
            this.tempHighTxt.Size = new System.Drawing.Size(39, 20);
            this.tempHighTxt.TabIndex = 3;
            this.tempHighTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tempHighTxt.TextChanged += new System.EventHandler(this.tempHighTxt_TextChanged);
            this.tempHighTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tempHighTxt_KeyPress);
            this.tempHighTxt.Validating += new System.ComponentModel.CancelEventHandler(this.tempHight_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "until optical density reach";
            // 
            // doThresholdTxt
            // 
            this.doThresholdTxt.Location = new System.Drawing.Point(229, 6);
            this.doThresholdTxt.Name = "doThresholdTxt";
            this.doThresholdTxt.Size = new System.Drawing.Size(39, 20);
            this.doThresholdTxt.TabIndex = 5;
            this.doThresholdTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.doThresholdTxt_KeyPress);
            this.doThresholdTxt.Validating += new System.ComponentModel.CancelEventHandler(this.do_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "then cooldown to";
            // 
            // tempLowTxt
            // 
            this.tempLowTxt.Location = new System.Drawing.Point(369, 6);
            this.tempLowTxt.Name = "tempLowTxt";
            this.tempLowTxt.Size = new System.Drawing.Size(39, 20);
            this.tempLowTxt.TabIndex = 7;
            this.tempLowTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tempHighTxt_KeyPress);
            this.tempLowTxt.Validating += new System.ComponentModel.CancelEventHandler(this.tempLow_Validating);
            // 
            // SmallProtDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 61);
            this.Controls.Add(this.tempLowTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.doThresholdTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tempHighTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "SmallProtDialog";
            this.Text = "Growth protocol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tempHighTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox doThresholdTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tempLowTxt;
    }
}