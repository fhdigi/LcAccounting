using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace LcAccountingApplication.Models.PopupControls
{
    class Project
    {

        [JsonProperty(PropertyName = "Client")]
        public string Client { get; set; }

        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "PurchaseOrderNumber")]
        public int PurchaseOrderNumber { get; set; }

        [JsonProperty(PropertyName = "PurchaseOrderAmount")]
        public int PurchaseOrderAmount { get; set; }

        [JsonProperty(PropertyName = "PrimaryContact")]
        public string PrimaryContact { get; set; }

        [JsonProperty(PropertyName = "DateReceived")]
        public DateTime DateReceived { get; set; }

        [JsonProperty(PropertyName = "DueDate")]
        public DateTime DueDate { get; set; }

        [JsonProperty(PropertyName = "ContractNumeber")]
        public string ContractNumber { get; set; }

        [JsonProperty(PropertyName = "FreightCode")]
        public string FreightCode { get; set; }

        [JsonProperty(PropertyName = "Hours")]
        public int Hours { get; set; }

        [JsonProperty(PropertyName = "Rate")]
        public int Rate { get; set; }

        [JsonProperty(PropertyName = "JobIsClosed")]
        public bool JobIsClosed { get; set; }

        [JsonProperty(PropertyName = "ShippedVia")]
        public string ShippedVia { get; set; }

        [JsonProperty(PropertyName = "OtherAmount")]
        public int OtherAmount { get; set; }

        [JsonProperty(PropertyName = "TotalAmount")]
        public string TotalAmount { get; set; }


        private static readonly IMobileServiceTable<Project> ProjectTable = App.MobileService.GetTable<Project>();
        public static async Task InsertProject(Project ProjectItem)
        {
            await ProjectTable.InsertAsync(ProjectItem);
        }

        public static async Task UpdateProject(Project ProjectItem)
        {
            await ProjectTable.UpdateAsync(ProjectItem);

        }
        public static async Task DeleteProject(Project ProjectItem)
        {
            await ProjectTable.DeleteAsync(ProjectItem);
        }

        public static async Task<List<Project>> ProjectListing()
        {
            try
            {
                var listing = await ProjectTable.ToListAsync();
                return listing;
            }
            catch (Exception)
            {
                return null;
            }
        }




    }
}
