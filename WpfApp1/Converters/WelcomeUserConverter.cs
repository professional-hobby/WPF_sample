using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfApp1.Converters
{
    class WelcomeUserConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return String.Format("Welcome, {0}!\r\nPlease use the form below.",value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
