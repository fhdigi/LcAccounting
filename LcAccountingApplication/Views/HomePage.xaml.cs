using LcAccountingApplication.ViewModels;

using Windows.UI.Xaml.Controls;

using LcAccountingApplication.Views.PopupControls;

namespace LcAccountingApplication.Views
{
    public sealed partial class HomePage : Page
    {
        public HomeViewModel ViewModel { get; } = new HomeViewModel();
        public HomePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ChartOfAccountListingPage));
        }
    }
}
