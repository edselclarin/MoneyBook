using System;
using TransactionsTool.Readers;

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
            try
            {
                // test
                var reader = TransactionFileReaderFactory.CreateReader(FileReaderTypes.Chase);
                reader?.Read(@"C:\Users\Edsel\Downloads\Chase6979_Activity20230722(1).CSV");
            }
            catch (Exception ex)
            {
                MainExceptionHandler.Instance.Process(ex);
            }
        }
    }
}
