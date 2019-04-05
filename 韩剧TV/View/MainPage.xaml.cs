/** 
* 
*----------CNM is here!----------/ 
* 　　　┏┓　　　┏┓ 
* 　　┏┛┻━━━┛┻┓ 
* 　　┃　　　　　　　┃ 
* 　　┃　　　━　　　┃ 
* 　　┃　┳┛　┗┳　┃ 
* 　　┃　　　　　　　┃ 
* 　　┃　　　┻　　　┃ 
* 　　┃　　　　　　　┃ 
* 　　┗━┓　　　┏━┛ 
* 　　　　┃　　　┃神兽保佑 
* 　　　　┃　　　┃代码无BUG！ 
* 　　　　┃　　　┗━━━┓ 
* 　　　　┃　　　　　　　┣┓ 
* 　　　　┃　　　　　　　┏┛ 
* 　　　　┗┓┓┏━┳┓┏┛ 
* 　　　　　┃┫┫　┃┫┫ 
* 　　　　　┗┻┛　┗┻┛ 
* ━━━━━━神兽出没━━━━━━
*/
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
using 韩剧TV.ViewModel;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace 韩剧TV.View
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
            this.mainFrame.Navigate(typeof(HomePage));
            this.SizeChanged += MainPage_SizeChanged;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MsgPostHelper.MianNavigateToEvent += MsgPostHelper_MianNavigateToEvent;
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            MsgPostHelper.MianNavigateToEvent -= MsgPostHelper_MianNavigateToEvent;
        }

        private void MsgPostHelper_MianNavigateToEvent(Type page,params object[] par)
        {
            this.Frame.Navigate(page, par[0]);
        }

        private void MainPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width<600)
            {
                mainSplitView.DisplayMode = SplitViewDisplayMode.Overlay;
            }
            else if (e.NewSize.Width<=990)
            {
                mainSplitView.DisplayMode = SplitViewDisplayMode.CompactOverlay;
            }
            else
            {
                mainSplitView.DisplayMode = SplitViewDisplayMode.CompactInline;
                mainSplitView.IsPaneOpen = true;
            }
        }

        bool _isHamburgerOpen = false;

        private void mainNavigationList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isHamburgerOpen)
            {
                _isHamburgerOpen = false;
                return;
            }
            ListBoxItem tapped_item = mainNavigationList.SelectedItems[0] as ListBoxItem;
            if (tapped_item!=null&&tapped_item.Tag!=null)
            {
                switch(tapped_item.Tag.ToString())
                {
                    case "1":
                        this.mainFrame.Navigate(typeof(HomePage));
                        mainSplitView.IsPaneOpen = false;
                        mainTitle.Text = "首页";
                        break;
                    case "2":
                        this.mainFrame.Navigate(typeof(DiscoveryPage));
                        mainSplitView.IsPaneOpen = false;
                        mainTitle.Text = "发现";

                        break;
                    case "3":
                        this.mainFrame.Navigate(typeof(ChasePage));
                        mainSplitView.IsPaneOpen = false;
                        mainTitle.Text = "追剧";

                        break;
                    default:
                        break;

                }
            }
        }


        public void ChangeHamburgerPanelShow()
        {
            mainSplitView.IsPaneOpen = !mainSplitView.IsPaneOpen;
        }

        private void SearchText_GotFocus(object sender, RoutedEventArgs e)
        {
            this.mainFrame.Navigate(typeof(DiscoveryPage));
            mainTitle.Text = "发现";
        }

        private void toggleBtn_Click(object sender, RoutedEventArgs e)
        {
            ChangeHamburgerPanelShow();
        }
    }
}
