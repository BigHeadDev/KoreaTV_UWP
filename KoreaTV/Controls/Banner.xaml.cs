using KoreaTV.Model;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace KoreaTV.Controls {
    public sealed partial class Banner : UserControl {
        public Banner() {
            this.InitializeComponent();
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(3) };
        private bool leftToRight = true;

        public ObservableCollection<Banners> BannerModels {
            get { return (ObservableCollection<Banners>)GetValue(BannerModelsProperty); }
            set {
                SetValue(BannerModelsProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BannerModelsProperty =
            DependencyProperty.Register("BannerModels", typeof(ObservableCollection<Banners>), typeof(Banner), new PropertyMetadata(null));

        private void Timer_Tick(object sender, object e) {
            if (BannerModels == null) {
                return;
            }
            try {
                if (leftToRight) {
                    fvCenter.SelectedIndex = fvCenter.SelectedIndex + 1;
                    if (fvCenter.SelectedIndex == BannerModels.Count - 1) {
                        leftToRight = false;
                    }
                } else {
                    fvCenter.SelectedIndex = fvCenter.SelectedIndex - 1;
                    if (fvCenter.SelectedIndex == 0) {
                        leftToRight = true;
                    }
                }
            }
            catch { }
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e) {
            if (e.NewSize.Width < 762) {
                widCenter.Width = new GridLength(e.NewSize.Width);
                this.Height = this.ActualWidth / 762.0 * 282.0;
            } else {
                widCenter.Width = new GridLength(762);
                this.Height = 282;
            }
        }

        private int RefreshIndex(int index) {
            if (index < 0) {
                index = BannerModels.Count - 1;
            } else if (index > BannerModels.Count - 1) {
                index = 0;
            }
            return index;
        }

        private void fvCenter_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            fvLeft.SelectedIndex = RefreshIndex(fvCenter.SelectedIndex - 1);
            fvRight.SelectedIndex = RefreshIndex(fvCenter.SelectedIndex + 1);
        }
    }
}
