using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Data;
using LcAccountingApplication.Helpers;

namespace LcAccountingApplication.Models
{
    public class Employee
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "LastName")] public string LastName { get; set; }
        [JsonProperty(PropertyName = "FirstName")] public string FirstName { get; set; }
        [JsonProperty(PropertyName = "MiddleInitial")] public string MiddleInitial { get; set; }
        [JsonProperty(PropertyName = "PinNumber")] public string PinNumber { get; set; }
        [JsonProperty(PropertyName = "IsAdmin")] public bool IsAdmin { get; set; }
        [JsonProperty(PropertyName = "Address")] public string Address { get; set; }
        [JsonProperty(PropertyName = "City")] public string City { get; set; }
        [JsonProperty(PropertyName = "State")] public string State { get; set; }
        [JsonProperty(PropertyName = "ZipCode")] public string ZipCode { get; set; }
        [JsonProperty(PropertyName = "PhoneNumber")] public string PhoneNumber { get; set; }
        [JsonProperty(PropertyName = "SocialSecurityNumber")] public string SocialSecurityNumber { get; set; }
        [JsonProperty(PropertyName = "DateHired")] public DateTimeOffset DateHired { get; set; }
        [JsonProperty(PropertyName = "PayType")] public string PayType { get; set; }
        [JsonProperty(PropertyName = "PayRate")] public decimal PayRate { get; set; }
        [JsonProperty(PropertyName = "AdditionalPay")] public double AdditionalPay { get; set; }
        [JsonProperty(PropertyName = "EmergeencyContact")] public string EmergencyContact { get; set; }
        [JsonProperty(PropertyName = "EmergencyRelationship")] public string EmergencyRelationship { get; set; }
        [JsonProperty(PropertyName = "EmergencyPhone")] public string EmergencyPhone { get; set; }
        [JsonProperty(PropertyName = "MedicalCondition")] public string MedicalCondition { get; set; }
        [JsonProperty(PropertyName = "Notes")] public string Notes { get; set; }
        [JsonProperty(PropertyName = "Inactive")] public bool? Inactive { get; set; }
        [JsonProperty(PropertyName = "DateOfBirth")] public DateTimeOffset DateOfBirth { get; set; }
        [JsonProperty(PropertyName = "DateTermination")] public DateTimeOffset DateTermination { get; set; }

        //For UI
        public string DisplayName
        {
            get { return LastName + ", " + FirstName; }
        }
        public string HomeAddress
        {
            get { return Address + "\n" + City + ", " + State + " " + ZipCode; }
        }
        public string Pay
        {
            get
            {
                if (PayType == "Hourly") return "$" + PayRate.ToString("C2") + "/hr";
                else return "$" + PayRate.ToString("C2");
            }
        }

        private static readonly IMobileServiceTable<Employee> EmployeesTable = App.MobileService.GetTable<Employee>();

        public static async Task InsertEmployee(Employee employee)
        {
            await EmployeesTable.InsertAsync(employee);
        }

        public static async Task UpdateEmployee(Employee employee)
        {
            await EmployeesTable.UpdateAsync(employee);

        }
        public static async Task DeleteEmployee(Employee employee)
        {
            await EmployeesTable.DeleteAsync(employee);
        }

        public static async Task<ObservableCollection<Employee>> EmployeeListing()
        {
            try
            {
                var listing = new ObservableCollection<Employee>(await EmployeesTable.ToListAsync());
                return listing;
            }
            catch (MobileServiceInvalidOperationException e)
            {
                return null;
            }
        }

        //For initializing values with a new employee
        public Employee()
        {
            LastName = "";
            FirstName = "";
            MiddleInitial = "";
            PinNumber = 0;
            IsAdmin = false;
            Address = "";
            City = "";
            State = "";
            ZipCode ="";
            PhoneNumber = "";
            SocialSecurityNumber = "";
            DateHired = DateTimeOffset.Now;
            PayType = "";
            PayRate = 10.40M;
            AdditionalPay = 0.00;
            EmergencyContact = "";
            EmergencyRelationship = "";
            EmergencyPhone = "";
            MedicalCondition = "";
            Notes = "";
            Inactive = false;
            DateOfBirth = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
            DateTermination = DateTimeOffset.Now;
        }

        public void CorrectNullValues()
        {
            if (FirstName == null) FirstName = "";
            if (LastName == null) LastName = "";
            if (MiddleInitial == null) MiddleInitial = "";
            if (Address == null) Address = "";
            if (City == null) City = "";
            if (State == null) State = "";
            if (ZipCode == null) ZipCode = "";
            if (PhoneNumber == null) PhoneNumber = "";
            if (SocialSecurityNumber == null) SocialSecurityNumber = "";
            if (DateHired == null) DateHired = DateTimeOffset.Now;
            if (PayType == null) PayType = "";
            if (EmergencyContact == null) EmergencyContact = "";
            if (EmergencyRelationship == null) EmergencyRelationship = "";
            if (EmergencyPhone == null) EmergencyPhone = "";
            if (Notes == null) Notes = "";
            if (DateOfBirth == null) DateOfBirth = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
            if (DateTermination == null) DateTermination = DateTimeOffset.Now;
        }
    }

    public class ObservableCollectionToObjectConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (object)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (ObservableCollection<Employee>)value;
        }
    }

}
