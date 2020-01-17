using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoreaTV.Model;

namespace KoreaTV.ViewModel.AppViewModel {
    public class VideoPlayViewModel:ViewModelBase {

        private Items videoItem;
        public Items VideoItem {
            get {
                return videoItem;
            }
            set {
                Set(() => VideoItem, ref videoItem, value);
            }
        }
    }
}
