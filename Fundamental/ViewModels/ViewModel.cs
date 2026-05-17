using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Fundamental.ViewModels
{
    internal abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public event CollectionChangeEventHandler? CollectionChange;

        protected virtual void OnPropertyChanged([CallerMemberName] string? PropertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));

        protected virtual void OnCollectionChanged([CallerMemberName] string? PropertyName = null) =>
            CollectionChange?.Invoke(this, new CollectionChangeEventArgs(CollectionChangeAction.Refresh, PropertyName));

        protected virtual bool Set<T>(ref T Field, T Value, [CallerMemberName] string? PropertyName = null)
        {
            if (Equals(Field, Value)) return false;
            Field = Value;
            OnPropertyChanged(PropertyName);
            return true;
        }
    }
}
