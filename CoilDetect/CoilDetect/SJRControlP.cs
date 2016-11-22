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
    public partial class SJRControlP : UserControl
    {
        Form1 fm;

        bool mouseDownState; //移动标志
        Point startPosition;

        public TextBox Box   
        {
            get { return carReceive_textBox; }
        }

        public Label Label_Coil 
        {
            get { return coilReceive_Lable; }
        }

        public Label Label_Speed //测速模块
        {
            get { return label_Speed; }
        }
        [DllImport("user32", EntryPoint = "HideCaret")]
        public static extern bool HideCaret(IntPtr hWnd);
        public SJRControlP(Form1 fm)
        {
            this.fm=fm;
            InitializeComponent();
            mouseDownState = false;
            startPosition = new Point();
        }
      
        private void frequency_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (frequency_CheckBox.Checked == true)
                dataGridView1.Columns.Remove(OneZero);
            else
                dataGridView1.Columns.Add(OneZero);
        }

        #region 窗体移动
        private void SJRControlP_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseDownState = true;
            this.startPosition = e.Location;
            this.BackColor =Form1.SJRPControlColor1 ;
        }

        private void SJRControlP_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mouseDownState&&Form1.SjrControlPMS)
            {
                int minX = this.Parent.Location.X;
                int maxX = this.Parent.Location.X + this.Parent.Width - 290;
                int maxY = this.Parent.Location.Y + this.Parent.Height-300;
                this.Location = new Point(Math.Max(minX, (Math.Min(this.Location.X + e.X - this.startPosition.X, maxX))),
                     Math.Min(Math.Max(this.Location.Y + e.Y - this.startPosition.Y, fm.toolStrip1.Location.Y + 75), maxY));

                this.BackColor = Color.Goldenrod;
            }
        }

        private void SJRControlP_MouseUp(object sender, MouseEventArgs e)
        {
            this.mouseDownState = false;
            this.BackColor = Form1.SJRPControlColor1;
        }
        #endregion

        public void Show(object sender, SJRControlCData data)
        {
            this.Invoke(new Action(() =>
            {
                int i;
                //输出车辆信号检测数据，不包含线圈编号
                if (SJRControlC.Cardetect_ButtonState == true && SJRControlC.CardetectLine_ButtonState == true && frequency_CheckBox.Checked == false)
                {
                    if (SJRControlC.CoilCheck_ButtonState == false || SJRControlC.CoilCheckLine_ButtonState == false)
                    {
                        i = dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = DateTime.Now.ToString("hh:mm:ss");
                        dataGridView1.Rows[i].Cells[2].Value = data.CarOrNot;
                    }

                     //输出车辆检测信号和线圈编号检测数据，
                    else if (SJRControlC.CoilCheck_ButtonState == true && SJRControlC.CoilCheckLine_ButtonState == true && frequency_CheckBox.Checked==false)
                    {
                        i = dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = DateTime.Now.ToString("hh:mm:ss");
                        dataGridView1.Rows[i].Cells[1].Value = data.LoopNum;
                        dataGridView1.Rows[i].Cells[2].Value = data.CarOrNot;
                    }
                }
                //输出线圈编号检测数据，
                else if (SJRControlC.CoilCheck_ButtonState == true && SJRControlC.CoilCheckLine_ButtonState)
                {
                    if (frequency_CheckBox.Checked == true)
                    {
                        i = dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = DateTime.Now.ToString("hh:mm:ss");
                        dataGridView1.Rows[i].Cells[1].Value = data.LoopNum;
                    }
                    else if (frequency_CheckBox.Checked == false)
                    {
                        if (SJRControlC.Cardetect_ButtonState == false || SJRControlC.CardetectLine_ButtonState == false)
                        {
                            i = dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells[0].Value = DateTime.Now.ToString("hh:mm:ss");
                            dataGridView1.Rows[i].Cells[1].Value = data.LoopNum;
                        }
                    }
                }
               
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
            }));
        }


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


        private void carReceive_textBox_MouseDown(object sender, MouseEventArgs e)
        {
            HideCaret((sender as TextBox).Handle);
        }

        //信息提示
        private void carReceive_textBox_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(carReceive_textBox, "车辆信号检测端口");
        }

        private void coilReceive_Lable_MouseEnter(object sender, EventArgs e)
        {
           toolTip1.SetToolTip(coilReceive_Lable, "线圈编号检测端口");  
        }

        private void label_Speed_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(label_Speed, "测速端口");  
        }

       

    }
}
