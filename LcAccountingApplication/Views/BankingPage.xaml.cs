using LcAccountingApplication.ViewModels;

using Windows.UI.Xaml.Controls;

namespace LcAccountingApplication.Views
{
    public sealed partial class BankingPage : Page
    {
        public BankingViewModel ViewModel { get; } = new BankingViewModel();
        public BankingPage()
        {
            InitializeComponent();
        }
    }
}
