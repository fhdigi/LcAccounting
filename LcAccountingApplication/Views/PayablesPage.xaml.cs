using LcAccountingApplication.Helpers;
using LcAccountingApplication.ViewModels;
using LcAccountingApplication.Views.PopupControls;
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
                SaveAndCloseCommand =new RelayCommand(() =>
                {
                    ViewModel.BillsListing.Add(ViewModel.NewBillsBuffer);
                    ViewModel.NewBillsBuffer = null;
                    Frame.GoBack();
                }),
                CancelCommand = new RelayCommand(() =>
                {
                    ViewModel.NewBillsBuffer = null;
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
