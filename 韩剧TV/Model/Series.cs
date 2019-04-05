using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 韩剧TV.Model
{
    public class Series
    {
        public int rescode { get; set; }
        public string ts { get; set; }
        public ObservableCollection<HanjuShort> seriesList { get; set; }
        public int more { get; set; }
    }
}
