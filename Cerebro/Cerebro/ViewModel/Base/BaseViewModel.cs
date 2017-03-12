using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Cerebro.Common;

namespace Cerebro.ViewModel.Base
{
    public abstract class BaseViewModel : NotifyPropertychange
    {
        protected Frame _navigate;

        protected BaseViewModel(Frame navigation)
        {
            _navigate = navigation;
            Navigate();
        }

        public abstract void Navigate();

        protected void Navigate(Type viewType, object context)
        {
            _navigate.Navigate(viewType);
            var element = (FrameworkElement)_navigate.Content;
            if (element != null)
            {
                element.DataContext = context;
            }
        }
    }
}