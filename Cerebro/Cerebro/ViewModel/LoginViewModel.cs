using System;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Cerebro.Common;
using Cerebro.Common.Helper;
using Cerebro.ViewModel.Base;
using Cerebro.Views;
using CerebroInfo;

namespace Cerebro.ViewModel
{
    public class LoginViewModel:BaseViewModel
    {
        public LoginViewModel(Frame navigation) : base(navigation)
        {
        }

        public override void Navigate()
        {
            Navigate(typeof(LoginView),this);
            UserName = string.Empty;
        }

        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        private ICommand _loginCommand;

        public ICommand LoginCommand
        {
            get
            {
                _loginCommand = _loginCommand ?? new CommandHandler(ValidateUser);
                return _loginCommand;
            }
        }

        private async void ValidateUser()
        {
            if (Validate.ValidateUser(UserName))
            {
                MainViewModel vm = new MainViewModel(_navigate);
                
            }
            else
            {
                MessageDialog message = new MessageDialog(string.Format(Resources.GetResource("InvalidMemberOfXmen"),UserName));
                await message.ShowAsync();
            }
        }
    }
}