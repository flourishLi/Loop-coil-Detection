namespace CoilDetect
{
    partial class CoilSimulateControl
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
            this.label2 = new System.Windows.Forms.Label();
            this.coilLable = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(32, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "线圈";
            // 
            // coilLable
            // 
            this.coilLable.BackColor = System.Drawing.Color.Transparent;
            this.coilLable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.coilLable.Location = new System.Drawing.Point(88, 42);
            this.coilLable.Name = "coilLable";
            this.coilLable.Size = new System.Drawing.Size(16, 16);
            this.coilLable.TabIndex = 12;
            this.coilLable.MouseEnter += new System.EventHandler(this.coilLable_MouseEnter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::CoilDetect.Properties.Resources.线圈;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(15, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 70);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // CoilSimulateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.coilLable);
            this.Controls.Add(this.label2);
            this.Name = "CoilSimulateControl";
            this.Size = new System.Drawing.Size(103, 98);
            this.Load += new System.EventHandler(this.CoilSimulateControl_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CoilSimulateControl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CoilSimulateControl_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CoilSimulateControl_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label coilLable;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
