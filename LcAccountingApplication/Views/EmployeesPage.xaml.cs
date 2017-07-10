using LcAccountingApplication.ViewModels;

using Windows.UI.Xaml.Controls;

namespace LcAccountingApplication.Views
{
    public sealed partial class EmployeesPage : Page
    {
        public EmployeesViewModel ViewModel { get; } = new EmployeesViewModel();
        public EmployeesPage()
        {
            InitializeComponent();
        }
    }
}
