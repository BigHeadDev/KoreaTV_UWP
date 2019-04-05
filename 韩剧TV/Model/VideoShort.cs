using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 韩剧TV.Model
{
    public class VideoShort
    {
        public int vid { get; set; }
        public string gvid { get; set; }
        public string title { get; set; }
        public List<Sources> sources { get; set; }
        public string thumb { get; set; }
        public string intro { get; set; }
        public int length { get; set; }
        public Int64 publishTime { get; set; }
        public int playCount { get; set; }
        public int danmuCount { get; set; }
        public int likeCount { get; set; }
        public int postCount { get; set; }
        public int videoType { get; set; }
        public int actType { get; set; }
        public Int64 updateTime { get; set; }
    }

    public class Sources
    {
        public string page { get; set; }//播放地址
        public int offset { get; set; }
        public int skip { get; set; }
        public int prior { get; set; }
    }
}
