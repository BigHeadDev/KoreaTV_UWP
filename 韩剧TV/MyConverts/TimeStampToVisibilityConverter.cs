using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace 韩剧TV.MyConverts
{
    public class TimeStampToVisibilityConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                long distance = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000) - (long)value/1000;
                return distance<86400?"Visibility":"Collapsed";
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
