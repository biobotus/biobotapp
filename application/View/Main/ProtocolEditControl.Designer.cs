﻿namespace BioBotApp.View.Main
{
    partial class ProtocolEditControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProtocolEditControl));
            this.operationControl21 = new BioBotApp.View.Step.OperationControl2();
            this.SuspendLayout();
            // 
            // operationControl21
            // 
            this.operationControl21.Dock = System.Windows.Forms.DockStyle.Left;
            this.operationControl21.Location = new System.Drawing.Point(293, 0);
            this.operationControl21.Name = "operationControl21";
            this.operationControl21.Size = new System.Drawing.Size(273, 444);
            this.operationControl21.TabIndex = 2;
            // 
            // ProtocolEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.operationControl21);
            this.Name = "ProtocolEditControl";
            this.Size = new System.Drawing.Size(964, 444);
            this.ResumeLayout(false);

        }

        #endregion
        
        private Step.OperationControl2 operationControl21;
    }
}