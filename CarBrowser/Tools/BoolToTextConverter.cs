using System;
using System.Globalization;
using System.Windows.Data;

namespace CarBrowser.Tools
{
    public class BoolToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => (bool)value ? "Szukanie..." : "Szukaj";

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
