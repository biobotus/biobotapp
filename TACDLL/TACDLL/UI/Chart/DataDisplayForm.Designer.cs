namespace TACDLL.Chart
{
    partial class DataDisplayForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.setIntervalBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.sampleIntervalMTxt = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.activateBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.resultChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.sampleGV = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.resetDataBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleGV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.resetDataBtn);
            this.panel1.Controls.Add(this.setIntervalBtn);
            this.panel1.Controls.Add(this.saveBtn);
            this.panel1.Controls.Add(this.sampleIntervalMTxt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.activateBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 459);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 36);
            this.panel1.TabIndex = 1;
            // 
            // setIntervalBtn
            // 
            this.setIntervalBtn.Location = new System.Drawing.Point(238, 6);
            this.setIntervalBtn.Name = "setIntervalBtn";
            this.setIntervalBtn.Size = new System.Drawing.Size(75, 23);
            this.setIntervalBtn.TabIndex = 4;
            this.setIntervalBtn.Text = "Set interval";
            this.setIntervalBtn.UseVisualStyleBackColor = true;
            this.setIntervalBtn.Click += new System.EventHandler(this.setIntervalBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(603, 6);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "Save data";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // sampleIntervalMTxt
            // 
            this.sampleIntervalMTxt.Location = new System.Drawing.Point(187, 8);
            this.sampleIntervalMTxt.Mask = "00:00";
            this.sampleIntervalMTxt.Name = "sampleIntervalMTxt";
            this.sampleIntervalMTxt.Size = new System.Drawing.Size(45, 20);
            this.sampleIntervalMTxt.TabIndex = 2;
            this.sampleIntervalMTxt.Text = "0001";
            this.sampleIntervalMTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sample interval";
            // 
            // activateBtn
            // 
            this.activateBtn.Location = new System.Drawing.Point(3, 6);
            this.activateBtn.Name = "activateBtn";
            this.activateBtn.Size = new System.Drawing.Size(75, 23);
            this.activateBtn.TabIndex = 0;
            this.activateBtn.Text = "Start";
            this.activateBtn.UseVisualStyleBackColor = true;
            this.activateBtn.Click += new System.EventHandler(this.activateBtn_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.95652F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.04348F));
            this.tableLayoutPanel1.Controls.Add(this.resultChart, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.sampleGV, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(690, 459);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // resultChart
            // 
            chartArea3.AxisX.Title = "time";
            chartArea3.AxisY.Title = "temperature";
            chartArea3.Name = "temperatureCA";
            chartArea4.AxisX.Title = "time";
            chartArea4.AxisY.Title = "Optical density";
            chartArea4.Name = "opticalDensityCA";
            this.resultChart.ChartAreas.Add(chartArea3);
            this.resultChart.ChartAreas.Add(chartArea4);
            this.resultChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.Name = "Legend1";
            this.resultChart.Legends.Add(legend2);
            this.resultChart.Location = new System.Drawing.Point(3, 3);
            this.resultChart.Name = "resultChart";
            series3.ChartArea = "temperatureCA";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "temperature";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series4.ChartArea = "opticalDensityCA";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "opticalDensity";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            this.resultChart.Series.Add(series3);
            this.resultChart.Series.Add(series4);
            this.resultChart.Size = new System.Drawing.Size(455, 453);
            this.resultChart.TabIndex = 2;
            this.resultChart.Text = "chart1";
            // 
            // sampleGV
            // 
            this.sampleGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sampleGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.sampleGV.DefaultCellStyle = dataGridViewCellStyle2;
            this.sampleGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sampleGV.Location = new System.Drawing.Point(464, 3);
            this.sampleGV.Name = "sampleGV";
            this.sampleGV.RowHeadersVisible = false;
            this.sampleGV.Size = new System.Drawing.Size(223, 453);
            this.sampleGV.TabIndex = 1;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Csv file(*.csv)|*.csv|All Files (*.*)|*.*";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // resetDataBtn
            // 
            this.resetDataBtn.Location = new System.Drawing.Point(522, 6);
            this.resetDataBtn.Name = "resetDataBtn";
            this.resetDataBtn.Size = new System.Drawing.Size(75, 23);
            this.resetDataBtn.TabIndex = 5;
            this.resetDataBtn.Text = "Reset Data";
            this.resetDataBtn.UseVisualStyleBackColor = true;
            this.resetDataBtn.Click += new System.EventHandler(this.resetDataBtn_Click);
            // 
            // DataDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 495);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "DataDisplayForm";
            this.Text = "DataDisplayForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button activateBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView sampleGV;
        private System.Windows.Forms.DataVisualization.Charting.Chart resultChart;
        private System.Windows.Forms.MaskedTextBox sampleIntervalMTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button setIntervalBtn;
        private System.Windows.Forms.Button resetDataBtn;
    }
}