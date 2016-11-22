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
    public partial class Skin : Form
    {
        Form1 fm;
        public Skin( Form1 fm1)
        {
            InitializeComponent();
            fm = fm1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fm.skinEngine1.Active = true;
            fm.menuStrip1.BackgroundImage = null;
            fm.toolStrip1.BackgroundImage = null;
            fm.BackgroundImage = null;
            if (radioButton1.Checked == true)
                fm.skinEngine1.SkinFile = System.Windows.Forms.Application.StartupPath + "\\Skins\\Calmness.ssk";
            if (radioButton2.Checked == true)
                fm.skinEngine1.SkinFile = System.Windows.Forms.Application.StartupPath + "\\Skins\\Eighteen.ssk";
            if (radioButton3.Checked == true)
                fm.skinEngine1.SkinFile = System.Windows.Forms.Application.StartupPath + "\\Skins\\XPOrange.ssk";
            if (radioButton4.Checked == true)
                fm.skinEngine1.SkinFile = System.Windows.Forms.Application.StartupPath + "\\Skins\\Warm.ssk";
            if (radioButton5.Checked == true)
                fm.skinEngine1.SkinFile = System.Windows.Forms.Application.StartupPath + "\\Skins\\vista1.ssk";
            this.Close();
        }
    }
}
