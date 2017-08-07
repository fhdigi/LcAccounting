using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace LcAccountingApplication.Models
{
    public class Bills
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "VendorId")]
        public string VendorId { get; set; }

        [JsonProperty(PropertyName = "InvNumber")]
        public string InvNumber { get; set; }

        [JsonProperty(PropertyName = "Amount")]
        public double Amount { get; set; }

        [JsonProperty(PropertyName = "Received")]
        public DateTimeOffset Received { get; set; }

        [JsonProperty(PropertyName = "DateDue")]
        public DateTimeOffset DateDue { get; set; }

        [JsonProperty(PropertyName = "AccountId")]
        public string AccountId { get; set; }

        [JsonProperty(PropertyName = "PaymentsMade")]
        public bool PaymentsMade { get; set; }

        [JsonProperty(PropertyName = "LedgerLink")]
        public string LedgerLink { get; set; }

        [JsonProperty(PropertyName = "DateAnticipated")]
        public DateTimeOffset DateAnticipated { get; set; }

        private static readonly IMobileServiceTable<Bills> BillsTable = App.MobileService.GetTable<Bills>();
        public static async Task InsertBills(Bills BillsItem)
        {
            await BillsTable.InsertAsync(BillsItem);
        }

        public static async Task UpdateBills(Bills BillsItem)
        {
            await BillsTable.UpdateAsync(BillsItem);

        }
        public static async Task DeleteBills(Bills BillsItem)
        {
            await BillsTable.DeleteAsync(BillsItem);
        }

        public static async Task<List<Bills>> BillsListing()
        {
            try
            {
                var listing = await BillsTable.ToListAsync();
                return listing;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Bills()
        {
            VendorId = "";
            InvNumber = "";
            Amount = 0.0;
            Received = DateTimeOffset.Now;
            DateDue = DateTimeOffset.Now;
            AccountId = "";
            PaymentsMade = false;
            LedgerLink = "";
            DateAnticipated = DateTimeOffset.Now;
        }
    }
}

    
