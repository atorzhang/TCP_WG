using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP_WG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DebugHelper.LogInfoHand += LogToText;
            //this.textSN.Text = "";//旧的222466751
        }
        public void LogToText(string msg)
        {
            this.textBox1.Invoke(new Action(() =>
            {
                this.textBox1.Text += msg;
                this.textBox1.SelectionStart = this.textBox1.Text.Length;
                this.textBox1.ScrollToCaret();
            }));
        }
        private delegate void BeginInvokeDelegate();

        private BinaryServer appServer;
        static BinarySession appSession;
        /// <summary>
        /// 监听socket
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            
            if(this.button1.Text == "监听")
            {
                BinaryReceiveFilterFactory filterFactory = new BinaryReceiveFilterFactory();
                appServer = new BinaryServer(filterFactory); ;
                var port = Convert.ToInt32(this.textPort.Text);
                if (!appServer.Setup(61005)) // Setup with listening port
                {
                    DebugHelper.DebugLog("Failed to Setup!");
                    return;
                }
                if (!appServer.Start())  //Try to start the appServer
                {
                    DebugHelper.DebugLog("Failed to start!");
                    return;
                }

                //SuperSocket自定义了三个事件 ,连接事件,接收事件,关闭事件
                appServer.NewSessionConnected += appServer_NewSessionConnected;
                appServer.NewRequestReceived += appServer_NewRequestReceived;
                appServer.SessionClosed += appServer_SessionClosed;

                this.button1.Text = "取消监听";
                DebugHelper.DebugLog("监听成功，端口号:"+ port);
            }
            else
            {
                appServer.Stop();
                //appServer.NewSessionConnected -= appServer_NewSessionConnected;
                //appServer.NewRequestReceived -= appServer_NewRequestReceived;
                //appServer.SessionClosed -= appServer_SessionClosed;
                this.button1.Text = "监听";
                DebugHelper.DebugLog("取消监听成功");
            }
        }

        /// <summary>
        /// 接收事件
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestInfo"></param>
        static void appServer_NewRequestReceived(BinarySession session, BinaryRequestInfo requestInfo)
        {
            StringBuilder sb = new StringBuilder();
            Array.ForEach(requestInfo.Body, b => sb.Append($"{Convert.ToString(b, 16).PadLeft(2,'0').ToUpper()} "));
            var str = sb.ToString().Trim();

            List<string> list = new List<string>();
            //粘包了，分包处理
            var splits = str.Split(' ');
            if (splits.Length / 64 > 1)
            {
                var sub = "";
                for (int i = 0; i < splits.Length; i++)
                {
                    sub += splits[i] + " ";
                    if ((i+1) % 64 == 0)
                    {
                        if (!sub.StartsWith("19 20 00 00"))
                        {
                            list.Add(sub.TrimEnd());
                        }
                        sub = "";
                    }
                }
            }
            else
            {
                if (!str.StartsWith("19 20 00 00"))
                {
                    list.Add(str);
                } 
            }
            if(list.Count > 0)
            {
                foreach (var item in list)
                {
                    if (item.StartsWith("17 B0 00 00"))
                    {
                        var cmdSplits = item.Split(' ');
                        //分析开门日志
                        //sn
                        var sn = Convert.ToInt64(cmdSplits[7] + cmdSplits[6] + cmdSplits[5] + cmdSplits[4], 16);
                        //刷卡记录的索引号
                        var index = Convert.ToInt64(cmdSplits[11] + cmdSplits[10] + cmdSplits[9] + cmdSplits[8], 16);
                        //记录类型,00无记录，01刷卡记录，02门磁,按钮, 设备启动, 远程开门记录，03报警记录
                        var logType = cmdSplits[12];
                        //有效性,00不允许，01通过
                        var isPass = cmdSplits[13];
                        //门号01-04
                        var doorNO = cmdSplits[14];
                        //进门/出门
                        var inOut = cmdSplits[15];
                        //卡号
                        var cardNo = Convert.ToInt64(cmdSplits[19] + cmdSplits[18] + cmdSplits[17] + cmdSplits[16], 16);
                        //刷卡时间
                        var time = $"{cmdSplits[20]}{cmdSplits[21]}-{cmdSplits[22]}-{cmdSplits[23]} {cmdSplits[24]}:{cmdSplits[25]}:{cmdSplits[26]}";
                        //记录原因代码
                        var reson = cmdSplits[27];
                        DebugHelper.DebugLog($"日志记录索引位={index}  卡号：{cardNo}  门号：{doorNO}  {(logType == "01" ? inOut == "01"?"进门":"出门":"")}  有效性：{isPass}  {time}  {Common.DicLogType[reson]}"  );
                    }
                    else
                    {
                        DebugHelper.DebugLog($"接收到客户端 {session.Config.Ip}:{session.Config.Port} 的数据：\r\n{item}\r\n");
                    }
                } 
            }
            //DebugHelper.DebugLog($"ASCII码：{Encoding.ASCII.GetString(requestInfo.Body)}");
        }

        /// <summary>
        /// 连接结束事件
        /// </summary>
        /// <param name="session"></param>
        /// <param name="value"></param>
        static void appServer_SessionClosed(BinarySession session, SuperSocket.SocketBase.CloseReason value)
        {
            string ipAddress_Close = session.RemoteEndPoint.ToString();
            DebugHelper.DebugLog("已关闭连接!  " + ipAddress_Close);
        }

        /// <summary>
        /// 连接事件
        /// </summary>
        /// <param name="session"></param>
        static void appServer_NewSessionConnected(BinarySession session)
        {
            DebugHelper.DebugLog("已连接!  " + session.RemoteEndPoint);
            appSession = session;
        }

        /// <summary>
        /// 发送指令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Send();
        }

        public static byte[] StrToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
        }

        /// <summary>
        /// 生成开门指令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGen_Click(object sender, EventArgs e)
        {
            var snStr = Common.GetCmdStr(this.textSN.Text);
            if(snStr.Count == 4)
            {
                var cmd = string.Format(ConstCtrl.openCmd, snStr[3], snStr[2], snStr[1], snStr[0], Convert.ToInt32(this.textDoor.Text).ToString("X").PadLeft(2,'0'));
                WriteCmd(cmd);
                TrySend();
            }
            else
            {
                MessageBox.Show("SN数据长度错误","错误");
            }
        }

        public void TrySend()
        {
            if (this.checkBox1.Checked)
            {
                Send();
            }
        }

        public void Send(int seleep = 50)
        {
            if (appSession != null)
            {
                var bytes = StrToHexByte(this.txtCmd.Text);
                if (appSession.TrySend(bytes, 0, bytes.Length))
                {
                    DebugHelper.DebugLog("发送成功：" + this.txtCmd.Text);
                    //Thread.Sleep(seleep);
                }
                else
                {
                    DebugHelper.DebugLog("发送失败");
                }
            }
            else
            {
                MessageBox.Show("客户端未连接无法发送", "提示");
            }
        }

       

        private void btnOnline_Click(object sender, EventArgs e)
        {
            var snStr = Common.GetCmdStr(this.textSN.Text);
            if (snStr.Count == 4)
            {
                var cmd = string.Format(ConstCtrl.ctrlCmd, snStr[3], snStr[2], snStr[1], snStr[0], Convert.ToInt32(this.textDoor.Text).ToString("X").PadLeft(2, '0'), "03", "03");
                WriteCmd(cmd);
            }
            else
            {
                MessageBox.Show("SN数据长度错误", "错误");
            }
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            var snStr = Common.GetCmdStr(this.textSN.Text);
            if (snStr.Count == 4)
            {
                var cmd = string.Format(ConstCtrl.ctrlCmd, snStr[3], snStr[2], snStr[1], snStr[0], Convert.ToInt32(this.textDoor.Text).ToString("X").PadLeft(2, '0'), "01", "03");
                WriteCmd(cmd);
            }
            else
            {
                MessageBox.Show("SN数据长度错误", "错误");
            }
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            var snStr = Common.GetCmdStr(this.textSN.Text);
            if (snStr.Count == 4)
            {
                var cmd = string.Format(ConstCtrl.ctrlCmd, snStr[3], snStr[2], snStr[1], snStr[0], Convert.ToInt32(this.textDoor.Text).ToString("X").PadLeft(2, '0'), "02", "03");
                WriteCmd(cmd);
            }
            else
            {
                MessageBox.Show("SN数据长度错误", "错误");
            }
        }

        public void WriteCmd(string cmd)
        {
            this.txtCmd.Text = cmd;
            TrySend();
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            FormMore formMore =  new FormMore();
            formMore.WriteCmdEvent += WriteCmd;
            formMore.SN = this.textSN.Text;
            formMore.Show();
        }
    }
}
