using System;
using System.Globalization;
using Xamarin.Forms;

namespace ECommerce.Localization
{
        public class TranslateConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value is string str)
                {
                    return LocalizedResourceHelper.GetText(str);
                }
                return value;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return value;
            }
        }
}
