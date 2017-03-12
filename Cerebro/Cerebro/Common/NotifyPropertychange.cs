using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Cerebro.Common
{
    public class NotifyPropertychange:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}