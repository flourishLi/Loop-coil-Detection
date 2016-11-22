namespace CoilDetect
{
    partial class NewControlC
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
            this.connect_Button = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ip_button1 = new System.Windows.Forms.Button();
            this.coilNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarON = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // connect_Button
            // 
            this.connect_Button.Location = new System.Drawing.Point(3, 61);
            this.connect_Button.Name = "connect_Button";
            this.connect_Button.Size = new System.Drawing.Size(75, 23);
            this.connect_Button.TabIndex = 11;
            this.connect_Button.Text = "Connect";
            this.connect_Button.UseVisualStyleBackColor = true;
            this.connect_Button.Click += new System.EventHandler(this.connect_Button_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.coilNum,
            this.CarON,
            this.Time,
            this.Length});
            this.dataGridView1.Location = new System.Drawing.Point(84, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(325, 359);
            this.dataGridView1.TabIndex = 16;
            // 
            // ip_button1
            // 
            this.ip_button1.Location = new System.Drawing.Point(3, 16);
            this.ip_button1.Name = "ip_button1";
            this.ip_button1.Size = new System.Drawing.Size(75, 23);
            this.ip_button1.TabIndex = 17;
            this.ip_button1.Text = "配置IP";
            this.ip_button1.UseVisualStyleBackColor = true;
            this.ip_button1.Click += new System.EventHandler(this.ip_button1_Click);
            // 
            // coilNum
            // 
            this.coilNum.HeaderText = "线圈编号";
            this.coilNum.Name = "coilNum";
            this.coilNum.Width = 78;
            // 
            // CarON
            // 
            this.CarON.HeaderText = "有无车辆(0/1)";
            this.CarON.Name = "CarON";
            this.CarON.Width = 78;
            // 
            // Time
            // 
            this.Time.HeaderText = "经过时间(ms)";
            this.Time.Name = "Time";
            this.Time.Width = 78;
            // 
            // Length
            // 
            this.Length.HeaderText = "故障(0/1)";
            this.Length.Name = "Length";
            this.Length.Width = 55;
            // 
            // NewControlC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.ip_button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.connect_Button);
            this.Name = "NewControlC";
            this.Size = new System.Drawing.Size(409, 364);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NewControlC_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NewControlC_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NewControlC_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button connect_Button;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button ip_button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn coilNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarON;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
    }
}
