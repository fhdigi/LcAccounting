using System;

using LcAccountingApplication.Helpers;
using PropertyChanged;
using System.Collections.ObjectModel;
using LcAccountingApplication.Models;
using System.Windows.Input;

namespace LcAccountingApplication.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class EmployeesViewModel : Observable
    {
        public ObservableCollection<Employee> EmployeeListing { get; set; }
        public int SelectedEmployeeListingIndex { get; set; }
        public int SelectedEmployeeIndex { get; set; }
        public Employee SelectedEmployeeListing { get; set; }

        public bool IsNewEmployee; //True if creating a chart of account. False is editing one.
        public Employee NewEmployeeBuffer; //Used when creating a new accont (Discarded if Cancel, Added if Save)
        public ICommand SaveEditedAccountCommand;

        public bool IsAccountListingSelected
        {
            get
            {
                return SelectedEmployeeListingIndex > -1;
            }
        }
        public ICommand EditEmployeeCommand;
        public ICommand RemoveEmployeeCommand;
        public ICommand NewEmployeeCommand;
        public ICommand SaveEditedEmployeeCommand;

        public EmployeesViewModel()
        {
            
        }
    }
}
