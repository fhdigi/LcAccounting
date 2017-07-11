using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LcAccountingApplication.Models.PopupControls;

namespace LcAccountingApplication.ViewModels.PopupControls
{
    public class ChartOfAccountViewModel
    {
        public List<ChartOfAccount> ChartOfAccountListing { get; set; }

        public ChartOfAccountViewModel()
        {
            Task.Run(SetAccountListing);
        }
        private async Task SetAccountListing()
        {
            ChartOfAccountListing = await ChartOfAccount.ChartOfAccountListing();
        }
    }
}
