namespace TransactionsTool.Readers
{
    public static class TransactionFileReaderFactory
    {
        public static ITransactionFileReader? CreateReader(string filepath)
        {
            return System.IO.Path.GetExtension(filepath).ToLower() switch
            {
                ".csv" => new ChaseFileReader(),
                ".qfx" => new SchoolsFirstFileReader(),
                _ => null
            };
        }
    }
}
