using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace LcAccountingApplication.Models
{
    public class ChartOfAccount
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "AccountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty(PropertyName = "AccountName")]
        public string AccountName { get; set; }

        [JsonProperty(PropertyName = "Grouping")]
        public string Grouping { get; set; }

        private static readonly IMobileServiceTable<ChartOfAccount> CoaTable = App.MobileService.GetTable<ChartOfAccount>();

        public static async Task InsertChartOfAccount(ChartOfAccount coaItem)
        {
            // This code inserts a new item into the database. 
            await CoaTable.InsertAsync(coaItem);
        }

        private static async Task<List<ChartOfAccount>> ChartOfAccountListing()
        {
            try
            {
                return await CoaTable.ToListAsync();
            }
            catch (MobileServiceInvalidOperationException e)
            {
                return null;
            }
        }
    }
}
