using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace KoreaTV.Converter {
    public class RankConverter:IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            int number = System.Convert.ToInt32(value);
            return (number / 10.0).ToString("0.0");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }
}
