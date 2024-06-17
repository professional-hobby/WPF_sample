using System;
using System.Globalization;
using System.Windows.Data;
using WpfApp1.Addons;

namespace WpfApp1.Converters
{
    class SendingStatusToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((SendingStatus)value)
            {
                case SendingStatus.WaitingResponse:
                    return false;
                case SendingStatus.EnterQuantity:
                case SendingStatus.PressSendButton:
                case SendingStatus.SuccessfulSend:
                case SendingStatus.FaultSend:
                default:
                    return true;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
