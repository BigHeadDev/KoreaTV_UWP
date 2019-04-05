using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 韩剧TV.Model
{
    public class HanjuDetail:VideoShort
    {
        public string sid { get; set; }//视频id
        public string name { get; set; }//视频名字
        public int rank { get; set; }//评分
        public bool isFinished { get; set; }//是否完结
        public bool isPreview { get; set; }
        public int living { get; set; }
        public int count { get; set; }//集数
        public string source { get; set; }//来源
        public int category { get; set; }//目录
        public string crew { get; set; }//主演
        public string shorthand { get; set; }//短评
        public string intro { get; set; }//简介
    }
}
