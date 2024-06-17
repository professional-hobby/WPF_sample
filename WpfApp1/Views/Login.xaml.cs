using System.Windows;
using System.Windows.Controls;
using WpfApp1.Addons;
using WpfApp1.ViewModels;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl,ICleanInputs
    {
        public Login()
        {
            InitializeComponent();

            DataContext = new Login();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((LoginVM)this.DataContext).Password =  ((PasswordBox)sender).SecurePassword; }
        }

        public void CleanInputs()
        {
            txtUserName.Clear();
            txtPassword.Clear();
        }
    }
}
