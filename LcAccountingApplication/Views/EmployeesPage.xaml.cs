using LcAccountingApplication.Helpers;
using LcAccountingApplication.Models;
using LcAccountingApplication.Models.PopupControls;
using LcAccountingApplication.ViewModels;
using LcAccountingApplication.Views.PopupControls;
using Windows.UI.Xaml.Controls;

namespace LcAccountingApplication.Views
{
    public sealed partial class EmployeesPage : Page
    {
        public EmployeesViewModel ViewModel;
        public EmployeesPage()
        {
            ViewModel = new EmployeesViewModel()
            {
                NewEmployeeCommand = new RelayCommand(() =>
                {
                    ViewModel.IsNewEmployee = true;
                    ViewModel.NewEmployeeBuffer = new Employee();
                    Frame.Navigate(typeof(EmployeeDataPage), this.ViewModel);
                }),
                EditEmployeeCommand = new RelayCommand(() =>
                {
                    ViewModel.IsNewEmployee = false;
                    ViewModel.NewEmployeeBuffer = ViewModel.SelectedEmployee;
                    Frame.Navigate(typeof(EmployeeDataPage), this.ViewModel);

                }),
                SaveEditedEmployeeCommand = new RelayCommand(async () =>
                {
                    if (ViewModel.IsNewEmployee) await Employee.InsertEmployee(ViewModel.NewEmployeeBuffer);
                    else await Employee.UpdateEmployee(ViewModel.NewEmployeeBuffer);
                    Frame.GoBack();
                }),
                RemoveEmployeeCommand = new RelayCommand(async () =>
                {
                    if (ViewModel.IsEmployeeSelected) await Employee.DeleteEmployee(ViewModel.SelectedEmployee);
                }),
                CancelCommand = new RelayCommand(() =>
                {
                    Frame.GoBack();
                })
                
            };

            DataContext = ViewModel;
            InitializeComponent();
        }
    }
}
