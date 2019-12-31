using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace KoreaTV.Converter {
    public class HanjuFinishedConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            bool isFinished = System.Convert.ToBoolean(value);
            if (isFinished) {
                return parameter;
            } else {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            return "";
        }
    }
}
