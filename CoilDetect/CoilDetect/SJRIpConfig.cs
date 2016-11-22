using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoilDetect
{
    public partial class SJRIpConfig : Form
    {
        static IPEndPoint serverEp;//传递到主窗体
        public static IPEndPoint ServerEp
        {
            get { return serverEp; }
            set { serverEp = value; }
        }   
        public SJRIpConfig()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                serverEp = new IPEndPoint(IPAddress.Parse(comboBox1.SelectedItem.ToString()), Int32.Parse(comboBox2.SelectedItem.ToString()));
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
