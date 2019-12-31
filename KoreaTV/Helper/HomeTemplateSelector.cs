using KoreaTV.Model;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace KoreaTV.Helper {
    public class HomeTemplateSelector : DataTemplateSelector {
        public DataTemplate HanjuListTemplate { get; set; }
        public DataTemplate ShotVideoListTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container) {
            Recs recs = item as Recs;
            DataTemplate result;
            switch (System.Convert.ToInt32(recs.type)) {
                case 1:
                    result= HanjuListTemplate;
                    break;
                default:
                    result= ShotVideoListTemplate;
                    break;
            }
            return result;
        }
    }
}
