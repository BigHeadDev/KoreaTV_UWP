using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 韩剧TV.Model
{
    public class Zero
    {
	    public string order { get; set; }
        public string length { get; set; }
        public string size { get; set; }
        public string url { get; set; }
    }

    public class Durl
    {
        public Zero zz { get; set; }
    }

    public class BilibiliVideo
    {
        public Durl durl { get; set; }
    }
}
