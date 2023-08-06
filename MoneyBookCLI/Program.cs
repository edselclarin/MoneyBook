using MoneyBookTest;

var dp = new ReminderDataProviderTest();

dp.Setup();
dp.GetAll();
dp.GetAllByInvalidFkId();
dp.GetAllByFkId();
dp.GetAllSinceLastMonth();
dp.GetAllNextYear();
dp.UpsertAndDelete();

return;