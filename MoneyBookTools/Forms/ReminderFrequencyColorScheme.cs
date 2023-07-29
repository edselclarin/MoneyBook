using MoneyBook.Data;

namespace MoneyBookTools.Forms
{
    public class ReminderFrequencyColorScheme : IFrequencyColorScheme
    {
        private static ReminderFrequencyColorScheme? m_instance;

        protected ReminderFrequencyColorScheme()
        {
        }

        public static ReminderFrequencyColorScheme Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance ??= new ReminderFrequencyColorScheme();
                }
                return m_instance;
            }
        }

        public Color ForeColor(string frequency)
        {
            switch (frequency)
            {
                case nameof(MoneyBookDbContextExtension.TransactionFrequency.Paused):
                    return Color.FromArgb(193, 1, 193); // purple
                default:
                    return Color.FromArgb(179, 179, 179); // gray
            }
        }
    }
}
