using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Cerebro.Common;

namespace Cerebro.ViewModel.Base
{
    public abstract class BaseViewModel : NotifyPropertychange
    {
        protected readonly Frame _navigate;

        protected BaseViewModel(Frame navigation)
        {
            _navigate = navigation;
            Navigate();
        }

        public abstract void Navigate();

        protected void Navigate(Type viewType, object context)
        {
            _navigate.Navigate(viewType);
            var element = _navigate.Content as FrameworkElement;
            if (element != null)
            {
                element.DataContext = context;
            }
        }
    }
}