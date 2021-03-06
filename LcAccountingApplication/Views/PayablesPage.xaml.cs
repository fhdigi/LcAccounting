using LcAccountingApplication.Helpers;
using LcAccountingApplication.Models;
using LcAccountingApplication.ViewModels;
using LcAccountingApplication.Views.PopupControls;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace LcAccountingApplication.Views
{
    public sealed partial class PayablesPage : Page
    {
        public PayablesViewModel ViewModel;
        public PayablesPage()
        {
            ViewModel = new PayablesViewModel()
            {
                NavigateToAddVendorPageCommand = new RelayCommand(() =>
                {
                    Frame.Navigate(typeof(VendorListPage), this.ViewModel);
                }),
                NavigateToAddAccountPageCommand = new RelayCommand(() =>
                {
                    //Frame.Navigate(typeof(AddAccountPage));
                }),
                SaveAndCloseCommand = new RelayCommand(() =>
                {
                    Task.Run(() => Bills.InsertBills(ViewModel.NewBillsBuffer));
                    Task.Run(ViewModel.SetBillsListing);
                    ViewModel.NewBillsBuffer = null;
                    Frame.GoBack();
                }),
                CancelCommand = new RelayCommand(() =>
                {
                    ViewModel.NewBillsBuffer = null;
                    Frame.GoBack();
                }),
                NewSupplierCommand = new RelayCommand(() =>
                {
                    ViewModel.NewSupplierBuffer = new Supplier();
                    Frame.Navigate(typeof(VendorPage), this.ViewModel);
                }),
                RemoveSupplierCommand = new RelayCommand(() =>
                {
                    Task.Run(() => Supplier.DeleteSuppliers(ViewModel.SelectedSupplier)).Wait();
                    Task.Run(ViewModel.SetSuppliers).Wait();
                }),
                SaveNewSupplierCommand = new RelayCommand(() =>
                {
                    ViewModel.NewSupplierBuffer.CorrectNullValues();
                    Task.Run(() => Supplier.InsertSuppliers(ViewModel.NewSupplierBuffer));
                    Task.Run(ViewModel.SetSuppliers);
                    Frame.GoBack();
                })
            };
            InitializeComponent();
        }

        private void navigateToPayBillsPageButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            payablesPageFrame.Navigate(typeof(PayBillPage), ViewModel);
        }

        private void navigateToEnterBillsPageButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            payablesPageFrame.Navigate(typeof(EnterBillPage), ViewModel);
        }
    }
}
