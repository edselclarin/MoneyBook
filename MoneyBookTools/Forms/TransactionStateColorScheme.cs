using MoneyBook.Data;

namespace MoneyBookTools.Forms
{
    public class TransactionStateColorScheme : IStateColorScheme
    {
        private static TransactionStateColorScheme m_instance;

        protected TransactionStateColorScheme() { }

        public static TransactionStateColorScheme Instance
        {
            get
            {
                m_instance ??= new TransactionStateColorScheme();
                return m_instance;
            }
        }

        public Color ForeColor(string state)
        {
            switch (state)
            {
                case nameof(MoneyBookDbContextExtension.StateTypes.New):
                    return Color.FromArgb(245, 127, 23); // orange
                case nameof(MoneyBookDbContextExtension.StateTypes.Ignored):
                    return Color.DimGray;
                case nameof(MoneyBookDbContextExtension.StateTypes.Staged):
                    return Color.DodgerBlue;
                case nameof(MoneyBookDbContextExtension.StateTypes.Reconciled):
                default:
                    return Color.FromArgb(179, 179, 179); // gray
            }
        }
    }
}
