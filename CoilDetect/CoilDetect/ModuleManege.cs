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
    public partial class ModuleManege : Form
    {
        Form1 fm;
        public ModuleManege(  Form1 fm1)
        {
            InitializeComponent();
            for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
            {
                this.checkedListBox1.SetItemChecked(i, true);
            }
            this.fm = fm1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.GetItemChecked(0))
            {
                fm.mUDToolStripMenuItem.Enabled = true;
                fm.toolStripSplitButton1.Enabled = true;
            }
            else
            {
                fm.mUDToolStripMenuItem.Enabled = false;
                fm.toolStripSplitButton1.Enabled = false;
            }
            if (checkedListBox1.GetItemChecked(1))
            {
                fm.sJRToolStripMenuItem.Enabled = true;
                fm.toolStripSplitButton2.Enabled = true;
            }
            else
            {
                fm.sJRToolStripMenuItem.Enabled = false;
                fm.toolStripSplitButton2.Enabled = false;
            }
            this.Close();
        }
    }
}
