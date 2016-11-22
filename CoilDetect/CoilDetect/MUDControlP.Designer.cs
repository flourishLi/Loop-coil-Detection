namespace CoilDetect
{
    partial class MUDControlP
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
            this.label1 = new System.Windows.Forms.Label();
            this.frequency_CheckBox = new System.Windows.Forms.CheckBox();
            this.saveExcel_Button = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.levReceive_Lable = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.freReceive_textBox = new System.Windows.Forms.TextBox();
            this.label_Speed = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "MUD3002_数据处理";
            // 
            // frequency_CheckBox
            // 
            this.frequency_CheckBox.AutoSize = true;
            this.frequency_CheckBox.Location = new System.Drawing.Point(12, 60);
            this.frequency_CheckBox.Name = "frequency_CheckBox";
            this.frequency_CheckBox.Size = new System.Drawing.Size(72, 16);
            this.frequency_CheckBox.TabIndex = 1;
            this.frequency_CheckBox.Text = "频率检测";
            this.frequency_CheckBox.UseVisualStyleBackColor = true;
            this.frequency_CheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // saveExcel_Button
            // 
            this.saveExcel_Button.Location = new System.Drawing.Point(194, 53);
            this.saveExcel_Button.Name = "saveExcel_Button";
            this.saveExcel_Button.Size = new System.Drawing.Size(75, 23);
            this.saveExcel_Button.TabIndex = 2;
            this.saveExcel_Button.Text = "SaveAsExcel";
            this.saveExcel_Button.UseVisualStyleBackColor = true;
            this.saveExcel_Button.Click += new System.EventHandler(this.saveExcel_Button_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.time,
            this.Frequency,
            this.zero});
            this.dataGridView1.Location = new System.Drawing.Point(25, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(244, 231);
            this.dataGridView1.TabIndex = 3;
            // 
            // time
            // 
            this.time.FillWeight = 102.5103F;
            this.time.HeaderText = "时间";
            this.time.Name = "time";
            // 
            // Frequency
            // 
            this.Frequency.FillWeight = 121.3476F;
            this.Frequency.HeaderText = "频率/KZ";
            this.Frequency.Name = "Frequency";
            // 
            // zero
            // 
            this.zero.FillWeight = 76.14214F;
            this.zero.HeaderText = "0/1";
            this.zero.Name = "zero";
            // 
            // levReceive_Lable
            // 
            this.levReceive_Lable.BackColor = System.Drawing.Color.WhiteSmoke;
            this.levReceive_Lable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.levReceive_Lable.Location = new System.Drawing.Point(-1, 176);
            this.levReceive_Lable.Name = "levReceive_Lable";
            this.levReceive_Lable.Size = new System.Drawing.Size(16, 16);
            this.levReceive_Lable.TabIndex = 8;
            this.levReceive_Lable.MouseEnter += new System.EventHandler(this.levReceive_Lable_MouseEnter);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // freReceive_textBox
            // 
            this.freReceive_textBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.freReceive_textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.freReceive_textBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.freReceive_textBox.Location = new System.Drawing.Point(-1, 131);
            this.freReceive_textBox.Multiline = true;
            this.freReceive_textBox.Name = "freReceive_textBox";
            this.freReceive_textBox.ReadOnly = true;
            this.freReceive_textBox.Size = new System.Drawing.Size(16, 16);
            this.freReceive_textBox.TabIndex = 9;
            this.freReceive_textBox.TabStop = false;
            this.freReceive_textBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.freReceive_textBox_MouseDown);
            this.freReceive_textBox.MouseEnter += new System.EventHandler(this.freReceive_textBox_MouseEnter);
            // 
            // label_Speed
            // 
            this.label_Speed.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label_Speed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Speed.Location = new System.Drawing.Point(271, 149);
            this.label_Speed.Name = "label_Speed";
            this.label_Speed.Size = new System.Drawing.Size(16, 16);
            this.label_Speed.TabIndex = 10;
            // 
            // MUDControlP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label_Speed);
            this.Controls.Add(this.freReceive_textBox);
            this.Controls.Add(this.levReceive_Lable);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.saveExcel_Button);
            this.Controls.Add(this.frequency_CheckBox);
            this.Controls.Add(this.label1);
            this.Name = "MUDControlP";
            this.Size = new System.Drawing.Size(286, 315);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserControlP_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UserControlP_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UserControlP_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn zero;
        protected System.Windows.Forms.Button saveExcel_Button;
        public System.Windows.Forms.CheckBox frequency_CheckBox;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label levReceive_Lable;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox freReceive_textBox;
        private System.Windows.Forms.Label label_Speed;
        public System.Windows.Forms.Label label1;

    }
}
