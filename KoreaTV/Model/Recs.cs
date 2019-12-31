using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoreaTV.Model {
	public class Recs: ObservableObject {
		public string type { get; set; }
		public string title { get; set; }
		public List<Items> items { get; set; }
		public string danmu { get; set; }
	}

	public class Items: ObservableObject {
		//公用
		public string publishTime { get; set; }
		public string thumb { get; set; }

		//韩剧
		public string sid { get; set; }
		public string name { get; set; }
		public string rank { get; set; }
		public bool isFinished { get; set; }
		
		public string intro { get; set; }
		
		public string poster { get; set; }
		public int count { get; set; }
		public string source { get; set; }
		public string category { get; set; }
		public bool isPreview { get; set; }
		public bool living { get; set; } = false;

		//视频
		public string vid { get; set; }
		public string gvid { get; set; }
		public string title { get; set; }
		public string actType { get; set; }
		public string videoType { get; set; }
		public string copyright { get; set; }




	}
}
