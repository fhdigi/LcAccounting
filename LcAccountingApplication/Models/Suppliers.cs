using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace LcAccountingApplication.Models
{
    public class Suppliers
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "SupplierName")]
        public string SupplierName { get; set; }

        [JsonProperty(PropertyName = "AccountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty(PropertyName = "Terms")]
        public int Terms { get; set; }

        [JsonProperty(PropertyName = "Address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "City")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "State")]
        public string State { get; set;}

        [JsonProperty (PropertyName ="ZipCode")]
        public string ZipCode { get; set; }

        [JsonProperty (PropertyName ="Phone")]
        public string Phone { get; set; }

        [JsonProperty (PropertyName ="Fax")]
        public string Fax { get; set; }

        [JsonProperty (PropertyName="Email")]
        public string Email { get; set; }

        private static readonly IMobileServiceTable<Suppliers> SuppliersTable = App.MobileService.GetTable<Suppliers>();

        public static async Task InsertSuppliers(Suppliers SuppliersItem)
        {
            await SuppliersTable.InsertAsync(SuppliersItem);
        }
        public static async Task UpdateSuppliers (Suppliers SuppliersItem)
        {
            await SuppliersTable.UpdateAsync(SuppliersItem);
        }
        public static async Task DeleteSuppliers(Suppliers SuppliersItem)
        {
            await SuppliersTable.DeleteAsync(SuppliersItem);

        }
        public static async Task<List<Suppliers>> SuppliersListing()
        {
       
            try
            {
                var listing = await SuppliersTable.ToListAsync();
                return listing;
            }
            catch (MobileServiceInvalidOperationException)
            {
                return null;

            }


        }

        public Suppliers()
        {
            SupplierName = "";
            AccountNumber = "";
            Terms = 0;
            Address = "";
            City = "";
            State = "";
            ZipCode = "";
            Phone = "";
            Fax = "";
            Email = "";
        }
        public void CorrectNullValues()
        {
            if (SupplierName == null) SupplierName = "";
            if (AccountNumber == null) AccountNumber = "";
            if (Address == null) Address = "";
            if (City == null) City = "";
            if (State == null) State = "";
            if (ZipCode == null) ZipCode = "";
            if (Phone == null) Phone = "";
            if (Fax == null) Fax = "";
            if (Email == null) Email = "";
        }
    }
}
