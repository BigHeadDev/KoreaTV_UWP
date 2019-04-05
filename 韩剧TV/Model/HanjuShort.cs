using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 韩剧TV.Model
{
    public class HanjuShort:VideoShort
    {
        public string sid { get; set; }//视频id
        public string name { get; set; }//视频名字
        public int rank { get; set; }//评分
        public bool isFinished { get; set; }//是否完结
        public bool isPreview { get; set; }
        public int living { get; set; }
        public int count { get; set; }//集数
    }
}
