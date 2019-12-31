using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoreaTV.Model {
    public class Banners: ObservableObject {
        public string bid { get; set;}
        public string tag { get; set; }
        public string title { get; set; }
        public string imgUrl { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string action { get; set; }
        public Data data { get; set; }
    }

    public class Data: ObservableObject {
        public string aid { get; set; }
        public string atitle { get; set; }
    }
}
