using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Windows.UI.Xaml.Navigation;
using 韩剧TV.Tools;
using 韩剧TV.Model;
using 韩剧TV.View.MediaPlayer;
using 韩剧TV.controls;
using Windows.System;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace 韩剧TV.View
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class StarInfoPage : Page
    {
        public StarInfoPage()
        {
            this.InitializeComponent();
        }
        public hotStars star = new hotStars();
        NetHelper netHelper = new NetHelper();
        private static ObservableCollection<HanjuShort> videoList = new ObservableCollection<HanjuShort>();
        private string videoUrl = "http://api.hanju.koudaibaobao.com/api/star/videos?sid={0}&sort=t&offset=0&count=20";
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            star =e.Parameter as hotStars;
            videoUrl = string.Format(videoUrl, star.sid);
            string jsonVideos = await netHelper.RequestStr(videoUrl, null);
            HotVideos video = netHelper.GetView<HotVideos>(jsonVideos);
            if (video.rescode != 0)
            {
                return;
            }
            videoList = video.videos;
            lvstarVideo.ItemsSource = videoList;
        }

        private async void Video_ItemClick(object sender, ItemClickEventArgs e)
        {
            HanjuShort hanjuShort = e.ClickedItem as HanjuShort;
            string Url = hanjuShort.sources[0].page;
            if (Url.Contains("bilibili"))
            {
                string biliUrl = await BilibiliHelper.GetUrlFromBilibili(Url);
                this.Frame.Navigate(typeof(VideoPlayer), biliUrl);
            }
            else
            {
                this.Frame.Navigate(typeof(VideoPlayer), Url);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new PopupNotification("关注失败!").show();
        }

        private async void WebButton_Click(object sender, RoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri(star.baikeUrl));
        }
    }
}
