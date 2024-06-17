using System;
using System.Globalization;
using System.Windows.Data;
using WpfApp1.Addons;

namespace WpfApp1.Converters
{
    public class SendingStatusToStringConverterRegister : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
                switch ((SendingStatus)value)
                {
                    case SendingStatus.WaitingResponse:
                        return "Status: Waiting server response.";
                    case SendingStatus.SuccessfulSend:
                        return "Status: A new user was successfully created.";
                    case SendingStatus.FaultSend:
                        return "Status: User registration failed.";
                    case SendingStatus.EnterQuantity:
                    default:
                        return "Status: Please enter username and password for a new user.\r\n\tUsername and password lenght must be at least 3";
                }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
