using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CoilDetect
{
    public partial class CoilDetectSimControl : UserControl
    {
        Form1 fm;
        public CoilDetectSimControl(Form1 fm)
        {
            this.fm = fm;
            InitializeComponent();
            this.BackColor = Color.AntiqueWhite;
        }
        private bool mouseDownState; //控件移动标志
        private Point startPosition; //控件初始位置

        [DllImport("user32", EntryPoint = "HideCaret")]//消除光标
        public static extern bool HideCaret(IntPtr hWnd);
        //消除光标影响
        private void freTransfer_textBox_MouseDown(object sender, MouseEventArgs e)
        {
            HideCaret((sender as TextBox).Handle);
            Refresh();
        }

        public Label[] Lab
        {
            get
            {
                return new[] { coilDe_Lable1, coilDe_lable2 }; 
            }
        }

        public TextBox Box
        {
            get { return coilDe_textBox1; }
        }

        private void CoilDetectSimControl_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseDownState = true;
            this.startPosition = e.Location;
        }

        private void CoilDetectSimControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mouseDownState)
            {
                int minX = this.Parent.Location.X;
                int maxX = this.Parent.Location.X + this.Parent.Width - 100;
                int maxY = this.Parent.Location.Y + this.Parent.Height - 160;
                this.Location = new Point(Math.Max(minX, (Math.Min(this.Location.X + e.X - this.startPosition.X, maxX))),
                     Math.Min(Math.Max(this.Location.Y + e.Y - this.startPosition.Y, fm.toolStrip1.Location.Y + 75), maxY));
       
            }
        }

        private void CoilDetectSimControl_MouseUp(object sender, MouseEventArgs e)
        {
            this.mouseDownState = false;
        }

        private void coilDe_textBox1_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(coilDe_textBox1, "串口服务器端口起点");
        }

        private void coilDe_Lable1_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(coilDe_Lable1, "线圈检测器端口一号终端");
        }

        private void coilDe_lable2_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(coilDe_lable2, "线圈检测器端口二号终端");
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

    }
}
