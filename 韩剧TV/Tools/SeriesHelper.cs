using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using 韩剧TV.Model;
using 韩剧TV.Tools.URLSources;

namespace 韩剧TV.Tools
{
    public class SeriesHelper
    {
        public async static Task<string> GetSeriesURL(string name)
        {
            if (name.Contains("/"))
            {
                name = name.Split(new char[] { '/' })[0];
            }
            string s= await YONGJIUZY.SearchUrlByName(name);
            return s;  
        }
        public async static Task<string> GetPlayURL(string url, string num,PlayType type)
        {
            string s = await YONGJIUZY.GetPlayUrl(url, Convert.ToInt32(num), type);
            return s.Split(new char[] { '$' })[1];
        }
    }
}
