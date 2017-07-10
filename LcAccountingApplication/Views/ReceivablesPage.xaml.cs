using LcAccountingApplication.ViewModels;

using Windows.UI.Xaml.Controls;

namespace LcAccountingApplication.Views
{
    public sealed partial class ReceivablesPage : Page
    {
        public ReceivablesViewModel ViewModel { get; } = new ReceivablesViewModel();
        public ReceivablesPage()
        {
            InitializeComponent();
        }
    }
}
