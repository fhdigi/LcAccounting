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
        public ICommand NavigateToCreateChartOfAccountPageCommand;
        public ICommand CloseChartOfAccountPageCommand;


        //CONSTRUCTOR
        public ChartOfAccountViewModel()
        {
            Task.Run(SetAccountListing).Wait();
        }


        //FUNCTIONS


        //TASKS
        private async Task SetAccountListing()
        {
            ChartOfAccountListing = new ObservableCollection<ChartOfAccount>(await ChartOfAccount.ChartOfAccountListing());
        }
    }
}
