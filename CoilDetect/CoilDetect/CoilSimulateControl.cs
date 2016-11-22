using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CoilDetect
{
    public partial class CoilSimulateControl : UserControl
    {
        Form1 fm;

        public Label Lab
        {
            get { return coilLable; }
        }

        public CoilSimulateControl(Form1 fm)
        {
            this.fm = fm;
            InitializeComponent();
        }

        private bool mouseDownState; //控件移动标志
        private Point startPosition; //控件初始位置

        private void CoilSimulateControl_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.AntiqueWhite;
        }

        private void CoilSimulateControl_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseDownState = true;
            this.startPosition = e.Location;
        }

        private void CoilSimulateControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mouseDownState)
            {
                int minX = this.Parent.Location.X;
                int maxX = this.Parent.Location.X + this.Parent.Width-100;
                int maxY = this.Parent.Location.Y + this.Parent.Height - 160;
                this.Location = new Point(Math.Max(minX, (Math.Min(this.Location.X + e.X - this.startPosition.X, maxX))),
                     Math.Min(Math.Max(this.Location.Y + e.Y - this.startPosition.Y, fm.toolStrip1.Location.Y + 75), maxY));
          
            }
        }

        private void CoilSimulateControl_MouseUp(object sender, MouseEventArgs e)
        {
            this.mouseDownState = false;
        }

        private void coilLable_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(coilLable, "线圈检测端口起点");
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }


    }
}
