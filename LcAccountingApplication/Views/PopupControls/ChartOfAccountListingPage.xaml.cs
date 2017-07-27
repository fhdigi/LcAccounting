using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using LcAccountingApplication.ViewModels.PopupControls;
using LcAccountingApplication.Helpers;
using LcAccountingApplication.Models.PopupControls;
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LcAccountingApplication.Views.PopupControls
{
    public sealed partial class ChartOfAccountListingPage : Page
    {
        ChartOfAccountViewModel ViewModel;

        public ChartOfAccountListingPage()
        {
            ViewModel = new ChartOfAccountViewModel()
            {
                EditSelectedAccountCommand = new RelayCommand(() =>
                {
                    ViewModel.IsNewAccount = false;
                    ViewModel.NewAccountBuffer = ViewModel.SelectedAccountListing;
                    Frame.Navigate(typeof(ChartOfAccountPage), this.ViewModel);
                }),
                ClosePageCommand = new RelayCommand(() =>
                {
                    //Frame.GoBack();
                }),
                AddNewAccountCommand = new RelayCommand(() =>
                {
                    ViewModel.IsNewAccount = true;
                    ViewModel.NewAccountBuffer = new ChartOfAccount();
                    Frame.Navigate(typeof(ChartOfAccountPage), this.ViewModel);
                }),
                SaveEditedAccountCommand = new RelayCommand(async () =>
                {

                    if(ViewModel.NewAccountBuffer.AccountName != null && ViewModel.NewAccountBuffer.AccountNumber != null) //TODO: Fix comboBox and add code here
                    if (ViewModel.IsNewAccount) await ChartOfAccount.InsertChartOfAccount(ViewModel.NewAccountBuffer);
                    else await ChartOfAccount.UpdateChartOfAccount(ViewModel.NewAccountBuffer);
                    ViewModel.SortAccountListings();
                    Frame.GoBack();
                })
            };
            DataContext = ViewModel;

            this.InitializeComponent();
        }

    }
}
