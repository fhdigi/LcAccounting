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
        //PROPERTIES
        public ObservableCollection<Bills> BillsListing { get; set; }
        public Bills SelectedBillsListing { get; set; }

        public Bills NewBillsBuffer; //Used when creating a new accont (Discarded if Cancel, Added if Save)
        public bool IsAccountListingSelected
        {
            get
            {
                return SelectedBillsListing != null;
            }
        }


        public ICommand NavigateToAddVendorPageCommand;
        public ICommand NavigateToAddAccountPageCommand;
        public ICommand SaveAndCloseCommand;
        public ICommand CancelCommand;

        public Type CurrentSourcePageType = null;

        public PayablesViewModel()
        {
            Task.Run(SetBillsListing).Wait();
            SortBillsListing();
            NewBillsBuffer = new Bills();

        }
        public void SortBillsListing()
        {
            //List<Bills> sortedList = BillsListing.ToList<Bills>();
            //sortedList.Sort((x, y) => x.VendorID.CompareTo(y.VendorID));
            //BillsListing = new ObservableCollection<Bills>(sortedList);
            Task.Run(Bills.BillsListing).Wait();
        }
        private async Task SetBillsListing()
        {
            try
            {
                BillsListing = new ObservableCollection<Bills>(await Bills.BillsListing());
            }
            catch (Exception e)
            {
                BillsListing = new ObservableCollection<Bills>();
            }

        }

    }
}
