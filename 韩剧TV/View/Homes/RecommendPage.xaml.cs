using Microsoft.Toolkit.Uwp.UI.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using 韩剧TV.Tools;
using 韩剧TV.Model;
using 韩剧TV.View.Seriess;
using 韩剧TV.View.MediaPlayer;
using System.Threading.Tasks;
using 韩剧TV.controls;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace 韩剧TV.View.Homes
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class RecommendPage : Page
    {
        public RecommendPage()
        {
            this.InitializeComponent();
            Initial();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
            this.SizeChanged += RecommendPage_SizeChanged;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new System.TimeSpan(0, 0, 3);
            timer.Tick += (sender, args) =>
            {
                this.fvCenter.SelectedIndex = this.fvCenter.SelectedIndex < this.fvCenter.Items.Count - 1 ? ++this.fvCenter.SelectedIndex : 0;
            };
            timer.Start();
        }
        private void RecommendPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _scale = 727 / this.ActualWidth;
            //焦点图自适应
            Refresh(e.NewSize.Width);
            //菜单自适应
            gridScnd.Width = this.ActualWidth;
            //Thumb自适应
            int hw = Convert.ToInt32(this.ActualWidth / 120);
            int vw = Convert.ToInt32(this.ActualWidth / 180);
            if (this.ActualWidth <= 500)
            {
                hanjuThumb_width.Width = ActualWidth / 3 - 20;
                videoThumb_width.Width = ActualWidth / 2 - 20;
            }
            else if(this.ActualWidth<=660)
            {
                hanjuThumb_width.Width = ActualWidth / hw - 15;
                videoThumb_width.Width = ActualWidth / vw - 17;
            }
            else if(this.ActualWidth<=990)
            {
                hanjuThumb_width.Width = ActualWidth / 6 - 15;
                videoThumb_width.Width = ActualWidth / vw - 17;
            }
            else
            {
                hanjuThumb_width.Width = ActualWidth / 6 - 15;
                videoThumb_width.Width = ActualWidth / 6 - 17;
            }
        }

        private void Refresh(double width)
        {
            if (width <= 727)
            {
                gridCenter.Width = this.ActualWidth;
                gridroot.Height = 282 / _scale;
                gridColumL.MaxWidth = 0;
                gridColumR.MaxWidth = 0;
            }
            else
            {
                gridCenter.Width = 727;
                gridroot.Height = 282;
                gridColumL.MaxWidth = (ActualWidth - 727) / 2;
                gridColumR.MaxWidth = (ActualWidth - 727) / 2;
                gridroot.Width = this.ActualWidth;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new System.TimeSpan(0, 0, 3);
            timer.Tick += (sender, args) =>
            {
                this.fvCenter.SelectedIndex = this.fvCenter.SelectedIndex < this.fvCenter.Items.Count - 1 ? ++this.fvCenter.SelectedIndex : 0;
            };
            timer.Start();
        }
        public NetHelper netHelper = new NetHelper();
        public static string homeRequestUrl = "http://api.hanju.koudaibaobao.com/api/index/recommend_v2";
        public Home home = new Home();
        public Dictionary<string, string> homeDics = new Dictionary<string, string>();
        public ObservableCollection<Banner> banners = new ObservableCollection<Banner>();
        public ObservableCollection<csmItems> csms = new ObservableCollection<csmItems>();
        public ObservableCollection<Recs> recs = new ObservableCollection<Recs>();
        public ObservableCollection<BitmapImage> images = new ObservableCollection<BitmapImage>();
        private double _scale=1.0;
        public async void Initial()
        {
            
            homeDics.Add("sign", @"Bpxz9Z7xA7lENVMLI+HDqK0JaEVaemQcYN2U9Z+VRtwjvRXwvc2okw8etkN8T6ZV7rcVRUuVWQO6VGIO3bkXolBpBXGnFSMHgxJuPzTPGCKboKvHiY4NBc1gdF9Ja0ovZCfOjGEicUQ/405u8pgXBQpJ5UT2sOhe96hBopejNDmoZJyWcU+P2jckTOB5quZpNKQErJDc9LdPvBlS5xRyqMf4uQQF2m+eYFR/bU7/1aApXXgBYwT/+xQ2ef85o2WB7r3mUuf7C6ByPZNf2XNGjRvHeRC7ixg81ZUbKp/x0XW4C2AfMul42yB8SA+MvG9xhGeK78xNHCcaRFJ1/3Ep5uaFdXMbqmrokG09TZqcvNFlbpeb2qX1jr/HWV8qA65TnDdPdWIr2VJLPiD8sAHCIdJ9Sw/5AiQxX25oDgPgzVpWsSqxp8YlZdwO5b4cdPKurVYf38D/rGPqCgLh+9JRkPdNGvLrn569NCwDjHx/LtSHBMyM6nUZmxDPpXtJ/a6sF3h0RADF00z2nImkC0KiusgTEqO2dy2pva0OaaWhy48=");
            string homeJson=await netHelper.RequestStr(homeRequestUrl, homeDics);
            home = netHelper.GetView<Home>(homeJson);
            //首页焦点图
            banners = home.banners;
            this.fvCenter.ItemsSource = new ObservableCollection<BitmapImage>();
            foreach (var banner in banners)
            {
                images.Add(new BitmapImage(new System.Uri(banner.imgUrl, System.UriKind.RelativeOrAbsolute)));
            }
            fvCenter.ItemsSource = images;
            fvLeft.ItemsSource = images;
            fvRight.ItemsSource = images;
            if (images.Count!=0)
            {
                gridroot.Visibility = Visibility.Visible;
                fvCenter.SelectedIndex = 0;
            }
            

            //下方菜单
            csms = home.csmItems;
            lvCsm.ItemsSource = csms;

            //gridS
            recs = home.recs;
            lvRecs.ItemsSource = recs;
        }

        private void FvCenter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fvRight.ItemsSource == null || fvLeft.ItemsSource == null)
            {
                return;
            }
            this.fvLeft.SelectedIndex = this.fvCenter.SelectedIndex - 1;
            if (fvLeft.SelectedIndex == -1)
            {
                fvLeft.SelectedIndex = fvCenter.Items.Count - 1;
            }
            try
            {
                this.fvRight.SelectedIndex = this.fvCenter.SelectedIndex + 1;
            }
            catch
            {
                fvRight.SelectedIndex = 0;
            }
        }

        private async void Video_ItemClick(object sender, ItemClickEventArgs e)
        {
            HanjuShort hanjuShort = e.ClickedItem as HanjuShort;
            string Url = hanjuShort.sources[0].page;
            if (Url.Contains("bilibili"))
            {
                string biliUrl= await BilibiliHelper.GetUrlFromBilibili(Url);
                MsgPostHelper.MainNavigateTo(typeof(VideoPlayer), biliUrl);
            }
            else
            {
                MsgPostHelper.MainNavigateTo(typeof(VideoPlayer), Url);
            }
            
        }

        private async void Hanju_ItemClick(object sender, ItemClickEventArgs e)
        {
            string url = "http://api.hanju.koudaibaobao.com/api/series/detailV3?sid=" + (e.ClickedItem as HanjuShort).sid;
            string json= await netHelper.RequestStr(url,null);
            SeriesDetail seriesDetail = netHelper.GetView<SeriesDetail>(json);
            MsgPostHelper.MainNavigateTo(typeof(SeriesDetailPage),seriesDetail);
        }

        private void csm_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as csmItems;
            switch (item.type)
            {
                case "srepo":
                    new PopupNotification("暂未开放!请关注更新").show();
                    break;
                case "hanju":
                    MsgPostHelper.ChangeHomePivotIndex(2);
                    break;
                case "series":
                    new PopupNotification("暂未开放!请关注更新").show();
                    break;
                case "tv_live":
                    new PopupNotification("暂未开放!请关注更新").show();
                    break;
                case "v_follow":
                    MsgPostHelper.ChangeHomePivotIndex(0);
                    break;
                default:
                    break;
            }
        }
    }
}
