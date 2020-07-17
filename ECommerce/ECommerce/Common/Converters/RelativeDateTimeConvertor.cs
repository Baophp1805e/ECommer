using System;
using System.Globalization;
using Xamarin.Forms;

namespace ECommerce.Common.Converters
{
    public class RelativeDateTimeConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var postedData = (DateTime)value;

            var ts = DateTime.Now.Subtract(postedData);

            var mins = ts.TotalMinutes;
            if (mins < 1)
            {
                return ts.Seconds == 1 ? "One second ago" : ts.Seconds + " seconds ago";
            }

            if (mins < 2)
                return "A minute ago";

            if (mins < 60)
            {
                return ts.Minutes + " minutes ago";
            }
            if (ts.TotalHours < 2)
                return "An hour ago";

            if (ts.TotalHours < 24)
            {
                return ts.Hours + " hours ago";
            }

            if (ts.TotalDays < 2)
                return $"Yesterday at {postedData.ToString("t")}";

            if (ts.TotalDays < 30)
            {
                //    return ts.Days + " days ago";
                return postedData.ToString("dd MMMM, yyyy");
            }

            if (ts.TotalDays < 365)
            {
                return postedData.ToString("dd MMMM, yyyy");
                //     int months = (int)(Math.Floor((double)ts.Days / 30));
                //   return months <= 1 ? "one month ago" : months + " months ago";
            }
            else
            {
                return postedData.ToString("dd MMMM, yyyy");
                //  int years = (int)(Math.Floor((double)ts.Days / 365));
                //  return years <= 1 ? "one year ago" : years + " years ago";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
