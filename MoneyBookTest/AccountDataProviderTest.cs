using Autofac;
using MoneyBook;
using MoneyBook.DataProviders;
using MoneyBook.Models;

namespace MoneyBookTest
{
    public class AccountDataProviderTest : BaseDataProviderTest<Account>
    {
        public AccountDataProviderTest()
        {
            DataProvider = MoneyBookContainerBuilder.Container.Resolve<IDataProvider<Account>>();
            Assert.IsNotNull(DataProvider, "dp_ is null");
        }

        [Test]
        public void GetAll()
        {
            var result = base.GetAllItemsPaged();
            Assert.True(result.totalRetrieved == result.totalCount);
        }

        [Test]
        public void Get()
        {
            var firstItem = GetFirstItem();
            var item = Get(firstItem.AcctId);
            Assert.IsTrue(firstItem.AcctId == item.AcctId);
        }


        [Test]
        public void InsertUpdateDelete()
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

            using (var tr = DataProvider.CreateDbTransaction())
            {
                newItem = Insert(newItem);
                tr.Commit();
            }

            Account item;
            using (var tr2 = DataProvider.CreateDbTransaction())
            {
                item = Get(newItem.AcctId);
                item.Name = "RENAMED ACCOUNT";
                Update(item.AcctId, item);
                tr2.Commit();
            }

            item = Get(item.AcctId);
            Assert.IsNotNull(item, "item is null");

            using (var tr3 = DataProvider.CreateDbTransaction())
            {
                Delete(item.AcctId);
                tr3.Commit();
            }
        }
    }
}
