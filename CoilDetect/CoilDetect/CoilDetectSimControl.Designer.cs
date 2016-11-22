namespace CoilDetect
{
    partial class CoilDetectSimControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoilDetectSimControl));
            this.label2 = new System.Windows.Forms.Label();
            this.coilDe_Lable1 = new System.Windows.Forms.Label();
            this.coilDe_lable2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.coilDe_textBox1 = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "线圈检测器";
            // 
            // coilDe_Lable1
            // 
            this.coilDe_Lable1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.coilDe_Lable1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.coilDe_Lable1.Location = new System.Drawing.Point(0, 38);
            this.coilDe_Lable1.Name = "coilDe_Lable1";
            this.coilDe_Lable1.Size = new System.Drawing.Size(16, 16);
            this.coilDe_Lable1.TabIndex = 12;
            this.coilDe_Lable1.MouseEnter += new System.EventHandler(this.coilDe_Lable1_MouseEnter);
            // 
            // coilDe_lable2
            // 
            this.coilDe_lable2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.coilDe_lable2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.coilDe_lable2.Location = new System.Drawing.Point(0, 77);
            this.coilDe_lable2.Name = "coilDe_lable2";
            this.coilDe_lable2.Size = new System.Drawing.Size(16, 16);
            this.coilDe_lable2.TabIndex = 13;
            this.coilDe_lable2.MouseEnter += new System.EventHandler(this.coilDe_lable2_MouseEnter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(22, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // coilDe_textBox1
            // 
            this.coilDe_textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.coilDe_textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.coilDe_textBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.coilDe_textBox1.Location = new System.Drawing.Point(104, 57);
            this.coilDe_textBox1.Multiline = true;
            this.coilDe_textBox1.Name = "coilDe_textBox1";
            this.coilDe_textBox1.ReadOnly = true;
            this.coilDe_textBox1.Size = new System.Drawing.Size(16, 16);
            this.coilDe_textBox1.TabIndex = 15;
            this.coilDe_textBox1.TabStop = false;
            this.coilDe_textBox1.MouseEnter += new System.EventHandler(this.coilDe_textBox1_MouseEnter);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // CoilDetectSimControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.coilDe_textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.coilDe_lable2);
            this.Controls.Add(this.coilDe_Lable1);
            this.Controls.Add(this.label2);
            this.Name = "CoilDetectSimControl";
            this.Size = new System.Drawing.Size(118, 118);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CoilDetectSimControl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CoilDetectSimControl_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CoilDetectSimControl_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label coilDe_Lable1;
        private System.Windows.Forms.Label coilDe_lable2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox coilDe_textBox1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
