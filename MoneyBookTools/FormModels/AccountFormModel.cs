using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MoneyBookTools.FormModels
{
    public class AccountFormModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            ContextChanged?.Invoke();
        }

        public delegate void ContextChangedEventHandler();
        public event ContextChangedEventHandler ContextChanged;

        private int m_acctId;
        public int AcctId
        {
            get => m_acctId;
            set
            {
                m_acctId = value;
                OnPropertyChanged();
            }
        }

        private string m_name;
        public string Name
        {
            get => m_name;
            set
            {
                m_name = value;
                OnPropertyChanged();
            }
        }

        private string m_description;
        public string Description
        {
            get => m_description;
            set
            {
                m_description = value;
                OnPropertyChanged();
            }
        }

        private string m_acctType;
        public string AcctType
        {
            get => m_acctType;
            set
            {
                m_acctType = value;
                OnPropertyChanged();
            }
        }

        private decimal m_startingBalance;
        public decimal StartingBalance
        {
            get => m_startingBalance;
            set
            {
                m_startingBalance = value;
                OnPropertyChanged();
            }
        }

        private decimal m_reserveAmount;
        public decimal ReserveAmount
        {
            get => m_reserveAmount;
            set
            {
                m_reserveAmount = value;
                OnPropertyChanged();
            }
        }
    }
}
