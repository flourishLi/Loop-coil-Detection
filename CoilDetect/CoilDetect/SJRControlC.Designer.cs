namespace CoilDetect
{
    partial class SJRControlC
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
            this.iP_button1 = new System.Windows.Forms.Button();
            this.carTransfer_textBox = new System.Windows.Forms.TextBox();
            this.coilTransfer_Lable = new System.Windows.Forms.Label();
            this.coilCheck_Button = new System.Windows.Forms.Button();
            this.cardetect_Button = new System.Windows.Forms.Button();
            this.connect_Button = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // iP_button1
            // 
            this.iP_button1.Location = new System.Drawing.Point(3, 41);
            this.iP_button1.Name = "iP_button1";
            this.iP_button1.Size = new System.Drawing.Size(75, 23);
            this.iP_button1.TabIndex = 17;
            this.iP_button1.Text = "服务器配置";
            this.iP_button1.UseVisualStyleBackColor = true;
            this.iP_button1.Click += new System.EventHandler(this.iP_button1_Click);
            // 
            // carTransfer_textBox
            // 
            this.carTransfer_textBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.carTransfer_textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.carTransfer_textBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.carTransfer_textBox.Location = new System.Drawing.Point(276, 43);
            this.carTransfer_textBox.Multiline = true;
            this.carTransfer_textBox.Name = "carTransfer_textBox";
            this.carTransfer_textBox.ReadOnly = true;
            this.carTransfer_textBox.Size = new System.Drawing.Size(16, 16);
            this.carTransfer_textBox.TabIndex = 16;
            this.carTransfer_textBox.TabStop = false;
            this.carTransfer_textBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.carTransfer_textBox_MouseDown);
            this.carTransfer_textBox.MouseEnter += new System.EventHandler(this.carTransfer_textBox_MouseEnter);
            // 
            // coilTransfer_Lable
            // 
            this.coilTransfer_Lable.BackColor = System.Drawing.Color.WhiteSmoke;
            this.coilTransfer_Lable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.coilTransfer_Lable.Location = new System.Drawing.Point(276, 85);
            this.coilTransfer_Lable.Name = "coilTransfer_Lable";
            this.coilTransfer_Lable.Size = new System.Drawing.Size(16, 16);
            this.coilTransfer_Lable.TabIndex = 15;
            this.coilTransfer_Lable.MouseEnter += new System.EventHandler(this.coilTransfer_Lable_MouseEnter);
            // 
            // coilCheck_Button
            // 
            this.coilCheck_Button.Enabled = false;
            this.coilCheck_Button.Location = new System.Drawing.Point(184, 80);
            this.coilCheck_Button.Name = "coilCheck_Button";
            this.coilCheck_Button.Size = new System.Drawing.Size(91, 23);
            this.coilCheck_Button.TabIndex = 14;
            this.coilCheck_Button.Text = "线圈编号检测";
            this.coilCheck_Button.UseVisualStyleBackColor = true;
            this.coilCheck_Button.Click += new System.EventHandler(this.coilCheck_Button_Click);
            // 
            // cardetect_Button
            // 
            this.cardetect_Button.Enabled = false;
            this.cardetect_Button.Location = new System.Drawing.Point(184, 41);
            this.cardetect_Button.Name = "cardetect_Button";
            this.cardetect_Button.Size = new System.Drawing.Size(91, 23);
            this.cardetect_Button.TabIndex = 13;
            this.cardetect_Button.Text = "车辆信号检测";
            this.cardetect_Button.UseVisualStyleBackColor = true;
            this.cardetect_Button.Click += new System.EventHandler(this.cardetect_Button_Click);
            // 
            // connect_Button
            // 
            this.connect_Button.Location = new System.Drawing.Point(3, 78);
            this.connect_Button.Name = "connect_Button";
            this.connect_Button.Size = new System.Drawing.Size(75, 23);
            this.connect_Button.TabIndex = 12;
            this.connect_Button.Text = "Connect";
            this.connect_Button.UseVisualStyleBackColor = true;
            this.connect_Button.Click += new System.EventHandler(this.connect_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "SJR_数据采集";
            // 
            // SJRControlC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.iP_button1);
            this.Controls.Add(this.carTransfer_textBox);
            this.Controls.Add(this.coilTransfer_Lable);
            this.Controls.Add(this.coilCheck_Button);
            this.Controls.Add(this.cardetect_Button);
            this.Controls.Add(this.connect_Button);
            this.Name = "SJRControlC";
            this.Size = new System.Drawing.Size(291, 109);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SJRControlC_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SJRControlC_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SJRControlC_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button iP_button1;
        private System.Windows.Forms.TextBox carTransfer_textBox;
        private System.Windows.Forms.Label coilTransfer_Lable;
        private System.Windows.Forms.Button coilCheck_Button;
        private System.Windows.Forms.Button cardetect_Button;
        protected System.Windows.Forms.Button connect_Button;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Label label1;
    }
}
