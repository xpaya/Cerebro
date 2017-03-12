using System;
using System.Windows.Input;

namespace Cerebro.Common
{
    public class CommandHandler : ICommand
    {
#pragma warning disable 0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore 0067

        private Action _action;
        private Func<bool> _canExecute;

        public CommandHandler(Action action) : this(action, () => true)
        {
        }

        public CommandHandler(Action action, Func<bool> canExecute)
        {
            this._action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute();
        }

        public void Execute(object parameter)
        {
            if (_canExecute())
            {
                _action();
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public class CommandHandler<T> : ICommand
    {
#pragma warning disable 0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore 0067

        private Action<T> _action;
        private Func<bool> _canExecute;
        private bool result;

        public CommandHandler(Action<T> action) : this(action, () => true)
        {
        }

        public CommandHandler(Action<T> action, Func<bool> canExecute)
        {
            this._action = action;
            _canExecute = canExecute;
        }

        public virtual bool CanExecute(object parameter)
        {
            result = _canExecute.Invoke();
            return result;
        }

        public void Execute(object parameter)
        {
            if (_canExecute())
            {
                this._action((T)parameter);
            }
        }

        public void RaiseCanExecuteChanged()
        {
            bool currentValue = result;
            if (CanExecute(null) != currentValue)
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}