namespace TCP_WG
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textPort = new System.Windows.Forms.TextBox();
            this.port = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtCmd = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMore = new System.Windows.Forms.Button();
            this.btnOnline = new System.Windows.Forms.Button();
            this.btnOff = new System.Windows.Forms.Button();
            this.btnOn = new System.Windows.Forms.Button();
            this.textDoor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGen = new System.Windows.Forms.Button();
            this.textSN = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textPort
            // 
            this.textPort.Location = new System.Drawing.Point(48, 21);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(100, 21);
            this.textPort.TabIndex = 1;
            this.textPort.Text = "61005";
            // 
            // port
            // 
            this.port.AutoSize = true;
            this.port.Location = new System.Drawing.Point(13, 24);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(29, 12);
            this.port.TabIndex = 3;
            this.port.Text = "Port";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(154, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "监听";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 170);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(504, 261);
            this.textBox1.TabIndex = 5;
            // 
            // txtCmd
            // 
            this.txtCmd.Location = new System.Drawing.Point(48, 109);
            this.txtCmd.Multiline = true;
            this.txtCmd.Name = "txtCmd";
            this.txtCmd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCmd.Size = new System.Drawing.Size(375, 53);
            this.txtCmd.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(429, 133);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "发送指令";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "指令";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(444, 437);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "清除输出";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "SN";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMore);
            this.groupBox1.Controls.Add(this.btnOnline);
            this.groupBox1.Controls.Add(this.btnOff);
            this.groupBox1.Controls.Add(this.btnOn);
            this.groupBox1.Controls.Add(this.textDoor);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnGen);
            this.groupBox1.Controls.Add(this.textSN);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(15, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 53);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "指令生成";
            // 
            // btnMore
            // 
            this.btnMore.Location = new System.Drawing.Point(476, 21);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(25, 23);
            this.btnMore.TabIndex = 19;
            this.btnMore.Text = "...";
            this.btnMore.UseVisualStyleBackColor = true;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // btnOnline
            // 
            this.btnOnline.BackColor = System.Drawing.Color.SteelBlue;
            this.btnOnline.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOnline.Location = new System.Drawing.Point(265, 19);
            this.btnOnline.Name = "btnOnline";
            this.btnOnline.Size = new System.Drawing.Size(64, 28);
            this.btnOnline.TabIndex = 18;
            this.btnOnline.Text = "在线";
            this.btnOnline.UseVisualStyleBackColor = false;
            this.btnOnline.Click += new System.EventHandler(this.btnOnline_Click);
            // 
            // btnOff
            // 
            this.btnOff.BackColor = System.Drawing.Color.PaleVioletRed;
            this.btnOff.ForeColor = System.Drawing.SystemColors.Control;
            this.btnOff.Location = new System.Drawing.Point(404, 20);
            this.btnOff.Name = "btnOff";
            this.btnOff.Size = new System.Drawing.Size(64, 25);
            this.btnOff.TabIndex = 17;
            this.btnOff.Text = "常关";
            this.btnOff.UseVisualStyleBackColor = false;
            this.btnOff.Click += new System.EventHandler(this.btnOff_Click);
            // 
            // btnOn
            // 
            this.btnOn.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnOn.ForeColor = System.Drawing.SystemColors.Control;
            this.btnOn.Location = new System.Drawing.Point(333, 20);
            this.btnOn.Name = "btnOn";
            this.btnOn.Size = new System.Drawing.Size(64, 26);
            this.btnOn.TabIndex = 16;
            this.btnOn.Text = "常开";
            this.btnOn.UseVisualStyleBackColor = false;
            this.btnOn.Click += new System.EventHandler(this.btnOn_Click);
            // 
            // textDoor
            // 
            this.textDoor.Location = new System.Drawing.Point(154, 21);
            this.textDoor.Name = "textDoor";
            this.textDoor.Size = new System.Drawing.Size(30, 21);
            this.textDoor.TabIndex = 15;
            this.textDoor.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "门号";
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(193, 21);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(64, 23);
            this.btnGen.TabIndex = 13;
            this.btnGen.Text = "开门指令";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // textSN
            // 
            this.textSN.Location = new System.Drawing.Point(42, 20);
            this.textSN.Name = "textSN";
            this.textSN.Size = new System.Drawing.Size(71, 21);
            this.textSN.TabIndex = 12;
            this.textSN.Text = "133146962";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(432, 111);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "自动发送";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 466);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtCmd);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.port);
            this.Controls.Add(this.textPort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "微耕TCP通信调试工具 V0.01(只能连接一台设备)";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textPort;
        private System.Windows.Forms.Label port;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtCmd;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textDoor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.TextBox textSN;
        private System.Windows.Forms.Button btnOnline;
        private System.Windows.Forms.Button btnOff;
        private System.Windows.Forms.Button btnOn;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnMore;
    }
}

