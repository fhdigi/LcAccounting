﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace LcAccountingApplication.Models
{
    public class Employee
    {
        [JsonProperty(PropertyName = "LastName")] public string LastName { get; set; }
        [JsonProperty(PropertyName = "FirstName")] public string FirstName { get; set; }
        [JsonProperty(PropertyName = "MiddleInitial")] public string MiddleInitial { get; set; }
        [JsonProperty(PropertyName = "PinNumber")] public int PinNumber { get; set; }
        [JsonProperty(PropertyName = "IsAdmin")] public bool IsAdmin { get; set; }
        [JsonProperty(PropertyName = "Address")] public string Address { get; set; }
        [JsonProperty(PropertyName = "City")] public string City { get; set; }
        [JsonProperty(PropertyName = "State")] public string State { get; set; }
        [JsonProperty(PropertyName = "ZipCode")] public string ZipCode { get; set; }
        [JsonProperty(PropertyName = "PhoneNumber")] public string PhoneNumber { get; set; }
        [JsonProperty(PropertyName = "SocialSecurityNumber")] public string SocialSecurityNumber { get; set; }
        [JsonProperty(PropertyName = "DateHired")] public DateTime DateHired { get; set; }
        [JsonProperty(PropertyName = "PayType")] public string PayType { get; set; }
        [JsonProperty(PropertyName = "PayRate")] public double PayRate { get; set; }
        [JsonProperty(PropertyName = "AdditionalPay")] public double AdditionalPay { get; set; }
        [JsonProperty(PropertyName = "EmergeencyContact")] public string EmergencyContact { get; set; }
        [JsonProperty(PropertyName = "EmergencyRelationship")] public string EmergencyRelationship { get; set; }
        [JsonProperty(PropertyName = "EmergencyPhone")] public string EmergencyPhone { get; set; }
        [JsonProperty(PropertyName = "MedicalCondition")] public string MedicalCondition { get; set; }
        [JsonProperty(PropertyName = "Notes")] public string Notes { get; set; }
        [JsonProperty(PropertyName = "Inactive")] public bool Inactive { get; set; }
        [JsonProperty(PropertyName = "DateOfBirth")] public DateTime DateOfBirth { get; set; }
        [JsonProperty(PropertyName = "DateTermination")] public DateTime DateTermination { get; set; }

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
