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

namespace CoilDetect
{
    public partial class MUDControlP : UserControl
    {
        #region 变量声明
        Form1 fm;
        private bool mouseDownState; //移动标志
        private Point startPosition; //控件初始位置

        bool fretransferState;//频率数据传输状态
        bool levtransferState;//高低电平传输状态
        Form1 pform=new Form1();
        #endregion
        
        #region 属性
        public TextBox  Box
        {
            get { return  freReceive_textBox; }
        }

        public Label Label_Speed //测速模块
        {
            get { return label_Speed; }
        }

        public Label Lab //高低电平
        {
            get { return levReceive_Lable; }
        }

        public bool FretransferState
        {
            get { return fretransferState; }
            set { fretransferState = value; }
        }

        public bool LevtransferState
        {
            get { return levtransferState; }
            set { levtransferState = value; }
        }

        #endregion 
      
        //隐藏textbox的光标输入功能
        [DllImport("user32", EntryPoint = "HideCaret")]
        public static extern bool HideCaret(IntPtr hWnd);
        public MUDControlP(Form1 fm)
        {
            this.fm = fm;
            InitializeComponent();
            mouseDownState = false;           
            startPosition = new Point();
            fretransferState = false;
            levtransferState = false;
        }

        #region 窗体移动
        private void UserControlP_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseDownState = true;
            this.startPosition = e.Location;
            Point p = new Point(((MUDControlP)sender).Location.X, ((MUDControlP)sender).Location.X);
            this.BackColor = Form1.MUDPControlColor1 ;
        }

        private void UserControlP_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mouseDownState&&Form1.MudControlPMS)
            {
                int minX = this.Parent.Location.X;
                int maxX = this.Parent.Location.X + this.Parent.Width - 290;
                int maxY = this.Parent.Location.Y + this.Parent.Height - 300;
                this.Location = new Point(Math.Max(minX, (Math.Min(this.Location.X + e.X - this.startPosition.X, maxX))),
                     Math.Min(Math.Max(this.Location.Y + e.Y - this.startPosition.Y, fm.toolStrip1.Location.Y + 75), maxY));

                this.BackColor = Color.Goldenrod;
            }
        }

        private void UserControlP_MouseUp(object sender, MouseEventArgs e)
        {
            this.mouseDownState = false;
            this.BackColor = Form1.MUDPControlColor1;
        }
        #endregion

        #region 数据显示处理方法
        public void Show(object sender, MUDControlCData data)
        {
            this.Invoke(new Action(() =>
            {
                int i;
                //输出频率检测数据，不包含高低电平0/字段
                if (data.State == true && fretransferState == true)
                {
                    i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = DateTime.Now.ToString("hh:mm:ss");
                    dataGridView1.Rows[i].Cells[1].Value = data.C;
                }
                //输出线圈检测数据，
                else if (data.State == false)
                {
                    //仅输出频率数据
                    if (fretransferState == true && levtransferState == false||fretransferState == true && levtransferState == true&&frequency_CheckBox.Checked == true )
                    {
                        i = dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = DateTime.Now.ToString("hh:mm:ss");
                        dataGridView1.Rows[i].Cells[1].Value = data.C;
                    }
                    //仅输出高低电平数据
                    if (fretransferState == false && levtransferState == true && frequency_CheckBox.Checked == false)
                    {
                        i = dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = DateTime.Now.ToString("hh:mm:ss");
                        dataGridView1.Rows[i].Cells[2].Value = data.D;
                    }
                    //输出频率数据和高低电平数据
                   else if (frequency_CheckBox.Checked == false && levtransferState == true)
                    {
                        i = dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = DateTime.Now.ToString("hh:mm:ss");
                        dataGridView1.Rows[i].Cells[1].Value = data.C;
                        dataGridView1.Rows[i].Cells[2].Value = data.D;
                    }        
                }                      
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
            }));
        }
        #endregion

        #region 数据保存
 
        private void saveExcel_Button_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "导出Excel(*.xls)|*.xls";
            saveFileDialog.Title = "保存到";
            saveFileDialog.ShowDialog();
            string savePath = saveFileDialog.FileName;
            //创建Excel对象    
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workBook = excel.Application.Workbooks.Add(true);
            //生成字段名称    
            for (int i = 0; i < this.dataGridView1.ColumnCount; i++)
            {
                excel.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
            }
            //填充数据    
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            //循环行   
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                //循环列       
                {
                    if (dataGridView1[j, i].Value != null)
                    {
                        if (dataGridView1[j, i].ValueType == typeof(string))
                        {
                            excel.Cells[i + 2, j + 1] = "'" + dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                        else
                        {
                            excel.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }
            }
            excel.Visible = false;
            excel.DisplayAlerts = false;
            excel.AlertBeforeOverwriting = false;
            workBook.SaveAs(savePath);
            excel.Quit();
            MessageBox.Show("保存成功");
        }
        
        #endregion

        #region 提示

        private void freReceive_textBox_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(freReceive_textBox, "频率接收端口");
        }

        private void levReceive_Lable_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(levReceive_Lable, "高低电平接收端口");
        }
        #endregion

        //消除光标
        private void freReceive_textBox_MouseDown(object sender, MouseEventArgs e)
        {
            HideCaret((sender as TextBox).Handle);
        }

        //有无车辆信号检测
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (frequency_CheckBox.Checked == true)
                dataGridView1.Columns.Remove(zero);
            else
                dataGridView1.Columns.Add(zero);
        }
 

   
    }
}
