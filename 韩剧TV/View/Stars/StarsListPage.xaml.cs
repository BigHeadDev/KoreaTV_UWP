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

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace 韩剧TV.View
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class StarsListPage : Page
    {
        public StarsListPage()
        {
            this.InitializeComponent();
            Initial();
        }
        private static string starsUrl = "http://api.hanju.koudaibaobao.com/api/star/hotStars?offset=0&count=30";
        public NetHelper netHelper = new NetHelper();
        public ObservableCollection<hotStars> stars123List = new ObservableCollection<hotStars>();
        public ObservableCollection<hotStars> hotStarsList = new ObservableCollection<hotStars>();
        private async void Initial()
        {
            string json = await netHelper.RequestStr(starsUrl, null);
            Stars stars = netHelper.GetView<Stars>(json);
            hotStarsList = stars.hotStars;

            for (int i = 0; i < 3; i++)
            {
                stars123List.Add(hotStarsList[0]);
                hotStarsList.RemoveAt(0);
            }
            lv123.ItemsSource = stars123List;
            lvOther.ItemsSource = hotStarsList;
        }

        private void btnStarInfo(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(StarInfoPage), e.ClickedItem);
        }
    }
}
