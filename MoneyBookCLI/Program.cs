using MoneyBook.Models;
using MoneyBookTest;
using NUnit.Framework;
using System.Diagnostics;

void Test1()
{
    var instutionsDataProviderTest = new InstitutionDataProviderTest();
    Assert.IsNotNull(instutionsDataProviderTest, "instutionsDataProviderTest is null");

    var inst = instutionsDataProviderTest.GetAllItems()
        .FirstOrDefault();
    Assert.IsNotNull(inst, "inst is null");

    var acctTypesDataProviderTest = new AccountTypeDataProviderTest();
    Assert.IsNotNull(acctTypesDataProviderTest, "acctTypesDataProviderTest is null");

    var acctType = acctTypesDataProviderTest.GetAllItems()
        .SingleOrDefault(x => x.TypeName.Equals("checking", StringComparison.InvariantCultureIgnoreCase));
    Assert.IsNotNull(acctType, "acctType is null");

    var newItem = new Account()
    {
        Name = "TEST ACCOUNT",
        AcctTypeId = acctType.AcctTypeId,
        StartingBalance = 0m,
        DateAdded = DateTime.Now,
        DateModified = DateTime.Now,
        ExtAcctId = "111",
        InstId = inst.InstId
    };

    var dp = new AccountDataProviderTest();

    using (var tr = dp.CreateDbTransaction())
    {
        newItem = dp.Insert(newItem);
        tr.Commit();
    }

    Account item;
    using (var tr2 = dp.CreateDbTransaction())
    {
        item = dp.Get(newItem.AcctId);
        item.Name = "RENAMED ACCOUNT";
        dp.Update(item.AcctId, item);
        tr2.Commit();
    }

    item = dp.Get(newItem.AcctId);
    Assert.IsNotNull(item, "item is null");

    Debug.WriteLine($"acct: {item.AcctId}, {item.Name}");

    using (var tr3 = dp.CreateDbTransaction())
    {
        dp.Delete(item.AcctId);
        tr3.Commit();
    }
}


Test1();

return;