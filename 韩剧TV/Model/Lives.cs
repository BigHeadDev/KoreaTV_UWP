using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 韩剧TV.Model
{
    public class Lives
    {
        public int rescode { get; set; }
        public Int64 ts { get; set; }
        public ObservableCollection<Rooms> items { get; set; }
        public string longTitle { get; set; }
        public long online { get; set; }
        public int pid { get; set; }
        public string showthand { get; set; }
        public long showEnd { get; set; }
        public long showStart { get; set; }
        public string sid { get; set; }
        public long startTime { get; set; }
        public int stationId { get; set; }
        public string thumb { get; set; }
        public string title { get; set; }
    }

    public class LiveSource
    {
        public string src { get; set; }
        public string page { get; set; }
    }

    public class Rooms
    {
        public string rid { get; set; }
        public string title { get; set; }
        public LiveSource source { get; set; }
        public string thumb { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string screen { get; set; }
        public string online { get; set; }
    }

}
