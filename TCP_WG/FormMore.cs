using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP_WG
{
    public partial class FormMore : Form
    {
        public FormMore()
        {
            InitializeComponent();
        }

        public delegate void WriteCmdDelegate(string cmd);
        public WriteCmdDelegate WriteCmdEvent;

        private void WriteCmd(string cmd)
        {
            WriteCmdEvent?.Invoke(cmd);
        }
        public string SN { get; set; }

        /// <summary>
        /// 时段设置发送的报文
        /// </summary>
        public const string BaseSDSZ = "17 88 00 00 {0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} 01 01 01 01 01 01 01 {13} {14} {15} {16} {17} {18} {19} {20} 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";
        /// <summary>
        /// 时段查询
        /// </summary>
        public const string BaseSDQuery = "17 98 00 00 {0} {1} {2} {3} {4} 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00  00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";
        /// <summary>
        /// 清空时段
        /// </summary>
        public const string BaseSDClear = "17 8A 00 00 {0} {1} {2} {3} 55 AA AA 55 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";
        /// <summary>
        /// 权限添加或修改发送的报文
        /// </summary>
        public const string BaseQXTJ = "17 50 00 00 {0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14} {15} {16} {16} {16} {16} 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";

        /// <summary>
        /// 生成时段信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSD_Click(object sender, EventArgs e)
        {
            var snStr = Common.GetSNStr(this.SN);
            if (snStr.Count == 4)
            {
                //开始的年月日
                var sYear1 = dtStartDate.Value.Year.ToString().Substring(0,2);
                var sYear2 = dtStartDate.Value.Year.ToString().Substring(2);
                var sDate = dtStartDate.Value.ToString("MM dd").Split(' ');

                //结束的年月日
                var eYear1 = dtEndDate.Value.Year.ToString().Substring(0, 2);
                var eYear2 = dtEndDate.Value.Year.ToString().Substring(2);
                var eDate = dtEndDate.Value.ToString("MM dd").Split(' ');

                //时区1
                var stime1 = new string[2];
                var etime1 = new string[2];
                //时区2
                var stime2 = new string[2];
                var etime2 = new string[2];

                //时区数据填充
                if (!txtB1.Text.Contains(':') || !txtE1.Text.Contains(':') || !txtB2.Text.Contains(':') || !txtE2.Text.Contains(':'))
                {
                    MessageBox.Show("时区数据格式错误，应为12:00这种格式!");
                    return;
                }
                stime1 = txtB1.Text.Split(':');
                etime1 = txtE1.Text.Split(':');
                stime2 = txtB2.Text.Split(':');
                etime2 = txtE2.Text.Split(':');

                var cmd = string.Format(BaseSDSZ, snStr[3], snStr[2], snStr[1], snStr[0], this.txtIndex.Text.PadLeft(2,'0'), sYear1, sYear2, sDate[0], sDate[1], eYear1, eYear2, eDate[0], eDate[1], stime1[0], stime1[1], etime1[0], etime1[1], stime2[0], stime2[1], etime2[0], etime2[1]); 
                WriteCmd(cmd);
            }
            else
            {
                MessageBox.Show("SN数据长度错误", "错误");
            }
        }

        private void btnCard_Click(object sender, EventArgs e)
        {
            var snStr = Common.GetSNStr(this.SN);
            var cardStr = Common.GetSNStr(this.txtCard.Text);
            if (snStr.Count == 4)
            {
                //开始的年月日
                var sYear1 = dtSPickerQX.Value.Year.ToString().Substring(0, 2);
                var sYear2 = dtSPickerQX.Value.Year.ToString().Substring(2);
                var sDate = dtSPickerQX.Value.ToString("MM dd").Split(' ');

                //结束的年月日
                var eYear1 = dtEPickerQX.Value.Year.ToString().Substring(0, 2);
                var eYear2 = dtEPickerQX.Value.Year.ToString().Substring(2);
                var eDate = dtEPickerQX.Value.ToString("MM dd").Split(' ');

                var cmd = string.Format(BaseQXTJ, snStr[3], snStr[2], snStr[1], snStr[0], cardStr[0], cardStr[1], cardStr[2], cardStr[3], sYear1, sYear2, sDate[0], sDate[1], eYear1, eYear2, eDate[0], eDate[1], this.txtQXindex.Text.PadLeft(2, '0'));
                WriteCmd(cmd);
            }
            else
            {
                MessageBox.Show("SN数据长度错误", "错误");
            }
        }

        /// <summary>
        /// 时段查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSDQuery_Click(object sender, EventArgs e)
        {
            var snStr = Common.GetSNStr(this.SN);
            if (snStr.Count == 4)
            {
                var cmd = string.Format(BaseSDQuery, snStr[3], snStr[2], snStr[1], snStr[0], this.txtQuerySD.Text.PadLeft(2, '0'));
                WriteCmd(cmd);
            }
            else
            {
                MessageBox.Show("SN数据长度错误", "错误");
            }
        }

        /// <summary>
        /// 清除时段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearSD_Click(object sender, EventArgs e)
        {
            var snStr = Common.GetSNStr(this.SN);
            if (snStr.Count == 4)
            {
                var cmd = string.Format(BaseSDClear, snStr[3], snStr[2], snStr[1], snStr[0]);
                WriteCmd(cmd);
            }
            else
            {
                MessageBox.Show("SN数据长度错误", "错误");
            }
        }
    }
}
