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

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace 韩剧TV.controls
{
    public sealed partial class StarsRankGridView : UserControl
    {
        public double Rank
        {
            get { return (double)GetValue(RankProperty); }
            set { SetValue(RankProperty, value); }
        }
        public ObservableCollection<string> starsList = new ObservableCollection<string>();
        public StarsRankGridView()
        {
            this.InitializeComponent();
        }
        public static readonly DependencyProperty RankProperty = DependencyProperty.Register
            (
                "Rank",
                typeof(double),
                typeof(UserControl),
                new PropertyMetadata(0, new PropertyChangedCallback(Initial))
            );

        private static void Initial(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue!=null)
            {
                StarsRankGridView starsRankGridView = (StarsRankGridView)d;
                starsRankGridView.starsList = starsRankGridView.AddImgsToList(starsRankGridView.starsList, (double)e.NewValue / 20);
                starsRankGridView.gridStars.ItemsSource = starsRankGridView.starsList;
            }
            
        }
        public ObservableCollection<string> AddImgsToList(ObservableCollection<string> imgs ,double rank)
        {
            int full_StarsNums = (int)rank;
            int half_StarsNums = (rank - (int)rank) > 0.5 ? 1 : 0;
            int balnk_StarNums = 5 - full_StarsNums - half_StarsNums;
            for (int i = 0; i < full_StarsNums; i++)
            {
                starsList.Add("/Assets/Icons/rank_star_full.png");
            }
            for (int i = 0; i < half_StarsNums; i++)
            {
                starsList.Add("/Assets/Icons/rank_star_half.png");
            }
            for (int i = 0; i < balnk_StarNums; i++)
            {
                starsList.Add("/Assets/Icons/rank_star_blank.png");
            }
            return imgs;
        }
    }
}
