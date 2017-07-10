using LcAccountingApplication.ViewModels;

using Windows.UI.Xaml.Controls;

namespace LcAccountingApplication.Views
{
    public sealed partial class CompanyPage : Page
    {
        public CompanyViewModel ViewModel { get; } = new CompanyViewModel();
        public CompanyPage()
        {
            InitializeComponent();
        }
    }
}
