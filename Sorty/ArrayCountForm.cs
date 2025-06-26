using System;
using System.Windows.Forms;

namespace Sorty
{
    public partial class ArrayCountForm : Form
    {
        public bool isOkPressed = false;
        public ArrayCountForm(int arrayCount)
        {
            InitializeComponent();
            numericUpDown1.Value = arrayCount;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            isOkPressed = true;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
