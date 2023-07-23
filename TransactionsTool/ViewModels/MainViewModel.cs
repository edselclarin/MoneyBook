using Caliburn.Micro;
using System;
using System.Collections.ObjectModel;
using TransactionsTool.Models;
using TransactionsTool.Readers;

namespace TransactionsTool.ViewModels
{
    public class MainViewModel : PropertyChangedBase
    {
        #region Properties
        private MainMenuViewModel mainMenu_;
        public MainMenuViewModel MainMenu
        { 
            get => mainMenu_;
            set
            {
                mainMenu_ = value;
                NotifyOfPropertyChange();
            }
        }

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
        #endregion

        public MainViewModel()
        {
            mainMenu_ = new MainMenuViewModel();
            mainMenu_.OnFileOpen += MainMenu_OnFileOpen;
        }

        private void MainMenu_OnFileOpen()
        {
            try
            {
                // test
                string filename = @"C:\Users\Edsel\Downloads\Chase6979_Activity20230722(1).CSV";
                Transactions = TransactionFileReaderFactory
                    .CreateReader(FileReaderTypes.Chase)
                    .Read(filename)
                    .ToObservableCollection();
            }
            catch (Exception ex)
            {
                MainExceptionHandler.Instance.Process(ex);
            }
        }
    }
}
