namespace TransactionsTool.Readers
{
    public interface ITransactionFileReader
    {
        bool Read(string filePath);
    }
}
