namespace BioBotApp.View.Execute
{
    partial class ExecuteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExecuteForm));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.executeView2 = new BioBotApp.View.Execute.ExecuteView();
            this.protocolControl2 = new BioBotApp.View.Protocol.ProtocolControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.executeView2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.protocolControl2);
            this.splitContainer2.Size = new System.Drawing.Size(775, 515);
            this.splitContainer2.SplitterDistance = 343;
            this.splitContainer2.TabIndex = 0;
            // 
            // executeView2
            // 
            this.executeView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.executeView2.Location = new System.Drawing.Point(0, 0);
            this.executeView2.Name = "executeView2";
            this.executeView2.Size = new System.Drawing.Size(343, 515);
            this.executeView2.TabIndex = 0;
            // 
            // protocolControl2
            // 
            this.protocolControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.protocolControl2.Location = new System.Drawing.Point(0, 0);
            this.protocolControl2.Margin = new System.Windows.Forms.Padding(2);
            this.protocolControl2.Name = "protocolControl2";
            this.protocolControl2.Size = new System.Drawing.Size(428, 515);
            this.protocolControl2.TabIndex = 0;
            // 
            // ExecuteForm
            // 
            this.ClientSize = new System.Drawing.Size(775, 515);
            this.Controls.Add(this.splitContainer2);
            this.Name = "ExecuteForm";
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ExecuteView executeView1;
        private Protocol.ProtocolControl protocolControl1;
        private Model.Data.BioBotDataSets bioBotDataSets;
        private System.Windows.Forms.BindingSource bioBotDataSetsBindingSource;
        private System.Windows.Forms.BindingSource bioBotDataSetsBindingSource1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ExecuteView executeView2;
        private Protocol.ProtocolControl protocolControl2;
    }
}