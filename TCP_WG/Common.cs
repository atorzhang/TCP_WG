using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP_WG
{
    public class Common
    {
        public static List<string> GetCmdStr(string snTxt, int padLeft = 8)
        {
            var sn = Convert.ToInt64(snTxt);
            var sn16 = sn.ToString("X").PadLeft(padLeft,'0');
            if (sn16.Length % 2 != 0)
            {
                sn16 = "0" + sn16;
            }
            List<string> list = new List<string>();
            for (int i = 0; i < sn16.Length; i += 2)
            {
                list.Add(sn16.Substring(i, 2));
            }
            return list;
        }

        public static List<string> GetCardStr(long card)
        {
            var cardBytes = BitConverter.GetBytes(card);
            List<string> nums = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                nums.Add(cardBytes[i].ToString("X").PadLeft(2,'0'));
            }
            return nums;
        }

        public static Dictionary<string,string> DicLogType = new Dictionary<string, string>()
        {
            { "00","无记录"},
            { "01","刷卡开门"},
            { "02","门磁,按钮, 设备启动, 远程开门"},
            { "03","报警记录"},
            { "05","刷卡禁止通过: 电脑控制"},
            { "06","刷卡禁止通过: 没有权限"},
            { "07","刷卡禁止通过: 密码不对"},
            { "08","刷卡禁止通过: 反潜回"},
            { "09","刷卡禁止通过: 多卡"},
            { "0A","刷卡禁止通过: 首卡"},
            { "0B","刷卡禁止通过: 门为常闭"},
            { "0C","刷卡禁止通过: 互锁"},
            { "0D","刷卡禁止通过: 受刷卡次数限制"},
            { "0F","刷卡禁止通过: 卡过期或不在有效时段"},
            { "12","刷卡禁止通过: 原因不明"},
            { "14","按钮开门"},
            { "17","门打开[门磁信号]"},
            { "18","门关闭[门磁信号]"},
            { "19","超级密码开门"},
            { "1C","控制器上电"},
            { "1D","控制器复位"},
            { "1F","按钮不开门: 强制关门"},
            { "20","按钮不开门: 门不在线"},
            { "21","按钮不开门: 互锁"},
            { "22","胁迫报警"},
            { "25","门长时间未关报警[合法开门后]"},
            { "26","强行闯入报警"},
            { "27","火警"},
            { "28","强制关门"},
            { "29","防盗报警"},
            { "2A","烟雾煤气温度报警"},
            { "2B","紧急呼救报警"},
            { "2C","操作员远程开门"},
            { "2D","发卡器确定发出的远程开门"},
        };
    }
}
