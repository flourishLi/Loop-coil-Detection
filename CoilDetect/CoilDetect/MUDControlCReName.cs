using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CoilDetect
{
    public partial class MUDControlCReName : Form
    {
        public MUDControlCReName()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.MudControlCReName.label2.Text = textBox1.Text;
            this.Close();
        }
    }
}
