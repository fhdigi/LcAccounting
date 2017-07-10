using LcAccountingApplication.ViewModels;

using Windows.UI.Xaml.Controls;

namespace LcAccountingApplication.Views
{
    public sealed partial class HomePage : Page
    {
        public HomeViewModel ViewModel { get; } = new HomeViewModel();
        public HomePage()
        {
            InitializeComponent();
        }
    }
}
