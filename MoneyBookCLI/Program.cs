// See https://aka.ms/new-console-template for more information

using MoneyBook.Data;
using MoneyBookCLI;
using Newtonsoft.Json.Linq;
using System.Reflection;

var db = MoneyBookDbContext.Create(MoneyBookToolsDbContextConfig.Instance);

var accts = db.account_details;

if (accts.Count()> 0)
{
    string header = String.Join(", ", accts.First().GetType().GetProperties().Select(x => x.Name));
    Console.WriteLine(header);
    foreach (var acct in accts)
    {
        string values = String.Join(", ", acct.GetType().GetProperties().Select(x => x.GetValue(acct)));
        Console.WriteLine(values);
    }
}

