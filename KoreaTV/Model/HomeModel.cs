using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace KoreaTV.Model {
	public class HomeModel:ObservableObject {
		public string rescode { get; set; }
		public string ab415 { get; set; }
		public string ts { get; set; }
		public ObservableCollection<Recs> recs { get; set; }
		public ObservableCollection<CsmItems> csmItems { get; set; }
		public string ab400 { get; set; }
		public string feed { get; set; }
		public ObservableCollection<Banners> banners { get; set; }
	}
}
