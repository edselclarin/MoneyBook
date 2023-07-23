using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using TransactionsTool.Models;

namespace TransactionsTool.Readers
{
    public class ChaseClassMap : ClassMap<Transaction>
    {
        public ChaseClassMap()
        {
            Map(m => m.Date).Name("Transaction Date");
            Map(m => m.PostDate).Name("Post Date");
            Map(m => m.Description).Name("Description");
            Map(m => m.Category).Name("Category");
            Map(m => m.Type).Name("Type");
            Map(m => m.Amount).Name("Amount");
            Map(m => m.Memo).Name("Memo");
        }
    }

    public class ChaseFileReader : ITransactionFileReader
    {
        public IEnumerable<Transaction> Read(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.Context.RegisterClassMap<ChaseClassMap>();
                return csv
                    .GetRecords<Transaction>()
                    .ToList();
            }
        }
    }
}
