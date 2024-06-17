
using WpfApp1.Addons;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class SupplierVM:BaseVM
    {
        #region Fields
        private string _userName;
        private int _quantity;
        private int _quantitySending;
        private SendingStatus _sendingStatus=SendingStatus.EnterQuantity;
        #endregion

        #region Properties
        public string UserName
        {
            get
            {
                if (_userName == null)
                {
                    _userName = "";
                }
                return _userName;
            }
            set
            {
                _userName = value;
                NotifyPropertyChanged(nameof(UserName));
              //  NotifyPropertyChanged(nameof(TopText));
            }
        }

        public SendingStatus SendingStatus
        {
            get
            {
                return _sendingStatus;
            }
            set
            {
                _sendingStatus = value;
                NotifyPropertyChanged(nameof(SendingStatus));
            }
        }

        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                NotifyPropertyChanged(nameof(Quantity));
            }
        }
        public int QuantitySending
        {
            get
            {
                return _quantitySending;
            }
            set
            {
                _quantitySending = value;
                NotifyPropertyChanged(nameof(QuantitySending));
            }
        }

        #endregion

        #region Commands

        private RelayCommand _sendCommand;

        public RelayCommand SendCommand
        {
            get
            {
                if (_sendCommand == null)
                {
                    _sendCommand = new RelayCommand(param => sendCommandCanExecute(), param => sendCommandExecute());
                }

                return _sendCommand;
            }
        }

        private bool sendCommandCanExecute()
        {
            if (Quantity > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async void sendCommandExecute()
        {
            SendingStatus = SendingStatus.WaitingResponse;

            QuantitySending = Quantity;

            AddQuantityResponseModel response = await ApiHelper.AddQuantity(new AddQuantityRequestModel(UserName, Quantity));

            if (response.ResultOk)
            {
                SendingStatus = SendingStatus.SuccessfulSend;

                ((Views.Supplier)App.Current.MainWindow.FindName("SupplierControl")).CleanInputs();
            }
            else
            {
                SendingStatus = SendingStatus.FaultSend;
            }

        }

        #endregion
    }
}
