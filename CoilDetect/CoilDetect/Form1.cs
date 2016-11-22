using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoilDetect
{
    public partial class Form1 : Form
    {
        #region 变量声明

        CoilSimulateControl coilSimControl;
        CoilDetectSimControl coilDetSimControl;
        ChuanKouSImControl chuanKouControl;

        public static ModuleManege mm;
        static MUDControlC mudControlC;

        public static MUDControlC MudControlC //传递到MUDControlA用于接收事件数据
        {
            get { return mudControlC; }
            set { mudControlC = value; }
        }
        MUDControlP mudControlP;
        MUDControlA mudControlA;

        static SJRControlC sjrControlC;

        public static SJRControlC SjrControlC  //传递到SJRControlA用于接收事件数据
        {
            get { return sjrControlC; }
            set { sjrControlC = value; }
        }
        SJRControlP sjrControlP;
        SJRControlA sjrControlA;
        int mudControlC_StartX;//mud控件初始位置
        int mudControlC_StartY;
        int mudControlP_StartX;
        int mudControlP_StartY;
        int mudControlA_StartX;
        int mudControlA_StartY;
        int sjrControlC_StartX;//sjr控件初始位置
        int sjrControlC_StartY;
        int sjrControlP_StartX;
        int sjrControlP_StartY;
        int sjrControlA_StartX;
        int sjrControlA_StartY;
        int coilSimControl_StartX;//模拟控件初始位置
        int coilSimControl_StartY;
        int coilDetSimControl_StartX;
        int coilDetSimControl_StartY;
        int chuanKouControl_StartX;
        int chuanKouControl_StartY;
        List<MUDControlP> mudControlPList;//MUDControlP控件实例化列表
        List<SJRControlP> sjrControlPList;//SJRControlP控件实例化列表

        List<Tuple<TextBox, TextBox>> mudFreLines = new List<Tuple<TextBox, TextBox>>();//MUD频率通讯线列表
        List<Tuple<Label, Label>> mudLevelLines = new List<Tuple<Label, Label>>();//MUD高低电平通讯线列表
        List<Tuple<Label, Label>> mudSpeedLines = new List<Tuple<Label, Label>>();//MUD测速通讯线列表

        List<Tuple<TextBox, TextBox>> sjrLevelLines = new List<Tuple<TextBox, TextBox>>();//SJR车辆检测高低电平通讯线列表
        List<Tuple<Label, Label>> sjrLoopLines = new List<Tuple<Label, Label>>();//SJR线圈编号通讯线列表
        List<Tuple<Label, Label>> sjrSpeedLines = new List<Tuple<Label, Label>>();//SJR测速通讯线列表

        //模拟线
        List<Tuple<TextBox, TextBox>> chuanKouLines = new List<Tuple<TextBox, TextBox>>();
        List<Tuple<Label, Label>> coilLinkLines = new List<Tuple<Label, Label>>();
        //清空窗体用
        ArrayList al = new ArrayList();
        //模拟点
        Label coilSimPoint;
        Label coilDetPoint_label;
        TextBox coilDetPoint_text;
        TextBox chuanKouPoint;

        TextBox mudfreBegin;//MUD频率通讯线端点
        TextBox mudfreEnd;//MUD频率通讯线终点
        Label mudlevBegin;//MUD高低电平通讯线终点
        Label mudlevEnd;//MUD高低电平通讯线终点
        Label mudspeedBegin;//MUD高低电平通讯线终点
        Label mudspeedEnd;//MUD高低电平通讯线终点

        TextBox sjrCarBegin;//SJR车辆检测通讯线起点
        TextBox sjrCarEnd;//SJR车辆检测通讯线终点
        Label sjrCoilBegin;//SJR线圈检测通讯线终点
        Label sjrCoilEnd;//SJR线圈检测通讯线终点
        Label sjrspeedBegin;//SJR测速通讯线终点
        Label sjrspeedEnd;//SJR测速通讯线终点

        bool mudfreMouseDown;//MUD频率发出端状态
        bool mudlevMouseDown;//MUD高低电平发出端状态
        bool mudspeedMouseDown;//MUD测速模块发出端状态

        bool coilSimMouseDown; //线圈线模拟发出端
        bool chuanKouSimMouseDown;//串口线模拟发出端

        static bool mudControlCMS; //MUDControlC可移动标志

        public static bool MudControlCMS
        {
            get { return mudControlCMS; }
            set { mudControlCMS = value; }
        }
        static bool mudControlPMS; //MUDControlP可移动标志

        public static bool MudControlPMS
        {
            get { return mudControlPMS; }
            set { mudControlPMS = value; }
        }
        static bool mudControlAMS; //MUDControlA可移动标志

        public static bool MudControlAMS
        {
            get { return mudControlAMS; }
            set { mudControlAMS = value; }
        }

        static bool sjrControlPMS; //SJRControlP可移动标志

        public static bool SjrControlPMS
        {
            get { return Form1.sjrControlPMS; }
            set { Form1.sjrControlPMS = value; }
        }

        static bool sjrControlCMS;

        public static bool SjrControlCMS
        {
            get { return Form1.sjrControlCMS; }
            set { Form1.sjrControlCMS = value; }
        }

        static bool sjrControlAMS;

        public static bool SjrControlAMS
        {
            get { return Form1.sjrControlAMS; }
            set { Form1.sjrControlAMS = value; }
        }

        bool sjrcarMouseDown;//SJR车辆检测发出端状态
        bool sjrcoilMouseDown;//SJR线圈检测出端状态
        bool sjrspeedMouseDown;//SJR测速模块发出端状态


        //重命名窗口使用
        static MUDControlP mudControlPReName;

        public static MUDControlP MudControlPReName
        {
            get { return mudControlPReName; }
            set { mudControlPReName = value; }
        }

        static MUDControlC mudControlCReName;

        public static MUDControlC MudControlCReName
        {
            get { return Form1.mudControlCReName; }
            set { Form1.mudControlCReName = value; }
        }

        static MUDControlA mudControlAReName;

        public static MUDControlA MudControlAReName
        {
            get { return Form1.mudControlAReName; }
            set { Form1.mudControlAReName = value; }
        }

        static SJRControlA sjrControlAReName;

        public static SJRControlA SjrControlAReName
        {
            get { return Form1.sjrControlAReName; }
            set { Form1.sjrControlAReName = value; }
        }

        static SJRControlP sjrControlPReName;

        public static SJRControlP SjrControlPReName
        {
            get { return Form1.sjrControlPReName; }
            set { Form1.sjrControlPReName = value; }
        }

        static SJRControlC sjrControlCReName;

        public static SJRControlC SjrControlCReName
        {
            get { return Form1.sjrControlCReName; }
            set { Form1.sjrControlCReName = value; }
        }


        static Color MUDPControlColor;   //供上下文菜单使用

        public static Color MUDPControlColor1
        {
            get { return Form1.MUDPControlColor; }
            set { Form1.MUDPControlColor = value; }
        }
        static Color MUDCControlColor;

        public static Color MUDCControlColor1
        {
            get { return Form1.MUDCControlColor; }
            set { Form1.MUDCControlColor = value; }
        }

        static Color MUDAControlColor;

        public static Color MUDAControlColor1
        {
            get { return Form1.MUDAControlColor; }
            set { Form1.MUDAControlColor = value; }
        }

        static Color SJRPControlColor;

        public static Color SJRPControlColor1
        {
            get { return Form1.SJRPControlColor; }
            set { Form1.SJRPControlColor = value; }
        }

        static Color SJRCControlColor;

        public static Color SJRCControlColor1
        {
            get { return Form1.SJRCControlColor; }
            set { Form1.SJRCControlColor = value; }
        }

        static Color SJRAControlColor;

        public static Color SJRAControlColor1
        {
            get { return Form1.SJRAControlColor; }
            set { Form1.SJRAControlColor = value; }
        }
        #endregion

      
        public Form1()
        {
            InitializeComponent();

            //MUD初始位置
            mudControlC_StartX = 100;
            mudControlC_StartY = 200;
            mudControlP_StartX = 500;
            mudControlP_StartY = 100;
            mudControlA_StartX = 800;
            mudControlA_StartY = 120;
            //SJR初始位置
            sjrControlC_StartX = 100;
            sjrControlC_StartY = 300;
            sjrControlP_StartX = 500;
            sjrControlP_StartY = 300;
            sjrControlA_StartX = 800;
            sjrControlA_StartY = 320;
            //模拟控件初始位置
            coilSimControl_StartX = 50;
            coilSimControl_StartY = 300;
            coilDetSimControl_StartX = 200;
            coilDetSimControl_StartY = 300;
            chuanKouControl_StartX = 400;
            chuanKouControl_StartY = 320;
            mudControlPList = new List<MUDControlP>();
            sjrControlPList = new List<SJRControlP>();
            mudfreMouseDown = false;
            mudlevMouseDown = false;
            mudspeedMouseDown = false;

            //MUD控件可移动标志
            MudControlAMS = true;
            MudControlPMS = true;
            MudControlCMS = true;
            SjrControlAMS = true;
            SjrControlPMS = true;
            SjrControlCMS = true;
            this.WindowState = FormWindowState.Normal;

            this.menuStrip1.BackgroundImage = Properties.Resources.menutool_bc;
            this.toolStrip1.BackgroundImage = Properties.Resources.menutool_bc;
            数据处理ToolStripMenuItem.Enabled = false;
            数据分析ToolStripMenuItem.Enabled = false;
            数据处理ToolStripMenuItem1.Enabled = false;
            数据分析ToolStripMenuItem1.Enabled = false;
            数据处理ToolStripMenuItem2.Enabled = false;
            数据分析ToolStripMenuItem2.Enabled = false;
            数据处理ToolStripMenuItem3.Enabled = false;
            数据分析ToolStripMenuItem3.Enabled = false;

        }

      

        #region 工具栏

        # region 模拟控件
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            try
            {
                coilSimControl = new CoilSimulateControl(this);
                coilSimControl.Parent = this;
                coilSimControl.ContextMenuStrip = contextMenuStripCoilSim;
                coilSimControl.Location = new Point(coilSimControl_StartX, coilSimControl_StartY);
                coilSimControl_StartX += 5;
                coilSimControl_StartY += 5;
                this.Controls.Add(coilSimControl);
                Label coilSim_lab = coilSimControl.Lab;
                coilSim_lab.MouseClick += coilSim_lab_MouseClick;
                coilSimControl.Move += coilSimControl_Move;
                al.Add(coilSimControl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        void coilSimControl_Move(object sender, EventArgs e)
        {
            Refresh();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            try
            {
                coilDetSimControl = new CoilDetectSimControl(this);
                coilDetSimControl.Parent = this;
                coilDetSimControl.ContextMenuStrip = contextMenuStripcoilDet;
                coilDetSimControl.Location = new Point(coilDetSimControl_StartX, coilDetSimControl_StartY);
                coilDetSimControl_StartX += 5;
                coilDetSimControl_StartY += 5;
                this.Controls.Add(coilDetSimControl);
                foreach (var coilDet_lab in coilDetSimControl.Lab)
                {
                    coilDet_lab.MouseClick += coilDet_lab_MouseClick; ; ;//添加对checkbox的click事件，用于绘制通讯线
                }
                TextBox coilDet_Text = coilDetSimControl.Box;
                coilDet_Text.MouseClick += coilDet_Text_MouseClick;
                coilDetSimControl.Move += coilDetSimControl_Move;
                al.Add(coilDetSimControl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void coilDetSimControl_Move(object sender, EventArgs e)
        {
            Refresh();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            try
            {
                chuanKouControl = new ChuanKouSImControl(this);
                chuanKouControl.Parent = this;
                chuanKouControl.ContextMenuStrip = contextMenuStripchuanKou;
                chuanKouControl.Location = new Point(chuanKouControl_StartX, chuanKouControl_StartY);
                chuanKouControl_StartX += 5;
                chuanKouControl_StartY += 5;
                this.Controls.Add(chuanKouControl);
                foreach (var chuanKou_text in chuanKouControl.Box)
                {
                    chuanKou_text.MouseClick += chuanKou_text_MouseClick; ; ; ;//添加对checkbox的click事件，用于绘制通讯线
                }
                chuanKouControl.Move += chuanKouControl_Move;
                al.Add(chuanKouControl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void chuanKouControl_Move(object sender, EventArgs e)
        {
            Refresh();
        }


        private void coilSim_lab_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                coilSimMouseDown = true;
                coilSimPoint = (Label)sender;
                coilSimPoint.BackColor = Color.Blue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void coilDet_lab_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (coilSimMouseDown)
                {
                    coilSimMouseDown = false;
                    coilDetPoint_label = (Label)sender;
                    coilDetPoint_label.BackColor = Color.Blue;
                    coilLinkLines.Add(new Tuple<Label, Label>(coilSimPoint, coilDetPoint_label));//添加起始点
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void coilDet_Text_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                chuanKouSimMouseDown = true;
                coilDetPoint_text = (TextBox)sender;
                coilDetPoint_text.BackColor = Color.Blue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void chuanKou_text_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (chuanKouSimMouseDown)
                {
                    chuanKouSimMouseDown = false;
                    chuanKouPoint = (TextBox)sender;
                    chuanKouPoint.BackColor = Color.Blue;
                    chuanKouLines.Add(new Tuple<TextBox, TextBox>(coilDetPoint_text, chuanKouPoint));
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
   
        #region MUD
        private void 数据处理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                mudControlP = new MUDControlP(this);
                mudControlP.Parent = this;
                MUDPControlColor1 = Color.AntiqueWhite;
                mudControlP.ContextMenuStrip = contextMenuStrip1_MUDP;
                mudControlP.Location = new Point(mudControlP_StartX, mudControlP_StartY);
                mudControlP.BackColor = Color.AntiqueWhite;
                this.Controls.Add(mudControlP);
                mudControlP_StartX += 10;                   //再次实例化后更新位置
                mudControlP_StartY += 10;
                mudControlPList.Add(mudControlP);
                TextBox boxP = mudControlP.Box;
                boxP.MouseClick += boxP_MouseClick;     //添加对checkbox（频率接收端）的click事件，用于绘制通讯线
                Label labP = mudControlP.Lab;
                labP.MouseClick += labP_MouseClick;     //添加对Label（高低电平接收端）的click事件，用于绘制通讯线
                Label labSpeed = mudControlP.Label_Speed;
                labSpeed.MouseClick += labSpeed_MouseClick;//添加测速label的click事件，用于绘制通讯线
                mudControlP.Move += controlP_Move;         //添加controlP的Move事件
                mudControlC.MsgRevieced += mudControlP.Show;  //事件处理,两个用户控件之间的频率通信
                al.Add(mudControlP);

            }
            catch (Exception ex)
            {
            }
        }

        private void 数据采集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                mudControlC = new MUDControlC(this);
                mudControlC.Parent = this;
                mudControlC.Parent = this;
                数据处理ToolStripMenuItem2.Enabled = true;
                数据分析ToolStripMenuItem2.Enabled = true;
                数据处理ToolStripMenuItem.Enabled = true;
                数据分析ToolStripMenuItem.Enabled = true;
                MUDCControlColor1 = Color.AntiqueWhite;
                mudControlC.ContextMenuStrip = contextMenuStrip2_MUDC;
                mudControlC.Location = new Point(mudControlC_StartX, mudControlC_StartY);
                mudControlC.BackColor = Color.AntiqueWhite;
                this.Controls.Add(mudControlC);
                mudControlC_StartY += 10;             //再次实例化后更新位置
                mudControlC_StartX += 10;
                TextBox boxC = mudControlC.Box;
                boxC.MouseClick += boxC_MouseClick;//添加对CheckBox（频率发出端）的click事件，用于绘制通讯线
                Label labC = mudControlC.Lab;
                labC.MouseClick += labC_MouseClick;//添加对Label（高低电平发出端）的click事件，用于绘制通讯线
                mudControlC.Move += controlC_Move;    //添加controlC的Move事件    
                al.Add(mudControlC);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 数据分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                mudControlA = new MUDControlA(this);
                mudControlA.Parent = this;
                MUDAControlColor1 = Color.AntiqueWhite;
                mudControlA.ContextMenuStrip = Spped_contextMenuStrip4_MUDA;
                mudControlA.Location = new Point(mudControlA_StartX, mudControlA_StartY);
                mudControlA.BackColor = Color.AntiqueWhite;
                this.Controls.Add(mudControlA);
                mudControlA_StartY += 5;             //再次实例化后更新位置
                mudControlA_StartX += 5;
                Label labSpeedEnd = mudControlA.Label_SpeedEnd;
                labSpeedEnd.MouseClick += labSpeedEnd_MouseClick;//添加测速label的click事件，用于绘制通讯线
                mudControlA.Move += controlA_Move;
                mudControlC.MsgRevieced += mudControlA.Show;  //事件处理,两个用户控件之间的速度通信
                al.Add(mudControlA);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region SJR
        private void 数据处理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                sjrControlP = new SJRControlP(this);
                sjrControlP.Parent = this;
                SJRPControlColor1 = Color.AntiqueWhite;
                sjrControlP.ContextMenuStrip = contextMenuStrip1_SJRP;
                sjrControlP.Location = new Point(sjrControlP_StartX, sjrControlP_StartY);
                sjrControlP.BackColor = Color.AntiqueWhite;
                this.Controls.Add(sjrControlP);
                sjrControlP_StartX += 10;                   //再次实例化后更新位置
                sjrControlP_StartY += 10;
                sjrControlPList.Add(sjrControlP);
                TextBox sjrBoxP = sjrControlP.Box;
                sjrBoxP.MouseClick += sjrBoxP_MouseClick;     //添加对Textbox（车辆检测接收端）的click事件，用于绘制通讯线
                Label sjrLabP = sjrControlP.Label_Coil;
                sjrLabP.MouseClick += sjrLabP_MouseClick;     //添加对Label（线圈编号接收端）的click事件，用于绘制通讯线
                Label sjrlabSpeed = sjrControlP.Label_Speed;
                sjrlabSpeed.MouseClick += sjrlabSpeed_MouseClick; //添加测速label的click事件，用于绘制通讯线
                sjrControlP.Move += sjrControlP_Move;         //添加controlP的Move事件
                sjrControlC.MsgRevieced += sjrControlP.Show;  //事件处理,两个用户控件之间的通信
                al.Add(sjrControlP);

            }
            catch (Exception ex)
            {
            }
        }

        private void 数据采集ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                sjrControlC = new SJRControlC(this);
                sjrControlC.Parent = this;
                数据处理ToolStripMenuItem1.Enabled = true;
                数据分析ToolStripMenuItem1.Enabled = true;
                数据处理ToolStripMenuItem3.Enabled = true;
                数据分析ToolStripMenuItem3.Enabled = true;
                SJRCControlColor1 = Color.AntiqueWhite;
                sjrControlC.ContextMenuStrip = contextMenuStrip1_SJRC;
                sjrControlC.Location = new Point(sjrControlC_StartX, sjrControlC_StartY);
                sjrControlC.BackColor = Color.AntiqueWhite;
                this.Controls.Add(sjrControlC);
                sjrControlC_StartY += 10;             //再次实例化后更新位置
                sjrControlC_StartX += 10;
                TextBox sjrboxC = sjrControlC.Box;
                sjrboxC.MouseClick += sjrboxC_MouseClick; ;//添加对TextBox（车辆检测发出端）的click事件，用于绘制通讯线
                Label sjrlabC = sjrControlC.Lab;
                sjrlabC.MouseClick += sjrlabC_MouseClick; ;//添加对Label（线圈检测发出端）的click事件，用于绘制通讯线
                sjrControlC.Move += sjrControlC_Move; ;    //添加sjrcontrolC的Move事件    
                al.Add(sjrControlC);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 数据分析ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                sjrControlA = new SJRControlA(this);
                sjrControlA.Parent = this;
                SJRAControlColor1 = Color.AntiqueWhite;
                sjrControlA.ContextMenuStrip = contextMenuStrip1_SJRA;
                sjrControlA.Location = new Point(sjrControlA_StartX, sjrControlA_StartY);
                sjrControlA.BackColor = Color.AntiqueWhite;
                this.Controls.Add(sjrControlA);
                sjrControlA_StartY += 5;             //再次实例化后更新位置
                sjrControlA_StartX += 5;
                Label sjrlabSpeedEnd = sjrControlA.Label_SpeedEnd;
                sjrlabSpeedEnd.MouseClick += sjrlabSpeedEnd_MouseClick; ; ;//添加测速label的click事件，用于绘制通讯线
                sjrControlA.Move += sjrControlA_Move;
                sjrControlC.MsgRevieced += sjrControlA.Show;  //事件处理,两个用户控件之间的通信
                al.Add(sjrControlA);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            mm = new ModuleManege(this);
            lg.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region 绘制通讯线

        private void sjrboxC_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                sjrcarMouseDown = true;
                sjrcoilMouseDown = false;
                sjrCarBegin = (TextBox)sender;               //保存车辆检测发出端
                sjrCarBegin.BackColor = Color.Blue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void sjrBoxP_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                TextBox box = (TextBox)sender;
                SJRControlP userContP = (SJRControlP)box.Parent;
                if (sjrcarMouseDown)  //从boxC到boxP画通讯线，即发出端到接收端
                {
                    sjrcarMouseDown = false;
                    sjrCarEnd = (TextBox)sender;
                    sjrCarEnd.BackColor = Color.Blue;
                    sjrLevelLines.Add(new Tuple<TextBox, TextBox>(sjrCarBegin, sjrCarEnd));
                    Refresh();
                }
                if (sjrcoilMouseDown)//前一出发点是线圈检测，数据不匹配
                {
                    sjrcoilMouseDown = false;
                    MessageBox.Show("数据类型不匹配");
                    if (sjrLoopLines.Count == 0)
                    {
                        sjrControlC.Lab.BackColor = Color.WhiteSmoke;//颜色变化
                    }
                    SJRControlP.HideCaret(userContP.Box.Handle); //隐藏当前textBox的光标

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void sjrlabC_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                sjrcoilMouseDown = true;
                sjrcarMouseDown = false;
                sjrCoilBegin = (Label)sender;               //保存线圈检测发出端
                sjrCoilBegin.BackColor = Color.Blue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void sjrLabP_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (sjrcoilMouseDown)               //从boxC到boxP画通讯线
                {
                    sjrcoilMouseDown = false;
                    sjrCoilEnd = (Label)sender;
                    sjrCoilEnd.BackColor = Color.Blue;
                    sjrLoopLines.Add(new Tuple<Label, Label>(sjrCoilBegin, sjrCoilEnd));
                    Refresh();
                }
                if (sjrcarMouseDown)  //前一出发点是车辆检测，数据不匹配
                {
                    sjrcarMouseDown = false;
                    MessageBox.Show("数据类型不匹配");
                    if (sjrLevelLines.Count == 0)
                    {
                        sjrControlC.Box.BackColor = Color.WhiteSmoke;//颜色变化
                    }

                    SJRControlC.HideCaret(mudControlC.Box.Handle);   //隐藏光标

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void sjrlabSpeedEnd_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (sjrspeedMouseDown)                                 //从speedLab到speedLabEnd画通讯线
                {
                    sjrspeedMouseDown = false;
                    sjrspeedEnd = (Label)sender;
                    sjrspeedEnd.BackColor = Color.Blue;
                    sjrSpeedLines.Add(new Tuple<Label, Label>(sjrspeedBegin, sjrspeedEnd));
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void sjrlabSpeed_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                sjrspeedMouseDown = true;
                sjrspeedBegin = (Label)sender;               //保存高低电平发出端
                sjrspeedBegin.BackColor = Color.Blue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void labC_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                mudlevMouseDown = true;
                mudfreMouseDown = false;
                mudlevBegin = (Label)sender;               //保存高低电平发出端
                mudlevBegin.BackColor = Color.Blue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void labP_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (mudlevMouseDown)                                 //从boxC到boxP画通讯线
                {
                    mudlevMouseDown = false;
                    mudlevEnd = (Label)sender;
                    mudlevEnd.BackColor = Color.Blue;
                    mudLevelLines.Add(new Tuple<Label, Label>(mudlevBegin, mudlevEnd));
                    Refresh();
                }
                if (mudfreMouseDown)
                {
                    mudfreMouseDown = false;
                    MessageBox.Show("数据类型不匹配");
                    if (mudFreLines.Count == 0)
                    {
                        mudControlC.Box.BackColor = Color.WhiteSmoke;//颜色变化
                    }

                    MUDControlC.HideCaret(mudControlC.Box.Handle);   //隐藏光标

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void boxC_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                mudlevMouseDown = false;
                mudfreMouseDown = true;
                mudfreBegin = (TextBox)sender;             //保存频率发出端
                mudfreBegin.BackColor = Color.Blue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void boxP_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                TextBox box = (TextBox)sender;
                MUDControlP userContP = (MUDControlP)box.Parent;
                if (mudfreMouseDown)                                 //从boxC到boxP画通讯线，即发出端到接收端
                {
                    mudfreMouseDown = false;
                    mudfreEnd = (TextBox)sender;
                    mudfreEnd.BackColor = Color.Blue;
                    mudFreLines.Add(new Tuple<TextBox, TextBox>(mudfreBegin, mudfreEnd));
                    Refresh();
                }
                if (mudlevMouseDown)
                {
                    mudlevMouseDown = false;
                    MessageBox.Show("数据类型不匹配");
                    if (mudLevelLines.Count == 0)
                    {
                        mudControlC.Lab.BackColor = Color.WhiteSmoke;//颜色变化
                    }
                    MUDControlP.HideCaret(userContP.Box.Handle); //隐藏当前textBox的光标

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void labSpeed_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                mudspeedMouseDown = true;
                mudspeedBegin = (Label)sender;               //保存高低电平发出端
                mudspeedBegin.BackColor = Color.Blue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void labSpeedEnd_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (mudspeedMouseDown)                                 //从speedLab到speedLabEnd画通讯线
                {
                    mudspeedMouseDown = false;
                    mudspeedEnd = (Label)sender;
                    mudspeedEnd.BackColor = Color.Blue;
                    mudSpeedLines.Add(new Tuple<Label, Label>(mudspeedBegin, mudspeedEnd));
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void controlC_Move(object sender, EventArgs e)
        {
            Refresh();//刷新，重绘窗体
        }

        private void controlP_Move(object sender, EventArgs e)
        {
            Refresh();//刷新，重绘窗体
        }

        private void controlA_Move(object sender, EventArgs e)
        {
            Refresh();//刷新，重绘窗体
        }

        private void sjrControlP_Move(object sender, EventArgs e)
        {
            Refresh();//刷新，重绘窗体
        }

        private void sjrControlC_Move(object sender, EventArgs e)
        {
            Refresh();//刷新，重绘窗体
        }

        private void sjrControlA_Move(object sender, EventArgs e)
        {
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                //重绘窗体，在此绘制通讯线,以便窗体发生变化时都会重新绘制通讯线
                base.OnPaint(e);
                Pen pen = new Pen(Color.Red, 5);
                pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                Point offset = new Point(2, 5);
                Point beginPosition = new Point();
                Point endPosition = new Point();
                //MUD频率检测通讯线
                foreach (var line in mudFreLines)
                {
                    if (line.Item1 != null && line.Item2 != null)
                    {
                        beginPosition = Add(Add(line.Item1.Location, line.Item1.Parent.Location), offset);
                        endPosition = Add(Add(line.Item2.Location, line.Item2.Parent.Location), offset);
                        e.Graphics.DrawLine(pen, beginPosition, endPosition);
                        mudControlP.FretransferState = true;//可进行频率数据的传输           
                    }

                }
                //MUD高低电平通讯线
                foreach (var line in mudLevelLines)
                {
                    if (line.Item1 != null && line.Item2 != null)
                    {
                        beginPosition = Add(Add(line.Item1.Location, line.Item1.Parent.Location), offset);
                        endPosition = Add(Add(line.Item2.Location, line.Item2.Parent.Location), offset);
                        e.Graphics.DrawLine(pen, beginPosition, endPosition);
                        mudControlP.LevtransferState = true;//可进行高低电平数据的传输
                    }

                }
                //MUD测速通讯线
                foreach (var line in mudSpeedLines)
                {
                    if (line.Item1 != null && line.Item2 != null)
                    {
                        beginPosition = Add(Add(line.Item1.Location, line.Item1.Parent.Location), offset);
                        endPosition = Add(Add(line.Item2.Location, line.Item2.Parent.Location), offset);
                        e.Graphics.DrawLine(pen, beginPosition, endPosition);
                        mudControlA.Moduleflag = true;//可进行测速数据的传输
                        mudControlA.button1.Enabled = true;
                    }

                }

                //SJR车辆检测通讯线
                foreach (var line in sjrLevelLines)
                {
                    if (line.Item1 != null && line.Item2 != null)
                    {
                        beginPosition = Add(Add(line.Item1.Location, line.Item1.Parent.Location), offset);
                        endPosition = Add(Add(line.Item2.Location, line.Item2.Parent.Location), offset);
                        e.Graphics.DrawLine(pen, beginPosition, endPosition);
                        SJRControlC.CardetectLine_ButtonState = true;//可进行车辆高低电平数据的传输
                    }

                }

                //SJR线圈检测通讯线
                foreach (var line in sjrLoopLines)
                {
                    if (line.Item1 != null && line.Item2 != null)
                    {
                        beginPosition = Add(Add(line.Item1.Location, line.Item1.Parent.Location), offset);
                        endPosition = Add(Add(line.Item2.Location, line.Item2.Parent.Location), offset);
                        e.Graphics.DrawLine(pen, beginPosition, endPosition);
                        SJRControlC.CoilCheckLine_ButtonState = true;//可进行线圈编号数据传输
                    }

                }

                //SJR测速通讯线
                foreach (var line in sjrSpeedLines)
                {
                    if (line.Item1 != null && line.Item2 != null)
                    {
                        beginPosition = Add(Add(line.Item1.Location, line.Item1.Parent.Location), offset);
                        endPosition = Add(Add(line.Item2.Location, line.Item2.Parent.Location), offset);
                        e.Graphics.DrawLine(pen, beginPosition, endPosition);
                        SJRControlA.SpeedLine = true;//可进行速度数据的传输
                        sjrControlA.button1.Enabled = true;
                    }

                }

                //线圈模拟线
                foreach (var line in coilLinkLines)
                {
                    if (line.Item1 != null && line.Item2 != null)
                    {
                        beginPosition = Add(Add(line.Item1.Location, line.Item1.Parent.Location), offset);
                        endPosition = Add(Add(line.Item2.Location, line.Item2.Parent.Location), offset);
                        e.Graphics.DrawLine(pen, beginPosition, endPosition);   
                    }
                }

                //串口服务器模拟线
                foreach (var line in chuanKouLines)
                {
                    if (line.Item1 != null && line.Item2 != null)
                    {
                        beginPosition = Add(Add(line.Item1.Location, line.Item1.Parent.Location), offset);
                        endPosition = Add(Add(line.Item2.Location, line.Item2.Parent.Location), offset);
                        e.Graphics.DrawLine(pen, beginPosition, endPosition);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public Point Add(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }
        #endregion

        #region 上下文菜单

        #region mudcontrolP
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;
                MUDControlP p = (MUDControlP)((ContextMenuStrip)item.Owner).SourceControl;//获取父控件
                for (int i = 0; i < mudFreLines.Count; i++)
                {
                    if (mudFreLines[i].Item2 == p.Box)
                    {
                        if (mudFreLines.Count == 1)
                        {
                            mudFreLines[i].Item1.BackColor = Color.WhiteSmoke;//频率接收端设置成初始颜色
                            mudControlP.FretransferState = false;             //频率传输状态设置不可用
                        }
                        mudFreLines.RemoveAt(i);
                        i--;
                    }
                }
                for (int i = 0; i < mudLevelLines.Count; i++)
                {
                    if (mudLevelLines[i].Item2 == p.Lab)
                    {
                        if (mudLevelLines.Count == 1)
                        {
                            mudLevelLines[i].Item1.BackColor = Color.WhiteSmoke;//高低电平接收端设置成初始颜色
                            mudControlP.LevtransferState = false;               //高低电平传输状态设置不可用
                        }
                        mudLevelLines.RemoveAt(i);
                        i--;
                    }
                }
                for (int i = 0; i < mudSpeedLines.Count; i++)
                {
                    mudSpeedLines[i].Item2.BackColor = Color.WhiteSmoke;//接收端设置成初始颜色
                    mudControlA.Moduleflag = false;//不可进行测速数据的传输
                    mudSpeedLines.RemoveAt(i);
                    i--;
                }
                mudControlPList.Remove(p);
                Controls.Remove(p);
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                mudControlP = new MUDControlP(this);
                mudControlP.ContextMenuStrip = contextMenuStrip1_MUDP;
                mudControlP.Location = new Point(mudControlP_StartX, mudControlP_StartY);
                mudControlP.BackColor = Color.AntiqueWhite;
                this.Controls.Add(mudControlP);
                mudControlP_StartX += 10;                   //再次实例化后更新位置
                mudControlP_StartY += 10;
                mudControlPList.Add(mudControlP);
                TextBox boxP = mudControlP.Box;
                boxP.MouseClick += boxP_MouseClick;     //添加对checkbox（频率接收端）的click事件，用于绘制通讯线
                Label labP = mudControlP.Lab;
                labP.MouseClick += labP_MouseClick;     //添加对Label（高低电平接收端）的click事件，用于绘制通讯线
                Label labSpeed = mudControlP.Label_Speed;
                labSpeed.MouseClick += labSpeed_MouseClick;//添加测速label的click事件，用于绘制通讯线
                mudControlP.Move += controlP_Move;         //添加controlP的Move事件
                mudControlC.MsgRevieced += mudControlP.Show;  //事件处理,两个用户控件之间的频率通信
                al.Add(mudControlP);

            }
            catch (Exception ex)
            {
            }
        }

        private void 模块移动ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (模块移动ToolStripMenuItem.Checked == true)
                MudControlPMS = true;
            else
                MudControlPMS = false;
        }

        private void 重命名模块ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            MudControlPReName = (MUDControlP)((ContextMenuStrip)item.Owner).SourceControl;//获取父控件
            MUDControlPReName rn = new MUDControlPReName();
            rn.Show();
        }

        private void 帮助ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("此模块暂无帮助");
        }

        private void 自定义ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            MUDControlP p = (MUDControlP)((ContextMenuStrip)item.Owner).SourceControl;//获取父控件           
            ColorDialog cg = new ColorDialog();
            cg.ShowDialog();
            MUDPControlColor = cg.Color;
            p.BackColor = MUDPControlColor;
        }
        #endregion

        #region mudcontrolC
        private void 删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;
                MUDControlC c = (MUDControlC)((ContextMenuStrip)item.Owner).SourceControl;//获取父控件
                for (int i = 0; i < mudFreLines.Count; i++)
                {
                    mudFreLines[i].Item2.BackColor = Color.WhiteSmoke;//频率接收端设置成初始颜色
                    mudControlP.FretransferState = false;             //频率传输状态设置不可用
                    mudFreLines.RemoveAt(i);
                    i--;
                }
                for (int i = 0; i < mudLevelLines.Count; i++)
                {
                    mudLevelLines[i].Item2.BackColor = Color.WhiteSmoke;//高低电平接收端设置成初始颜色
                    mudControlP.LevtransferState = false;               //高低电平传输状态设置不可用
                    mudLevelLines.RemoveAt(i);
                    i--;
                }
                Controls.Remove(c);
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 新建ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                mudControlC = new MUDControlC(this);
                mudControlC.ContextMenuStrip = contextMenuStrip2_MUDC;
                mudControlC.Location = new Point(mudControlC_StartX, mudControlC_StartY);
                mudControlC.BackColor = Color.AntiqueWhite;
                this.Controls.Add(mudControlC);
                mudControlC_StartY += 10;             //再次实例化后更新位置
                mudControlC_StartX += 10;
                TextBox boxC = mudControlC.Box;
                boxC.MouseClick += boxC_MouseClick;//添加对CheckBox（频率发出端）的click事件，用于绘制通讯线
                Label labC = mudControlC.Lab;
                labC.MouseClick += labC_MouseClick;//添加对Label（高低电平发出端）的click事件，用于绘制通讯线
                mudControlC.Move += controlC_Move;    //添加controlC的Move事件    
                al.Add(mudControlC);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 模块移动ToolStripMenuItem1_CheckedChanged(object sender, EventArgs e)
        {
            if (模块移动ToolStripMenuItem1.Checked == true)
                MudControlCMS = true;
            else
                MudControlCMS = false;
        }

        private void 重命名模块ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            MudControlCReName = (MUDControlC)((ContextMenuStrip)item.Owner).SourceControl;//获取父控件
            MUDControlCReName rn = new MUDControlCReName();
            rn.Show();
        }

        private void 帮助ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("此模块暂无帮助");
        }

        private void 自定义ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            MUDControlC c = (MUDControlC)((ContextMenuStrip)item.Owner).SourceControl;//获取父控件           
            ColorDialog cg = new ColorDialog();
            cg.ShowDialog();
            MUDCControlColor = cg.Color;
            c.BackColor = MUDCControlColor;
        }
        #endregion

        #region mudControlA
        private void 删除ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;
                MUDControlA a = (MUDControlA)((ContextMenuStrip)item.Owner).SourceControl;//获取父控件
                for (int i = 0; i < mudSpeedLines.Count; i++)
                {
                    //  controlP.FretransferState = false;             //频率传输状态设置不可用
                    mudSpeedLines[i].Item1.BackColor = Color.WhiteSmoke;//高低电平接收端设置成初始颜色
                    mudSpeedLines.RemoveAt(i);
                    i--;
                }
                Controls.Remove(a);
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 新建ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                mudControlA = new MUDControlA(this);
                mudControlA.ContextMenuStrip = Spped_contextMenuStrip4_MUDA;
                mudControlA.Location = new Point(mudControlA_StartX, mudControlA_StartY);
                mudControlA.BackColor = Color.AntiqueWhite;
                this.Controls.Add(mudControlA);
                mudControlA_StartY += 5;             //再次实例化后更新位置
                mudControlA_StartX += 5;
                Label labSpeedEnd = mudControlA.Label_SpeedEnd;
                labSpeedEnd.MouseClick += labSpeedEnd_MouseClick;//添加测速label的click事件，用于绘制通讯线
                mudControlA.Move += controlA_Move;
                mudControlC.MsgRevieced += mudControlA.Show;  //事件处理,两个用户控件之间的速度通信
                al.Add(mudControlA);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 模块移动ToolStripMenuItem2_CheckedChanged(object sender, EventArgs e)
        {
            if (模块移动ToolStripMenuItem2.Checked == true)
                MudControlAMS = true;
            else
                MudControlAMS = false;
        }

        private void 重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            MudControlAReName = (MUDControlA)((ContextMenuStrip)item.Owner).SourceControl;//获取父控件
            MUDControlAReName rn = new MUDControlAReName();
            rn.Show();
        }

        private void 帮助ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("此模块暂无帮助");
        }

        private void 自定义ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            MUDControlA a = (MUDControlA)((ContextMenuStrip)item.Owner).SourceControl;//获取父控件           
            ColorDialog cg = new ColorDialog();
            cg.ShowDialog();
            MUDAControlColor = cg.Color;
            a.BackColor = MUDAControlColor;
        }
        #endregion

        #region sjrControlP
        private void 新建ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                sjrControlP = new SJRControlP(this);
                sjrControlP.ContextMenuStrip = contextMenuStrip1_SJRP;
                sjrControlP.Location = new Point(sjrControlP_StartX, sjrControlP_StartY);
                sjrControlP.BackColor = Color.AntiqueWhite;
                this.Controls.Add(sjrControlP);
                sjrControlP_StartX += 10;                   //再次实例化后更新位置
                sjrControlP_StartY += 10;
                sjrControlPList.Add(sjrControlP);
                TextBox sjrBoxP = sjrControlP.Box;
                sjrBoxP.MouseClick += sjrBoxP_MouseClick;     //添加对Textbox（车辆检测接收端）的click事件，用于绘制通讯线
                Label sjrLabP = sjrControlP.Label_Coil;
                sjrLabP.MouseClick += sjrLabP_MouseClick;     //添加对Label（线圈编号接收端）的click事件，用于绘制通讯线
                Label sjrlabSpeed = sjrControlP.Label_Speed;
                sjrlabSpeed.MouseClick += sjrlabSpeed_MouseClick; //添加测速label的click事件，用于绘制通讯线
                sjrControlP.Move += sjrControlP_Move;         //添加controlP的Move事件
                sjrControlC.MsgRevieced += sjrControlP.Show;  //事件处理,两个用户控件之间的通信
                al.Add(sjrControlP);

            }
            catch (Exception ex)
            {
            }
        }

        private void 删除ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;
                SJRControlP p = (SJRControlP)((ContextMenuStrip)item.Owner).SourceControl;//获取父控件
                //车辆检测通讯线
                for (int i = 0; i < sjrLevelLines.Count; i++)
                {
                    if (sjrLevelLines[i].Item2 == p.Box)
                    {
                        if (sjrLevelLines.Count == 1)
                        {
                            sjrLevelLines[i].Item1.BackColor = Color.WhiteSmoke;//频率接收端设置成初始颜色
                            SJRControlC.CardetectLine_ButtonState = false;//不可进行车辆高低电平数据的传输
                        }
                        sjrLevelLines.RemoveAt(i);
                        i--;
                    }
                }
                //线圈检测通讯线
                for (int i = 0; i < sjrLoopLines.Count; i++)
                {
                    if (sjrLoopLines[i].Item2 == p.Label_Coil)
                    {
                        if (sjrLoopLines.Count == 1)
                        {
                            sjrLoopLines[i].Item1.BackColor = Color.WhiteSmoke;//高低电平接收端设置成初始颜色
                            SJRControlC.CoilCheckLine_ButtonState = true;//不可进行线圈编号数据传输
                        }
                        sjrLoopLines.RemoveAt(i);
                        i--;
                    }
                }
                //测速通讯线
                for (int i = 0; i < sjrSpeedLines.Count; i++)
                {
                    sjrSpeedLines[i].Item2.BackColor = Color.WhiteSmoke;//接收端设置成初始颜色
                    SJRControlA.SpeedLine = true;//不可进行速度数据的传输
                    sjrControlA.button1.Enabled = false;
                    sjrSpeedLines.RemoveAt(i);
                    i--;
                }
                sjrControlPList.Remove(p);
                Controls.Remove(p);
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 重命名ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            sjrControlPReName = (SJRControlP)((ContextMenuStrip)item.Owner).SourceControl;//获取父控件
            SJRControlPReName rn = new SJRControlPReName();
            rn.Show();
        }

        private void 帮助ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("此模块暂无帮助");
        }

        private void 模块移动ToolStripMenuItem3_CheckedChanged(object sender, EventArgs e)
        {
            if (模块移动ToolStripMenuItem3.Checked == true)
                SjrControlPMS = true;
            else
                SjrControlPMS = false;
        }

        private void 自定义ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            SJRControlP p = (SJRControlP)((ContextMenuStrip)item.Owner).SourceControl;//获取父控件           
            ColorDialog cg = new ColorDialog();
            cg.ShowDialog();
            SJRPControlColor = cg.Color;
            p.BackColor = SJRPControlColor;
        }
        #endregion

        #region sjrControlC
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                sjrControlC = new SJRControlC(this);
                sjrControlC.ContextMenuStrip = contextMenuStrip1_SJRC;
                sjrControlC.Location = new Point(sjrControlC_StartX, sjrControlC_StartY);
                sjrControlC.BackColor = Color.AntiqueWhite;
                this.Controls.Add(sjrControlC);
                sjrControlC_StartY += 10;             //再次实例化后更新位置
                sjrControlC_StartX += 10;
                TextBox sjrboxC = sjrControlC.Box;
                sjrboxC.MouseClick += sjrboxC_MouseClick; ;//添加对TextBox（车辆检测发出端）的click事件，用于绘制通讯线
                Label sjrlabC = sjrControlC.Lab;
                sjrlabC.MouseClick += sjrlabC_MouseClick; ;//添加对Label（线圈检测发出端）的click事件，用于绘制通讯线
                sjrControlC.Move += sjrControlC_Move; ;    //添加sjrcontrolC的Move事件    
                al.Add(sjrControlC);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

            try
            {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;
                SJRControlC c = (SJRControlC)((ContextMenuStrip)item.Owner).SourceControl;//获取父控件
                for (int i = 0; i < sjrLevelLines.Count; i++)
                {
                    sjrLevelLines[i].Item2.BackColor = Color.WhiteSmoke;//频率接收端设置成初始颜色
                    SJRControlC.CardetectLine_ButtonState = false;//不可进行车辆高低电平数据的传输
                    sjrLevelLines.RemoveAt(i);
                    i--;
                }
                for (int i = 0; i < sjrLoopLines.Count; i++)
                {
                    sjrLoopLines[i].Item2.BackColor = Color.WhiteSmoke;//高低电平接收端设置成初始颜色
                    SJRControlC.CoilCheckLine_ButtonState = true;//不可进行线圈编号数据传
                    sjrLoopLines.RemoveAt(i);
                    i--;
                }
                Controls.Remove(c);
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            sjrControlCReName = (SJRControlC)((ContextMenuStrip)item.Owner).SourceControl;//获取父控件
            SJRControlCReName rn = new SJRControlCReName();
            rn.Show();
        }

        private void toolStripMenuItem4_CheckedChanged(object sender, EventArgs e)
        {
            if (toolStripMenuItem4.Checked == true)
                SjrControlCMS = true;
            else
                SjrControlCMS = false;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("此模块暂无帮助");
        }

        private void 自定义ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            SJRControlC c = (SJRControlC)((ContextMenuStrip)item.Owner).SourceControl;//获取父控件           
            ColorDialog cg = new ColorDialog();
            cg.ShowDialog();
            SJRCControlColor = cg.Color;
            c.BackColor = SJRCControlColor;
        }
        #endregion

        #region sjrControlA
        private void 帮助ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("此模块暂无帮助");
        }

        private void 新建ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                sjrControlA = new SJRControlA(this);
                sjrControlA.ContextMenuStrip = contextMenuStrip1_SJRA;
                sjrControlA.Location = new Point(sjrControlA_StartX, sjrControlA_StartY);
                sjrControlA.BackColor = Color.AntiqueWhite;
                this.Controls.Add(sjrControlA);
                sjrControlA_StartY += 5;             //再次实例化后更新位置
                sjrControlA_StartX += 5;
                Label sjrlabSpeedEnd = sjrControlA.Label_SpeedEnd;
                sjrlabSpeedEnd.MouseClick += sjrlabSpeedEnd_MouseClick; ; ;//添加测速label的click事件，用于绘制通讯线
                sjrControlA.Move += sjrControlA_Move;
                al.Add(sjrControlA);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 删除ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;
                SJRControlA a = (SJRControlA)((ContextMenuStrip)item.Owner).SourceControl;//获取父控件
                for (int i = 0; i < sjrSpeedLines.Count; i++)
                {
                    sjrSpeedLines[i].Item1.BackColor = Color.WhiteSmoke;//高低电平接收端设置成初始颜色
                    sjrSpeedLines.RemoveAt(i);
                    i--;
                }
                Controls.Remove(a);
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 重命名模块ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            sjrControlAReName = (SJRControlA)((ContextMenuStrip)item.Owner).SourceControl;//获取父控件
            SJRControlAReName rn = new SJRControlAReName();
            rn.Show();
        }

        private void 模块移动ToolStripMenuItem4_CheckedChanged(object sender, EventArgs e)
        {
            if (模块移动ToolStripMenuItem4.Checked == true)
                SjrControlAMS = true;
            else
                SjrControlAMS = false;
        }

        private void 自定义ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            SJRControlA a = (SJRControlA)((ContextMenuStrip)item.Owner).SourceControl;//获取父控件           
            ColorDialog cg = new ColorDialog();
            cg.ShowDialog();
            SJRAControlColor = cg.Color;
            a.BackColor = SJRAControlColor;
        }
        #endregion

        #region 模拟

        private void 新建ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            try
            {
                coilSimControl = new CoilSimulateControl(this);
                coilSimControl.ContextMenuStrip = contextMenuStripCoilSim;
                coilSimControl.Location = new Point(coilSimControl_StartX, coilSimControl_StartY);
                coilSimControl_StartX += 5;
                coilSimControl_StartY += 5;
                this.Controls.Add(coilSimControl);
                Label coilSim_lab = coilSimControl.Lab;
                coilSim_lab.MouseClick += coilSim_lab_MouseClick;
                coilSimControl.Move += coilSimControl_Move;
                al.Add(coilSimControl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 新建ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            try
            {
                coilDetSimControl = new CoilDetectSimControl(this);
                coilDetSimControl.ContextMenuStrip = contextMenuStripcoilDet;
                coilDetSimControl.Location = new Point(coilDetSimControl_StartX, coilDetSimControl_StartY);
                coilDetSimControl_StartX += 5;
                coilDetSimControl_StartY += 5;
                this.Controls.Add(coilDetSimControl);
                foreach (var coilDet_lab in coilDetSimControl.Lab)
                {
                    coilDet_lab.MouseClick += coilDet_lab_MouseClick; ; ;//添加对checkbox的click事件，用于绘制通讯线
                }
                TextBox coilDet_Text = coilDetSimControl.Box;
                coilDet_Text.MouseClick += coilDet_Text_MouseClick;
                coilDetSimControl.Move += coilDetSimControl_Move;
                al.Add(coilDetSimControl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void 新建ToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            try
            {
                chuanKouControl = new ChuanKouSImControl(this);
                chuanKouControl.ContextMenuStrip = contextMenuStripchuanKou;
                chuanKouControl.Location = new Point(chuanKouControl_StartX, chuanKouControl_StartY);
                chuanKouControl_StartX += 5;
                chuanKouControl_StartY += 5;
                this.Controls.Add(chuanKouControl);
                foreach (var chuanKou_text in chuanKouControl.Box)
                {
                    chuanKou_text.MouseClick += chuanKou_text_MouseClick; ; ; ;//添加对checkbox的click事件，用于绘制通讯线
                }
                chuanKouControl.Move += chuanKouControl_Move;
                al.Add(chuanKouControl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //CoilSimulateControl
        private void 删除ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;
                CoilSimulateControl p = (CoilSimulateControl)((ContextMenuStrip)item.Owner).SourceControl;//获取父控件
                for (int i = 0; i < coilLinkLines.Count; i++)
                {
                    if (coilLinkLines[i].Item1 == p.Lab)
                    {
                        coilLinkLines[i].Item2.BackColor = Color.White;
                        coilLinkLines.RemoveAt(i);
                        // i--;
                    }
                }
                Controls.Remove(p);
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //CoilDetectSimControl
        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;
                CoilDetectSimControl p = (CoilDetectSimControl)((ContextMenuStrip)item.Owner).SourceControl;//获取父控件
                for (int i = 0; i < coilLinkLines.Count; i++)
                {
                    if (coilLinkLines[i].Item2 == p.Lab[0] || coilLinkLines[i].Item2 == p.Lab[1])
                    {
                        coilLinkLines[i].Item1.BackColor = Color.White;
                        coilLinkLines.RemoveAt(i);
                        i--;//上面已经remove了 所以如果还有第二条线的话 索引需要减一
                    }
                }
                for (int i = 0; i < chuanKouLines.Count; i++)
                {
                    if (chuanKouLines[i].Item1 == p.Box)
                    {
                        chuanKouLines[i].Item2.BackColor = Color.White;
                        chuanKouLines.RemoveAt(i);
                        // i--;
                    }
                }
                Controls.Remove(p);
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //ChuanKouSImControl
        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;
                ChuanKouSImControl p = (ChuanKouSImControl)((ContextMenuStrip)item.Owner).SourceControl;//获取父控件
                for (int i = 0; i < chuanKouLines.Count; i++)
                {
                    if (chuanKouLines[i].Item2 != null)
                    {
                        chuanKouLines[i].Item1.BackColor = Color.White;
                        chuanKouLines.RemoveAt(i);
                        // i--;
                    }
                }
                Controls.Remove(p);
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        #endregion

        #endregion

        #region 菜单栏

        #region 菜单项

        #region 模拟

        private void 线圈ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                coilSimControl = new CoilSimulateControl(this);
                coilSimControl.Parent = this;
                coilSimControl.ContextMenuStrip = contextMenuStripCoilSim;
                coilSimControl.Location = new Point(coilSimControl_StartX, coilSimControl_StartY);
                coilSimControl_StartX += 5;
                coilSimControl_StartY += 5;
                this.Controls.Add(coilSimControl);
                Label coilSim_lab = coilSimControl.Lab;
                coilSim_lab.MouseClick += coilSim_lab_MouseClick;
                coilSimControl.Move += coilSimControl_Move;
                al.Add(coilSimControl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 线圈检测器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                coilDetSimControl = new CoilDetectSimControl(this);
                coilDetSimControl.Parent = this;
                coilDetSimControl.ContextMenuStrip = contextMenuStripcoilDet;
                coilDetSimControl.Location = new Point(coilDetSimControl_StartX, coilDetSimControl_StartY);
                coilDetSimControl_StartX += 5;
                coilDetSimControl_StartY += 5;
                this.Controls.Add(coilDetSimControl);
                foreach (var coilDet_lab in coilDetSimControl.Lab)
                {
                    coilDet_lab.MouseClick += coilDet_lab_MouseClick; ; ;//添加对checkbox的click事件，用于绘制通讯线
                }
                TextBox coilDet_Text = coilDetSimControl.Box;
                coilDet_Text.MouseClick += coilDet_Text_MouseClick;
                coilDetSimControl.Move += coilDetSimControl_Move;
                al.Add(coilDetSimControl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 串口服务器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                chuanKouControl = new ChuanKouSImControl(this);
                chuanKouControl.Parent = this;

                chuanKouControl.ContextMenuStrip = contextMenuStripchuanKou;
                chuanKouControl.Location = new Point(chuanKouControl_StartX, chuanKouControl_StartY);
                chuanKouControl_StartX += 5;
                chuanKouControl_StartY += 5;
                this.Controls.Add(chuanKouControl);
                foreach (var chuanKou_text in chuanKouControl.Box)
                {
                    chuanKou_text.MouseClick += chuanKou_text_MouseClick; ; ; ;//添加对checkbox的click事件，用于绘制通讯线
                }
                chuanKouControl.Move += chuanKouControl_Move;
                al.Add(chuanKouControl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region MUD
        private void 数据处理ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                mudControlP = new MUDControlP(this);
                mudControlP.Parent = this;
                MUDPControlColor1 = Color.AntiqueWhite;
                mudControlP.ContextMenuStrip = contextMenuStrip1_MUDP;
                mudControlP.Location = new Point(mudControlP_StartX, mudControlP_StartY);
                mudControlP.BackColor = Color.AntiqueWhite;
                this.Controls.Add(mudControlP);
                mudControlP_StartX += 10;                   //再次实例化后更新位置
                mudControlP_StartY += 10;
                mudControlPList.Add(mudControlP);
                TextBox boxP = mudControlP.Box;
                boxP.MouseClick += boxP_MouseClick;     //添加对checkbox（频率接收端）的click事件，用于绘制通讯线
                Label labP = mudControlP.Lab;
                labP.MouseClick += labP_MouseClick;     //添加对Label（高低电平接收端）的click事件，用于绘制通讯线
                Label labSpeed = mudControlP.Label_Speed;
                labSpeed.MouseClick += labSpeed_MouseClick;//添加测速label的click事件，用于绘制通讯线
                mudControlP.Move += controlP_Move;         //添加controlP的Move事件
                mudControlC.MsgRevieced += mudControlP.Show;  //事件处理,两个用户控件之间的频率通信
                al.Add(mudControlP);

            }
            catch (Exception ex)
            {
            }
        }

        private void pToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                mudControlC = new MUDControlC(this);
                mudControlC.Parent = this;
                数据处理ToolStripMenuItem2.Enabled = true;
                数据分析ToolStripMenuItem2.Enabled = true;
                数据处理ToolStripMenuItem.Enabled = true;
                数据分析ToolStripMenuItem.Enabled = true;
                MUDCControlColor1 = Color.AntiqueWhite;
                mudControlC.ContextMenuStrip = contextMenuStrip2_MUDC;
                mudControlC.Location = new Point(mudControlC_StartX, mudControlC_StartY);
                mudControlC.BackColor = Color.AntiqueWhite;
                this.Controls.Add(mudControlC);
                mudControlC_StartY += 10;             //再次实例化后更新位置
                mudControlC_StartX += 10;
                TextBox boxC = mudControlC.Box;
                boxC.MouseClick += boxC_MouseClick;//添加对CheckBox（频率发出端）的click事件，用于绘制通讯线
                Label labC = mudControlC.Lab;
                labC.MouseClick += labC_MouseClick;//添加对Label（高低电平发出端）的click事件，用于绘制通讯线
                mudControlC.Move += controlC_Move;    //添加controlC的Move事件    
                al.Add(mudControlC);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 数据分析ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                mudControlA = new MUDControlA(this);
                mudControlA.Parent = this;

                MUDAControlColor1 = Color.AntiqueWhite;
                mudControlA.ContextMenuStrip = Spped_contextMenuStrip4_MUDA;
                mudControlA.Location = new Point(mudControlA_StartX, mudControlA_StartY);
                mudControlA.BackColor = Color.AntiqueWhite;
                this.Controls.Add(mudControlA);
                mudControlA_StartY += 5;             //再次实例化后更新位置
                mudControlA_StartX += 5;
                Label labSpeedEnd = mudControlA.Label_SpeedEnd;
                labSpeedEnd.MouseClick += labSpeedEnd_MouseClick;//添加测速label的click事件，用于绘制通讯线
                mudControlA.Move += controlA_Move;
                mudControlC.MsgRevieced += mudControlA.Show;  //事件处理,两个用户控件之间的速度通信
                al.Add(mudControlA);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region SJR
        private void 数据处理ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                sjrControlP = new SJRControlP(this);
                sjrControlP.Parent = this;
                SJRPControlColor1 = Color.AntiqueWhite;
                sjrControlP.ContextMenuStrip = contextMenuStrip1_SJRP;
                sjrControlP.Location = new Point(sjrControlP_StartX, sjrControlP_StartY);
                sjrControlP.BackColor = Color.AntiqueWhite;
                this.Controls.Add(sjrControlP);
                sjrControlP_StartX += 10;                   //再次实例化后更新位置
                sjrControlP_StartY += 10;
                sjrControlPList.Add(sjrControlP);
                TextBox sjrBoxP = sjrControlP.Box;
                sjrBoxP.MouseClick += sjrBoxP_MouseClick;     //添加对Textbox（车辆检测接收端）的click事件，用于绘制通讯线
                Label sjrLabP = sjrControlP.Label_Coil;
                sjrLabP.MouseClick += sjrLabP_MouseClick;     //添加对Label（线圈编号接收端）的click事件，用于绘制通讯线
                Label sjrlabSpeed = sjrControlP.Label_Speed;
                sjrlabSpeed.MouseClick += sjrlabSpeed_MouseClick; //添加测速label的click事件，用于绘制通讯线
                sjrControlP.Move += sjrControlP_Move;         //添加controlP的Move事件
                sjrControlC.MsgRevieced += sjrControlP.Show;  //事件处理,两个用户控件之间的通信
                al.Add(sjrControlP);

            }
            catch (Exception ex)
            {
            }
        }

        private void 数据采集ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                sjrControlC = new SJRControlC(this);
                sjrControlC.Parent = this;
                数据处理ToolStripMenuItem1.Enabled = true;
                数据分析ToolStripMenuItem1.Enabled = true;
                数据处理ToolStripMenuItem3.Enabled = true;
                数据分析ToolStripMenuItem3.Enabled = true;
                SJRCControlColor1 = Color.AntiqueWhite;
                sjrControlC.ContextMenuStrip = contextMenuStrip1_SJRC;
                sjrControlC.Location = new Point(sjrControlC_StartX, sjrControlC_StartY);
                sjrControlC.BackColor = Color.AntiqueWhite;
                this.Controls.Add(sjrControlC);
                sjrControlC_StartY += 10;             //再次实例化后更新位置
                sjrControlC_StartX += 10;
                TextBox sjrboxC = sjrControlC.Box;
                sjrboxC.MouseClick += sjrboxC_MouseClick; ;//添加对TextBox（车辆检测发出端）的click事件，用于绘制通讯线
                Label sjrlabC = sjrControlC.Lab;
                sjrlabC.MouseClick += sjrlabC_MouseClick; ;//添加对Label（线圈检测发出端）的click事件，用于绘制通讯线
                sjrControlC.Move += sjrControlC_Move; ;    //添加sjrcontrolC的Move事件    
                al.Add(sjrControlC);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 数据分析ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                sjrControlA = new SJRControlA(this);
                sjrControlA.Parent = this;

                SJRAControlColor1 = Color.AntiqueWhite;
                sjrControlA.ContextMenuStrip = contextMenuStrip1_SJRA;
                sjrControlA.Location = new Point(sjrControlA_StartX, sjrControlA_StartY);
                sjrControlA.BackColor = Color.AntiqueWhite;
                this.Controls.Add(sjrControlA);
                sjrControlA_StartY += 5;             //再次实例化后更新位置
                sjrControlA_StartX += 5;
                Label sjrlabSpeedEnd = sjrControlA.Label_SpeedEnd;
                sjrlabSpeedEnd.MouseClick += sjrlabSpeedEnd_MouseClick; ; ;//添加测速label的click事件，用于绘制通讯线
                sjrControlA.Move += sjrControlA_Move;
                al.Add(sjrControlA);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        private void 模块管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            mm = new ModuleManege(this);
            lg.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region 查看项

        private void 还原ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip1.Visible = true;
            statusStrip1.Visible = true;
            工具栏ToolStripMenuItem.Checked = true;
            状态栏ToolStripMenuItem.Checked = true;
        }

        private void 查询历史数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "excel File(*.xls)|*.xls";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                System.Diagnostics.Process.Start(fileName);
            }
        }
    

        private void 工具栏ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (工具栏ToolStripMenuItem.Checked == false)
                toolStrip1.Visible = false;
            else
                toolStrip1.Visible = true;
        }

        private void 状态栏ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (状态栏ToolStripMenuItem.Checked == false)
                statusStrip1.Visible = false;
            else
                statusStrip1.Visible = true;
        }

        private void 全屏显示ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (全屏显示ToolStripMenuItem.Checked == true)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void 最小化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void 自动隐藏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip1.Visible = false;
            statusStrip1.Visible = false;
            工具栏ToolStripMenuItem.Checked = false;
            状态栏ToolStripMenuItem.Checked = false;
        }


        #endregion

        #region 设置项


        private void 皮肤更换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Skin sk = new Skin(this);
            sk.Show();
        }

        private void 自定义窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cg = new ColorDialog();
            cg.ShowDialog();
            Color selectedColor = cg.Color;
            this.BackgroundImage = null;
            this.menuStrip1.BackgroundImage = null;
            this.menuStrip1.BackColor = Color.Transparent;
            this.toolStrip1.BackgroundImage = null;
            this.toolStrip1.BackColor = Color.Transparent;
            this.BackColor = selectedColor;
        }

        private void 自定义菜单栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cg = new ColorDialog();
            cg.ShowDialog();
            Color selectedColor = cg.Color;
            this.menuStrip1.BackgroundImage = null;
            this.menuStrip1.BackColor = selectedColor;
        }

        private void 自定义工具栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cg = new ColorDialog();
            cg.ShowDialog();
            Color selectedColor = cg.Color;
            this.toolStrip1.BackgroundImage = null;
            this.toolStrip1.BackColor = selectedColor;
        }

        private void 恢复默认ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.bc;
            this.menuStrip1.BackgroundImage = Properties.Resources.menutool_bc;
            this.toolStrip1.BackgroundImage = Properties.Resources.menutool_bc;
            this.skinEngine1.Active = false;
        }

        #endregion

        #region 帮助项

        private void 指导文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("D:\\总控平台需求说明.doc");
        }

        private void 技术支持ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("此模块暂无技术说明");
        }

        private void 订购帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Subscribe sc = new Subscribe();
            sc.Show();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyRight co = new CopyRight();
            co.Show();
        }

        #endregion

        #endregion

        #region 状态栏

        private void 场景模拟ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "场景模拟，可了解线圈、线圈检测器及串口服务器的连接模式";
        }

        private void 场景模拟ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void toolStripSplitButton3_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text="场景模拟，可了解线圈、线圈检测器及串口服务器的连接模式";
        }

        private void toolStripSplitButton3_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void 查询历史数据ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "查看用户保存的数据";
        }

        private void 查询历史数据ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void mUDToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "MUD3002检测器";
        }

        private void mUDToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void sJRToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "SJR检测器";
        }

        private void sJRToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void 数据处理ToolStripMenuItem2_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "MUD3002检测器数据处理模块";
        }

        private void 数据处理ToolStripMenuItem2_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void pToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "MUD3002检测器数据采集模块";
        }

        private void pToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void 数据分析ToolStripMenuItem2_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "MUD3002检测器数据分析模块";
        }

        private void 数据分析ToolStripMenuItem2_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void 数据处理ToolStripMenuItem3_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "SJR检测器数据处理模块";
        }

        private void 数据处理ToolStripMenuItem3_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void 数据采集ToolStripMenuItem2_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "SJR检测器数据采集模块";
        }

        private void 数据采集ToolStripMenuItem2_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void 数据分析ToolStripMenuItem3_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "SJR检测器数据分析模块";
        }

        private void 数据分析ToolStripMenuItem3_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void 工具栏ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "工具栏显示与隐藏";
        }

        private void 工具栏ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void 状态栏ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "状态栏显示与隐藏";
        }

        private void 状态栏ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void 全屏显示ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "全屏显示开关";
        }

        private void 全屏显示ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void 最小化ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "屏幕最小化";
        }

        private void 最小化ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void 自动隐藏ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "状态栏 工具栏隐藏";
        }

        private void 自动隐藏ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void toolStripSplitButton1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "MUD3002线圈检测";
        }

        private void toolStripSplitButton1_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void toolStripSplitButton2_MouseEnter(object sender, EventArgs e)
        {

            toolStripStatusLabel1.Text = "SJR线圈检测";
        }

        private void toolStripSplitButton2_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void 指导文件ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "模块使用说明文件";
        }

        private void 指导文件ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void 技术支持ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "模块技术说明";
        }

        private void 技术支持ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void 订购帮助ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "模块订购帮助";
        }

        private void 订购帮助ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void 关于ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "模块说明";
        }

        private void 关于ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void 模块管理ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "管理员管理模块";
        }

        private void 模块管理ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void 自定义窗体ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "用户自定义窗体背景";
        }

        private void 自定义窗体ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void 自定义菜单栏ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "用户自定义菜单栏";
        }

        private void 自定义菜单栏ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void 自定义工具栏ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "用户自定义工具栏";
        }

        private void 自定义工具栏ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void 恢复默认ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "恢复系统默认状态";
        }

        private void 恢复默认ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }
        #endregion

        private void toolStrip1_Paint(object sender, PaintEventArgs e)
        {
            if ((sender as ToolStrip).RenderMode == ToolStripRenderMode.System)
            {
                Rectangle rect = new Rectangle(0, 0, this.toolStrip1.Width - 2, this.toolStrip1.Height - 2);
                e.Graphics.SetClip(rect);
            }
        }

        private void 清空窗体ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            foreach (Control c in al)
            {
                 Controls.Remove(c);
            }
            for (int i = 0; i < coilLinkLines.Count; i++)
            {
                    coilLinkLines.RemoveAt(i);
                     i--;
            }
            for (int i = 0; i < chuanKouLines.Count; i++)
            {
                chuanKouLines.RemoveAt(i);
                i--;
            }
            for (int i = 0; i < mudFreLines.Count; i++)
            {
                mudFreLines.RemoveAt(i);
                i--;
            }
            for (int i = 0; i < mudLevelLines.Count; i++)
            {
                mudLevelLines.RemoveAt(i);
                i--;
            }
            for (int i = 0; i < mudSpeedLines.Count; i++)
            {
                mudSpeedLines.RemoveAt(i);
                i--;
            }
            for (int i = 0; i < sjrSpeedLines.Count; i++)
            {
                sjrSpeedLines.RemoveAt(i);
                i--;
            }
            for (int i = 0; i < sjrLoopLines.Count; i++)
            {
                sjrLoopLines.RemoveAt(i);
                i--;
            }
            for (int i = 0; i < sjrLevelLines.Count; i++)
            {
                sjrLevelLines.RemoveAt(i);
                i--;
            }
            Refresh();
            数据处理ToolStripMenuItem2.Enabled = false;
            数据分析ToolStripMenuItem2.Enabled = false;
            数据处理ToolStripMenuItem.Enabled = false;
            数据分析ToolStripMenuItem.Enabled = false;
            数据处理ToolStripMenuItem1.Enabled = false;
            数据分析ToolStripMenuItem1.Enabled = false;
            数据处理ToolStripMenuItem3.Enabled = false;
            数据分析ToolStripMenuItem3.Enabled = false;      
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.ContextMenuStrip = contextMenuStrip1;
            }
        }

   
    }  
}

