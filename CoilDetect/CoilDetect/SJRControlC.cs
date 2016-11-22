using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.InteropServices;

namespace CoilDetect
{
    public partial class SJRControlC : UserControl
    {
        #region 变量声明
        Form1 fm;
        private bool mouseDownState; //移动标志
        private Point startPosition; //新建窗体的初始位置

        Socket client;
        Thread th = null;

        int lastTime;           //计算车辆经过线圈时间
        int inTime;         //记录前一次的进入时间
        int outTime;         //记录离开时间
        int loopNumber;         //线圈编号1/2
        int carOrNot;           //有无车辆标志0/1
        int troubleOrNot;       //线圈运行状态0/1
        double speed;              //车速
        bool inFlag;//车辆第一次进入线圈的标志

        SJRControlCData data;

        static bool connectState; //服务器连接状态

        public static bool ConnectState
        {
            get { return SJRControlC.connectState; }
            set { SJRControlC.connectState = value; }
        }

        static bool cardetect_ButtonState;  //车辆信号检测状态

        public static bool Cardetect_ButtonState
        {
            get { return cardetect_ButtonState; }
            set { cardetect_ButtonState = value; }
        }
        static bool coilCheck_ButtonState;  //线圈检测信号状态

        public static bool CoilCheck_ButtonState
        {
            get { return coilCheck_ButtonState; }
            set { coilCheck_ButtonState = value; }
        }
        static bool cardetectLine_ButtonState;  //车辆信号检测通讯线状态

        public static bool CardetectLine_ButtonState
        {
            get { return cardetectLine_ButtonState; }
            set { cardetectLine_ButtonState = value; }
        }
        static bool coilCheckLine_ButtonState;  //线圈检测通讯线状态

        public static bool CoilCheckLine_ButtonState
        {
            get { return coilCheckLine_ButtonState; }
            set { coilCheckLine_ButtonState = value; }
        }
        #endregion

        #region 属性
        public TextBox Box
        {
            get { return carTransfer_textBox; }
        }

        public Label Lab
        {
            get { return coilTransfer_Lable; }
        }


        #endregion

        public event EventHandler<SJRControlCData> MsgRevieced;//事件  
        public event EventHandler<SJRControlCData> TimerMsgRevieced;//与测速模块中Timer计时器交互的事件 
        [DllImport("user32", EntryPoint = "HideCaret")]//消除光标
        public static extern bool HideCaret(IntPtr hWnd);
        public SJRControlC(Form1 fm)
        {
            this.fm = fm;
            InitializeComponent();
            connect_Button.Enabled = false;
            cardetect_Button.Enabled = false;
            coilCheck_Button.Enabled = false;
            //carTransfer_textBox.Enabled = false;
            //coilTransfer_Lable.Enabled = false;
        }

        //设置服务器
        private void iP_button1_Click(object sender, EventArgs e)
        {
            try
            {
                SJRIpConfig ipForm = new SJRIpConfig();
                ipForm.Show();
                connect_Button.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //连接服务器
        private void connect_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (connectState == false)//当前处于非连接状态，则可以进行连接操作，否则可以关闭连接
                {
                    client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//TCP协议
                    client.Connect(SJRIpConfig.ServerEp);
                    MessageBox.Show("Connect Success");
                    cardetect_Button.Enabled = true;
                    coilCheck_Button.Enabled = true;
                    carTransfer_textBox.Enabled = true;
                    coilTransfer_Lable.Enabled = true;
                    connect_Button.Text = "DisConnect";
                    th = new Thread(new ThreadStart(GetMsg));//开启线程接收数据
                    th.IsBackground = true;
                    th.Start();
                    connectState = true;
                }
                else
                {
                    th.Abort();
                    client.Shutdown(SocketShutdown.Both);//通知接受双发都不在发送数据
                    client.Close();//释放套接字
                    client.Dispose();
                    MessageBox.Show("DisConnect Success");
                    connectState = false;
                    cardetect_Button.Enabled = false;
                    coilCheck_Button.Enabled = false;
                    carTransfer_textBox.Enabled = false;
                    coilTransfer_Lable.Enabled = false;
                    connect_Button.Text = "Connect";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //解析数据
        private void GetMsg()
        {
            try
            {
                while (true)
                {
                    //存储二进制数据的数组
                    int[] lAChannelbits = new int[8];
                    int[] tHBbits = new int[8];
                    int[] tLBbits = new int[8];
                    int[] timebits;//高低位结合，组成十六位，值范围 =0-65535ms
                    int[] troubleStatebits = new int[8];
                    byte[] arrRecMsg = new byte[4];//接收数据字节数组

                    //十进制
                    byte LAChannel = 0;//线圈编号和通道检测状态
                    byte THB = 0;//系统计时高位
                    byte TLB = 0;//系统计时低位
                    byte TroubleState = 0;//通道故障状态

                    int length = client.Receive(arrRecMsg);//接收数据
                    LAChannel = arrRecMsg[0];
                    THB = arrRecMsg[1];
                    TLB = arrRecMsg[2];
                    TroubleState = arrRecMsg[3];

                    GetBit(LAChannel, lAChannelbits);
                    GetBit(THB, tHBbits);
                    GetBit(TLB, tLBbits);
                    GetBit(TroubleState, troubleStatebits);
                   

                    //计算线圈编号
                    loopNumber = lAChannelbits[4] + lAChannelbits[5] * 2 + lAChannelbits[6] * 4 + lAChannelbits[7] * 8;
    
                    //有无车辆经过
                    carOrNot = lAChannelbits[0];
                    //线圈故障检测
                    if (loopNumber == 1)
                    {
                        troubleOrNot = troubleStatebits[0];
                    }
                    else if (loopNumber == 2)
                    {
                        troubleOrNot = troubleStatebits[1];
                    }

                    speed = 0;
                    lastTime = 0;
                    if (carOrNot == 1 && inFlag == false)
                    {
                        inTime = System.DateTime.Now.Second * 1000 + System.DateTime.Now.Millisecond;//以毫秒为单位
                        inFlag = true;
                    }
                    if (carOrNot == 0 && inFlag == true)
                    {
                        outTime = System.DateTime.Now.Second * 1000 + System.DateTime.Now.Millisecond;//以毫秒为单位
                        inFlag = false;//还原车辆第一次进入线圈的标志

                        //车辆离开线圈时计算时间和车速
                        lastTime = outTime - inTime;
                        speed = Math.Round((0.3 * 1000 / lastTime), 2);
                    }
                    data = new SJRControlCData { Time=lastTime,LoopNum=loopNumber,CarOrNot=carOrNot,TroubleState=troubleOrNot,Speed=speed};
                    OnMsgRecieved(data);
                    OnTimerMsgRecieved(data);
                }
            }
            catch (SocketException ex)
            {
                client.Close();
                client.Dispose();
                MessageBox.Show(ex.ToString());
            }
        }

        //解析十进制数据，获取bit位数据  
        public static void GetBit(byte byte1, int[] bits)
        {
            int bit8 = (byte1 & 128) == 128 ? 1 : 0;
            int bit7 = (byte1 & 64) == 64 ? 1 : 0;
            int bit6 = (byte1 & 32) == 32 ? 1 : 0;
            int bit5 = (byte1 & 16) == 16 ? 1 : 0;
            int bit4 = (byte1 & 8) == 8 ? 1 : 0;
            int bit3 = (byte1 & 4) == 4 ? 1 : 0;
            int bit2 = (byte1 & 2) == 2 ? 1 : 0;
            int bit1 = (byte1 & 1) == 1 ? 1 : 0;
            bits[0] = bit1;//低位
            bits[1] = bit2;
            bits[2] = bit3;
            bits[3] = bit4;
            bits[4] = bit5;//高位
            bits[5] = bit6;
            bits[6] = bit7;
            bits[7] = bit8;
        }

      
        #region 窗体移动
        private void SJRControlC_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseDownState = true;
            this.startPosition = e.Location;
            this.BackColor =Form1.SJRCControlColor1 ;
        }

        private void SJRControlC_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mouseDownState&&Form1.SjrControlCMS)
            {
                int minX = this.Parent.Location.X;
                int maxX = this.Parent.Location.X + this.Parent.Width - 290;
                int maxY = this.Parent.Location.Y + this.Parent.Height - 300;
                this.Location = new Point(Math.Max(minX, (Math.Min(this.Location.X + e.X - this.startPosition.X, maxX))),
                     Math.Min(Math.Max(this.Location.Y + e.Y - this.startPosition.Y, fm.toolStrip1.Location.Y + 75), maxY));

                this.BackColor = Color.Goldenrod;
            }
        }

        private void SJRControlC_MouseUp(object sender, MouseEventArgs e)
        {
            this.mouseDownState = false;
            this.BackColor = Form1.SJRCControlColor1;
        }
        #endregion

        //车辆检测
        private void cardetect_Button_Click(object sender, EventArgs e)
        {
            if (cardetect_ButtonState == false)
            {
                cardetect_Button.Text = "停止检查";
                Cardetect_ButtonState = true;
            }
            else
            {
                cardetect_Button.Text = "车辆检查";
                Cardetect_ButtonState = false;
            }
        }
        //线圈检测
        private void coilCheck_Button_Click(object sender, EventArgs e)
        {
            if (CoilCheck_ButtonState == false)
            {
                coilCheck_Button.Text = "停止检查";
                CoilCheck_ButtonState = true;
            }
            else
            {
                coilCheck_Button.Text = "线圈检查";
                CoilCheck_ButtonState = false;
            }
        }

        protected void OnMsgRecieved(SJRControlCData data)//触发事件方法
        {
            if (MsgRevieced != null)
            {
                MsgRevieced(this, data);
            }
        }

        protected void OnTimerMsgRecieved(SJRControlCData data)//触发事件方法
        {
            if (TimerMsgRevieced != null)
            {
                TimerMsgRevieced(this, data);
            }
        }

        //消除光标
        private void carTransfer_textBox_MouseDown(object sender, MouseEventArgs e)
        {
            HideCaret((sender as TextBox).Handle);
        }

        //提示信息
        private void carTransfer_textBox_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(carTransfer_textBox, "车辆信号检测端口");
        }

        private void coilTransfer_Lable_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(coilTransfer_Lable, "线圈编号检测端口");
        }



      

    }
}
