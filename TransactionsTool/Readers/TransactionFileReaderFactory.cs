namespace TransactionsTool.Readers
{
    public enum FileReaderTypes
    {
        Chase
    }

    public static class TransactionFileReaderFactory
    {
        public static ITransactionFileReader? CreateReader(FileReaderTypes type)
        {
            return type switch
            {
                FileReaderTypes.Chase => new ChaseFileReader(),
                _ => null
            };
        }
    }
}
