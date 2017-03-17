using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Windows.System.Profile;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Cerebro.Common;
using Cerebro.Model;
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
            LoadData();
            Frame = ((MainView)_navigate.Content).FrameControl;
        }
        private void NavigationServiceBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (_navigate.CanGoBack)
            {
                _navigate.GoBack();
            }
        }


        private ObservableCollection<MenuItemModel> _menuList;

        public ObservableCollection<MenuItemModel> MenuList
        {
            get { return _menuList; }
            set
            {
                _menuList = value;
                OnPropertyChanged();
            }
        }

        private ICommand _showOptionCommand;

        public ICommand ShowOptionCommand
        {
            get
            {
                _showOptionCommand = _showOptionCommand ?? new CommandHandler<MenuItemModel>(LoadPage);
                return _showOptionCommand;
            }

        }

        private Frame _frame;

        public Frame Frame
        {
            get { return _frame; }
            set
            {
                _frame = value;
                OnPropertyChanged();
            }
        }

        private void LoadPage(MenuItemModel item)
        {
            switch (item.Id)
            {
                case 1:
                    var vm = new InfoListViewModel(Frame);
            
                    break;
            }
        }
        public void LoadData()
        {
            MenuList =  new ObservableCollection<MenuItemModel>(new List<MenuItemModel>()
            {
                new MenuItemModel()
                {
                    Id = 1,
                    Icon = "",
                    Title = "Buscar Muntante"
                }
            });
        }

    }
}