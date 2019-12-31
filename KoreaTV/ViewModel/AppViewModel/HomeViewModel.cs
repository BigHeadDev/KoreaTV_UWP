using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using KoreaTV.AppClass;
using KoreaTV.Helper;
using KoreaTV.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace KoreaTV.ViewModel.AppViewModel {
    public class HomeViewModel:ViewModelBase {
        public HomeViewModel() {
            InitialData();
        }
        private static HomeModel homeDatas;
        private ObservableCollection<Banners> bannerDatas;
        public ObservableCollection<Banners> BannerDatas {
            get {
                return bannerDatas;
            }
            set {
                Set(() => BannerDatas, ref bannerDatas, value);
            }
        }

        private ObservableCollection<Recs> recsDatas;
        public ObservableCollection<Recs> RecsDatas {
            get {
                return recsDatas;
            }
            set {
                Set(() => RecsDatas, ref recsDatas, value);
            }
        }
        private Visibility loadingVisibility=Visibility.Collapsed;
        public Visibility LoadingVisibility {
            get {
                return loadingVisibility;
            }
            set {
                Set(() => LoadingVisibility, ref loadingVisibility, value);
            }
        }

        private RelayCommand<TappedRoutedEventArgs> bannerItemClikedCommand;
        public RelayCommand<TappedRoutedEventArgs> BannerItemClikedCommand {
            get {
                return bannerItemClikedCommand ?? new RelayCommand<TappedRoutedEventArgs>((obj) => {
                    if (obj.OriginalSource is Image) {
                        var image = (obj.OriginalSource as Image);
                        var banner = image.DataContext as Banners;
                    }
                });
            }
        }

        public async void InitialData() {
            LoadingVisibility = Visibility.Visible;
            string homeJson = await HttpHelper.HttpGet(Urls.HomeUrl);
            homeDatas = JsonHelper.ReadToObject<HomeModel>(homeJson);
            BannerDatas = homeDatas.banners;
            RecsDatas = homeDatas.recs;
            LoadingVisibility = Visibility.Collapsed;
        }
    }
}
