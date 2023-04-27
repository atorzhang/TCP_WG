using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP_WG
{
    public class DebugHelper
    {
        public static bool IsDebugLog = true;
        private static string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\Log"; //路径

        public delegate void LogInfo(string msg);
        public static event LogInfo LogInfoHand;

        /// <summary>
        /// 默认不写日志，配置文件DebugLog开启后写调试日志
        /// </summary>
        /// <param name="msg"></param>
        public static void DebugLog(string msg, bool o = false)
        {
            if(LogInfoHand != null)
            {
                LogInfoHand($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}: {msg}\r\n");
            }
            if (IsDebugLog)
            {
                //写日志到专属的debug文件
                Write(msg);

                //写日志到原始文件
                if (o)
                {
                    //LogHelper.Write(msg);
                }
            }
        }

        /// <summary>
        /// 同步写日志消息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="fileSuffix"></param>
        public static void Write(string msg, string fileSuffix = "debug")
        {
            string logPath = "";
            try
            {
                logPath = filePath + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + $".{fileSuffix}.txt";
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                using (StreamWriter sw = File.AppendText(logPath))
                {
                    sw.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}: {msg}");
                    sw.WriteLine();
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
            catch (IOException e)
            {
            }
        }
    }
}
