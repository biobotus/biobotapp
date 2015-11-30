using BioBotApp.Utils.Communication;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BioBotApp.Controls.Option.Options
{
    //
    // Required for Windows Form Designer support.
    //
    // Initialize the user-defined button,
    // including defining handler for Click message,
    // location and size.


    //    myButtonObject myButton = new myButtonObject();
    //    EventHandler myHandler = new EventHandler(myButton_Click);
    //    myButton.Click += myHandler;
    //    myButton.Location = new System.Drawing.Point(20, 20);
    //    myButton.Size = new System.Drawing.Size(101, 101);
    //    this.Controls.Add(myButton);
    //}



    public class myButtonObject : UserControl
    {
        // Draw the new button.
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen myPen = new Pen(Color.Black);
            // Draw the button in the form of a circle
            graphics.DrawEllipse(myPen, 0, 0, 100, 100);
            myPen.Dispose();
        }
    }

    partial class optionJoypad
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
            this.components = new System.ComponentModel.Container();
            this.Home = new System.Windows.Forms.Button();
            this.buttonYPlus = new System.Windows.Forms.Button();
            this.buttonYPlus2 = new System.Windows.Forms.Button();
            this.buttonYPlus3 = new System.Windows.Forms.Button();
            this.buttonYMinus2 = new System.Windows.Forms.Button();
            this.buttonYMinus3 = new System.Windows.Forms.Button();
            this.buttonXMinus2 = new System.Windows.Forms.Button();
            this.buttonXPlus2 = new System.Windows.Forms.Button();
            this.buttonXPlus3 = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.z3coord = new System.Windows.Forms.Label();
            this.z2coord = new System.Windows.Forms.Label();
            this.z1coord = new System.Windows.Forms.Label();
            this.ycoord = new System.Windows.Forms.Label();
            this.xcoord = new System.Windows.Forms.Label();
            this.labelZ3 = new System.Windows.Forms.Label();
            this.labelZ2 = new System.Windows.Forms.Label();
            this.labelZ1 = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.refresh = new System.Windows.Forms.Button();
            this.buttonZ1Plus2 = new System.Windows.Forms.Button();
            this.buttonZ1Minus2 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonZ2Minus2 = new System.Windows.Forms.Button();
            this.buttonZ2Plus3 = new System.Windows.Forms.Button();
            this.buttonZ2Plus2 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.buttonZ3Minus2 = new System.Windows.Forms.Button();
            this.buttonZ3Plus3 = new System.Windows.Forms.Button();
            this.buttonXPlus = new System.Windows.Forms.Button();
            this.buttonXMinus3 = new System.Windows.Forms.Button();
            this.buttonZ1Plus3 = new System.Windows.Forms.Button();
            this.edtMoveValue = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonZ3Plus2 = new System.Windows.Forms.Button();
            this.buttonZ3Minus = new System.Windows.Forms.Button();
            this.buttonZ3Minus3 = new System.Windows.Forms.Button();
            this.buttonZ3Plus = new System.Windows.Forms.Button();
            this.buttonZ2Minus = new System.Windows.Forms.Button();
            this.buttonZ2Minus3 = new System.Windows.Forms.Button();
            this.buttonZ2Plus = new System.Windows.Forms.Button();
            this.buttonZ1Minus = new System.Windows.Forms.Button();
            this.buttonZ1Minus3 = new System.Windows.Forms.Button();
            this.buttonZ1Plus = new System.Windows.Forms.Button();
            this.buttonXMinus = new System.Windows.Forms.Button();
            this.buttonYMinus = new System.Windows.Forms.Button();
            this.dsModuleStructure1 = new BioBotApp.DataSets.dsModuleStructure3();
            this.taModule1 = new BioBotApp.DataSets.dsModuleStructure3TableAdapters.taModule();
            this.bs1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnHomeZ3 = new System.Windows.Forms.Button();
            this.btnHomeZ2 = new System.Windows.Forms.Button();
            this.btnHomeZ1 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsModuleStructure1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs1)).BeginInit();
            this.SuspendLayout();
            // 
            // Home
            // 
            this.Home.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Home.Location = new System.Drawing.Point(479, 159);
            this.Home.Margin = new System.Windows.Forms.Padding(30);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(34, 29);
            this.Home.TabIndex = 0;
            this.Home.Text = "H";
            this.Home.UseVisualStyleBackColor = true;
            this.Home.Click += new System.EventHandler(this.Home_Click);
            // 
            // buttonYPlus
            // 
            this.buttonYPlus.Location = new System.Drawing.Point(537, 159);
            this.buttonYPlus.Name = "buttonYPlus";
            this.buttonYPlus.Size = new System.Drawing.Size(36, 29);
            this.buttonYPlus.TabIndex = 1;
            this.buttonYPlus.UseVisualStyleBackColor = true;
            this.buttonYPlus.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonYPlus2
            // 
            this.buttonYPlus2.Location = new System.Drawing.Point(590, 160);
            this.buttonYPlus2.Name = "buttonYPlus2";
            this.buttonYPlus2.Size = new System.Drawing.Size(36, 29);
            this.buttonYPlus2.TabIndex = 2;
            this.buttonYPlus2.UseVisualStyleBackColor = true;
            this.buttonYPlus2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonYPlus3
            // 
            this.buttonYPlus3.Location = new System.Drawing.Point(643, 160);
            this.buttonYPlus3.Name = "buttonYPlus3";
            this.buttonYPlus3.Size = new System.Drawing.Size(36, 29);
            this.buttonYPlus3.TabIndex = 3;
            this.buttonYPlus3.UseVisualStyleBackColor = true;
            this.buttonYPlus3.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonYMinus2
            // 
            this.buttonYMinus2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonYMinus2.Location = new System.Drawing.Point(358, 160);
            this.buttonYMinus2.Name = "buttonYMinus2";
            this.buttonYMinus2.Size = new System.Drawing.Size(36, 29);
            this.buttonYMinus2.TabIndex = 5;
            this.buttonYMinus2.UseVisualStyleBackColor = true;
            this.buttonYMinus2.Click += new System.EventHandler(this.button6_Click);
            // 
            // buttonYMinus3
            // 
            this.buttonYMinus3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonYMinus3.Location = new System.Drawing.Point(305, 159);
            this.buttonYMinus3.Name = "buttonYMinus3";
            this.buttonYMinus3.Size = new System.Drawing.Size(36, 29);
            this.buttonYMinus3.TabIndex = 4;
            this.buttonYMinus3.Text = "Y";
            this.buttonYMinus3.UseVisualStyleBackColor = true;
            this.buttonYMinus3.Click += new System.EventHandler(this.button7_Click);
            // 
            // buttonXMinus2
            // 
            this.buttonXMinus2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonXMinus2.Location = new System.Drawing.Point(479, 75);
            this.buttonXMinus2.Margin = new System.Windows.Forms.Padding(30);
            this.buttonXMinus2.Name = "buttonXMinus2";
            this.buttonXMinus2.Size = new System.Drawing.Size(36, 29);
            this.buttonXMinus2.TabIndex = 8;
            this.buttonXMinus2.UseVisualStyleBackColor = true;
            this.buttonXMinus2.Click += new System.EventHandler(this.button9_Click);
            // 
            // buttonXPlus2
            // 
            this.buttonXPlus2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonXPlus2.Location = new System.Drawing.Point(479, 252);
            this.buttonXPlus2.Margin = new System.Windows.Forms.Padding(30);
            this.buttonXPlus2.Name = "buttonXPlus2";
            this.buttonXPlus2.Size = new System.Drawing.Size(36, 29);
            this.buttonXPlus2.TabIndex = 11;
            this.buttonXPlus2.UseVisualStyleBackColor = true;
            this.buttonXPlus2.Click += new System.EventHandler(this.button12_Click);
            // 
            // buttonXPlus3
            // 
            this.buttonXPlus3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonXPlus3.Location = new System.Drawing.Point(479, 294);
            this.buttonXPlus3.Margin = new System.Windows.Forms.Padding(30);
            this.buttonXPlus3.Name = "buttonXPlus3";
            this.buttonXPlus3.Size = new System.Drawing.Size(36, 29);
            this.buttonXPlus3.TabIndex = 10;
            this.buttonXPlus3.UseVisualStyleBackColor = true;
            this.buttonXPlus3.Click += new System.EventHandler(this.button13_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 376);
            this.splitter1.TabIndex = 17;
            this.splitter1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.z3coord);
            this.groupBox1.Controls.Add(this.z2coord);
            this.groupBox1.Controls.Add(this.z1coord);
            this.groupBox1.Controls.Add(this.ycoord);
            this.groupBox1.Controls.Add(this.xcoord);
            this.groupBox1.Controls.Add(this.labelZ3);
            this.groupBox1.Controls.Add(this.labelZ2);
            this.groupBox1.Controls.Add(this.labelZ1);
            this.groupBox1.Controls.Add(this.labelY);
            this.groupBox1.Controls.Add(this.labelX);
            this.groupBox1.Controls.Add(this.refresh);
            this.groupBox1.Location = new System.Drawing.Point(223, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 128);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Position du Robot";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // z3coord
            // 
            this.z3coord.AutoSize = true;
            this.z3coord.Location = new System.Drawing.Point(122, 100);
            this.z3coord.Name = "z3coord";
            this.z3coord.Size = new System.Drawing.Size(0, 13);
            this.z3coord.TabIndex = 41;
            // 
            // z2coord
            // 
            this.z2coord.AutoSize = true;
            this.z2coord.Location = new System.Drawing.Point(74, 100);
            this.z2coord.Name = "z2coord";
            this.z2coord.Size = new System.Drawing.Size(0, 13);
            this.z2coord.TabIndex = 41;
            // 
            // z1coord
            // 
            this.z1coord.AutoSize = true;
            this.z1coord.Location = new System.Drawing.Point(18, 100);
            this.z1coord.Name = "z1coord";
            this.z1coord.Size = new System.Drawing.Size(0, 13);
            this.z1coord.TabIndex = 41;
            // 
            // ycoord
            // 
            this.ycoord.AutoSize = true;
            this.ycoord.Location = new System.Drawing.Point(89, 69);
            this.ycoord.Name = "ycoord";
            this.ycoord.Size = new System.Drawing.Size(0, 13);
            this.ycoord.TabIndex = 41;
            // 
            // xcoord
            // 
            this.xcoord.AutoSize = true;
            this.xcoord.Location = new System.Drawing.Point(29, 69);
            this.xcoord.Name = "xcoord";
            this.xcoord.Size = new System.Drawing.Size(0, 13);
            this.xcoord.TabIndex = 6;
            // 
            // labelZ3
            // 
            this.labelZ3.AutoSize = true;
            this.labelZ3.Location = new System.Drawing.Point(110, 100);
            this.labelZ3.Name = "labelZ3";
            this.labelZ3.Size = new System.Drawing.Size(35, 13);
            this.labelZ3.TabIndex = 5;
            this.labelZ3.Text = "Z3 :   ";
            // 
            // labelZ2
            // 
            this.labelZ2.AutoSize = true;
            this.labelZ2.Location = new System.Drawing.Point(58, 100);
            this.labelZ2.Name = "labelZ2";
            this.labelZ2.Size = new System.Drawing.Size(35, 13);
            this.labelZ2.TabIndex = 4;
            this.labelZ2.Text = "Z2 :   ";
            this.labelZ2.Click += new System.EventHandler(this.z2coord_Click);
            // 
            // labelZ1
            // 
            this.labelZ1.AutoSize = true;
            this.labelZ1.Location = new System.Drawing.Point(6, 100);
            this.labelZ1.Name = "labelZ1";
            this.labelZ1.Size = new System.Drawing.Size(35, 13);
            this.labelZ1.TabIndex = 3;
            this.labelZ1.Text = "Z1 :   ";
            this.labelZ1.Click += new System.EventHandler(this.z1coord_Click);
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(79, 69);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(29, 13);
            this.labelY.TabIndex = 2;
            this.labelY.Text = "Y :   ";
            this.labelY.Click += new System.EventHandler(this.ycoord_Click);
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(17, 69);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(29, 13);
            this.labelX.TabIndex = 1;
            this.labelX.Text = "X :   ";
            this.labelX.Click += new System.EventHandler(this.xcoord_Click);
            // 
            // refresh
            // 
            this.refresh.BackgroundImage = global::BioBotApp.Properties.Resources.refresh;
            this.refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refresh.Location = new System.Drawing.Point(61, 20);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(39, 34);
            this.refresh.TabIndex = 0;
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // buttonZ1Plus2
            // 
            this.buttonZ1Plus2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonZ1Plus2.Location = new System.Drawing.Point(18, 79);
            this.buttonZ1Plus2.Margin = new System.Windows.Forms.Padding(30);
            this.buttonZ1Plus2.Name = "buttonZ1Plus2";
            this.buttonZ1Plus2.Size = new System.Drawing.Size(28, 29);
            this.buttonZ1Plus2.TabIndex = 20;
            this.buttonZ1Plus2.UseVisualStyleBackColor = true;
            this.buttonZ1Plus2.Click += new System.EventHandler(this.button16_Click);
            // 
            // buttonZ1Minus2
            // 
            this.buttonZ1Minus2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonZ1Minus2.Location = new System.Drawing.Point(18, 243);
            this.buttonZ1Minus2.Margin = new System.Windows.Forms.Padding(30);
            this.buttonZ1Minus2.Name = "buttonZ1Minus2";
            this.buttonZ1Minus2.Size = new System.Drawing.Size(28, 29);
            this.buttonZ1Minus2.TabIndex = 23;
            this.buttonZ1Minus2.UseVisualStyleBackColor = true;
            this.buttonZ1Minus2.Click += new System.EventHandler(this.button33_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(19, 168);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Z1";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(69, 168);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Z2";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonZ2Minus2
            // 
            this.buttonZ2Minus2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonZ2Minus2.Location = new System.Drawing.Point(68, 243);
            this.buttonZ2Minus2.Margin = new System.Windows.Forms.Padding(30);
            this.buttonZ2Minus2.Name = "buttonZ2Minus2";
            this.buttonZ2Minus2.Size = new System.Drawing.Size(28, 29);
            this.buttonZ2Minus2.TabIndex = 30;
            this.buttonZ2Minus2.UseVisualStyleBackColor = true;
            this.buttonZ2Minus2.Click += new System.EventHandler(this.button36_Click);
            // 
            // buttonZ2Plus3
            // 
            this.buttonZ2Plus3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonZ2Plus3.Location = new System.Drawing.Point(68, 34);
            this.buttonZ2Plus3.Margin = new System.Windows.Forms.Padding(30);
            this.buttonZ2Plus3.Name = "buttonZ2Plus3";
            this.buttonZ2Plus3.Size = new System.Drawing.Size(28, 29);
            this.buttonZ2Plus3.TabIndex = 28;
            this.buttonZ2Plus3.UseVisualStyleBackColor = true;
            this.buttonZ2Plus3.Click += new System.EventHandler(this.button38_Click);
            // 
            // buttonZ2Plus2
            // 
            this.buttonZ2Plus2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonZ2Plus2.Location = new System.Drawing.Point(68, 79);
            this.buttonZ2Plus2.Margin = new System.Windows.Forms.Padding(30);
            this.buttonZ2Plus2.Name = "buttonZ2Plus2";
            this.buttonZ2Plus2.Size = new System.Drawing.Size(28, 29);
            this.buttonZ2Plus2.TabIndex = 27;
            this.buttonZ2Plus2.UseVisualStyleBackColor = true;
            this.buttonZ2Plus2.Click += new System.EventHandler(this.button39_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(125, 168);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "Z3";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // buttonZ3Minus2
            // 
            this.buttonZ3Minus2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonZ3Minus2.Location = new System.Drawing.Point(124, 243);
            this.buttonZ3Minus2.Margin = new System.Windows.Forms.Padding(30);
            this.buttonZ3Minus2.Name = "buttonZ3Minus2";
            this.buttonZ3Minus2.Size = new System.Drawing.Size(28, 29);
            this.buttonZ3Minus2.TabIndex = 37;
            this.buttonZ3Minus2.UseVisualStyleBackColor = true;
            this.buttonZ3Minus2.Click += new System.EventHandler(this.button42_Click);
            // 
            // buttonZ3Plus3
            // 
            this.buttonZ3Plus3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonZ3Plus3.Location = new System.Drawing.Point(124, 34);
            this.buttonZ3Plus3.Margin = new System.Windows.Forms.Padding(30);
            this.buttonZ3Plus3.Name = "buttonZ3Plus3";
            this.buttonZ3Plus3.Size = new System.Drawing.Size(28, 29);
            this.buttonZ3Plus3.TabIndex = 35;
            this.buttonZ3Plus3.UseVisualStyleBackColor = true;
            this.buttonZ3Plus3.Click += new System.EventHandler(this.button44_Click);
            // 
            // buttonXPlus
            // 
            this.buttonXPlus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonXPlus.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonXPlus.Location = new System.Drawing.Point(479, 207);
            this.buttonXPlus.Margin = new System.Windows.Forms.Padding(30);
            this.buttonXPlus.Name = "buttonXPlus";
            this.buttonXPlus.Size = new System.Drawing.Size(36, 29);
            this.buttonXPlus.TabIndex = 12;
            this.buttonXPlus.UseVisualStyleBackColor = true;
            this.buttonXPlus.Click += new System.EventHandler(this.button11_Click);
            // 
            // buttonXMinus3
            // 
            this.buttonXMinus3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonXMinus3.Location = new System.Drawing.Point(479, 30);
            this.buttonXMinus3.Margin = new System.Windows.Forms.Padding(30);
            this.buttonXMinus3.Name = "buttonXMinus3";
            this.buttonXMinus3.Size = new System.Drawing.Size(36, 29);
            this.buttonXMinus3.TabIndex = 9;
            this.buttonXMinus3.Text = "X";
            this.buttonXMinus3.UseVisualStyleBackColor = true;
            this.buttonXMinus3.Click += new System.EventHandler(this.button10_Click);
            // 
            // buttonZ1Plus3
            // 
            this.buttonZ1Plus3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonZ1Plus3.Location = new System.Drawing.Point(18, 34);
            this.buttonZ1Plus3.Margin = new System.Windows.Forms.Padding(30);
            this.buttonZ1Plus3.Name = "buttonZ1Plus3";
            this.buttonZ1Plus3.Size = new System.Drawing.Size(28, 29);
            this.buttonZ1Plus3.TabIndex = 21;
            this.buttonZ1Plus3.UseVisualStyleBackColor = true;
            this.buttonZ1Plus3.Click += new System.EventHandler(this.button15_Click);
            // 
            // edtMoveValue
            // 
            this.edtMoveValue.Location = new System.Drawing.Point(41, 29);
            this.edtMoveValue.MaxLength = 5;
            this.edtMoveValue.Name = "edtMoveValue";
            this.edtMoveValue.Size = new System.Drawing.Size(84, 20);
            this.edtMoveValue.TabIndex = 14;
            this.edtMoveValue.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            this.edtMoveValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox6_KeyPressed);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button8);
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.edtMoveValue);
            this.groupBox3.Location = new System.Drawing.Point(177, 230);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(230, 104);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Valeur de Decalement";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // button8
            // 
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.Location = new System.Drawing.Point(181, 62);
            this.button8.Margin = new System.Windows.Forms.Padding(30);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(36, 29);
            this.button8.TabIndex = 19;
            this.button8.Text = "Z3";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click_1);
            // 
            // button7
            // 
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.Location = new System.Drawing.Point(138, 62);
            this.button7.Margin = new System.Windows.Forms.Padding(30);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(36, 29);
            this.button7.TabIndex = 18;
            this.button7.Text = "Z2";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // button6
            // 
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Location = new System.Drawing.Point(93, 62);
            this.button6.Margin = new System.Windows.Forms.Padding(30);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(36, 29);
            this.button6.TabIndex = 17;
            this.button6.Text = "Z1";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // button5
            // 
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Location = new System.Drawing.Point(52, 62);
            this.button5.Margin = new System.Windows.Forms.Padding(30);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(36, 29);
            this.button5.TabIndex = 16;
            this.button5.Text = "Y";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button3
            // 
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(12, 62);
            this.button3.Margin = new System.Windows.Forms.Padding(30);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(36, 29);
            this.button3.TabIndex = 15;
            this.button3.Text = "X";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // buttonZ3Plus2
            // 
            this.buttonZ3Plus2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonZ3Plus2.Location = new System.Drawing.Point(124, 79);
            this.buttonZ3Plus2.Margin = new System.Windows.Forms.Padding(30);
            this.buttonZ3Plus2.Name = "buttonZ3Plus2";
            this.buttonZ3Plus2.Size = new System.Drawing.Size(28, 29);
            this.buttonZ3Plus2.TabIndex = 34;
            this.buttonZ3Plus2.UseVisualStyleBackColor = true;
            this.buttonZ3Plus2.Click += new System.EventHandler(this.button45_Click);
            // 
            // buttonZ3Minus
            // 
            this.buttonZ3Minus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonZ3Minus.Location = new System.Drawing.Point(124, 198);
            this.buttonZ3Minus.Margin = new System.Windows.Forms.Padding(30);
            this.buttonZ3Minus.Name = "buttonZ3Minus";
            this.buttonZ3Minus.Size = new System.Drawing.Size(28, 29);
            this.buttonZ3Minus.TabIndex = 38;
            this.buttonZ3Minus.UseVisualStyleBackColor = true;
            this.buttonZ3Minus.Click += new System.EventHandler(this.button41_Click);
            // 
            // buttonZ3Minus3
            // 
            this.buttonZ3Minus3.BackColor = System.Drawing.SystemColors.Control;
            this.buttonZ3Minus3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonZ3Minus3.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonZ3Minus3.Location = new System.Drawing.Point(124, 285);
            this.buttonZ3Minus3.Margin = new System.Windows.Forms.Padding(30);
            this.buttonZ3Minus3.Name = "buttonZ3Minus3";
            this.buttonZ3Minus3.Size = new System.Drawing.Size(28, 29);
            this.buttonZ3Minus3.TabIndex = 36;
            this.buttonZ3Minus3.UseVisualStyleBackColor = false;
            this.buttonZ3Minus3.Click += new System.EventHandler(this.button43_Click);
            // 
            // buttonZ3Plus
            // 
            this.buttonZ3Plus.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonZ3Plus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonZ3Plus.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonZ3Plus.Location = new System.Drawing.Point(124, 121);
            this.buttonZ3Plus.Margin = new System.Windows.Forms.Padding(30);
            this.buttonZ3Plus.Name = "buttonZ3Plus";
            this.buttonZ3Plus.Size = new System.Drawing.Size(28, 29);
            this.buttonZ3Plus.TabIndex = 33;
            this.buttonZ3Plus.UseVisualStyleBackColor = false;
            this.buttonZ3Plus.Click += new System.EventHandler(this.button46_Click);
            // 
            // buttonZ2Minus
            // 
            this.buttonZ2Minus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonZ2Minus.Location = new System.Drawing.Point(68, 198);
            this.buttonZ2Minus.Margin = new System.Windows.Forms.Padding(30);
            this.buttonZ2Minus.Name = "buttonZ2Minus";
            this.buttonZ2Minus.Size = new System.Drawing.Size(28, 29);
            this.buttonZ2Minus.TabIndex = 31;
            this.buttonZ2Minus.UseVisualStyleBackColor = true;
            this.buttonZ2Minus.Click += new System.EventHandler(this.button35_Click);
            // 
            // buttonZ2Minus3
            // 
            this.buttonZ2Minus3.BackColor = System.Drawing.SystemColors.Control;
            this.buttonZ2Minus3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonZ2Minus3.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonZ2Minus3.Location = new System.Drawing.Point(68, 285);
            this.buttonZ2Minus3.Margin = new System.Windows.Forms.Padding(30);
            this.buttonZ2Minus3.Name = "buttonZ2Minus3";
            this.buttonZ2Minus3.Size = new System.Drawing.Size(28, 29);
            this.buttonZ2Minus3.TabIndex = 29;
            this.buttonZ2Minus3.UseVisualStyleBackColor = false;
            this.buttonZ2Minus3.Click += new System.EventHandler(this.button37_Click);
            // 
            // buttonZ2Plus
            // 
            this.buttonZ2Plus.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonZ2Plus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonZ2Plus.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonZ2Plus.Location = new System.Drawing.Point(68, 121);
            this.buttonZ2Plus.Margin = new System.Windows.Forms.Padding(30);
            this.buttonZ2Plus.Name = "buttonZ2Plus";
            this.buttonZ2Plus.Size = new System.Drawing.Size(28, 29);
            this.buttonZ2Plus.TabIndex = 26;
            this.buttonZ2Plus.UseVisualStyleBackColor = false;
            this.buttonZ2Plus.Click += new System.EventHandler(this.button40_Click);
            // 
            // buttonZ1Minus
            // 
            this.buttonZ1Minus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonZ1Minus.Location = new System.Drawing.Point(18, 198);
            this.buttonZ1Minus.Margin = new System.Windows.Forms.Padding(30);
            this.buttonZ1Minus.Name = "buttonZ1Minus";
            this.buttonZ1Minus.Size = new System.Drawing.Size(28, 29);
            this.buttonZ1Minus.TabIndex = 24;
            this.buttonZ1Minus.UseVisualStyleBackColor = true;
            this.buttonZ1Minus.Click += new System.EventHandler(this.button32_Click);
            // 
            // buttonZ1Minus3
            // 
            this.buttonZ1Minus3.BackColor = System.Drawing.SystemColors.Control;
            this.buttonZ1Minus3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonZ1Minus3.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonZ1Minus3.Location = new System.Drawing.Point(18, 285);
            this.buttonZ1Minus3.Margin = new System.Windows.Forms.Padding(30);
            this.buttonZ1Minus3.Name = "buttonZ1Minus3";
            this.buttonZ1Minus3.Size = new System.Drawing.Size(28, 29);
            this.buttonZ1Minus3.TabIndex = 22;
            this.buttonZ1Minus3.UseVisualStyleBackColor = false;
            this.buttonZ1Minus3.Click += new System.EventHandler(this.button34_Click);
            // 
            // buttonZ1Plus
            // 
            this.buttonZ1Plus.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonZ1Plus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonZ1Plus.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonZ1Plus.Location = new System.Drawing.Point(18, 121);
            this.buttonZ1Plus.Margin = new System.Windows.Forms.Padding(30);
            this.buttonZ1Plus.Name = "buttonZ1Plus";
            this.buttonZ1Plus.Size = new System.Drawing.Size(28, 29);
            this.buttonZ1Plus.TabIndex = 19;
            this.buttonZ1Plus.UseVisualStyleBackColor = false;
            this.buttonZ1Plus.Click += new System.EventHandler(this.button17_Click);
            // 
            // buttonXMinus
            // 
            this.buttonXMinus.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonXMinus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonXMinus.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonXMinus.Location = new System.Drawing.Point(479, 117);
            this.buttonXMinus.Margin = new System.Windows.Forms.Padding(30);
            this.buttonXMinus.Name = "buttonXMinus";
            this.buttonXMinus.Size = new System.Drawing.Size(36, 29);
            this.buttonXMinus.TabIndex = 7;
            this.buttonXMinus.UseVisualStyleBackColor = false;
            this.buttonXMinus.Click += new System.EventHandler(this.button8_Click);
            // 
            // buttonYMinus
            // 
            this.buttonYMinus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonYMinus.Location = new System.Drawing.Point(411, 160);
            this.buttonYMinus.Name = "buttonYMinus";
            this.buttonYMinus.Size = new System.Drawing.Size(36, 29);
            this.buttonYMinus.TabIndex = 6;
            this.buttonYMinus.UseVisualStyleBackColor = true;
            this.buttonYMinus.Click += new System.EventHandler(this.button5_Click);
            // 
            // dsModuleStructure1
            // 
            this.dsModuleStructure1.DataSetName = "dsModuleStructure3";
            this.dsModuleStructure1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taModule1
            // 
            this.taModule1.ClearBeforeFill = true;
            // 
            // bs1
            // 
            this.bs1.DataMember = "dtModule";
            this.bs1.DataSource = this.dsModuleStructure1;
            // 
            // btnHomeZ3
            // 
            this.btnHomeZ3.Location = new System.Drawing.Point(124, 3);
            this.btnHomeZ3.Name = "btnHomeZ3";
            this.btnHomeZ3.Size = new System.Drawing.Size(28, 23);
            this.btnHomeZ3.TabIndex = 41;
            this.btnHomeZ3.Text = "H";
            this.btnHomeZ3.UseVisualStyleBackColor = true;
            this.btnHomeZ3.Click += new System.EventHandler(this.btnHomeZ3_Click);
            // 
            // btnHomeZ2
            // 
            this.btnHomeZ2.Location = new System.Drawing.Point(68, 3);
            this.btnHomeZ2.Name = "btnHomeZ2";
            this.btnHomeZ2.Size = new System.Drawing.Size(28, 23);
            this.btnHomeZ2.TabIndex = 42;
            this.btnHomeZ2.Text = "H";
            this.btnHomeZ2.UseVisualStyleBackColor = true;
            this.btnHomeZ2.Click += new System.EventHandler(this.btnHomeZ2_Click);
            // 
            // btnHomeZ1
            // 
            this.btnHomeZ1.Location = new System.Drawing.Point(18, 3);
            this.btnHomeZ1.Name = "btnHomeZ1";
            this.btnHomeZ1.Size = new System.Drawing.Size(28, 23);
            this.btnHomeZ1.TabIndex = 43;
            this.btnHomeZ1.Text = "H";
            this.btnHomeZ1.UseVisualStyleBackColor = true;
            this.btnHomeZ1.Click += new System.EventHandler(this.btnHomeZ1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(479, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 23);
            this.button1.TabIndex = 44;
            this.button1.Text = "H";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(269, 162);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(28, 23);
            this.button2.TabIndex = 45;
            this.button2.Text = "H";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // optionJoypad
            // 
            this.AccessibleName = "";
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(716, 351);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnHomeZ1);
            this.Controls.Add(this.btnHomeZ2);
            this.Controls.Add(this.btnHomeZ3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.buttonZ3Minus);
            this.Controls.Add(this.buttonZ3Minus2);
            this.Controls.Add(this.buttonZ3Minus3);
            this.Controls.Add(this.buttonZ3Plus3);
            this.Controls.Add(this.buttonZ3Plus2);
            this.Controls.Add(this.buttonZ3Plus);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.buttonZ2Minus);
            this.Controls.Add(this.buttonZ2Minus2);
            this.Controls.Add(this.buttonZ2Minus3);
            this.Controls.Add(this.buttonZ2Plus3);
            this.Controls.Add(this.buttonZ2Plus2);
            this.Controls.Add(this.buttonZ2Plus);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.buttonZ1Minus);
            this.Controls.Add(this.buttonZ1Minus2);
            this.Controls.Add(this.buttonZ1Minus3);
            this.Controls.Add(this.buttonZ1Plus3);
            this.Controls.Add(this.buttonZ1Plus2);
            this.Controls.Add(this.buttonZ1Plus);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.buttonXPlus);
            this.Controls.Add(this.buttonXPlus2);
            this.Controls.Add(this.buttonXPlus3);
            this.Controls.Add(this.buttonXMinus3);
            this.Controls.Add(this.buttonXMinus2);
            this.Controls.Add(this.buttonXMinus);
            this.Controls.Add(this.buttonYMinus);
            this.Controls.Add(this.buttonYMinus2);
            this.Controls.Add(this.buttonYMinus3);
            this.Controls.Add(this.buttonYPlus3);
            this.Controls.Add(this.buttonYPlus2);
            this.Controls.Add(this.buttonYPlus);
            this.Controls.Add(this.Home);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Name = "optionJoypad";
            this.Size = new System.Drawing.Size(764, 376);
            this.Tag = "Joypad";
            this.Load += new System.EventHandler(this.optionJoypad_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsModuleStructure1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Home_Click(object sender, EventArgs e)
        {
            ComChannelFactory.getGCodeSerial().WriteLine("H\n");
        }

        #endregion
        private System.Windows.Forms.Button button4;
        private Button Home;
        private Button buttonYPlus;
        private Button buttonYPlus2;
        private Button buttonYPlus3;
        private Button buttonYMinus;
        private Button buttonYMinus2;
        private Button buttonYMinus3;
        private Button buttonXMinus;
        private Button buttonXMinus2;
        private Button buttonXPlus2;
        private Button buttonXPlus3;
        private Splitter splitter1;
        private GroupBox groupBox1;
        private Label labelZ3;
        private Label labelZ2;
        private Label labelZ1;
        private Label labelY;
        private Label labelX;
        private Button refresh;
        private Button buttonZ1Plus2;
        private Button buttonZ1Plus;
        private Button buttonZ1Minus;
        private Button buttonZ1Minus2;
        private Button buttonZ1Minus3;
        private Label label11;
        private Label label12;
        private Button buttonZ2Minus;
        private Button buttonZ2Minus2;
        private Button buttonZ2Minus3;
        private Button buttonZ2Plus3;
        private Button buttonZ2Plus2;
        private Button buttonZ2Plus;
        private Label label13;
        private Button buttonZ3Minus;
        private Button buttonZ3Minus2;
        private Button buttonZ3Minus3;
        private Button buttonZ3Plus3;
        private Button buttonZ3Plus;
        private Button buttonXPlus;
        private Button buttonXMinus3;
        private Button buttonZ1Plus3;
        private TextBox edtMoveValue;
        private GroupBox groupBox3;
        private Button buttonZ3Plus2;
        private Label z3coord;
        public Double newCoord;

        public double GetValue(string x)
        {
            switch (x)
            {
                case "x":
                    newCoord = Int32.Parse(xcoord.Text);
                    break;
                case "y":
                    newCoord = Int32.Parse(ycoord.Text);
                    break;
                case "z1":
                    newCoord = Int32.Parse(z1coord.Text);
                    break;
                case "z2":
                    newCoord = Int32.Parse(z2coord.Text);
                    break;
                case "z3":
                    newCoord = Int32.Parse(z3coord.Text);
                    break;
            }
            return newCoord;
        }

        private Label z2coord;
        private Label z1coord;
        private Label ycoord;
        private Label xcoord;
        private DataSets.dsModuleStructure3 dsModuleStructure1;
        private BindingSource bs1;
        private DataSets.dsModuleStructure3TableAdapters.taModule taModule1;
        private Button btnHomeZ3;
        private Button btnHomeZ2;
        private Button btnHomeZ1;
        private Button button1;
        private Button button2;
        private Button button6;
        private Button button5;
        private Button button3;
        private Button button8;
        private Button button7;
    }
}
