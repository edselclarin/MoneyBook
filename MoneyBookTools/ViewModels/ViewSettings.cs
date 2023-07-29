namespace MoneyBookTools.ViewModels
{
    public class ViewSettings
    {
        private static ViewSettings m_settings;

        public static ViewSettings Instance
        {
            get
            {
                if (m_settings == null)
                {
                    m_settings = new ViewSettings();
                }

                return m_settings;
            }
        }

        protected ViewSettings() { }

        /// <summary>
        /// Used to determine transactions due soon.
        /// </summary>
        public DayOfWeek DueBeforeDay { get; set; } = DayOfWeek.Wednesday;

    }
}
