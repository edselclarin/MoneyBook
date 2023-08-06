using Caliburn.Micro;
using MoneyBook.Data;
using MoneyBook.DataProviders;
using MoneyBook.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using System.Windows;

namespace TransactionsTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Test();

            //// Activate Caliburn logging.
            //LogManager.GetLog = type => new DebugLog(type);

            //// Initialize main engine.
            //MainEngine.Instance.Init();
        }

        private async void Test()
        {
            Debug.WriteLine("### get all ###");
            DumpList(await Get());

            int fkId = (await Get()).FirstOrDefault().AcctId;
            Debug.WriteLine("### get by fkid ###");
            DumpList(await Get(fkId));
        }

        private void DumpList(IEnumerable<Transaction> list)
        {
            if (list.Any())
            {
                int count = 0;
                foreach (var item in list)
                {
                    Debug.WriteLine($"[{count}] {item.TrnsId}, {item.Date}, {item.Payee}, {item.Amount}");
                    count++;
                }
            }
            else
            {
                Debug.WriteLine("empty list");
            }
        }

        private async Task<IEnumerable<Transaction>> Get(int? fkId = null, DateTime? dateTimeFrom = null)
        {
            var list = new List<Transaction>();
            var db = MoneyBookDbContext.Create(MoneyBookToolsDbContextConfig.Instance);
            var dp = TransactionDataProvider.Create(db);
            int take = 100;
            int skip = 0;
            int count = 0;
            var res = await dp.GetPagedAsync(skip, take, fkId, dateTimeFrom);
            while (res.Items != null && res.Count > 0)
            {
                list.AddRange(res.Items);
                skip += take;
                count += res.Count;
                res = await dp.GetPagedAsync(skip, take, fkId, dateTimeFrom);
            }
            return list;
        }
    }
}
