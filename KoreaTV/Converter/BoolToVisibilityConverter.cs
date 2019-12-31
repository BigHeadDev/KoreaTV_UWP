using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace KoreaTV.Converter {
    public class BoolToVisibilityConverter:IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            bool visible = System.Convert.ToBoolean(value);
            return visible ? "Visible" : "Collapsed";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            return "Collapsed";
        }
    }
}
