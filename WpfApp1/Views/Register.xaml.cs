using System.Windows;
using System.Windows.Controls;
using WpfApp1.Addons;
using WpfApp1.ViewModels;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Register : UserControl, ICleanInputs
    {
        public Register()
        {
            InitializeComponent();

            DataContext = new RegisterVM();
        }

        public void CleanInputs()
        {
            txtUserName.Clear();
            txtPassword1.Clear();
            txtPassword2.Clear();
        }

        private void txtPassword1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((RegisterVM)this.DataContext).Password1 =  ((PasswordBox)sender).SecurePassword; }
        }

        private void txtPassword2_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((RegisterVM)this.DataContext).Password2 = ((PasswordBox)sender).SecurePassword; }
        }

    }
}
