namespace Sorty
{
    partial class SortForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SortForm));
            this.buttonSort = new System.Windows.Forms.Button();
            this.buttonShuffle = new System.Windows.Forms.Button();
            this.buttonArray = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelArrayLength = new System.Windows.Forms.Label();
            this.labelIsArraySorted = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSort
            // 
            this.buttonSort.Location = new System.Drawing.Point(174, 636);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(75, 23);
            this.buttonSort.TabIndex = 0;
            this.buttonSort.Text = "Sort";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // buttonShuffle
            // 
            this.buttonShuffle.Location = new System.Drawing.Point(93, 636);
            this.buttonShuffle.Name = "buttonShuffle";
            this.buttonShuffle.Size = new System.Drawing.Size(75, 23);
            this.buttonShuffle.TabIndex = 2;
            this.buttonShuffle.Text = "Shuffle";
            this.buttonShuffle.UseVisualStyleBackColor = true;
            this.buttonShuffle.Click += new System.EventHandler(this.buttonShuffle_Click);
            // 
            // buttonArray
            // 
            this.buttonArray.Location = new System.Drawing.Point(12, 636);
            this.buttonArray.Name = "buttonArray";
            this.buttonArray.Size = new System.Drawing.Size(75, 23);
            this.buttonArray.TabIndex = 5;
            this.buttonArray.Text = "Array Count";
            this.buttonArray.UseVisualStyleBackColor = true;
            this.buttonArray.Click += new System.EventHandler(this.buttonArray_Click);
            // 
            // chart1
            // 
            chartArea1.AxisX.Interval = 1D;
            chartArea1.Name = "ChartAreaDuration";
            chartArea2.AxisX.Interval = 1D;
            chartArea2.Name = "ChartAreaOperation";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartAreaDuration";
            series1.IsValueShownAsLabel = true;
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Duration (ms)";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.ChartArea = "ChartAreaOperation";
            series2.IsValueShownAsLabel = true;
            series2.IsXValueIndexed = true;
            series2.Legend = "Legend1";
            series2.Name = "Compare Count";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series3.ChartArea = "ChartAreaOperation";
            series3.IsValueShownAsLabel = true;
            series3.IsXValueIndexed = true;
            series3.Legend = "Legend1";
            series3.Name = "Swap Count";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series4.ChartArea = "ChartAreaOperation";
            series4.IsValueShownAsLabel = true;
            series4.IsXValueIndexed = true;
            series4.Legend = "Legend1";
            series4.Name = "Set Count";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(675, 630);
            this.chart1.TabIndex = 8;
            this.chart1.Text = "chart1";
            title1.Name = "Sorting Algorithms";
            this.chart1.Titles.Add(title1);
            // 
            // labelArrayLength
            // 
            this.labelArrayLength.AutoSize = true;
            this.labelArrayLength.BackColor = System.Drawing.Color.White;
            this.labelArrayLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelArrayLength.Location = new System.Drawing.Point(12, 9);
            this.labelArrayLength.Name = "labelArrayLength";
            this.labelArrayLength.Size = new System.Drawing.Size(101, 18);
            this.labelArrayLength.TabIndex = 9;
            this.labelArrayLength.Text = "Array length: 1";
            // 
            // labelIsArraySorted
            // 
            this.labelIsArraySorted.AutoSize = true;
            this.labelIsArraySorted.BackColor = System.Drawing.Color.White;
            this.labelIsArraySorted.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIsArraySorted.ForeColor = System.Drawing.Color.Black;
            this.labelIsArraySorted.Location = new System.Drawing.Point(12, 27);
            this.labelIsArraySorted.Name = "labelIsArraySorted";
            this.labelIsArraySorted.Size = new System.Drawing.Size(141, 18);
            this.labelIsArraySorted.TabIndex = 10;
            this.labelIsArraySorted.Text = "Is array sorted: false";
            // 
            // SortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 671);
            this.Controls.Add(this.labelIsArraySorted);
            this.Controls.Add(this.labelArrayLength);
            this.Controls.Add(this.buttonArray);
            this.Controls.Add(this.buttonShuffle);
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.chart1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SortForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sorty";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SortForm_FormClosing);
            this.Load += new System.EventHandler(this.SortForm_Load);
            this.SizeChanged += new System.EventHandler(this.SortForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.Button buttonShuffle;
        private System.Windows.Forms.Button buttonArray;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label labelArrayLength;
        private System.Windows.Forms.Label labelIsArraySorted;
    }
}

