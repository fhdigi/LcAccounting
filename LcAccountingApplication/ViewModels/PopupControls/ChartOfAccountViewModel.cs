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
        public ChartOfAccount SelectedAccountListing { get; set; }
        public int SelectedGroupingIndex
        {
            get
            {
                return (int)NewAccountBuffer.Grouping;
            }

            set
            {
                switch(value)
                {
                    default: break;
                    case 0:
                        NewAccountBuffer.Grouping = AccountTypes.Asset;
                        break;
                    case 1:
                        NewAccountBuffer.Grouping = AccountTypes.Liability;
                        break;
                    case 2:
                        NewAccountBuffer.Grouping = AccountTypes.Equity;
                        break;
                    case 3:
                        NewAccountBuffer.Grouping = AccountTypes.Income;
                        break;
                    case 4:
                        NewAccountBuffer.Grouping = AccountTypes.Expense;
                        break;
                }
            }
        }

        public List<string> Groupings
        {
            get { return Enum.GetNames(typeof(AccountTypes)).ToList<string>(); }
        }

        public ChartOfAccount NewAccountBuffer; //Useed when creating a new accont (Discarded if Cancel, Added if Save)
        public bool IsNewAccount; //True if creating a chart of account. False is editing one.
        public bool IsAccountListingSelected { get; set; }

        //COMMANDS
        public ICommand EditSelectedAccountCommand; //Defined in code-behind
        public ICommand ClosePageCommand; //Defined in code-behind
        public ICommand DeleteSelectedAccountCommand;
        public ICommand AddNewAccountCommand; //Defined in code-behind

        public ICommand SaveEditedAccountCommand;

        //CONSTRUCTOR
        public ChartOfAccountViewModel()
        {
            Task.Run(SetAccountListing).Wait();
            SortAccountListings();
            DeleteSelectedAccountCommand = new RelayCommand(DeleteSelectedAccount);

        }


        //FUNCTIONS
        private async void DeleteSelectedAccount()
        {
            await ChartOfAccount.DeleteChartOfAccount(SelectedAccountListing);
        }
        public void SortAccountListings()
        {
            List<ChartOfAccount> sortedList = ChartOfAccountListing.ToList<ChartOfAccount>();
            sortedList.Sort((x, y) => x.AccountNumber.CompareTo(y.AccountNumber));
            ChartOfAccountListing = new ObservableCollection<ChartOfAccount>(sortedList);
            Task.Run(ChartOfAccount.ChartOfAccountListing).Wait();
        }
        public async Task SetAccountListing()
        {
            ChartOfAccountListing = await ChartOfAccount.ChartOfAccountListing();
        }
    }
}
