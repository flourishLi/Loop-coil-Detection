using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Runtime.InteropServices;

namespace CoilDetect
{
    public partial class MUDControlC : UserControl
    {
        
        #region 变量声明
        Form1 fm;
        bool mouseDownState; //移动标志
        Point startPosition; //控件初始位置
        Socket client;
        // IPAddress ip = IPAddress.Parse("192.168.32.21");//服务器IP
        // private int port = 10002;//端口
        Thread th = null;
        byte[] msg = { 0xff, 0xfe, 00, 02, 01, 00, 00, 00, 00, 00, 00, 03 };//数据发送指令

        bool connectState;//服务器连接状态
        static bool coilCheckState;//线圈检测状态
        bool frequencyState;//频率检测状态

        /// <summary> 
        /// 计算车速变量声明
        /// </summary>
        int inTime ;//车辆第一次进入线圈的时间
        int outTime;//车辆离开线圈的时间
        int lastTime;//车辆经过线圈的时间
        double speed;//车速
        bool inFlag;//车辆第一次进入线圈的标志

        MUDControlCData data;
       
        #endregion

        #region 属性
        public TextBox  Box
        {
            get { return freTransfer_textBox; }
        }

        public Label  Lab
        {
            get { return  levTransfer_Lable ; }
        }

        public static bool CoilCheckState //用于测速模块，测速的前提是线圈检测进行中
        {
            get { return MUDControlC.coilCheckState; }
            set { MUDControlC.coilCheckState = value; }
        }
        #endregion
      
        public event EventHandler<MUDControlCData> MsgRevieced;//与ControlP和实时测速交互的事件   
        public event EventHandler<MUDControlCData> TimerMsgRevieced;//与测速模块中Timer计时器交互的事件  
        [DllImport("user32", EntryPoint = "HideCaret")]//消除光标
        public static extern bool HideCaret(IntPtr hWnd);

        public MUDControlC(Form1 fm)
        {
            this.fm = fm;
            InitializeComponent();
            connect_Button.Enabled = false;
            connectState = false;
            coilCheckState = true;
            inFlag = false;
            frequencyState = false;       
            comboBox1.SelectedIndex = 0;
            comboBox1.Enabled = false;
            label1.Enabled = false;

        }
  

        #region 窗体移动
        private void UserControlC_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseDownState = true;
            this.startPosition = e.Location;
            this.BackColor = Form1.MUDCControlColor1 ;
        }

        private void UserControlC_MouseMove(object sender, MouseEventArgs e)
        {
            
               if (this.mouseDownState && Form1.MudControlCMS)
               {
                   int minX = this.Parent.Location.X;
                   int maxX = this.Parent.Location.X+this.Parent.Width-290;
                   int maxY = this.Parent.Location.Y + this.Parent.Height-160;
                   this.Location = new Point(Math.Max(minX,(Math.Min(this.Location.X + e.X - this.startPosition.X, maxX))),
                        Math.Min(Math.Max(this.Location.Y + e.Y - this.startPosition.Y, fm.toolStrip1.Location.Y + 75),maxY));

                   this.BackColor = Color.Goldenrod;
               }
           }
        

        private void UserControlC_MouseUp(object sender, MouseEventArgs e)
        {
            this.mouseDownState = false;
            this.BackColor = Form1.MUDCControlColor1;
        }
        #endregion

        #region 数据发送与接收
        protected void OnMsgRecieved(MUDControlCData data)//触发事件方法
        {
            if (MsgRevieced != null)
            {
                MsgRevieced(this, data);
            }
        }

        protected void OnTimerMsgRecieved(MUDControlCData data)//触发事件方法
        {
            if (TimerMsgRevieced != null)
            {
                TimerMsgRevieced(this, data);
            }
        }

        private void connect_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (connectState == false)//当前处于非连接状态，则可以进行连接操作，否则可以关闭连接
                {
                   
                    client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    client.Connect(MUDIPConfig.ServerEp);
                    th = new Thread(new ThreadStart(GetMsg));
                    th.IsBackground = true;
                    th.Start();
                    MessageBox.Show("Connect Success");
                    connect_Button.Text = "DisConnect";
                    connectState = true;
                    frequencyCheck_Button.Enabled = true;
                    coilCheck_Button.Enabled = true;
                    label1.Enabled = true;
                    comboBox1.Enabled = true;
                }
                else
                {
                    timer1.Stop();
                    th.Abort();
                    client.Close();
                    client.Dispose();
                    MessageBox.Show("DisConnect Success");
                    connectState = false;
                    connect_Button.Text = "Connect";
                    frequencyCheck_Button.Enabled = false;
                    coilCheck_Button.Enabled = false;
                    label1.Enabled = false;
                    comboBox1.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frequencyCheck_Button_Click(object sender, EventArgs e)
        {
            try
            {
                frequencyState = true;
                client.Send(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString ());
            }
        }

        private void coilCheck_Button_Click(object sender, EventArgs e)
        {
            try
            {
                frequencyState = false;
                if (coilCheckState == true)
                {
                    timer1.Start();
                    coilCheck_Button.Text = "停止检测";
                    coilCheckState = false;
                }
                else
                {
                    coilCheckState = true;
                    timer1.Stop();
                    coilCheck_Button.Text = "线圈检测";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString ());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                client.Send(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString ());
            }
        }

        private void GetMsg()
        {
            try
            {
                while (true)
                {
                    byte[] arrRecMsg = new byte[12];
                    int length = client.Receive(arrRecMsg);
                    float a = 0;
                    float b = 0;
                    float c = 0;
                    float d = 0;
                    this.Invoke(new Action(() =>
                  {
                      if (comboBox1.SelectedIndex == 0)
                      {
                          a = arrRecMsg[9];
                          b = arrRecMsg[10];
                      }
                      if (comboBox1.SelectedIndex == 1)
                      {
                          a = arrRecMsg[7];
                          b = arrRecMsg[8];
                      }
                      c = (a * 256 + b) / 100;//频率
                      d = (arrRecMsg[4] >> 4) & 0x01;//0 1
                      speed = 0;
                      lastTime = 0;
                      if (d == 1&&inFlag==false)
                      {
                          inTime = System.DateTime.Now.Second*1000+System.DateTime.Now.Millisecond;//以毫秒为单位
                          inFlag = true;
                      }
                      if (d == 0 && inFlag == true)
                      {
                          outTime = System.DateTime.Now.Second * 1000 + System.DateTime.Now.Millisecond;//以毫秒为单位
                          inFlag = false;//还原车辆第一次进入线圈的标志
                          
                          //车辆离开线圈时计算时间和车速
                          lastTime = outTime - inTime;
                          speed = Math.Round(( 0.3 * 1000 / lastTime),2);
                      }
                      data = new MUDControlCData { A = a, B = b, C = c, D = d,Time =lastTime, Speed = speed, State = frequencyState };
                      OnMsgRecieved(data);
                      OnTimerMsgRecieved(data);
                  }));
                }
            
            }
            catch (SocketException ex)
            {
                client.Close();
                client.Dispose();
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion 

        #region 提示
        private void freTransfer_textBox_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(freTransfer_textBox, "频率传输端口");
        }

        private void freTransfer_Lable_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(levTransfer_Lable, "高低电平传输端口");
        }
        #endregion

        //消除光标影响
        private void freTransfer_textBox_MouseDown(object sender, MouseEventArgs e)
        {
            HideCaret((sender as TextBox).Handle);
        }

        //配置IP
        private void iP_button1_Click(object sender, EventArgs e)
        {
            try
            {
                MUDIPConfig ipForm = new MUDIPConfig();
                ipForm.Show();
                connect_Button.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

  

   
    }

}
