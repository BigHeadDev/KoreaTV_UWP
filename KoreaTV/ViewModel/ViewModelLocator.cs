using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using KoreaTV.ViewModel.AppViewModel;

namespace KoreaTV.ViewModel {
    public class ViewModelLocator   {

        private static ViewModelLocator _current;
        public static ViewModelLocator Current => _current ?? (_current = new ViewModelLocator());
        public ViewModelLocator() {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<VideoPlayViewModel>();
        }

        public MainViewModel Main {
            get {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public HomeViewModel Home {
            get {
                return ServiceLocator.Current.GetInstance<HomeViewModel>();
            }
        }

        public VideoPlayViewModel VideoPlay {
            get {
                return ServiceLocator.Current.GetInstance<VideoPlayViewModel>();
            }
        }
    }
}