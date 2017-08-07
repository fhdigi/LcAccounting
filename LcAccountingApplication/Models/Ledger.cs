using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace LcAccountingApplication.Models
{
    public class Ledger
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "TransactionDate")]
        public DateTimeOffset TransactionDate { get; set; }

        [JsonProperty(PropertyName = "TransactionType")]
        public float TransactionType { get; set; }

        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "Amount")]
        public float Amount { get; set; }

        [JsonProperty(PropertyName = "AssociativeId")]
        public Guid AssociativeId { get; set; }


        private static readonly IMobileServiceTable<Ledger> LedgerTable = App.MobileService.GetTable<Ledger>();
        public static async Task InsertLedger(Ledger LedgerItem)
        {
            await LedgerTable.InsertAsync(LedgerItem);
        }

        public static async Task UpdateLedger(Ledger LedgerItem)
        {
            await LedgerTable.UpdateAsync(LedgerItem);

        }
        public static async Task DeleteLedger(Ledger LedgerItem)
        {
            await LedgerTable.DeleteAsync(LedgerItem);
        }

        public static async Task<List<Ledger>> LedgerListing()
        {
            try
            {
                var listing = await LedgerTable.ToListAsync();
                return listing;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Ledger()
        {
            TransactionDate = DateTimeOffset.Now;
            TransactionType = 1.0f;
            Amount = 0.0f;
        }
    }
}
