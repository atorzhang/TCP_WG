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
        /// <summary>
        /// 序列号
        /// </summary>
        public string SN { get; set; }

        /// <summary>
        /// 生成时段信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSD_Click(object sender, EventArgs e)
        {
            var snStr = Common.GetCmdStr(this.SN);
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

                var cmd = string.Format(ConstCtrl.BaseSDSZ, snStr[3], snStr[2], snStr[1], snStr[0], this.txtIndex.Text.PadLeft(2,'0'), sYear1, sYear2, sDate[0], sDate[1], eYear1, eYear2, eDate[0], eDate[1], stime1[0], stime1[1], etime1[0], etime1[1], stime2[0], stime2[1], etime2[0], etime2[1]); 
                WriteCmd(cmd);
            }
            else
            {
                MessageBox.Show("SN数据长度错误", "错误");
            }
        }

        /// <summary>
        /// 添加卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCard_Click(object sender, EventArgs e)
        {
            var snStr = Common.GetCmdStr(this.SN);
            var cardStr = Common.GetCardStr(Convert.ToInt64(this.txtCard.Text));
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

                var cmd = string.Format(ConstCtrl.BaseQXTJ, snStr[3], snStr[2], snStr[1], snStr[0], cardStr[0], cardStr[1], cardStr[2], cardStr[3], sYear1, sYear2, sDate[0], sDate[1], eYear1, eYear2, eDate[0], eDate[1], this.txtQXindex.Text.PadLeft(2, '0'));
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
            var snStr = Common.GetCmdStr(this.SN);
            if (snStr.Count == 4)
            {
                var cmd = string.Format(ConstCtrl.BaseSDQuery, snStr[3], snStr[2], snStr[1], snStr[0], this.txtQuerySD.Text.PadLeft(2, '0'));
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
            var snStr = Common.GetCmdStr(this.SN);
            if (snStr.Count == 4)
            {
                var cmd = string.Format(ConstCtrl.BaseSDClear, snStr[3], snStr[2], snStr[1], snStr[0]);
                WriteCmd(cmd);
            }
            else
            {
                MessageBox.Show("SN数据长度错误", "错误");
            }
        }

        /// <summary>
        /// 删除卡号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelCard_Click(object sender, EventArgs e)
        {
            var snStr = Common.GetCmdStr(this.SN);
            var cardStr = Common.GetCmdStr(this.txtCard.Text);
            if (snStr.Count == 4 && cardStr.Count == 4)
            {
                var cmd = string.Format(ConstCtrl.BaseQXDel, snStr[3], snStr[2], snStr[1], snStr[0], cardStr[0], cardStr[1], cardStr[2], cardStr[3]);
                WriteCmd(cmd);
            }
            else
            {
                MessageBox.Show("SN或者卡号数据长度错误", "错误");
            }
        }

        /// <summary>
        /// 删除所有卡号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelCards_Click(object sender, EventArgs e)
        {
            var snStr = Common.GetCmdStr(this.SN);
            if (snStr.Count == 4 )
            {
                var cmd = string.Format(ConstCtrl.BaseQXDelAll, snStr[3], snStr[2], snStr[1], snStr[0]);
                WriteCmd(cmd);
            }
            else
            {
                MessageBox.Show("SN数据长度错误", "错误");
            }
        }

        /// <summary>
        /// 获取已读取过的记录索引号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogIndexRead_Click(object sender, EventArgs e)
        {
            var snStr = Common.GetCmdStr(this.SN);
            if (snStr.Count == 4)
            {
                var cmd = string.Format(ConstCtrl.BaseLogIndexGet, snStr[3], snStr[2], snStr[1], snStr[0]);
                WriteCmd(cmd);
            }
            else
            {
                MessageBox.Show("SN数据长度错误", "错误");
            }
        }
        /// <summary>
        /// 设置已读取过的记录索引号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogIndexSet_Click(object sender, EventArgs e)
        {
            var snStr = Common.GetCmdStr(this.SN);
            var cardStr = Common.GetCmdStr(this.txtLogIndex.Text);
            if (snStr.Count == 4)
            {
                var cmd = string.Format(ConstCtrl.BaseLogIndexSet, snStr[3], snStr[2], snStr[1], snStr[0], cardStr[3], cardStr[2], cardStr[1], cardStr[0]);
                WriteCmd(cmd);
            }
            else
            {
                MessageBox.Show("SN数据长度错误", "错误");
            }
        }

        /// <summary>
        /// 读取日志，若记录号为0，读取第一条日志，若记录号为-1,读取最后一条日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogGet_Click(object sender, EventArgs e)
        {
            var index = Convert.ToInt64(this.txtLogIndex.Text.Trim());
            if(index < 0)
            {
                index = 0xffffffff;//4294967295;
            }
            var snStr = Common.GetCmdStr(this.SN);
            if(index > 0 && index != 16777215)
            {
                var num = Convert.ToInt64(this.txtLogCount.Text);
                for (var i = index - num; i <= index; i++)
                {
                    var indexStr = Common.GetCmdStr(i.ToString());
                    if (snStr.Count == 4)
                    {
                        var cmd = string.Format(ConstCtrl.BaseLogRead, snStr[3], snStr[2], snStr[1], snStr[0], indexStr[3], indexStr[2], indexStr[1], indexStr[0]);
                        WriteCmd(cmd);
                    }
                    else
                    {
                        MessageBox.Show("SN数据长度错误", "错误");
                    }
                }
            }
            else
            {
                var indexStr = Common.GetCmdStr(index.ToString());
                if (snStr.Count == 4)
                {
                    var cmd = string.Format(ConstCtrl.BaseLogRead, snStr[3], snStr[2], snStr[1], snStr[0], indexStr[3], indexStr[2], indexStr[1], indexStr[0]);
                    WriteCmd(cmd);
                }
                else
                {
                    MessageBox.Show("SN数据长度错误", "错误");
                }
            }
        }

        /// <summary>
        /// 查询控制器状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCtrlStatus_Click(object sender, EventArgs e)
        {
            var snStr = Common.GetCmdStr(this.SN);
            if (snStr.Count == 4)
            {
                var cmd = string.Format(ConstCtrl.BaseCtrlStatus, snStr[3], snStr[2], snStr[1], snStr[0]);
                WriteCmd(cmd);
            }
            else
            {
                MessageBox.Show("SN数据长度错误", "错误");
            }
        }
    }
}
