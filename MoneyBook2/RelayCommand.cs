using System.Windows.Input;

namespace MoneyBook2
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool>? _canExecute;

        public RelayCommand(Action<T> execute, Func<T, bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            if (_canExecute == null)
                return true;

            if (parameter == null && typeof(T).IsValueType)
                return _canExecute(default!);

            return _canExecute((T)parameter);
        }

        public void Execute(object? parameter)
        {
            if (parameter == null && typeof(T).IsValueType)
                _execute(default!);
            else
                _execute((T)parameter);
        }

        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// Forces WPF to re-evaluate CanExecute
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
