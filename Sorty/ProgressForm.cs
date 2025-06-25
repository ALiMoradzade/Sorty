using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Sorty
{
    public partial class ProgressForm : Form
    {
        private string formText = "Processing";
        private int n = 1;
        private List<Task> tasks;
        public ProgressForm(List<Task> tasks)
        {
            InitializeComponent();
            this.tasks = tasks;
        }

        private async void ProgressForm_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = SystemIcons.Information.ToBitmap();
            await Task.WhenAll(tasks);
            timer1.Stop();
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Text = formText + new string('.', n++ % 4);
        }
    }
}
