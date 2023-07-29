using MoneyBook;
using MoneyBook.Data;

try
{
    var accountDataArr = AppSettings.Instance?.Accounts?
        .Where(x => File.Exists(x.ImportFilePath));
    if (accountDataArr?.Count() > 0)
    {
        using var db = MoneyBookDbContext.Create(MoneyBookToolsDbContextConfig.Instance);
        var importer = new OfxTransactionImporter(db, accountDataArr);
        importer.Import();
    }
}
catch (Exception ex)
{
    string error = 
        ex.Message + Environment.NewLine +
        ex.StackTrace;
    string filepath = $"exception-{DateTime.Now.ToString("yyyyMMdd-hhmmss")}.log";
    File.WriteAllText(filepath, error);
}