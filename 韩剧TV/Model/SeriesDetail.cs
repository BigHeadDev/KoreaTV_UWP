using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 韩剧TV.Model
{
    public class SeriesDetail
    {
        public int rescode { get; set; }
        public string ts { get; set; }
        public HanjuDetail series { get; set; }
        public int more { get; set; }
    }
}
