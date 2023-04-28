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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP_WG
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 远程开门(0x40)
        /// </summary>
        const string openCmd = "19 40 00 00 {0} {1} {2} {3} {4} 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";
        /// <summary>
        /// 1.17设置门控制参数(0x80)
        /// </summary>
        const string ctrlCmd = "17 80 00 00 {0} {1} {2} {3} {4} {5} {6} 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";
        public Form1()
        {
            InitializeComponent();
            DebugHelper.LogInfoHand += LogToText;
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
            Array.ForEach(requestInfo.Body, b => sb.Append($"{b} "));
            DebugHelper.DebugLog($"接收到客户端 {session.Config.Ip}:{session.Config.Port} 的数据：\r\n{sb.ToString()}\r\n");
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
            var snStr = getSNStr(this.textSN.Text);
            if(snStr.Count == 4)
            {
                var cmd = string.Format(openCmd, snStr[3], snStr[2], snStr[1], snStr[0], Convert.ToInt32(this.textDoor.Text).ToString("X").PadLeft(2,'0'));
                this.txtCmd.Text = cmd;
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

        public void Send()
        {
            if (appSession != null)
            {
                var bytes = StrToHexByte(this.txtCmd.Text);
                if (appSession.TrySend(bytes, 0, bytes.Length))
                {
                    DebugHelper.DebugLog("发送成功：" + this.txtCmd.Text);
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

        private List<string> getSNStr(string snTxt)
        {
            var sn = Convert.ToInt64(snTxt);
            var sn16 = sn.ToString("X");
            if (sn16.Length % 2 != 0)
            {
                sn16 = "0" + sn16;
            }
            List<string> list = new List<string>();
            for (int i = 0; i < sn16.Length; i += 2)
            {
                list.Add(sn16.Substring(i,2));
            }
            return list;
        }

        private void btnOnline_Click(object sender, EventArgs e)
        {
            var snStr = getSNStr(this.textSN.Text);
            if (snStr.Count == 4)
            {
                var cmd = string.Format(ctrlCmd, snStr[3], snStr[2], snStr[1], snStr[0], Convert.ToInt32(this.textDoor.Text).ToString("X").PadLeft(2, '0'), "03", "03");
                this.txtCmd.Text = cmd;
                TrySend();
            }
            else
            {
                MessageBox.Show("SN数据长度错误", "错误");
            }
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            var snStr = getSNStr(this.textSN.Text);
            if (snStr.Count == 4)
            {
                var cmd = string.Format(ctrlCmd, snStr[3], snStr[2], snStr[1], snStr[0], Convert.ToInt32(this.textDoor.Text).ToString("X").PadLeft(2, '0'), "01", "03");
                this.txtCmd.Text = cmd;
                TrySend();
            }
            else
            {
                MessageBox.Show("SN数据长度错误", "错误");
            }
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            var snStr = getSNStr(this.textSN.Text);
            if (snStr.Count == 4)
            {
                var cmd = string.Format(ctrlCmd, snStr[3], snStr[2], snStr[1], snStr[0], Convert.ToInt32(this.textDoor.Text).ToString("X").PadLeft(2, '0'), "02", "03");
                this.txtCmd.Text = cmd;
                TrySend();
            }
            else
            {
                MessageBox.Show("SN数据长度错误", "错误");
            }
        }
    }
}
