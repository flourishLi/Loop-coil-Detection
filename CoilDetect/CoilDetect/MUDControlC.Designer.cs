namespace CoilDetect
{
    partial class MUDControlC
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.connect_Button = new System.Windows.Forms.Button();
            this.frequencyCheck_Button = new System.Windows.Forms.Button();
            this.coilCheck_Button = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.levTransfer_Lable = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.freTransfer_textBox = new System.Windows.Forms.TextBox();
            this.iP_button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "线圈编号：";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2"});
            this.comboBox1.Location = new System.Drawing.Point(243, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(48, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // connect_Button
            // 
            this.connect_Button.Location = new System.Drawing.Point(5, 79);
            this.connect_Button.Name = "connect_Button";
            this.connect_Button.Size = new System.Drawing.Size(75, 23);
            this.connect_Button.TabIndex = 2;
            this.connect_Button.Text = "Connect";
            this.connect_Button.UseVisualStyleBackColor = true;
            this.connect_Button.Click += new System.EventHandler(this.connect_Button_Click);
            // 
            // frequencyCheck_Button
            // 
            this.frequencyCheck_Button.Enabled = false;
            this.frequencyCheck_Button.Location = new System.Drawing.Point(201, 40);
            this.frequencyCheck_Button.Name = "frequencyCheck_Button";
            this.frequencyCheck_Button.Size = new System.Drawing.Size(75, 23);
            this.frequencyCheck_Button.TabIndex = 3;
            this.frequencyCheck_Button.Text = "频率检测";
            this.frequencyCheck_Button.UseVisualStyleBackColor = true;
            this.frequencyCheck_Button.Click += new System.EventHandler(this.frequencyCheck_Button_Click);
            // 
            // coilCheck_Button
            // 
            this.coilCheck_Button.Enabled = false;
            this.coilCheck_Button.Location = new System.Drawing.Point(201, 79);
            this.coilCheck_Button.Name = "coilCheck_Button";
            this.coilCheck_Button.Size = new System.Drawing.Size(75, 23);
            this.coilCheck_Button.TabIndex = 4;
            this.coilCheck_Button.Text = "线圈检测";
            this.coilCheck_Button.UseVisualStyleBackColor = true;
            this.coilCheck_Button.Click += new System.EventHandler(this.coilCheck_Button_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // levTransfer_Lable
            // 
            this.levTransfer_Lable.BackColor = System.Drawing.Color.WhiteSmoke;
            this.levTransfer_Lable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.levTransfer_Lable.Location = new System.Drawing.Point(277, 84);
            this.levTransfer_Lable.Name = "levTransfer_Lable";
            this.levTransfer_Lable.Size = new System.Drawing.Size(16, 16);
            this.levTransfer_Lable.TabIndex = 7;
            this.levTransfer_Lable.MouseEnter += new System.EventHandler(this.freTransfer_Lable_MouseEnter);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // freTransfer_textBox
            // 
            this.freTransfer_textBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.freTransfer_textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.freTransfer_textBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.freTransfer_textBox.Location = new System.Drawing.Point(277, 42);
            this.freTransfer_textBox.Multiline = true;
            this.freTransfer_textBox.Name = "freTransfer_textBox";
            this.freTransfer_textBox.ReadOnly = true;
            this.freTransfer_textBox.Size = new System.Drawing.Size(16, 16);
            this.freTransfer_textBox.TabIndex = 8;
            this.freTransfer_textBox.TabStop = false;
            this.freTransfer_textBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.freTransfer_textBox_MouseDown);
            this.freTransfer_textBox.MouseEnter += new System.EventHandler(this.freTransfer_textBox_MouseEnter);
            // 
            // iP_button1
            // 
            this.iP_button1.Location = new System.Drawing.Point(5, 42);
            this.iP_button1.Name = "iP_button1";
            this.iP_button1.Size = new System.Drawing.Size(75, 23);
            this.iP_button1.TabIndex = 9;
            this.iP_button1.Text = "服务器配置";
            this.iP_button1.UseVisualStyleBackColor = true;
            this.iP_button1.Click += new System.EventHandler(this.iP_button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "MUD3002_数据采集";
            // 
            // MUDControlC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.iP_button1);
            this.Controls.Add(this.freTransfer_textBox);
            this.Controls.Add(this.levTransfer_Lable);
            this.Controls.Add(this.coilCheck_Button);
            this.Controls.Add(this.frequencyCheck_Button);
            this.Controls.Add(this.connect_Button);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Name = "MUDControlC";
            this.Size = new System.Drawing.Size(294, 103);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserControlC_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UserControlC_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UserControlC_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button frequencyCheck_Button;
        private System.Windows.Forms.Button coilCheck_Button;
        protected System.Windows.Forms.Button connect_Button;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label levTransfer_Lable;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox freTransfer_textBox;
        private System.Windows.Forms.Button iP_button1;
        public System.Windows.Forms.Label label2;
    }
}
