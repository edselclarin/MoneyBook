using MoneyBook.DataProviders;
using MoneyBook.Models;

namespace MoneyBookTest
{
    public class AccountDataProviderTest : BaseDataProviderTest<Account>
    {
        public AccountDataProviderTest()
        {
            DataProvider = (AccountDataProvider)DataProviderFactory.Create(typeof(Account));
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

            using (var tr = CreateDbTransaction())
            {
                newItem = Insert(newItem);
                tr.SetCommitFlag(true);
            }

            Account item;
            using (var tr2 = CreateDbTransaction())
            {
                item = Get(newItem.AcctId);
                item.Name = "RENAMED ACCOUNT";
                Update(item.AcctId, item);
                tr2.SetCommitFlag(true);
            }

            item = Get(item.AcctId);
            Assert.IsNotNull(item, "item is null");

            using (var tr3 = CreateDbTransaction())
            {
                Delete(item.AcctId);
                tr3.SetCommitFlag(true);
            }
        }
    }
}
