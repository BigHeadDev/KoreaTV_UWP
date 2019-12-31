using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace KoreaTV.Converter {
    public class TimeSpanToUpdateConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            long distance = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000) - (long)value / 1000;
            return distance < 86400 ? "Visibility" : "Collapsed";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }
}
