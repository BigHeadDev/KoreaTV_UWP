using System;
using System.Collections.Generic;
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
using System.Threading.Tasks;
using 韩剧TV.controls;
using 韩剧TV.View.MediaPlayer;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace 韩剧TV.View.Seriess
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SeriesDetailPage : Page
    {
        public SeriesDetailPage()
        {
            this.InitializeComponent();
        }
        public SeriesDetail serie = new SeriesDetail();
        public List<int> nums = new List<int>();
        public string url = "";
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            serie = e.Parameter as SeriesDetail;
            Initial();
        }
        private async void Initial()
        {
            for (int i = 1; i <= serie.series.count; i++)
            {
                nums.Add(i);
            }
            try
            {
                url = await SeriesHelper.GetSeriesURL(serie.series.name);
            }
            catch
            {

            }
            lvPlays.ItemsSource = nums;
            introWeb.NavigateToString(serie.series.intro);
        }

        private void GoToPlay(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(HanjuPlayer),new string[] {url, e.ClickedItem.ToString()});
        }
    }
}
