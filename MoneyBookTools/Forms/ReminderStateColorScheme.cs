using MoneyBook.Data;

namespace MoneyBookTools.Forms
{
    public class ReminderStateColorScheme : IStateColorScheme
    {
        private static ReminderStateColorScheme m_instance;

        protected ReminderStateColorScheme() { }

        public static ReminderStateColorScheme Instance
        {
            get
            {
                m_instance ??= new ReminderStateColorScheme();
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
