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

namespace 韩剧TV.View.Searchs
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SearchResultPage : Page
    {
        public SearchResultPage()
        {
            this.InitializeComponent();
        }
        NetHelper netHelper = new NetHelper();
        private static ObservableCollection<HanjuShort> seriesResult = new ObservableCollection<HanjuShort>();
        private static ObservableCollection<hotStars> starsResult = new ObservableCollection<hotStars>();

        private static string keyWords = "";
        private string searchResultUrl = "http://api.hanju.koudaibaobao.com/api/search/s2?k={0}&srefer=search_input";
        private async void Initial()
        {
            string json =await netHelper.RequestStr(searchResultUrl, null);
            SearchResult sResult = netHelper.GetView<SearchResult>(json);
            starsResult = sResult.starList;
            seriesResult = sResult.seriesList;
            lvStarsResult.ItemsSource = starsResult;
            lvSeriesResult.ItemsSource = seriesResult;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            keyWords = e.Parameter.ToString();
            searchResultUrl = string.Format(searchResultUrl, keyWords);
            Initial();
        }

        private async void btnDetailSerie(object sender, ItemClickEventArgs e)
        {
            string url = "http://api.hanju.koudaibaobao.com/api/series/detailV3?sid=" + (e.ClickedItem as HanjuShort).sid;
            string json = await netHelper.RequestStr(url, null);
            SeriesDetail seriesDetail = netHelper.GetView<SeriesDetail>(json);
            this.Frame.Navigate(typeof(SeriesDetailPage), seriesDetail);
        }

        private void btnDetailStar(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(StarInfoPage), e.ClickedItem);
        }
    }
}
