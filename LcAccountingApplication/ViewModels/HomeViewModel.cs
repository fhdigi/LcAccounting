using System;
using System.Threading.Tasks;
using LcAccountingApplication.Helpers;
using LcAccountingApplication.Models;

namespace LcAccountingApplication.ViewModels
{
    public class HomeViewModel : Observable
    {
        public HomeViewModel()
        {
            Task.Run(GetAccountListing);
        }

        public async Task GetAccountListing()
        {
            var listing = await ChartOfAccount.ChartOfAccountListing();
        }
    }
}
