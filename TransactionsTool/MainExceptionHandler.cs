using System;
using System.Diagnostics;

namespace TransactionsTool
{
    public class MainExceptionHandler
    {
        private static MainExceptionHandler instance_ = new MainExceptionHandler();
        public static MainExceptionHandler Instance { get { return instance_; } }

        public void Process(Exception ex)
        {
            Debug.WriteLine($"[MAIN] EXCEPTION: {ex}");
        }
    }
}
