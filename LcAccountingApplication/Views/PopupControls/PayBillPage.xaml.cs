﻿using LcAccountingApplication.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LcAccountingApplication.Views.PopupControls
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PayBillPage : Page
    {
        PayablesViewModel ViewModel;

        public PayBillPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel = (PayablesViewModel)e.Parameter;
            DataContext = ViewModel;
        }
    }
}
