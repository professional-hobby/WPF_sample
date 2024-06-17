using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp1.Addons;
using WpfApp1.ViewModels;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for Supplier.xaml
    /// </summary>
    public partial class Supplier : UserControl, ICleanInputs
    {
        public Supplier()
        {
            InitializeComponent();

            DataContext = new SupplierVM();
        }

        public void CleanInputs()
        {
            txtQuantity.Clear();
        }

        private static readonly Regex _regex = new Regex("[^0-9]");
        private void txtQuantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            switch (e.Text)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    e.Handled = false;
                    break;
                default:
                    e.Handled = true;
                    break;
            }
        }
    }
}
