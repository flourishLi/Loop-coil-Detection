namespace CoilDetect
{
    partial class SJRControlP
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label_Speed = new System.Windows.Forms.Label();
            this.carReceive_textBox = new System.Windows.Forms.TextBox();
            this.coilReceive_Lable = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.saveExcel_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.frequency_CheckBox = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Coilnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OneZero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Speed
            // 
            this.label_Speed.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label_Speed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Speed.Location = new System.Drawing.Point(294, 139);
            this.label_Speed.Name = "label_Speed";
            this.label_Speed.Size = new System.Drawing.Size(16, 16);
            this.label_Speed.TabIndex = 17;
            this.label_Speed.MouseEnter += new System.EventHandler(this.label_Speed_MouseEnter);
            // 
            // carReceive_textBox
            // 
            this.carReceive_textBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.carReceive_textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.carReceive_textBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.carReceive_textBox.Location = new System.Drawing.Point(0, 120);
            this.carReceive_textBox.Multiline = true;
            this.carReceive_textBox.Name = "carReceive_textBox";
            this.carReceive_textBox.ReadOnly = true;
            this.carReceive_textBox.Size = new System.Drawing.Size(16, 16);
            this.carReceive_textBox.TabIndex = 16;
            this.carReceive_textBox.TabStop = false;
            this.carReceive_textBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.carReceive_textBox_MouseDown);
            this.carReceive_textBox.MouseEnter += new System.EventHandler(this.carReceive_textBox_MouseEnter);
            // 
            // coilReceive_Lable
            // 
            this.coilReceive_Lable.BackColor = System.Drawing.Color.WhiteSmoke;
            this.coilReceive_Lable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.coilReceive_Lable.Location = new System.Drawing.Point(0, 166);
            this.coilReceive_Lable.Name = "coilReceive_Lable";
            this.coilReceive_Lable.Size = new System.Drawing.Size(16, 16);
            this.coilReceive_Lable.TabIndex = 15;
            this.coilReceive_Lable.MouseEnter += new System.EventHandler(this.coilReceive_Lable_MouseEnter);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.time,
            this.Coilnumber,
            this.OneZero});
            this.dataGridView1.Location = new System.Drawing.Point(26, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(262, 231);
            this.dataGridView1.TabIndex = 14;
            // 
            // saveExcel_Button
            // 
            this.saveExcel_Button.Location = new System.Drawing.Point(195, 42);
            this.saveExcel_Button.Name = "saveExcel_Button";
            this.saveExcel_Button.Size = new System.Drawing.Size(75, 23);
            this.saveExcel_Button.TabIndex = 13;
            this.saveExcel_Button.Text = "SaveAsExcel";
            this.saveExcel_Button.UseVisualStyleBackColor = true;
            this.saveExcel_Button.Click += new System.EventHandler(this.saveExcel_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "SJR_数据处理";
            // 
            // frequency_CheckBox
            // 
            this.frequency_CheckBox.AutoSize = true;
            this.frequency_CheckBox.Location = new System.Drawing.Point(26, 49);
            this.frequency_CheckBox.Name = "frequency_CheckBox";
            this.frequency_CheckBox.Size = new System.Drawing.Size(72, 16);
            this.frequency_CheckBox.TabIndex = 18;
            this.frequency_CheckBox.Text = "线圈编号";
            this.frequency_CheckBox.UseVisualStyleBackColor = true;
            this.frequency_CheckBox.CheckedChanged += new System.EventHandler(this.frequency_CheckBox_CheckedChanged);
            // 
            // time
            // 
            this.time.FillWeight = 85.12685F;
            this.time.HeaderText = "时间";
            this.time.Name = "time";
            // 
            // Coilnumber
            // 
            this.Coilnumber.FillWeight = 106.599F;
            this.Coilnumber.HeaderText = "线圈编号（1/2）";
            this.Coilnumber.Name = "Coilnumber";
            // 
            // OneZero
            // 
            this.OneZero.FillWeight = 108.2742F;
            this.OneZero.HeaderText = "车辆检测（0/1）";
            this.OneZero.Name = "OneZero";
            // 
            // SJRControlP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.frequency_CheckBox);
            this.Controls.Add(this.label_Speed);
            this.Controls.Add(this.carReceive_textBox);
            this.Controls.Add(this.coilReceive_Lable);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.saveExcel_Button);
            this.Controls.Add(this.label1);
            this.Name = "SJRControlP";
            this.Size = new System.Drawing.Size(310, 303);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SJRControlP_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SJRControlP_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SJRControlP_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Speed;
        private System.Windows.Forms.TextBox carReceive_textBox;
        private System.Windows.Forms.Label coilReceive_Lable;
        public System.Windows.Forms.DataGridView dataGridView1;
        protected System.Windows.Forms.Button saveExcel_Button;
        public System.Windows.Forms.CheckBox frequency_CheckBox;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Coilnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn OneZero;
    }
}
