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

        public Employee SelectedEmployee { get; set; }

        public bool IsNewEmployee; //True if creating a chart of account. False is editing one.
        public Employee NewEmployeeBuffer; //Used when creating a new accont (Discarded if Cancel, Added if Save)

        public bool IsEmployeeSelected
        {
            get
            {
                return SelectedEmployee != null;
            }
        }
        public ICommand EditEmployeeCommand;
        public ICommand RemoveEmployeeCommand;
        public ICommand NewEmployeeCommand;
        public ICommand SaveEditedEmployeeCommand;
        public ICommand CancelCommand;

        public EmployeesViewModel()
        {
            
        }
    }
}
