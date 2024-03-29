﻿using Autofac;
using Dark.Net;
using MoneyBook;
using MoneyBook.DataProviders;
using MoneyBook.Models;
using MoneyBookTools.FormModels;

namespace MoneyBookTools.Forms
{
    public partial class AccountForm : Form
    {
        private int m_acctId;
        private AccountFormModel m_formModel;

        public static AccountForm Create(int acctId)
        {
            var form = new AccountForm()
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            form.m_acctId = acctId;

            DarkNet.Instance.SetWindowThemeForms(form, Theme.Dark);
            form.ChangeTheme(DarkColorScheme.Create());

            return form;
        }

        protected AccountForm()
        {
            InitializeComponent();

            int i = 0;
            textName.TabIndex = i++;
            textDescription.TabIndex = i++;
            textType.TabIndex = i++;
            textStartingBalance.TabIndex = i++;
            textReserveAmount.TabIndex = i++;
            buttonSave.TabIndex = i++;

            buttonSave.Enabled = false;
        }

        private async void AccountForm_Load(object sender, EventArgs e)
        {
            try
            {
                var adp = MoneyBookContainerBuilder.Container.Resolve<IDataProvider<Account>>();
                var acct = await adp.GetAsync(m_acctId);

                var atdp = MoneyBookContainerBuilder.Container.Resolve<IDataProvider<AccountType>>();
                var acctType = await atdp.GetAsync(acct.AcctTypeId);

                m_formModel = new AccountFormModel()
                {
                    AcctId = acct.AcctId,
                    AcctType = acctType.TypeName,
                    Name = acct.Name,
                    Description = acct.Description,
                    StartingBalance = acct.StartingBalance,
                    ReserveAmount = acct.ReserveAmount
                };

                textName.DataBindings.Add(
                    new Binding("Text", m_formModel, "Name", false, DataSourceUpdateMode.OnPropertyChanged));
                textDescription.DataBindings.Add(
                    new Binding("Text", m_formModel, "Description", false, DataSourceUpdateMode.OnPropertyChanged));
                textStartingBalance.DataBindings.Add(
                    new Binding("Text", m_formModel, "StartingBalance", false, DataSourceUpdateMode.OnPropertyChanged));
                textReserveAmount.DataBindings.Add(
                    new Binding("Text", m_formModel, "ReserveAmount", false, DataSourceUpdateMode.OnPropertyChanged));
                textType.DataBindings.Add(
                    new Binding("Text", m_formModel, "AcctType"));

                m_formModel.ContextChanged += () => buttonSave.Enabled = true;
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                var adp = MoneyBookContainerBuilder.Container.Resolve<IDataProvider<Account>>();
                var acct = await adp.GetAsync(m_formModel.AcctId);

                acct.Name = m_formModel.Name;
                acct.Description = m_formModel.Description;
                acct.StartingBalance = m_formModel.StartingBalance;
                acct.ReserveAmount = m_formModel.ReserveAmount;

                using var tr = adp.CreateDbTransaction();

                if (await adp.UpsertAsync(acct) is null)
                {
                    throw new Exception("Failed to update account info.");
                }

                await tr.CommitAsync();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                this.ShowException(ex);
                DialogResult = DialogResult.None;
            }
            finally
            { 
                Close(); 
            }
        }
    }
}
