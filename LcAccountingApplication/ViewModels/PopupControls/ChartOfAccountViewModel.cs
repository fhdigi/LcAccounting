using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

using LcAccountingApplication.Models.PopupControls;
using System.Collections.ObjectModel;
using System.Windows.Input;
using LcAccountingApplication.Helpers;

namespace LcAccountingApplication.ViewModels.PopupControls
{
    [AddINotifyPropertyChangedInterface]
    public class ChartOfAccountViewModel
    {
        //PROPERTIES
        public ObservableCollection<ChartOfAccount> ChartOfAccountListing { get; set; }
        public int SelectedAccountListingIndex { get; set; }
        public bool IsAccountListingSelected
        {
            get
            {
                return SelectedAccountListingIndex >= -1;
            }
        }



        //COMMANDS
        public ICommand EditSelectedAccountCommand;
        public ICommand ClosePageCommand;
        public ICommand DeleteSelectedAccountCommand;
        public ICommand AddNewAccountCommand;


        //CONSTRUCTOR
        public ChartOfAccountViewModel()
        {
            Task.Run(SetAccountListing).Wait();
            SortAccountListings();
            DeleteSelectedAccountCommand = new RelayCommand(DeleteSelectedAccount);
        }


        //FUNCTIONS
        private void DeleteSelectedAccount()
        {
            ChartOfAccountListing.Remove(ChartOfAccountListing[SelectedAccountListingIndex]);
        }
        private void SortAccountListings()
        {
            ChartOfAccountListing.ToList<ChartOfAccount>().Sort((x, y) => x.AccountName.CompareTo(y.AccountName));
        }

        //TASKS
        private async Task SetAccountListing()
        {
            ChartOfAccountListing = new ObservableCollection<ChartOfAccount>(await ChartOfAccount.ChartOfAccountListing());
        }
    }
}
