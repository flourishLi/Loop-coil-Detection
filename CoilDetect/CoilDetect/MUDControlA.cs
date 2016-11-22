using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CoilDetect
{
    public partial class MUDControlA : UserControl
    {
        #region 变量声明
        MUDControlC mUDControlC;
        Form1 fm;
        int runTime;//在运行周期内计时器运行的次数,多处调用设为全局变量
        int runNum;//计时器运行计数器，当其值达到runTime时，计时器停止，设为全局变量
        int carCount;//交通量
        double timeHeadWay;//车头时距
        double speed;//车速
        double timeTotal;//车辆时间占有总和
        double lastTime;

        bool inFlag;//车辆第一次进入线圈的标志
        bool moduleflag;//测速模块可用标志

        private bool mouseDownState; //控件移动标志
        private Point startPosition; //控件初始位置
        
        DataGridViewTextBoxColumn time = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn carTraffic = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn carSpeed = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn carDistance = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn timePercent = new DataGridViewTextBoxColumn();

        public  bool Moduleflag
        {
            get { return moduleflag; }
            set { moduleflag = value; }
        }

        public Label Label_SpeedEnd //测速模块
        {
            get { return label_SpeedEnd; }
        }

       #endregion
    
        public MUDControlA(Form1 fm)
        {
            this.fm = fm;
            InitializeComponent();
            mouseDownState = false;
            Moduleflag = false;
            inFlag = false;
            startPosition = new Point();
            button1.Enabled = false;
            time.HeaderText = "时间";
            carTraffic.HeaderText = "交通量";
            time.Width = 60;
            carTraffic.Width = 70;
            carSpeed.HeaderText = "车速(m/s)";
            carSpeed.Width = 70;
            carDistance.HeaderText = "车头时距(S)";
            carDistance.Width = 80;
            timePercent.HeaderText = "时间占有率()";
            timePercent.Width = 80;
        }

        #region 窗体移动
        private void UserControlA_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseDownState = true;
            this.startPosition = e.Location;
            this.BackColor =Form1.MUDAControlColor1 ;
        }

        private void UserControlA_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mouseDownState && Form1.MudControlAMS)
            {

                int minX = this.Parent.Location.X;
                int maxX = this.Parent.Location.X + this.Parent.Width - 290;
                int maxY = this.Parent.Location.Y + this.Parent.Height - 300;
                this.Location = new Point(Math.Max(minX, (Math.Min(this.Location.X + e.X - this.startPosition.X, maxX))),
                     Math.Min(Math.Max(this.Location.Y + e.Y - this.startPosition.Y, fm.toolStrip1.Location.Y + 75), maxY));

                this.BackColor = Color.Goldenrod;
            }
        }

        private void UserControlA_MouseUp(object sender, MouseEventArgs e)
        {
            this.mouseDownState = false;
            this.BackColor = Form1.MUDAControlColor1;
        }
        #endregion

        #region 用户选择交通物理量
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            switch (index)
            {
                case 0:
                    dataGridView2.Columns.Clear();
                    dataGridView2.Columns.Add(time);
                    dataGridView2.Columns.Add(carTraffic);
                    break;
                case 1:
                    dataGridView2.Columns.Clear();
                    dataGridView2.Columns.Add(time);
                    dataGridView2.Columns.Add(carSpeed);
                    break;
                case 2:
                    dataGridView2.Columns.Clear();
                    dataGridView2.Columns.Add(time);
                    dataGridView2.Columns.Add(carDistance);
                    break;
                case 3:
                    dataGridView2.Columns.Clear();
                    dataGridView2.Columns.Add(time);
                    dataGridView2.Columns.Add(timePercent);
                    break;
            }

        }
        #endregion

        #region 启动测试
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                comboBox1.Enabled = false;
                label1.Enabled = false;
                mUDControlC = Form1.MudControlC;
                lastTime = Double.Parse(textBox1.Text) * 60 * 1000;//用户设定的运行周期，把时间从分钟换算成毫秒
                runTime =(int) lastTime / 10;                                  //在运行周期内计时器运行的次数

                mUDControlC.TimerMsgRevieced += TimerShow;                                    
                timer1.Start();
                 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
 
        private void timer1_Tick(object sender, EventArgs e)
        {
            runNum++;
            if (runNum>runTime)
            {
                int carCountPH;   
                int index = comboBox1.SelectedIndex;                      //用户选定的数据分析变量
                switch (index)
                {
                    case 0://交通量
                        carCountPH = (int)(60 / Double.Parse(textBox1.Text) * carCount);
                        dataGridView2.Rows[0].Cells[0].Value = DateTime.Now.ToString("hh:mm:ss");
                        dataGridView2.Rows[0].Cells[1].Value = carCountPH;
                        break;
                    case 1://车速
                        dataGridView2.Rows[0].Cells[0].Value = DateTime.Now.ToString("hh:mm:ss");
                        dataGridView2.Rows[0].Cells[1].Value = Math.Round(speed / carCount,2);
                        break;
                    case 2://车头时距
                        timeHeadWay = Double.Parse(textBox1.Text)*60 / carCount;  //车头时距
                        dataGridView2.Rows[0].Cells[0].Value = DateTime.Now.ToString("hh:mm:ss");
                        dataGridView2.Rows[0].Cells[1].Value = timeHeadWay;
                        break;
                    case 3://时间占有率
                        dataGridView2.Rows[0].Cells[0].Value = DateTime.Now.ToString("hh:mm:ss");
                        dataGridView2.Rows[0].Cells[1].Value =(Math.Round(timeTotal / lastTime,3)*100).ToString()+"%";
                        break;
                }
                runNum = 0;
                runTime = 0;
                speed = 0;
                timeTotal = 0;
                carCount = 0;
                timer1.Stop();
                comboBox1.Enabled = true;
                label1.Enabled = true;
                button1.Enabled = true;
            }
        }
        #endregion

        #region 数据接收
        //传给实时测速的数据
        public void Show(object sender, MUDControlCData data)
        {
            this.Invoke(new Action(() =>
            {
                int i;
                //输出速度
                if (MUDControlC.CoilCheckState == false&& Moduleflag==true)
                {
                    if (data.Speed != 0)
                    {
                        i = dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = DateTime.Now.ToString("hh:mm:ss");
                        dataGridView1.Rows[i].Cells[1].Value = data.Speed;
                    }
                }
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
            }));
         }
        //传给Timer的数据用于分析用户选择的物理量
        public void TimerShow(object sender, MUDControlCData data)
        {
            this.Invoke(new Action(() =>
            {
                //线圈检测状态和测速通讯线连接状态同时满足
                if (MUDControlC.CoilCheckState == false && Moduleflag == true)
                {
                    //在用户设定的周期内
                    if (runNum < runTime)
                    {
                        button1.Enabled = false;
                        if (data.D == 1 && inFlag == false)
                        {
                            //测交通量
                            carCount++;   
                            inFlag = true; 
                        }
                        if (data.D == 0)
                        {
                            inFlag = false;//还原车辆第一次进入线圈的标志,以便再次计数
                        }
                        //测车速                   
                        speed += data.Speed;
                        //测时间
                        timeTotal += data.Time; 
                    }
                }
            }));
        }
        #endregion

    }
}
