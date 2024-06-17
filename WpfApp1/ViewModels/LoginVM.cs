using System.Net;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Addons;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class LoginVM:BaseVM
    {
        #region Fields
        private string _userName;
        private SecureString _password;
        private SendingStatus _sendingStatus = SendingStatus.EnterQuantity;
        #endregion

        #region Properties

        public string UserName {
            get {
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

        public SecureString Password {
            get
            {
                if (_password == null)
                {
                    return new SecureString();
                }
                else
                {
                    return _password;
                }
            }
            set
            {
                _password = value;
                NotifyPropertyChanged(nameof(Password));
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

        private RelayCommand _loginCommand;

        public RelayCommand LoginCommand 
        {
            get
            {
                if (_loginCommand == null)
                {
                    _loginCommand = new RelayCommand(param => loginCommandCanExecute(), async param => await loginCommandExecute());
                }

                return _loginCommand;
            }
        } 

        private bool loginCommandCanExecute()
        {
            if (UserName.Length > 2 && Password.Length>2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task loginCommandExecute()
        {
            if(UserName=="Administrator"&& new NetworkCredential(string.Empty, Password).Password == "NiceLabel123!")
            {
                ((Views.Login)App.Current.MainWindow.FindName("LoginControl")).Visibility = Visibility.Collapsed;
                ((Views.Register)App.Current.MainWindow.FindName("RegisterControl")).Visibility = Visibility.Visible;
            }
            else
            {
                SendingStatus = SendingStatus.WaitingResponse;

                LoginResponseModel response = await ApiHelper.Login(new LoginRequestModel(UserName, new NetworkCredential(string.Empty, Password).Password));

                if (response.IsLoggedIn)
                {
                    ((Views.Login)App.Current.MainWindow.FindName("LoginControl")).Visibility = Visibility.Collapsed;
                    ((Views.Supplier)App.Current.MainWindow.FindName("SupplierControl")).Visibility = Visibility.Visible;
                    ((SupplierVM)(((Views.Supplier)App.Current.MainWindow.FindName("SupplierControl")).DataContext)).UserName = response.UserName;

                    SendingStatus = SendingStatus.SuccessfulSend;
                }
                else
                {
                    SendingStatus = SendingStatus.FaultSend;
                }
            }


            ((Views.Login)App.Current.MainWindow.FindName("LoginControl")).CleanInputs();
            ((Views.Register)App.Current.MainWindow.FindName("RegisterControl")).CleanInputs();
            ((Views.Supplier)App.Current.MainWindow.FindName("SupplierControl")).CleanInputs();
        }

        #endregion
    }
}
