using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sorty
{
    public partial class SortForm : Form
    {
        private int[] array = new int[100];

        public SortForm()
        {
            InitializeComponent();
        }
  
        private void SetArray(int count = 100)
        {
            array = new int[count];
            Random r = new Random();
            for (int i = 0; i < count; i++)
            {
                array[i] = r.Next();
            }
        }

        private void buttonArray_Click(object sender, EventArgs e)
        {
            using (ArrayCountForm f = new ArrayCountForm(array.Length))
            {
                f.ShowDialog();
                if (f.isOkPressed)
                {
                    SetArray((int)f.numericUpDown1.Value);
                }
            }
        }
    }
}
