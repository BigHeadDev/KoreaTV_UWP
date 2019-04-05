using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using 韩剧TV.Model;

namespace 韩剧TV.Tools.URLSources
{
    public class YONGJIUZY
    {
        public async static Task<string> SearchUrlByName(string name)
        {
            //查找所有韩国地区的项
            //如果只有一个
            //锁定
            //如果有多个-->
            //返回未找到
            List<KeyValuePair<string, string>> dataContent = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("wd",name),
                new KeyValuePair<string, string>("submit","search")
            };
            List<string> urls = new List<string>();
            NetHelper netHelper = new NetHelper();
            string htmlStr = await netHelper.RequestStrWithParams("http://yongjiuzy.cc/index.php?m=vod-search", dataContent);
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlStr);
            HtmlNodeCollection trs = htmlDocument.DocumentNode.SelectNodes(".//tr[@class='DianDian']");
            foreach (var item in trs)
            {
                if (item.InnerText.Replace("\r\n","-").Split(new char[] { '-' })[3].Contains("韩国"))
                {
                    urls.Add(item.LastChild.FirstChild.GetAttributeValue("href", null));
                }
            }
            return urls.Count == 1 ? "http://yongjiuzy.cc"+urls[0] : null;
        }
        public async static Task<string> GetPlayUrl(string url,int num,PlayType type)
        {
            int index = 0;
            NetHelper netHelper = new NetHelper();
            string htmlStr = await netHelper.RequestStr(url,null);
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlStr);
            HtmlNodeCollection inputs= htmlDocument.DocumentNode.SelectNodes(".//input[@name='copy_sel']");
            int count = inputs.Count;
            if (type==PlayType.weburl)
            {
                index += 0;
            }
            else if (type==PlayType.m3u8)
            {
                index += count/2+num-1;
            }
            string Playurl=inputs[index].GetAttributeValue("value", "");
            return Playurl;
        }
    }
}
