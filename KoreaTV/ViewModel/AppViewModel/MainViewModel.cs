using GalaSoft.MvvmLight;
using KoreaTV.Model;
using KoreaTV.View.AppPages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoreaTV.ViewModel.AppViewModel {
    public class MainViewModel:ViewModelBase {
        public MainViewModel() {
            
        }
        private Type framePage = typeof(HomePage);
        public Type FramePage {
            get {
                return framePage;
            }
            set {
                Set(() => FramePage, ref framePage, value);
            }
        }

        
    }
}
