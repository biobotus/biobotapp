namespace BioBotApp.View.Deck
{
    partial class DeckForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeckForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.objectView2 = new BioBotApp.View.Deck.ObjectView();
            this.objectView1 = new BioBotApp.View.Deck.ObjectView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.deckView1 = new BioBotApp.View.Deck.DeckView();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitter2);
            this.panel1.Controls.Add(this.objectView2);
            this.panel1.Controls.Add(this.objectView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 376);
            this.panel1.TabIndex = 0;
            // 
            // objectView2
            // 
            this.objectView2.AllowDrop = true;
            this.objectView2.AutoSize = true;
            this.objectView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectView2.Location = new System.Drawing.Point(0, 0);
            this.objectView2.Name = "objectView2";
            this.objectView2.Size = new System.Drawing.Size(200, 376);
            this.objectView2.TabIndex = 1;
            // 
            // objectView1
            // 
            this.objectView1.AllowDrop = true;
            this.objectView1.AutoSize = true;
            this.objectView1.Location = new System.Drawing.Point(114, 68);
            this.objectView1.Name = "objectView1";
            this.objectView1.Size = new System.Drawing.Size(337, 0);
            this.objectView1.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(200, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 376);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.deckView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(203, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(343, 376);
            this.panel2.TabIndex = 2;
            // 
            // deckView1
            // 
            this.deckView1.AllowDrop = true;
            this.deckView1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.deckView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.deckView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deckView1.Location = new System.Drawing.Point(0, 0);
            this.deckView1.Name = "deckView1";
            this.deckView1.NewObject = null;
            this.deckView1.Size = new System.Drawing.Size(343, 376);
            this.deckView1.TabIndex = 0;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(0, 186);
            this.splitter2.Name = "splitter2";
            this.splitter2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitter2.Size = new System.Drawing.Size(200, 190);
            this.splitter2.TabIndex = 2;
            this.splitter2.TabStop = false;
            // 
            // DeckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 376);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Name = "DeckForm";
            this.Text = "DeckForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private DeckView deckView1;
        private ObjectView objectView2;
        private ObjectView objectView1;
        private System.Windows.Forms.Splitter splitter2;
    }
}