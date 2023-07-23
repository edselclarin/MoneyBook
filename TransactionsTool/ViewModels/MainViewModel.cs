using Caliburn.Micro;
using Microsoft.Win32;
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
                var ofd = new OpenFileDialog()
                {
                    Filter = "CSV Files (*.csv)|*.csv|QFX Files (*.qfx)|*.qfx|All Files (*.*)|*.*"
                };

                if (ofd.ShowDialog() == true)
                {
                    Transactions = TransactionFileReaderFactory
                        .CreateReader(FileReaderTypes.Chase)
                        .Read(ofd.FileName)
                        .ToObservableCollection();
                }
            }
            catch (Exception ex)
            {
                MainExceptionHandler.Instance.Process(ex);
            }
        }
    }
}
