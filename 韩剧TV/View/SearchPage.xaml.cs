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
using 韩剧TV.View.Searchs;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace 韩剧TV.View
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SearchPage : Page
    {
        public SearchPage()
        {
            this.InitializeComponent();
            Initial();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
        }
        NetHelper netHelper = new NetHelper();
        private static ObservableCollection<string> hotWordsList = new ObservableCollection<string>();
        private string searchUrl = "http://api.hanju.koudaibaobao.com/api/search/configs";
        private async void Initial()
        {
            string json = await netHelper.RequestStr(searchUrl,null);
            Search search = netHelper.GetView<Search>(json);
            if (search.rescode != 0)
            {
                return;
            }
            hotWordsList = search.hotWords;
            lvHotWords.ItemsSource = hotWordsList;
        }

        private void btnSerach_Click(object sender, RoutedEventArgs e)
        {
            MsgPostHelper.MainNavigateTo(typeof(SearchResultPage), txtKeyWords.Text);
        }

        private void KeyWords_Click(object sender, ItemClickEventArgs e)
        {
            string selection_words = e.ClickedItem.ToString();
            txtKeyWords.Text = selection_words;
            btnSerach_Click(null,null);
        }
    }
}
