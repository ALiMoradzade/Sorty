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
            this.buttonSort = new System.Windows.Forms.Button();
            this.comboBoxSort = new System.Windows.Forms.ComboBox();
            this.buttonShuffle = new System.Windows.Forms.Button();
            this.buttonArray = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGenerateNumbers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSort
            // 
            this.buttonSort.Location = new System.Drawing.Point(255, 19);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(75, 23);
            this.buttonSort.TabIndex = 0;
            this.buttonSort.Text = "Sort";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // comboBoxSort
            // 
            this.comboBoxSort.FormattingEnabled = true;
            this.comboBoxSort.Items.AddRange(new object[] {
            "Bead Sort",
            "Bubble Sort",
            "Cocktail Sort",
            "Cycle Sort",
            "Gnome Sort",
            "Heap Sort",
            "Insertion Sort",
            "Merge Sort",
            "Odd Even Sort",
            "Quick Sort",
            "Radix Sort",
            "Selection Sort",
            "Shell Sort"});
            this.comboBoxSort.Location = new System.Drawing.Point(336, 21);
            this.comboBoxSort.Name = "comboBoxSort";
            this.comboBoxSort.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSort.TabIndex = 1;
            // 
            // buttonShuffle
            // 
            this.buttonShuffle.Location = new System.Drawing.Point(174, 19);
            this.buttonShuffle.Name = "buttonShuffle";
            this.buttonShuffle.Size = new System.Drawing.Size(75, 23);
            this.buttonShuffle.TabIndex = 2;
            this.buttonShuffle.Text = "Shuffle";
            this.buttonShuffle.UseVisualStyleBackColor = true;
            this.buttonShuffle.Click += new System.EventHandler(this.buttonShuffle_Click);
            // 
            // buttonArray
            // 
            this.buttonArray.Location = new System.Drawing.Point(93, 19);
            this.buttonArray.Name = "buttonArray";
            this.buttonArray.Size = new System.Drawing.Size(75, 23);
            this.buttonArray.TabIndex = 5;
            this.buttonArray.Text = "Array Count";
            this.buttonArray.UseVisualStyleBackColor = true;
            this.buttonArray.Click += new System.EventHandler(this.buttonArray_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(463, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // buttonGenerateNumbers
            // 
            this.buttonGenerateNumbers.Location = new System.Drawing.Point(12, 12);
            this.buttonGenerateNumbers.Name = "buttonGenerateNumbers";
            this.buttonGenerateNumbers.Size = new System.Drawing.Size(75, 37);
            this.buttonGenerateNumbers.TabIndex = 7;
            this.buttonGenerateNumbers.Text = "Generate Numbers";
            this.buttonGenerateNumbers.UseVisualStyleBackColor = true;
            this.buttonGenerateNumbers.Click += new System.EventHandler(this.buttonGenerateNumbers_Click);
            // 
            // SortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 68);
            this.Controls.Add(this.buttonGenerateNumbers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonArray);
            this.Controls.Add(this.buttonShuffle);
            this.Controls.Add(this.comboBoxSort);
            this.Controls.Add(this.buttonSort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SortForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sorty";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SortForm_FormClosing);
            this.Load += new System.EventHandler(this.SortForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.ComboBox comboBoxSort;
        private System.Windows.Forms.Button buttonShuffle;
        private System.Windows.Forms.Button buttonArray;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGenerateNumbers;
    }
}

