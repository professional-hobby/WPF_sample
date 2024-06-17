using System;
using System.Globalization;
using System.Windows.Data;
using WpfApp1.Addons;

namespace WpfApp1.Converters
{
    public class SendingStatusToStringConverterLogin : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
                switch ((SendingStatus)value)
                {
                    case SendingStatus.WaitingResponse:
                        return "Status: Waiting server response.";
                    case SendingStatus.SuccessfulSend:
                        return "Status: Succesfully logged in.";
                    case SendingStatus.FaultSend:
                        return "Status: Username and password are incorrect.";
                    case SendingStatus.EnterQuantity:
                    default:
                        return "Status: Use your username and password for login.";
                }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
