using System.Windows;

namespace TransactionsTool
{
    public class MainEngine
    {
        private static MainEngine? instance_;
        public static MainEngine Instance
        {
            get
            {
                if (instance_ == null)
                {
                    instance_ = new MainEngine();
                }
                return instance_;
            }
        }

        protected MainEngine() { }

        public void Init()
        {
        }
    }
}
