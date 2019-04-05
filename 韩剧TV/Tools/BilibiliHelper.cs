using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 韩剧TV.Model;

namespace 韩剧TV.Tools
{
    public class BilibiliHelper
    {
        public static async Task<string> GetUrlFromBilibili(string aid)
        {
            aid = aid.Split(new char[] { '/' })[4].Replace("av", "");
            string param= String.Format("http://api.bilibili.com/playurl?aid={0}&platform=html5&quality=1&vtype=mp4&type=jsonp", aid);
            NetHelper netHelper = new NetHelper();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("Cookie", " buvid3=test");
            string json = await netHelper.RequestStr(param,dic);
            json=json.Replace("\"0\"", "\"zz\"");
            BilibiliVideo bv= netHelper.GetView<BilibiliVideo>(json);
            return bv.durl.zz.url;
        }
    }
}
