namespace TCP_WG
{
    partial class FormMore
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReadSD = new System.Windows.Forms.Button();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSD = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtE2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtB2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtE1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtB1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtQXindex = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnCard = new System.Windows.Forms.Button();
            this.dtEPickerQX = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dtSPickerQX = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCard = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtQuerySD = new System.Windows.Forms.TextBox();
            this.btnSDQuery = new System.Windows.Forms.Button();
            this.btnClearSD = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReadSD);
            this.groupBox1.Controls.Add(this.txtIndex);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnSD);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.dtEndDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtStartDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(695, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "时段设置";
            // 
            // btnReadSD
            // 
            this.btnReadSD.Location = new System.Drawing.Point(608, 13);
            this.btnReadSD.Name = "btnReadSD";
            this.btnReadSD.Size = new System.Drawing.Size(75, 23);
            this.btnReadSD.TabIndex = 13;
            this.btnReadSD.Text = "读取时段";
            this.btnReadSD.UseVisualStyleBackColor = true;
            // 
            // txtIndex
            // 
            this.txtIndex.Location = new System.Drawing.Point(418, 15);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(76, 21);
            this.txtIndex.TabIndex = 12;
            this.txtIndex.Text = "2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(371, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "索引号";
            // 
            // btnSD
            // 
            this.btnSD.Location = new System.Drawing.Point(527, 13);
            this.btnSD.Name = "btnSD";
            this.btnSD.Size = new System.Drawing.Size(75, 23);
            this.btnSD.TabIndex = 10;
            this.btnSD.Text = "生成时段";
            this.btnSD.UseVisualStyleBackColor = true;
            this.btnSD.Click += new System.EventHandler(this.btnSD_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtE2);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtB2);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(353, 42);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(335, 47);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "时区2设置";
            // 
            // txtE2
            // 
            this.txtE2.Location = new System.Drawing.Point(242, 19);
            this.txtE2.Name = "txtE2";
            this.txtE2.Size = new System.Drawing.Size(76, 21);
            this.txtE2.TabIndex = 8;
            this.txtE2.Text = "18:00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(183, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "截止时间";
            // 
            // txtB2
            // 
            this.txtB2.Location = new System.Drawing.Point(65, 19);
            this.txtB2.Name = "txtB2";
            this.txtB2.Size = new System.Drawing.Size(76, 21);
            this.txtB2.TabIndex = 6;
            this.txtB2.Text = "14:01";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "起始时间";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtE1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtB1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(6, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 47);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "时区1设置";
            // 
            // txtE1
            // 
            this.txtE1.Location = new System.Drawing.Point(242, 19);
            this.txtE1.Name = "txtE1";
            this.txtE1.Size = new System.Drawing.Size(76, 21);
            this.txtE1.TabIndex = 8;
            this.txtE1.Text = "14:00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(183, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "截止时间";
            // 
            // txtB1
            // 
            this.txtB1.Location = new System.Drawing.Point(65, 19);
            this.txtB1.Name = "txtB1";
            this.txtB1.Size = new System.Drawing.Size(76, 21);
            this.txtB1.TabIndex = 6;
            this.txtB1.Text = "12:00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "起始时间";
            // 
            // dtEndDate
            // 
            this.dtEndDate.Location = new System.Drawing.Point(248, 15);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(108, 21);
            this.dtEndDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "截止日期";
            // 
            // dtStartDate
            // 
            this.dtStartDate.Location = new System.Drawing.Point(66, 15);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(108, 21);
            this.dtStartDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "起始日期";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtQXindex);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.btnCard);
            this.groupBox4.Controls.Add(this.dtEPickerQX);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.dtSPickerQX);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txtCard);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(5, 204);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(695, 54);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "权限添加或修改";
            // 
            // txtQXindex
            // 
            this.txtQXindex.Location = new System.Drawing.Point(572, 19);
            this.txtQXindex.Name = "txtQXindex";
            this.txtQXindex.Size = new System.Drawing.Size(21, 21);
            this.txtQXindex.TabIndex = 14;
            this.txtQXindex.Text = "1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(500, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 14;
            this.label11.Text = "时段索引号";
            // 
            // btnCard
            // 
            this.btnCard.Location = new System.Drawing.Point(613, 19);
            this.btnCard.Name = "btnCard";
            this.btnCard.Size = new System.Drawing.Size(75, 23);
            this.btnCard.TabIndex = 14;
            this.btnCard.Text = "下发卡号";
            this.btnCard.UseVisualStyleBackColor = true;
            this.btnCard.Click += new System.EventHandler(this.btnCard_Click);
            // 
            // dtEPickerQX
            // 
            this.dtEPickerQX.Location = new System.Drawing.Point(248, 18);
            this.dtEPickerQX.Name = "dtEPickerQX";
            this.dtEPickerQX.Size = new System.Drawing.Size(108, 21);
            this.dtEPickerQX.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(189, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "截止日期";
            // 
            // dtSPickerQX
            // 
            this.dtSPickerQX.Location = new System.Drawing.Point(66, 18);
            this.dtSPickerQX.Name = "dtSPickerQX";
            this.dtSPickerQX.Size = new System.Drawing.Size(108, 21);
            this.dtSPickerQX.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "起始日期";
            // 
            // txtCard
            // 
            this.txtCard.Location = new System.Drawing.Point(406, 18);
            this.txtCard.Name = "txtCard";
            this.txtCard.Size = new System.Drawing.Size(76, 21);
            this.txtCard.TabIndex = 9;
            this.txtCard.Text = "1614493185";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(371, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "卡号";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnClearSD);
            this.groupBox5.Controls.Add(this.btnSDQuery);
            this.groupBox5.Controls.Add(this.txtQuerySD);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Location = new System.Drawing.Point(12, 122);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(695, 64);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "时段操作";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(125, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 9;
            this.label12.Text = "时段索引";
            // 
            // txtQuerySD
            // 
            this.txtQuerySD.Location = new System.Drawing.Point(184, 28);
            this.txtQuerySD.Name = "txtQuerySD";
            this.txtQuerySD.Size = new System.Drawing.Size(76, 21);
            this.txtQuerySD.TabIndex = 14;
            this.txtQuerySD.Text = "2";
            // 
            // btnSDQuery
            // 
            this.btnSDQuery.Location = new System.Drawing.Point(266, 28);
            this.btnSDQuery.Name = "btnSDQuery";
            this.btnSDQuery.Size = new System.Drawing.Size(75, 23);
            this.btnSDQuery.TabIndex = 14;
            this.btnSDQuery.Text = "读取时段";
            this.btnSDQuery.UseVisualStyleBackColor = true;
            this.btnSDQuery.Click += new System.EventHandler(this.btnSDQuery_Click);
            // 
            // btnClearSD
            // 
            this.btnClearSD.Location = new System.Drawing.Point(14, 28);
            this.btnClearSD.Name = "btnClearSD";
            this.btnClearSD.Size = new System.Drawing.Size(75, 23);
            this.btnClearSD.TabIndex = 15;
            this.btnClearSD.Text = "全时段清除";
            this.btnClearSD.UseVisualStyleBackColor = true;
            this.btnClearSD.Click += new System.EventHandler(this.btnClearSD_Click);
            // 
            // FormMore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 473);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormMore";
            this.Text = "更多指令生成";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtE2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtB2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtE1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtB1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSD;
        private System.Windows.Forms.TextBox txtIndex;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnReadSD;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtQXindex;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnCard;
        private System.Windows.Forms.DateTimePicker dtEPickerQX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtSPickerQX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCard;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtQuerySD;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSDQuery;
        private System.Windows.Forms.Button btnClearSD;
    }
}