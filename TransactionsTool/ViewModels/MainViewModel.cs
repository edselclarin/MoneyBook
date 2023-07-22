using Caliburn.Micro;
using System;
using System.Collections.ObjectModel;
using TransactionsTool.Models;
using TransactionsTool.Readers;

namespace TransactionsTool.ViewModels
{
    public class MainViewModel : PropertyChangedBase
    {
        private ObservableCollection<Transaction> transactions_;
        public ObservableCollection<Transaction> Transactions
        {
            get => transactions_;
            set
            {
                transactions_ = value;
                NotifyOfPropertyChange();
            }
        }

        public MainViewModel()
        {
            try
            {
                // test
                var reader = (ChaseFileReader)TransactionFileReaderFactory.CreateReader(FileReaderTypes.Chase);
                reader?.Read(@"C:\Users\Edsel\Downloads\Chase6979_Activity20230722(1).CSV");
                Transactions = new ObservableCollection<Transaction>();
                foreach (var transaction in reader.Transactions) 
                {
                    Transactions.Add(transaction);
                }
            }
            catch (Exception ex)
            {
                MainExceptionHandler.Instance.Process(ex);
            }
        }
    }
}
