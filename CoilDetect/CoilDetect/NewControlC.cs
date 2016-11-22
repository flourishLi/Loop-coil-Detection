using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace CoilDetect
{
    public partial class NewControlC : UserControl
    {
        public NewControlC()
        {
            InitializeComponent();
            connect_Button.Enabled = false;
        }

        #region 变量声明
        private bool mouseDownState; //移动标志
        private Point startPosition; //新建窗体的初始位置

        Socket client;
        Thread th = null;
        bool connectState;          //服务器连接状态

        int passTime = 0;           //计算车辆经过线圈时间
        int beforeTime = 0;          
        int loopNumber =0;         //线圈编号1/2
        int carOrNot = 0;           //有无车辆标志0/1
        int troubleOrNot = 0;       //线圈运行状态0/1
       
        [DllImport("user32", EntryPoint = "HideCaret")]
        public static extern bool HideCaret(IntPtr hWnd);
        #endregion

        #region 窗体移动
        private void NewControlC_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseDownState = true;
            this.startPosition = e.Location;
        }

        private void NewControlC_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mouseDownState)
            {
                this.Location = new Point(this.Location.X + e.X - this.startPosition.X,
                    this.Location.Y + e.Y - this.startPosition.Y);
            }
        }

        private void NewControlC_MouseUp(object sender, MouseEventArgs e)
        {
            this.mouseDownState = false;
        }
        #endregion

        #region 服务器连接、数据处理
        private void connect_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (connectState == false)//当前处于非连接状态，则可以进行连接操作，否则可以关闭连接
                {
                    client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//TCP协议
                    client.Connect(SJRIpConfig.ServerEp);
                    MessageBox.Show("Connect Success");
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
                    connect_Button.Text = "Connect";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //解析十进制数据，获取bit位数据  
        public static void GetBit(byte byte1,int[] bits)
        {
           int bit8 = (byte1 & 128) == 128 ? 1 : 0;
           int bit7 = (byte1 & 64) == 64 ? 1 : 0;
           int bit6 = (byte1 & 32) == 32 ? 1 : 0;
           int bit5 = (byte1 & 16) == 16 ? 1 : 0;
           int bit4 = (byte1 & 8) == 8 ? 1 : 0;
           int bit3 = (byte1 & 4) == 4 ? 1 : 0;
           int bit2 = (byte1 & 2) == 2 ? 1 : 0;
           int bit1 = (byte1 & 1) == 1 ? 1 : 0;
           bits[0]=bit1;//低位
           bits[1]=bit2;                                                                                                                 
           bits[2]=bit3;
           bits[3]=bit4;
           bits[4]=bit5;//高位
           bits[5]=bit6;
           bits[6]=bit7;
           bits[7]=bit8;
        }
       
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

                    int time = 0;
                    int length = client.Receive(arrRecMsg);//接收数据
                    LAChannel = arrRecMsg[0];
                    THB = arrRecMsg[1];
                    TLB = arrRecMsg[2];
                    TroubleState = arrRecMsg[3];

                    GetBit(LAChannel, lAChannelbits);
                    GetBit(THB, tHBbits);
                    GetBit(TLB, tLBbits);
                    GetBit(TroubleState, troubleStatebits);
                    //计算线圈时间
                    timebits = new int[] {  tLBbits[0],tLBbits[1],tLBbits[2],tLBbits[3],tLBbits[4],tLBbits[5],tLBbits[6],tLBbits[7],
                                                    tHBbits[0], tHBbits[1], tHBbits[2], tHBbits[3], tHBbits[4], tHBbits[5] ,tHBbits[6],tHBbits[7]
                                                     };
                    for (int i = 0; i < 16; i++)
                        time += timebits[i] *(int)Math.Pow(2, i);
                     
                    passTime = time - beforeTime;

                    //计算线圈编号
                    loopNumber =lAChannelbits[4] + lAChannelbits[5] * 2 + lAChannelbits[6] * 4 + lAChannelbits[7]*8 ;
                    if (loopNumber>2)
                       loopNumber =0;
                    //有无车辆经过
                    carOrNot = lAChannelbits[0];
                    //线圈故障检测
                    if (loopNumber == 1)
                    {
                        troubleOrNot = troubleStatebits[0];
                    }
                    else if (loopNumber ==2)
                    {
                        troubleOrNot = troubleStatebits[1];
                    }
                    this.Invoke(new Action(() =>
                    {
                        int i = dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = loopNumber;
                        dataGridView1.Rows[i].Cells[1].Value = carOrNot;
                        dataGridView1.Rows[i].Cells[3].Value = troubleOrNot;
                        if (loopNumber == 0||carOrNot==1)
                        {
                            dataGridView1.Rows[i].Cells[2].Value = 0;
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[2].Value = passTime;
                        }
                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
                    }));
                    beforeTime = time;
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
        //配置IP
        private void ip_button1_Click(object sender, EventArgs e)
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
    }
}
