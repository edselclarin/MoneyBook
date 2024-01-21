namespace MoneyBookService.Loggers
{
    public class Log
    {
        private static Log log_;

        public static Log Instance
        {
            get
            {
                if (log_ == null)
                {
                    log_= new Log ();
                }
                return log_;
            }
        }

        public void Info(string message)
        {
            WriteLine($"[INFO] {message}");
        }

        public void Warning(string message)
        {
            WriteLine($"[WARNING] {message}");
        }

        public void Error(string message)
        {
            WriteLine($"[ERROR] {message}");
        }

        public void Exception(string message)
        {
            WriteLine($"[EXCEPTION] {message}");
        }

        protected void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
