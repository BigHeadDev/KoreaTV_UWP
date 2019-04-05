using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using 韩剧TV.Model;

namespace 韩剧TV.Tools
{
    class MyTemplateSelector:DataTemplateSelector
    {
        public DataTemplate DataTemplate1 { get; set; }
        public DataTemplate DataTemplate2 { get; set; }
        public DataTemplate DataTemplate3 { get; set; }
        public DataTemplate DataTemplate4 { get; set; }
        public DataTemplate DataTemplate5 { get; set; }
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            //var a = ItemsControl.ItemsControlFromItemContainer(container) as GridView;
            Recs rec = item as Recs;
            try
            {
                switch (rec.type)
                {
                    case 1:
                        return DataTemplate1;
                    case 2:
                        return DataTemplate2;
                    case 3:
                        return DataTemplate3;
                    case 4:
                        return DataTemplate4;
                    case 5:
                        return DataTemplate5;
                    default:
                        break;
                }
            }
            catch
            {
                return null;
            }
            return base.SelectTemplate(item, container);
        }
    }
}
