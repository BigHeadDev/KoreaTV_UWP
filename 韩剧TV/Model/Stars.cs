using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 韩剧TV.Model
{
    public class Stars
    {
        public int rescode { get; set; }
        public Int64 ts { get; set; }
        public ObservableCollection<hotStars> hotStars { get; set; }
    }

    public class hotStars
    {
        public int sid { get; set; }
        public string name { get; set; }
        public string thumb { get; set; }
        public string baikeUrl { get; set; }
        public int fansCount { get; set; }
        public int rank { get; set; }
    }
}
