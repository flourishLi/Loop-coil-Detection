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
    public partial class SJRControlPReName : Form
    {
        public SJRControlPReName()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.SjrControlPReName.label1.Text = textBox1.Text;
            this.Close();
        }
    }
}
