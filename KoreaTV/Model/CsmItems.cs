using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoreaTV.Model {
	public class CsmItems: ObservableObject {
		public string type { get; set; }
		public string name { get; set; }
		public string icon { get; set; }
	}
}
