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
using 韩剧TV.View.Seriess;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace 韩剧TV.View.Homes
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SeriesPage : Page
    {
        public SeriesPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Enabled;
            Initial();
            this.SizeChanged += SeriesPage_SizeChanged;
        }

        private void SeriesPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            int hw = Convert.ToInt32(this.ActualWidth / 120);
            if (this.ActualWidth <= 500)
            {
                hanjuThumb_width.Width = ActualWidth / 3 - 20;
            }
            else if (this.ActualWidth <= 660)
            {
                hanjuThumb_width.Width = ActualWidth / hw - 15;
            }
            else
            {
                hanjuThumb_width.Width = ActualWidth / 6 - 15;
            }
        }

        NetHelper netHelper = new NetHelper();
        public static ObservableCollection<HanjuShort> seriesList = new ObservableCollection<HanjuShort>();
        private string seriesUrl = "http://api.hanju.koudaibaobao.com/api/series/indexV2?offset=0&count=48";
        private async void Initial()
        {
            string json = await netHelper.RequestStr(seriesUrl,null);
            Series series = netHelper.GetView<Series>(json);
            if (series.rescode != 0)
            {
                return;
            }
            seriesList = series.seriesList;
            lvSeries.ItemsSource = seriesList;
        }

        private async void btnDetailSerie(object sender, ItemClickEventArgs e)
        {
            string url = "http://api.hanju.koudaibaobao.com/api/series/detailV3?sid=" + (e.ClickedItem as HanjuShort).sid;
            string json = await netHelper.RequestStr(url, null);
            SeriesDetail seriesDetail = netHelper.GetView<SeriesDetail>(json);
            MsgPostHelper.MainNavigateTo(typeof(SeriesDetailPage), seriesDetail);
        }
    }
}
