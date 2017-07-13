﻿using System;
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
        public int SelectedGroupingIndex { get; set; }
        public List<AccountTypes> AccountTypesList { get; protected set; }


        public ChartOfAccount NewAccountBuffer; //Useed when creating a new accont (Discarded if Cancel, Added if Save)
        public bool IsNewAccount; //True if creating a chart of account. False is editing one.
        public ChartOfAccount SelectedAccountListing
        {
            get
            {
                return ChartOfAccountListing[SelectedAccountListingIndex];
            }
        }
        public bool IsAccountListingSelected
        {
            get
            {
                return SelectedAccountListingIndex > -1;
            }
        }

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

            var _enumeratorValue = Enum.GetValues(typeof(AccountTypes)).Cast<AccountTypes>();
            AccountTypesList = _enumeratorValue.ToList();
        }


        //FUNCTIONS
        private async void DeleteSelectedAccount()
        {
            await ChartOfAccount.DeleteChartOfAccount(ChartOfAccountListing[SelectedAccountListingIndex]);
            SortAccountListings();
        }
        public void SortAccountListings()
        {
            List<ChartOfAccount> sortedList = ChartOfAccountListing.ToList<ChartOfAccount>();
                sortedList.Sort((x, y) => x.AccountNumber.CompareTo(y.AccountNumber));
            ChartOfAccountListing = new ObservableCollection<ChartOfAccount>(sortedList);
            Task.Run(ChartOfAccount.ChartOfAccountListing).Wait();
        }
        private async Task SetAccountListing()
        {
            ChartOfAccountListing = new ObservableCollection<ChartOfAccount>(await ChartOfAccount.ChartOfAccountListing());
        }
    }
}
