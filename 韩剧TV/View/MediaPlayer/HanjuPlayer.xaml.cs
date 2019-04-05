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
using 韩剧TV.Model;
using 韩剧TV.Tools;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace 韩剧TV.View.MediaPlayer
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class HanjuPlayer : Page
    {
        public HanjuPlayer()
        {
            this.InitializeComponent();
        }

        public string url = "";
        public string num = "";
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.url = (e.Parameter as string[])[0];
            this.num = (e.Parameter as string[])[1];
            Initial();
        }
        public async void Initial()
        {
            string playUrl = await SeriesHelper.GetPlayURL(url, num, PlayType.m3u8);
            mediaHnaju.Source = new Uri(playUrl);
        }
    }
}
