﻿using Caliburn.Micro;
using MoneyBookDash.DataProviders;
using MoneyBookDash.Models;
using System.Collections.ObjectModel;

namespace MoneyBookDash.ViewModels
{
    public class MainViewModel : Screen
    {
        private ObservableCollection<AccountModel> accounts_ = new ObservableCollection<AccountModel>();

        public ObservableCollection<AccountModel> Accounts
        {
            get { return accounts_; }
            set
            {
                accounts_ = value;
                NotifyOfPropertyChange();
            }
        }

        private ObservableCollection<ReminderModel> overdue_ = new ObservableCollection<ReminderModel>();

        public ObservableCollection<ReminderModel> Overdue
        {
            get { return overdue_; }
            set
            {
                overdue_ = value;
                NotifyOfPropertyChange();
            }
        }

        private ObservableCollection<ReminderModel> dueNow_ = new ObservableCollection<ReminderModel>();

        public ObservableCollection<ReminderModel> DueNow
        {
            get { return dueNow_; }
            set
            {
                dueNow_ = value;
                NotifyOfPropertyChange();
            }
        }

        private ObservableCollection<ReminderModel> upcoming_ = new ObservableCollection<ReminderModel>();

        public ObservableCollection<ReminderModel> Upcoming
        {
            get { return upcoming_; }
            set
            {
                upcoming_ = value;
                NotifyOfPropertyChange();
            }
        }

        public MainViewModel()
        {
            foreach (var acct in AccountDataProvider.GetAll())
            {
                Accounts.Add(acct);
            }

            foreach (var rmdr in ReminderDataProvider.GetOverdue())
            {
                Overdue.Add(rmdr);
            }

            foreach (var rmdr in ReminderDataProvider.GetDueNow())
            {
                DueNow.Add(rmdr);
            }

            foreach (var rmdr in ReminderDataProvider.GetUpcoming())
            {
                Upcoming.Add(rmdr);
            }
        }
    }
}