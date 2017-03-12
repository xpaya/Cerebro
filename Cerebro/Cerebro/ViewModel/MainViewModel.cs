using Windows.System.Profile;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Cerebro.ViewModel.Base;
using Cerebro.Views;

namespace Cerebro.ViewModel
{
    public class MainViewModel :BaseViewModel
    {
        public MainViewModel(Frame navigation) : base(navigation)
        {
        }

        public override void Navigate()
        {
            Navigate(typeof(MainView), this);
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = _navigate.CanGoBack ?
                                                                           AppViewBackButtonVisibility.Visible :
                                                                           AppViewBackButtonVisibility.Collapsed;
            SystemNavigationManager.GetForCurrentView().BackRequested += NavigationServiceBackRequested;
        }
        private void NavigationServiceBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (_navigate.CanGoBack)
            {
                _navigate.GoBack();
            }
        }
      

    }
}