using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 韩剧TV.Model
{
    public class Home
    {
        public int rescode { get; set; }
        public string ts { get; set; }
        public ObservableCollection<Recs> recs { get; set; }
        public ObservableCollection<Banner> banners { get; set; }
        public ObservableCollection<csmItems> csmItems { get; set; }
    }
    public class Recs
    {
        public int type { get; set; }
        public string title { get; set; }
        public ObservableCollection<HanjuShort> items { get; set; }
        public ObservableCollection<Lives> extItems { get; set; }
    }

}
