using System;
using System.Globalization;
using System.Windows.Data;

namespace CarBrowser.Tools
{
    public class BoolToTextFilesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => (bool)value ? "Pobieranie..." : "Pobierz metadane";

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
