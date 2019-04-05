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

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace 韩剧TV.View.Homes
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class StarPage : Page
    {
        public StarPage()
        {
            this.InitializeComponent();
            Initial();
            this.SizeChanged += StarPage_SizeChanged;
        }
        private void StarPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            int vw = Convert.ToInt32(this.ActualWidth / 160);
            int sw = Convert.ToInt32(this.ActualWidth / 80);
            if (this.ActualWidth <= 500)
            {
                starThumb_width.Width = ActualWidth / 4-16;
                videoThumb_width.Width = ActualWidth / 2 - 20;
            }
            else if (this.ActualWidth <= 990)
            {
                videoThumb_width.Width = ActualWidth / vw - 17;
                starThumb_width.Width = ActualWidth / 8 - 16;
            }
            else
            {
                videoThumb_width.Width = ActualWidth / 6 - 17;
                starThumb_width.Width = ActualWidth / 8 - 16;
            }
        }

        NetHelper netHelper = new NetHelper();
        private static ObservableCollection<hotStars> starsList = new ObservableCollection<hotStars>();
        private static ObservableCollection<HanjuShort> videoList = new ObservableCollection<HanjuShort>();
        private string starsUrl = "http://api.hanju.koudaibaobao.com/api/star/index";
        private string videoUrl = "http://api.hanju.koudaibaobao.com/api/star/hotVideos?offset=0&count=30";
        private async void Initial()
        {
            string jsonStars = await netHelper.RequestStr(starsUrl,null);
            string jsonVideos = await netHelper.RequestStr(videoUrl,null);
            Stars stars = netHelper.GetView<Stars>(jsonStars);
            HotVideos video= netHelper.GetView<HotVideos>(jsonVideos);
            if (stars.rescode != 0)
            {
                return;
            }
            if (video.rescode!=0)
            {
                return;
            }
            starsList = stars.hotStars;
            starsList.Add(new hotStars()
            {
                thumb = "/Assets/Icons/more.png",
                name = "更多",
                sid=0
            });
            videoList = video.videos;
            lvStars.ItemsSource = starsList;
            lvVideo.ItemsSource = videoList;
        }

        private void lvStarsClick(object sender, ItemClickEventArgs e)
        {
            if ((e.ClickedItem as hotStars).sid!=0)
            {
                MsgPostHelper.MainNavigateTo(typeof(StarInfoPage), e.ClickedItem);
            }
            else
            {                                
                MsgPostHelper.MainNavigateTo(typeof(StarsListPage),0);
            }
        }

        private async void Video_ItemClick(object sender, ItemClickEventArgs e)
        {
            HanjuShort hanjuShort = e.ClickedItem as HanjuShort;
            string Url = hanjuShort.sources[0].page;
            if (Url.Contains("bilibili"))
            {
                string biliUrl = await BilibiliHelper.GetUrlFromBilibili(Url);
                MsgPostHelper.MainNavigateTo(typeof(VideoPlayer), biliUrl);
            }
            else
            {
                MsgPostHelper.MainNavigateTo(typeof(VideoPlayer), Url);
            }

        }
    }
}
