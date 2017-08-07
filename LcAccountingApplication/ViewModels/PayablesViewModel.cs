using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

using LcAccountingApplication.Models.PopupControls;
using System.Collections.ObjectModel;
using System.Windows.Input;
using LcAccountingApplication.Helpers;
using LcAccountingApplication.Views.PopupControls;
using LcAccountingApplication.Models;
using Windows.UI.Xaml.Data;

namespace LcAccountingApplication.ViewModels
{
    public class PayablesViewModel : Observable
    {
        public ObservableCollection<Bills> BillsListing { get; set; }
        public ObservableCollection<Bills> SpecificBillsListing
        {
            get
            {
                //ObservableCollection<Bills> filteredBillsListing = new ObservableCollection<Bills>();

                //foreach (Bills b in BillsListing)
                //{
                //    if (b.VendorId == SelectedSupplier.Id) filteredBillsListing.Add(b);
                //}
                //return filteredBillsListing;

                return BillsListing;
            }
        }
        public int SelectedBillsListingIndex { get; set; }
        public Bills SelectedBillsListing
        {
            get
            {
                if (SelectedBillsListingIndex > 0 && BillsListing.Count > 0) return BillsListing[SelectedBillsListingIndex];
                else return null;
            }
        }
        public Type CurrentSourcePageType = null;

        public Bills NewBillsBuffer; //Used when creating a new accont (Discarded if Cancel, Added if Save)
        public bool IsBillListingSelected
        {
            get
            {
                return SelectedBillsListing != null;
            }
        }
        public bool IsVendorListingSelected
        {
            get
            {
                return SelectedSupplier != null;
            }
        }


        public ICommand NavigateToAddVendorPageCommand;
        public ICommand NavigateToAddAccountPageCommand;
        public ICommand SaveAndCloseCommand;
        public ICommand CancelCommand;

        public ICommand NewSupplierCommand;
        public ICommand RemoveSupplierCommand;
        public ICommand SaveNewSupplierCommand;

        public ObservableCollection<Supplier> SuppliersListing { get; set; }

        private Supplier _SelectedSupplier;
        public Supplier SelectedSupplier
        {
            get
            {
                SortBillsListing();
                if (SelectedSupplierIndex != -1) return SuppliersListing[SelectedSupplierIndex];
                else return null;
            }
        }
        int _SelectedSupplierIndex;
        public int SelectedSupplierIndex
        {
            get
            {
                return _SelectedSupplierIndex;
            }
            set
            {
                _SelectedSupplierIndex = value;
                SortBillsListing();
            }
        }

        public Supplier NewSupplierBuffer { get; set; }



        public ObservableCollection<ChartOfAccount> ChartOfAccountListing {
            get
            {
                return Task.Run(ChartOfAccount.ChartOfAccountListing).GetAwaiter().GetResult();
            }
        }

        private ChartOfAccount _SelectedChartOfAccount;
        public ChartOfAccount SelectedChartOfAccount
        {
            get
            {
                if (SelectedChartOfAccountIndex != -1) return ChartOfAccountListing[SelectedChartOfAccountIndex];
                else return null;
            }
            set
            {
                _SelectedChartOfAccount = value;
                NewBillsBuffer.AccountId = _SelectedChartOfAccount.Id;
            }
        }

        public int SelectedChartOfAccountIndex { get; set; }
        public ChartOfAccount NewChartOfAccountBuffer { get; set; }




        //FUNCTIONS
        public PayablesViewModel()
        {
            Task.Run(SetBillsListing).Wait();
            SortBillsListing();
            NewBillsBuffer = new Bills();

            Task.Run(SetSuppliers).Wait();
            NewSupplierBuffer = new Supplier();
        }
        public void SortBillsListing()
        {
            List<Bills> sortedList = BillsListing.ToList<Bills>();
            sortedList.Sort((x, y) => x.VendorId.CompareTo(y.VendorId));
            BillsListing = new ObservableCollection<Bills>(sortedList);
            Task.Run(Bills.BillsListing).Wait();
        }
        public void SortVendorsListing()
        {
            List<Supplier> sortedList = SuppliersListing.ToList<Supplier>();
            sortedList.Sort((x, y) => x.SupplierName.CompareTo(y.SupplierName));
            SuppliersListing = new ObservableCollection<Supplier>(sortedList);
            Task.Run(Supplier.SuppliersListing).Wait();
        }
        public async Task SetBillsListing()
        {
            try
            {
                BillsListing = new ObservableCollection<Bills>(await Bills.BillsListing());
                SortBillsListing();
            }
            catch (Exception e)
            {
                BillsListing = new ObservableCollection<Bills>();
            }
        }

        public async Task SetSuppliers()
        {
            try
            {
                SuppliersListing = new ObservableCollection<Supplier>(await Supplier.SuppliersListing());
                SortVendorsListing();
            }
            catch(Exception e)
            {
                SuppliersListing = new ObservableCollection<Supplier>();
            }
        }
    }
}