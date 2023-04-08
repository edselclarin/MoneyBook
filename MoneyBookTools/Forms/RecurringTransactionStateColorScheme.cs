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
                case nameof(DueStateTypes.Past):
                case nameof(DueStateTypes.Today):
                    return Color.Red;
                case nameof(DueStateTypes.Soon):
                    return Color.Yellow;
                case nameof(DueStateTypes.Upcoming):
                    return Color.FromArgb(245, 127, 23); // orange
                default:
                    return Color.FromArgb(179, 179, 179); // gray
            }
        }
    }
}
