using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 韩剧TV.Model
{
    public class Search
    {
        public int rescode { get; set; }
        public Int64 ts { get; set; }
        public ObservableCollection<string> hotWords { get; set; }
    }

}
