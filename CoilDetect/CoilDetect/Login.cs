using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CoilDetect
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //加密用户名
            string strUserName = encrypt(textBox1.Text);
             // 加密密码  
            string strPwd = encrypt(textBox2.Text);
            if (strUserName == "76fd89e04e171b787dc480ea274ec2" && strPwd == "76fd89e04e171b787dc480ea274ec2")
            {
                Form1.mm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("用户名或密码错误");
                textBox1.Text = "";
                textBox2.Text = "";
            }
            
        }

        public string encrypt(string strPwd)
        {
            String str = "";

            // 初始化MD5对象  
            MD5 md5 = new MD5CryptoServiceProvider();
            // 将字符编码为一个字节数组  
            byte[] data = Encoding.Default.GetBytes(strPwd);
            // 计算data字节数组的哈希值  
            byte[] md5Data = md5.ComputeHash(data);
            // 清空md5  
            md5.Clear();
            // 遍历md5Data哈希数组  
            for (int i = 0; i < md5Data.Length - 1; i++)
            {
                str += md5Data[i].ToString("x").PadLeft(2, '0');
            }

            return str;
        }  


    }
}
