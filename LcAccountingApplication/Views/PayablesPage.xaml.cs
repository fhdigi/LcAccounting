using LcAccountingApplication.ViewModels;

using Windows.UI.Xaml.Controls;

namespace LcAccountingApplication.Views
{
    public sealed partial class PayablesPage : Page
    {
        public PayablesViewModel ViewModel { get; } = new PayablesViewModel();
        public PayablesPage()
        {
            InitializeComponent();
        }
    }
}
