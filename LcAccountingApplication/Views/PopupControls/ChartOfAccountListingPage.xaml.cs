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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LcAccountingApplication.Views.PopupControls
{
    public sealed partial class ChartOfAccountListingPage : Page
    {
        ChartOfAccountViewModel ViewModel;

        public ChartOfAccountListingPage()
        {
            ViewModel = new ChartOfAccountViewModel();

            DataContext = ViewModel;
            this.InitializeComponent();
        }
    }
}
