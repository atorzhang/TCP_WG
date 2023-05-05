using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP_WG
{
    public class Common
    {
        public static List<string> GetSNStr(string snTxt)
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
                list.Add(sn16.Substring(i, 2));
            }
            return list;
        }
    }
}
