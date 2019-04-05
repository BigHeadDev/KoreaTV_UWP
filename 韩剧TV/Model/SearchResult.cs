using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 韩剧TV.Model
{
    public class SearchResult
    {
        public int rescode { get; set; }
        public Int64 ts { get; set; }
        public string confVer { get; set; }
        public ObservableCollection<HanjuShort> seriesList { get; set; }
        public int censored { get; set; }
        public Int64 mode { get; set; }
        public int wmode { get; set; }
        public ObservableCollection<hotStars> starList { get; set; }
    }
}
