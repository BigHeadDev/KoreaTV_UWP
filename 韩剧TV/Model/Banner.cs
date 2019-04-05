using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 韩剧TV.Model
{
    public class Banner
    {
        public int action { get; set; }
        public int bid { get; set; }
        public Datas data { get; set; }
        public int height { get; set; }
        public string imgUrl { get; set; }
        public int tag { get; set; }
        public string  title { get; set; }
        public int width { get; set; }
    }
    public class Datas
    {
        public string sid { get; set; }
        public string gvid { get; set; }
        public int aid { get; set; }
        public string atitle { get; set; }
    }
}
