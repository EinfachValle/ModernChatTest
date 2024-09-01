using System;
using System.Globalization;
using System.Windows.Data;

namespace ModernChatTest.Core
{
    public class DateToTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime)
            {
                if (dateTime.Date == DateTime.Today)
                {
                    return $"Today {dateTime:hh:mm tt}";
                }
                else
                {
                    return dateTime.ToString("MM/dd/yyyy hh:mm tt");
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
