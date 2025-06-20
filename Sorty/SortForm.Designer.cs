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
            this.SuspendLayout();
            // 
            // buttonSort
            // 
            this.buttonSort.Location = new System.Drawing.Point(12, 12);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(75, 23);
            this.buttonSort.TabIndex = 0;
            this.buttonSort.Text = "Sort";
            this.buttonSort.UseVisualStyleBackColor = true;
            // 
            // comboBoxSort
            // 
            this.comboBoxSort.FormattingEnabled = true;
            this.comboBoxSort.Location = new System.Drawing.Point(93, 14);
            this.comboBoxSort.Name = "comboBoxSort";
            this.comboBoxSort.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSort.TabIndex = 1;
            // 
            // buttonShuffle
            // 
            this.buttonShuffle.Location = new System.Drawing.Point(12, 41);
            this.buttonShuffle.Name = "buttonShuffle";
            this.buttonShuffle.Size = new System.Drawing.Size(75, 23);
            this.buttonShuffle.TabIndex = 2;
            this.buttonShuffle.Text = "Shuffle";
            this.buttonShuffle.UseVisualStyleBackColor = true;
            this.buttonShuffle.Click += new System.EventHandler(this.buttonShuffle_Click);
            // 
            // buttonArray
            // 
            this.buttonArray.Location = new System.Drawing.Point(12, 70);
            this.buttonArray.Name = "buttonArray";
            this.buttonArray.Size = new System.Drawing.Size(75, 23);
            this.buttonArray.TabIndex = 5;
            this.buttonArray.Text = "Array Count";
            this.buttonArray.UseVisualStyleBackColor = true;
            this.buttonArray.Click += new System.EventHandler(this.buttonArray_Click);
            // 
            // SortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 100);
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

        }

        #endregion

        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.ComboBox comboBoxSort;
        private System.Windows.Forms.Button buttonShuffle;
        private System.Windows.Forms.Button buttonArray;
    }
}

