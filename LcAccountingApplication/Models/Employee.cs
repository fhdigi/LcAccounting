using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace LcAccountingApplication.Models
{
    public class Employee
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string SocialSecurityNumber { get; set; }
        public DateTime DateHired { get; set; }
        public string PayType { get; set; }
        public double PayRate { get; set; }
        public double AdditionalPay { get; set; }
        public string EmergencyContact { get; set; }
        public string EmergencyRelationship { get; set; }
        public string EmergencyPhone { get; set; }
        public string MedicalCondition { get; set; }
        public string Notes { get; set; }
        public bool Inactive { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateTermination { get; set; }

        private static readonly IMobileServiceTable<Employee> BillsTable = App.MobileService.GetTable<Employee>();

        public static async Task InsertBills(Employee employee)
        {
            await BillsTable.InsertAsync(employee);
        }

        public static async Task UpdateBills(Employee employee)
        {
            await BillsTable.UpdateAsync(employee);

        }
        public static async Task DeleteBills(Employee employee)
        {
            await BillsTable.DeleteAsync(employee);
        }

        public static async Task<List<Employee>> BillsListing()
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
    }
}
