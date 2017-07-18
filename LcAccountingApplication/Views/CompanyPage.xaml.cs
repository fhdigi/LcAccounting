using LcAccountingApplication.ViewModels;
using LcAccountingApplication.Views.PopupControls;

using Windows.UI.Xaml.Controls;

namespace LcAccountingApplication.Views
{
    public sealed partial class CompanyPage : Page
    {
        public CompanyViewModel ViewModel;
        public CompanyPage()
        {
            ViewModel = new CompanyViewModel();

            DataContext = ViewModel;
            InitializeComponent();
            companyPagePopupFrame.Navigate(typeof(ChartOfAccountListingPage));
        }
    }
}
