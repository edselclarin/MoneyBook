using MoneyBook.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBookTools.Forms
{
    public class RecurringTransactionsFrequencyColorScheme : IFrequencyColorScheme
    {
        private static RecurringTransactionsFrequencyColorScheme? m_instance;

        protected RecurringTransactionsFrequencyColorScheme()
        {
        }

        public static RecurringTransactionsFrequencyColorScheme Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance ??= new RecurringTransactionsFrequencyColorScheme();
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
