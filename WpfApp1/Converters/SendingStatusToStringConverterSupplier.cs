using System;
using System.Globalization;
using System.Windows.Data;
using WpfApp1.Addons;

namespace WpfApp1.Converters
{
    public class SendingStatusToStringConverterSupplier : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            // value[0] - SendingStatusEnum; value[1] - QuantitySending amount

            if (value[0] is SendingStatus && value[1] is int)
            {
                switch ((SendingStatus)value[0])
                {
                    case SendingStatus.WaitingResponse:
                        return "Status: Waiting server response.";
                    case SendingStatus.SuccessfulSend:
                        return String.Format("Status: {0} products have been successfully sent.\r\nYou can send a new package now.", value[1].ToString());
                    case SendingStatus.FaultSend:
                        return String.Format("Status: Unfortunately, {0} products have not been sent.", value[1].ToString());
                    case SendingStatus.EnterQuantity:
                    default:
                        return "Status: Please enter amount of products you are sending and press \"Send\" button.";
                }
            }
            else
            {
                return "Status: Internal error";
            }
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
