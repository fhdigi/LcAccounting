using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace LcAccountingApplication.Models.PopupControls
{
    public class ChartOfAccount
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "AccountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty(PropertyName = "AccountName")]
        public string AccountName { get; set; }

        [JsonProperty(PropertyName = "Grouping")]
        public AccountTypes Grouping { get; set; }

        private static readonly IMobileServiceTable<ChartOfAccount> CoaTable = App.MobileService.GetTable<ChartOfAccount>();

        public static async Task InsertChartOfAccount(ChartOfAccount coaItem)
        {
            await CoaTable.InsertAsync(coaItem);
        }

        public static async Task UpdateChartOfAccount(ChartOfAccount coaItem)
        {
            await CoaTable.UpdateAsync(coaItem);
        }

        public static async Task DeleteChartOfAccount(ChartOfAccount coaItem)
        {
            await CoaTable.DeleteAsync(coaItem);
        }

        public static async Task<List<ChartOfAccount>> ChartOfAccountListing()
        {
            try
            {
                var listing = await CoaTable.ToListAsync();
                return listing;
            }
            catch (MobileServiceInvalidOperationException e)
            {
                return null;
            }
        }
    }
    public enum AccountTypes
    {
        Asset = 0,
        Liability = 1,
        Equity = 2,
        Income = 3,
        Expense = 4
    }
}
