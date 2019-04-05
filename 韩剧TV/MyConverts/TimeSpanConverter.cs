using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Animation;

namespace 韩剧TV.MyConverts
{
    public class TimeSpanConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value!=null)
            {
                return howLong(spanToDate(long.Parse(value.ToString())/1000));
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
        public static DateTime spanToDate(long oldTime)
        {
            System.DateTime dtDateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(oldTime);
            return dtDateTime;
        }
        public string howLong(DateTime publisTime)
        {
            TimeSpan t = DateTime.Now - publisTime;
            if (t.Days!=0)
            {
                return t.Days + "天前";
            }
            if (t.Hours!=0)
            {
                return t.Hours + "小时前";
            }
            if (t.Milliseconds>3)
            {
                return t.Minutes + "分钟前";
            }
            else
            {
                return "刚刚";
            }
        }
    }
}
