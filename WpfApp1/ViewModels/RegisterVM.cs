using System.Net;
using System.Security;
using System.Windows;
using WpfApp1.Addons;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class RegisterVM : BaseVM
    {
        #region Fields
        private string _userName;
        private SecureString _password1;
        private SecureString _password2;
        private SendingStatus _sendingStatus = SendingStatus.EnterQuantity;
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
            }
        }

        public SecureString Password1
        {
            get
            {
                if (_password1 == null)
                {
                    return new SecureString();
                }
                else
                {
                    return _password1;
                }
            }
            set
            {
                _password1 = value;
                NotifyPropertyChanged(nameof(Password1));
            }
        }

        public SecureString Password2
        {
            get
            {
                if (_password2 == null)
                {
                    return new SecureString();
                }
                else
                {
                    return _password2;
                }
            }
            set
            {
                _password2 = value;
                NotifyPropertyChanged(nameof(Password2));
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

        #endregion

        #region Commands

        #region Register

        private RelayCommand _registerCommand;

        public RelayCommand RegisterCommand
        {
            get
            {
                if (_registerCommand == null)
                {
                    _registerCommand = new RelayCommand(param => registerCommandCanExecute(), param => registerCommandExecute());
                }

                return _registerCommand;
            }
        }

        private bool registerCommandCanExecute()
        {
            if (UserName.Length > 2 && Password1.Length > 2 && new NetworkCredential(string.Empty, Password1).Password == new NetworkCredential(string.Empty, Password2).Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async void registerCommandExecute()
        {
            SendingStatus = SendingStatus.WaitingResponse;

            RegisterResponseModel response = await ApiHelper.Register(new RegisterRequestModel(UserName, new NetworkCredential(string.Empty, Password1).Password));

            if (response.ResultOk)
            {
                SendingStatus = SendingStatus.SuccessfulSend;
            }
            else
            {
                SendingStatus = SendingStatus.FaultSend;
            }

            ((Views.Register)App.Current.MainWindow.FindName("RegisterControl")).CleanInputs();

        }

        #endregion

        #region Cancel

        private RelayCommand _cancelCommand;

        public RelayCommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                {
                    _cancelCommand = new RelayCommand(param => cancelCommandCanExecute(), param => cancelCommandExecute());
                }

                return _cancelCommand;
            }
        }

        private bool cancelCommandCanExecute()
        {
            return true;
        }

        private void cancelCommandExecute()
        {
            exitForm();
        }

        #endregion

        #endregion

        #region Private Methods

        private void exitForm()
        {
            ((Views.Register)App.Current.MainWindow.FindName("RegisterControl")).Visibility = Visibility.Collapsed;
            ((Views.Login)App.Current.MainWindow.FindName("LoginControl")).Visibility = Visibility.Visible;


            ((Views.Login)App.Current.MainWindow.FindName("LoginControl")).CleanInputs();
            ((Views.Register)App.Current.MainWindow.FindName("RegisterControl")).CleanInputs();
            ((Views.Supplier)App.Current.MainWindow.FindName("SupplierControl")).CleanInputs();

        }
        #endregion
    }
}
