using MoneyBookTools.ViewModels;

namespace MoneyBookTools.Forms
{
    public class RecurringTransactionStateColorScheme : IStateColorScheme
    {
        private static RecurringTransactionStateColorScheme? m_instance;

        protected RecurringTransactionStateColorScheme() { }

        public static RecurringTransactionStateColorScheme Instance
        {
            get
            {
                m_instance ??= new RecurringTransactionStateColorScheme();
                return m_instance;
            }
        }

        public Color ForeColor(string state)
        {
            switch (state)
            {
                case nameof(ViewRecurringTransaction.DueStateTypes.Past):
                case nameof(ViewRecurringTransaction.DueStateTypes.Today):
                    return Color.Red;
                case nameof(ViewRecurringTransaction.DueStateTypes.Soon):
                    return Color.Yellow;
                case nameof(ViewRecurringTransaction.DueStateTypes.Upcoming):
                    return Color.FromArgb(245, 127, 23); // orange
                default:
                    return Color.FromArgb(179, 179, 179); // gray
            }
        }
    }
}
