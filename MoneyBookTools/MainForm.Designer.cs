﻿
using MoneyBookTools.Forms;

namespace MoneyBookTools
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            mainMenuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            refreshToolStripMenuItem = new ToolStripMenuItem();
            transactionsToolStripMenuItem = new ToolStripMenuItem();
            filterToolStripMenuItem = new ToolStripMenuItem();
            twoWeeksToolStripMenuItem = new ToolStripMenuItem();
            thisMonthToolStripMenuItem = new ToolStripMenuItem();
            thisYearToolStripMenuItem = new ToolStripMenuItem();
            allDatesToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator10 = new ToolStripSeparator();
            newStatusMenuItem = new ToolStripMenuItem();
            pendingToolStripMenuItem = new ToolStripMenuItem();
            reconciledStatusMenuItem = new ToolStripMenuItem();
            ignoredStatusMenuItem = new ToolStripMenuItem();
            anyStatusMenuItem = new ToolStripMenuItem();
            toolStripSeparator11 = new ToolStripSeparator();
            sortToolStripMenuItem = new ToolStripMenuItem();
            dateDescendingToolStripMenuItem = new ToolStripMenuItem();
            dateAscendingToolStripMenuItem = new ToolStripMenuItem();
            operationsToolStripMenuItem = new ToolStripMenuItem();
            importTransactionsToolStripMenuItem = new ToolStripMenuItem();
            deleteAllTransactionsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            backupDatabaseToolStripMenuItem = new ToolStripMenuItem();
            restoreDatabaseToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            deleteTransactionFilesToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            hSplit1 = new SplitContainer();
            vSplit1 = new SplitContainer();
            groupAccounts = new GroupBox();
            listViewAccounts = new CustomListView();
            accountsContextMenuStrip = new ContextMenuStrip(components);
            editAccountToolStripMenuItem = new ToolStripMenuItem();
            tableLayoutLedger = new TableLayoutPanel();
            ledgerSplit = new SplitContainer();
            groupLedger = new GroupBox();
            dgvAccountTransactions = new DataGridView();
            transactionsContextMenu = new ContextMenuStrip(components);
            addTransToolStripMenuItem = new ToolStripMenuItem();
            editTransToolStripMenuItem = new ToolStripMenuItem();
            setTransStateToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator7 = new ToolStripSeparator();
            reconcileNewToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator9 = new ToolStripSeparator();
            addReminderToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            deleteTransToolStripMenuItem = new ToolStripMenuItem();
            groupStaged = new GroupBox();
            dgvStagedAccountTransactions = new DataGridView();
            mainStatusStrip1 = new StatusStrip();
            accountToolStripStatusLabel = new ToolStripStatusLabel();
            currentToolStripStatusLabel = new ToolStripStatusLabel();
            availableToolStripStatusLabel = new ToolStripStatusLabel();
            stagedToolStripStatusLabel = new ToolStripStatusLabel();
            finalToolStripStatusLabel = new ToolStripStatusLabel();
            sumToolStripStatusLabel = new ToolStripStatusLabel();
            groupReminders = new GroupBox();
            dgvReminders = new DataGridView();
            remindersContextMenu = new ContextMenuStrip(components);
            createReminderToolStripMenuItem = new ToolStripMenuItem();
            editReminderToolStripMenuItem = new ToolStripMenuItem();
            skipReminderToolStripMenuItem = new ToolStripMenuItem();
            stageReminderToolStripMenuItem = new ToolStripMenuItem();
            copyReminderToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator8 = new ToolStripSeparator();
            openWebsiteToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            deleteReminderToolStripMenuItem = new ToolStripMenuItem();
            mainPanel = new Panel();
            threeMonthsAgoToolStripMenuItem = new ToolStripMenuItem();
            mainMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)hSplit1).BeginInit();
            hSplit1.Panel1.SuspendLayout();
            hSplit1.Panel2.SuspendLayout();
            hSplit1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)vSplit1).BeginInit();
            vSplit1.Panel1.SuspendLayout();
            vSplit1.Panel2.SuspendLayout();
            vSplit1.SuspendLayout();
            groupAccounts.SuspendLayout();
            accountsContextMenuStrip.SuspendLayout();
            tableLayoutLedger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ledgerSplit).BeginInit();
            ledgerSplit.Panel1.SuspendLayout();
            ledgerSplit.Panel2.SuspendLayout();
            ledgerSplit.SuspendLayout();
            groupLedger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccountTransactions).BeginInit();
            transactionsContextMenu.SuspendLayout();
            groupStaged.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStagedAccountTransactions).BeginInit();
            mainStatusStrip1.SuspendLayout();
            groupReminders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReminders).BeginInit();
            remindersContextMenu.SuspendLayout();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainMenuStrip1
            // 
            mainMenuStrip1.ImageScalingSize = new Size(20, 20);
            mainMenuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem, transactionsToolStripMenuItem, operationsToolStripMenuItem, helpToolStripMenuItem });
            mainMenuStrip1.Location = new Point(0, 0);
            mainMenuStrip1.Name = "mainMenuStrip1";
            mainMenuStrip1.Padding = new Padding(7, 3, 0, 3);
            mainMenuStrip1.Size = new Size(1321, 30);
            mainMenuStrip1.TabIndex = 0;
            mainMenuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(116, 26);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.ToolTipText = "Close application";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { refreshToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(55, 24);
            viewToolStripMenuItem.Text = "&View";
            // 
            // refreshToolStripMenuItem
            // 
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.ShortcutKeys = Keys.F5;
            refreshToolStripMenuItem.Size = new Size(165, 26);
            refreshToolStripMenuItem.Text = "&Refresh";
            refreshToolStripMenuItem.ToolTipText = "Refresh";
            refreshToolStripMenuItem.Click += refreshToolStripMenuItem_Click;
            // 
            // transactionsToolStripMenuItem
            // 
            transactionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { filterToolStripMenuItem, sortToolStripMenuItem });
            transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            transactionsToolStripMenuItem.Size = new Size(104, 24);
            transactionsToolStripMenuItem.Text = "Transactions";
            // 
            // filterToolStripMenuItem
            // 
            filterToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { twoWeeksToolStripMenuItem, thisMonthToolStripMenuItem, threeMonthsAgoToolStripMenuItem, thisYearToolStripMenuItem, allDatesToolStripMenuItem, toolStripSeparator10, newStatusMenuItem, pendingToolStripMenuItem, reconciledStatusMenuItem, ignoredStatusMenuItem, anyStatusMenuItem, toolStripSeparator11 });
            filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            filterToolStripMenuItem.Size = new Size(224, 26);
            filterToolStripMenuItem.Text = "Filter...";
            filterToolStripMenuItem.ToolTipText = "Show transactions...";
            // 
            // twoWeeksToolStripMenuItem
            // 
            twoWeeksToolStripMenuItem.Name = "twoWeeksToolStripMenuItem";
            twoWeeksToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.W;
            twoWeeksToolStripMenuItem.Size = new Size(302, 26);
            twoWeeksToolStripMenuItem.Text = "Two Weeks";
            twoWeeksToolStripMenuItem.ToolTipText = "In past two weeks";
            twoWeeksToolStripMenuItem.Click += twoWeeksToolStripMenuItem_Click;
            // 
            // thisMonthToolStripMenuItem
            // 
            thisMonthToolStripMenuItem.Name = "thisMonthToolStripMenuItem";
            thisMonthToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.M;
            thisMonthToolStripMenuItem.Size = new Size(302, 26);
            thisMonthToolStripMenuItem.Text = "This Month";
            thisMonthToolStripMenuItem.ToolTipText = "Of the current month";
            thisMonthToolStripMenuItem.Click += thisMonthToolStripMenuItem_Click;
            // 
            // thisYearToolStripMenuItem
            // 
            thisYearToolStripMenuItem.Name = "thisYearToolStripMenuItem";
            thisYearToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.Y;
            thisYearToolStripMenuItem.Size = new Size(302, 26);
            thisYearToolStripMenuItem.Text = "This Year";
            thisYearToolStripMenuItem.ToolTipText = "Of the current year";
            thisYearToolStripMenuItem.Click += thisYearToolStripMenuItem_Click;
            // 
            // allDatesToolStripMenuItem
            // 
            allDatesToolStripMenuItem.Name = "allDatesToolStripMenuItem";
            allDatesToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.L;
            allDatesToolStripMenuItem.Size = new Size(302, 26);
            allDatesToolStripMenuItem.Text = "All Dates";
            allDatesToolStripMenuItem.ToolTipText = "Show any transactions of any date";
            allDatesToolStripMenuItem.Click += allDatesToolStripMenuItem_Click;
            // 
            // toolStripSeparator10
            // 
            toolStripSeparator10.Name = "toolStripSeparator10";
            toolStripSeparator10.Size = new Size(299, 6);
            // 
            // newStatusMenuItem
            // 
            newStatusMenuItem.Name = "newStatusMenuItem";
            newStatusMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.N;
            newStatusMenuItem.Size = new Size(302, 26);
            newStatusMenuItem.Text = "New";
            newStatusMenuItem.ToolTipText = "Show New transactions";
            newStatusMenuItem.Click += newStatusMenuItem_Click;
            // 
            // pendingToolStripMenuItem
            // 
            pendingToolStripMenuItem.Name = "pendingToolStripMenuItem";
            pendingToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.P;
            pendingToolStripMenuItem.Size = new Size(302, 26);
            pendingToolStripMenuItem.Text = "Pending";
            pendingToolStripMenuItem.Click += pendingToolStripMenuItem_Click;
            // 
            // reconciledStatusMenuItem
            // 
            reconciledStatusMenuItem.Name = "reconciledStatusMenuItem";
            reconciledStatusMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.R;
            reconciledStatusMenuItem.Size = new Size(302, 26);
            reconciledStatusMenuItem.Text = "Reconciled";
            reconciledStatusMenuItem.ToolTipText = "Show Reconciled transactions";
            reconciledStatusMenuItem.Click += reconciledStatusMenuItem_Click;
            // 
            // ignoredStatusMenuItem
            // 
            ignoredStatusMenuItem.Name = "ignoredStatusMenuItem";
            ignoredStatusMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.I;
            ignoredStatusMenuItem.Size = new Size(302, 26);
            ignoredStatusMenuItem.Text = "Ignored";
            ignoredStatusMenuItem.ToolTipText = "Show Ignored transactions";
            ignoredStatusMenuItem.Click += ignoredStatusMenuItem_Click;
            // 
            // anyStatusMenuItem
            // 
            anyStatusMenuItem.Name = "anyStatusMenuItem";
            anyStatusMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.U;
            anyStatusMenuItem.Size = new Size(302, 26);
            anyStatusMenuItem.Text = "Any Status";
            anyStatusMenuItem.ToolTipText = "Show transactions of any status";
            anyStatusMenuItem.Click += anyStatusMenuItem_Click;
            // 
            // toolStripSeparator11
            // 
            toolStripSeparator11.Name = "toolStripSeparator11";
            toolStripSeparator11.Size = new Size(299, 6);
            // 
            // sortToolStripMenuItem
            // 
            sortToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dateDescendingToolStripMenuItem, dateAscendingToolStripMenuItem });
            sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            sortToolStripMenuItem.Size = new Size(224, 26);
            sortToolStripMenuItem.Text = "Sort...";
            // 
            // dateDescendingToolStripMenuItem
            // 
            dateDescendingToolStripMenuItem.Name = "dateDescendingToolStripMenuItem";
            dateDescendingToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.D;
            dateDescendingToolStripMenuItem.Size = new Size(299, 26);
            dateDescendingToolStripMenuItem.Text = "Date Descending";
            dateDescendingToolStripMenuItem.ToolTipText = "Sort by date in descending order.";
            dateDescendingToolStripMenuItem.Click += dateDescendingToolStripMenuItem_Click;
            // 
            // dateAscendingToolStripMenuItem
            // 
            dateAscendingToolStripMenuItem.Name = "dateAscendingToolStripMenuItem";
            dateAscendingToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.A;
            dateAscendingToolStripMenuItem.Size = new Size(299, 26);
            dateAscendingToolStripMenuItem.Text = "Date Ascending";
            dateAscendingToolStripMenuItem.ToolTipText = "Sort by date in ascending order.";
            dateAscendingToolStripMenuItem.Click += dateAscendingToolStripMenuItem_Click;
            // 
            // operationsToolStripMenuItem
            // 
            operationsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importTransactionsToolStripMenuItem, deleteAllTransactionsToolStripMenuItem, toolStripSeparator4, backupDatabaseToolStripMenuItem, restoreDatabaseToolStripMenuItem, toolStripSeparator1, deleteTransactionFilesToolStripMenuItem });
            operationsToolStripMenuItem.Name = "operationsToolStripMenuItem";
            operationsToolStripMenuItem.Size = new Size(96, 24);
            operationsToolStripMenuItem.Text = "&Operations";
            // 
            // importTransactionsToolStripMenuItem
            // 
            importTransactionsToolStripMenuItem.Name = "importTransactionsToolStripMenuItem";
            importTransactionsToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.I;
            importTransactionsToolStripMenuItem.Size = new Size(297, 26);
            importTransactionsToolStripMenuItem.Text = "Import Transactions...";
            importTransactionsToolStripMenuItem.ToolTipText = "Import transactions from file";
            importTransactionsToolStripMenuItem.Click += importTransactionsToolStripMenuItem_Click;
            // 
            // deleteAllTransactionsToolStripMenuItem
            // 
            deleteAllTransactionsToolStripMenuItem.Name = "deleteAllTransactionsToolStripMenuItem";
            deleteAllTransactionsToolStripMenuItem.Size = new Size(297, 26);
            deleteAllTransactionsToolStripMenuItem.Text = "Delete All Transactions";
            deleteAllTransactionsToolStripMenuItem.ToolTipText = "Delete transactions across all accounts";
            deleteAllTransactionsToolStripMenuItem.Click += deleteAllTransactionsToolStripMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(294, 6);
            // 
            // backupDatabaseToolStripMenuItem
            // 
            backupDatabaseToolStripMenuItem.Name = "backupDatabaseToolStripMenuItem";
            backupDatabaseToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.B;
            backupDatabaseToolStripMenuItem.Size = new Size(297, 26);
            backupDatabaseToolStripMenuItem.Text = "Backup Database...";
            backupDatabaseToolStripMenuItem.ToolTipText = "Backup database to tape file and text file";
            backupDatabaseToolStripMenuItem.Click += backupDatabaseToolStripMenuItem_Click;
            // 
            // restoreDatabaseToolStripMenuItem
            // 
            restoreDatabaseToolStripMenuItem.Name = "restoreDatabaseToolStripMenuItem";
            restoreDatabaseToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.R;
            restoreDatabaseToolStripMenuItem.Size = new Size(297, 26);
            restoreDatabaseToolStripMenuItem.Text = "Restore Database...";
            restoreDatabaseToolStripMenuItem.ToolTipText = "Restore table data from text file backup";
            restoreDatabaseToolStripMenuItem.Click += restoreDatabaseToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(294, 6);
            // 
            // deleteTransactionFilesToolStripMenuItem
            // 
            deleteTransactionFilesToolStripMenuItem.Name = "deleteTransactionFilesToolStripMenuItem";
            deleteTransactionFilesToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.D;
            deleteTransactionFilesToolStripMenuItem.Size = new Size(297, 26);
            deleteTransactionFilesToolStripMenuItem.Text = "Delete Transaction Files";
            deleteTransactionFilesToolStripMenuItem.Click += deleteTransactionFilesToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(55, 24);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(142, 26);
            aboutToolStripMenuItem.Text = "&About...";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // hSplit1
            // 
            hSplit1.Dock = DockStyle.Fill;
            hSplit1.FixedPanel = FixedPanel.Panel2;
            hSplit1.Location = new Point(0, 0);
            hSplit1.Margin = new Padding(3, 4, 3, 4);
            hSplit1.Name = "hSplit1";
            hSplit1.Orientation = Orientation.Horizontal;
            // 
            // hSplit1.Panel1
            // 
            hSplit1.Panel1.Controls.Add(vSplit1);
            // 
            // hSplit1.Panel2
            // 
            hSplit1.Panel2.Controls.Add(groupReminders);
            hSplit1.Size = new Size(1321, 851);
            hSplit1.SplitterDistance = 567;
            hSplit1.SplitterWidth = 5;
            hSplit1.TabIndex = 3;
            // 
            // vSplit1
            // 
            vSplit1.FixedPanel = FixedPanel.Panel1;
            vSplit1.Location = new Point(6, 4);
            vSplit1.Margin = new Padding(3, 4, 3, 4);
            vSplit1.Name = "vSplit1";
            // 
            // vSplit1.Panel1
            // 
            vSplit1.Panel1.Controls.Add(groupAccounts);
            // 
            // vSplit1.Panel2
            // 
            vSplit1.Panel2.Controls.Add(tableLayoutLedger);
            vSplit1.Size = new Size(1302, 368);
            vSplit1.SplitterDistance = 226;
            vSplit1.SplitterWidth = 5;
            vSplit1.TabIndex = 0;
            // 
            // groupAccounts
            // 
            groupAccounts.Controls.Add(listViewAccounts);
            groupAccounts.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            groupAccounts.Location = new Point(3, 4);
            groupAccounts.Margin = new Padding(3, 4, 3, 4);
            groupAccounts.Name = "groupAccounts";
            groupAccounts.Padding = new Padding(3, 4, 3, 4);
            groupAccounts.Size = new Size(147, 223);
            groupAccounts.TabIndex = 2;
            groupAccounts.TabStop = false;
            groupAccounts.Text = "Accounts";
            // 
            // listViewAccounts
            // 
            listViewAccounts.ContextMenuStrip = accountsContextMenuStrip;
            listViewAccounts.Location = new Point(7, 29);
            listViewAccounts.Margin = new Padding(3, 4, 3, 4);
            listViewAccounts.Name = "listViewAccounts";
            listViewAccounts.SelectionBackColor = Color.Blue;
            listViewAccounts.SelectionForeColor = Color.Black;
            listViewAccounts.Size = new Size(102, 167);
            listViewAccounts.TabIndex = 1;
            listViewAccounts.UseCompatibleStateImageBehavior = false;
            listViewAccounts.SelectedIndexChanged += listView1_SelectedIndexChanged;
            listViewAccounts.DoubleClick += listViewAccounts_DoubleClick;
            // 
            // accountsContextMenuStrip
            // 
            accountsContextMenuStrip.ImageScalingSize = new Size(20, 20);
            accountsContextMenuStrip.Items.AddRange(new ToolStripItem[] { editAccountToolStripMenuItem });
            accountsContextMenuStrip.Name = "accountsContextMenuStrip";
            accountsContextMenuStrip.Size = new Size(105, 28);
            // 
            // editAccountToolStripMenuItem
            // 
            editAccountToolStripMenuItem.Name = "editAccountToolStripMenuItem";
            editAccountToolStripMenuItem.Size = new Size(104, 24);
            editAccountToolStripMenuItem.Text = "Edit";
            editAccountToolStripMenuItem.Click += editAccountToolStripMenuItem_Click;
            // 
            // tableLayoutLedger
            // 
            tableLayoutLedger.ColumnCount = 1;
            tableLayoutLedger.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutLedger.Controls.Add(ledgerSplit, 0, 0);
            tableLayoutLedger.Controls.Add(mainStatusStrip1, 0, 1);
            tableLayoutLedger.Location = new Point(3, 4);
            tableLayoutLedger.Margin = new Padding(3, 4, 3, 4);
            tableLayoutLedger.Name = "tableLayoutLedger";
            tableLayoutLedger.RowCount = 2;
            tableLayoutLedger.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutLedger.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
            tableLayoutLedger.Size = new Size(1008, 253);
            tableLayoutLedger.TabIndex = 7;
            // 
            // ledgerSplit
            // 
            ledgerSplit.Location = new Point(3, 4);
            ledgerSplit.Margin = new Padding(3, 4, 3, 4);
            ledgerSplit.Name = "ledgerSplit";
            ledgerSplit.Orientation = Orientation.Horizontal;
            // 
            // ledgerSplit.Panel1
            // 
            ledgerSplit.Panel1.Controls.Add(groupLedger);
            // 
            // ledgerSplit.Panel2
            // 
            ledgerSplit.Panel2.Controls.Add(groupStaged);
            ledgerSplit.Size = new Size(310, 206);
            ledgerSplit.SplitterDistance = 130;
            ledgerSplit.SplitterWidth = 5;
            ledgerSplit.TabIndex = 4;
            // 
            // groupLedger
            // 
            groupLedger.Controls.Add(dgvAccountTransactions);
            groupLedger.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            groupLedger.Location = new Point(3, 4);
            groupLedger.Margin = new Padding(3, 4, 3, 4);
            groupLedger.Name = "groupLedger";
            groupLedger.Padding = new Padding(3, 4, 3, 4);
            groupLedger.Size = new Size(143, 87);
            groupLedger.TabIndex = 5;
            groupLedger.TabStop = false;
            groupLedger.Text = "Ledger";
            // 
            // dgvAccountTransactions
            // 
            dgvAccountTransactions.BackgroundColor = SystemColors.Window;
            dgvAccountTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccountTransactions.ContextMenuStrip = transactionsContextMenu;
            dgvAccountTransactions.Location = new Point(7, 32);
            dgvAccountTransactions.Margin = new Padding(3, 4, 3, 4);
            dgvAccountTransactions.Name = "dgvAccountTransactions";
            dgvAccountTransactions.RowHeadersWidth = 51;
            dgvAccountTransactions.RowTemplate.Height = 25;
            dgvAccountTransactions.Size = new Size(115, 39);
            dgvAccountTransactions.TabIndex = 3;
            dgvAccountTransactions.CellBeginEdit += dataGridView_CellBeginEdit;
            dgvAccountTransactions.CellMouseDoubleClick += dgvAccountTransactions_CellMouseDoubleClick;
            dgvAccountTransactions.SelectionChanged += dgvAccountTransactions_SelectionChanged;
            // 
            // transactionsContextMenu
            // 
            transactionsContextMenu.ImageScalingSize = new Size(20, 20);
            transactionsContextMenu.Items.AddRange(new ToolStripItem[] { addTransToolStripMenuItem, editTransToolStripMenuItem, setTransStateToolStripMenuItem, toolStripSeparator7, reconcileNewToolStripMenuItem, toolStripSeparator9, addReminderToolStripMenuItem, toolStripSeparator2, deleteTransToolStripMenuItem });
            transactionsContextMenu.Name = "transContextMenu";
            transactionsContextMenu.Size = new Size(184, 166);
            transactionsContextMenu.Opening += transactionsContextMenu_Opening;
            // 
            // addTransToolStripMenuItem
            // 
            addTransToolStripMenuItem.Name = "addTransToolStripMenuItem";
            addTransToolStripMenuItem.Size = new Size(183, 24);
            addTransToolStripMenuItem.Text = "Add...";
            addTransToolStripMenuItem.ToolTipText = "Add transaction";
            addTransToolStripMenuItem.Click += addTransToolStripMenuItem_Click;
            // 
            // editTransToolStripMenuItem
            // 
            editTransToolStripMenuItem.Name = "editTransToolStripMenuItem";
            editTransToolStripMenuItem.Size = new Size(183, 24);
            editTransToolStripMenuItem.Text = "Edit...";
            editTransToolStripMenuItem.ToolTipText = "Modify transaction";
            editTransToolStripMenuItem.Click += editTransToolStripMenuItem_Click;
            // 
            // setTransStateToolStripMenuItem
            // 
            setTransStateToolStripMenuItem.Name = "setTransStateToolStripMenuItem";
            setTransStateToolStripMenuItem.Size = new Size(183, 24);
            setTransStateToolStripMenuItem.Text = "Set State...";
            setTransStateToolStripMenuItem.ToolTipText = "Set state of transaction(s)";
            setTransStateToolStripMenuItem.Click += setTransStateToolStripMenuItem_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(180, 6);
            // 
            // reconcileNewToolStripMenuItem
            // 
            reconcileNewToolStripMenuItem.Name = "reconcileNewToolStripMenuItem";
            reconcileNewToolStripMenuItem.Size = new Size(183, 24);
            reconcileNewToolStripMenuItem.Text = "Reconcile New";
            reconcileNewToolStripMenuItem.ToolTipText = "Set state of new transactions to Reconciled";
            reconcileNewToolStripMenuItem.Click += reconcileNewToolStripMenuItem_Click;
            // 
            // toolStripSeparator9
            // 
            toolStripSeparator9.Name = "toolStripSeparator9";
            toolStripSeparator9.Size = new Size(180, 6);
            // 
            // addReminderToolStripMenuItem
            // 
            addReminderToolStripMenuItem.Name = "addReminderToolStripMenuItem";
            addReminderToolStripMenuItem.Size = new Size(183, 24);
            addReminderToolStripMenuItem.Text = "Add Reminder...";
            addReminderToolStripMenuItem.ToolTipText = "Add reminder for this transaction.";
            addReminderToolStripMenuItem.Click += makeReminderToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(180, 6);
            // 
            // deleteTransToolStripMenuItem
            // 
            deleteTransToolStripMenuItem.Name = "deleteTransToolStripMenuItem";
            deleteTransToolStripMenuItem.Size = new Size(183, 24);
            deleteTransToolStripMenuItem.Text = "Delete";
            deleteTransToolStripMenuItem.ToolTipText = "Delete transaction(s)";
            deleteTransToolStripMenuItem.Click += deleteTransToolStripMenuItem_Click;
            // 
            // groupStaged
            // 
            groupStaged.Controls.Add(dgvStagedAccountTransactions);
            groupStaged.Location = new Point(3, 4);
            groupStaged.Margin = new Padding(3, 4, 3, 4);
            groupStaged.Name = "groupStaged";
            groupStaged.Padding = new Padding(3, 4, 3, 4);
            groupStaged.Size = new Size(187, 71);
            groupStaged.TabIndex = 0;
            groupStaged.TabStop = false;
            groupStaged.Text = "Staged";
            // 
            // dgvStagedAccountTransactions
            // 
            dgvStagedAccountTransactions.BackgroundColor = SystemColors.Window;
            dgvStagedAccountTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStagedAccountTransactions.ContextMenuStrip = transactionsContextMenu;
            dgvStagedAccountTransactions.Location = new Point(7, 28);
            dgvStagedAccountTransactions.Margin = new Padding(3, 4, 3, 4);
            dgvStagedAccountTransactions.Name = "dgvStagedAccountTransactions";
            dgvStagedAccountTransactions.RowHeadersWidth = 51;
            dgvStagedAccountTransactions.RowTemplate.Height = 25;
            dgvStagedAccountTransactions.Size = new Size(115, 39);
            dgvStagedAccountTransactions.TabIndex = 3;
            dgvStagedAccountTransactions.CellBeginEdit += dataGridView_CellBeginEdit;
            dgvStagedAccountTransactions.CellMouseDoubleClick += dgvAccountTransactions_CellMouseDoubleClick;
            dgvStagedAccountTransactions.SelectionChanged += dgvAccountTransactions_SelectionChanged;
            // 
            // mainStatusStrip1
            // 
            mainStatusStrip1.Dock = DockStyle.None;
            mainStatusStrip1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            mainStatusStrip1.ImageScalingSize = new Size(20, 20);
            mainStatusStrip1.Items.AddRange(new ToolStripItem[] { accountToolStripStatusLabel, currentToolStripStatusLabel, availableToolStripStatusLabel, stagedToolStripStatusLabel, finalToolStripStatusLabel, sumToolStripStatusLabel });
            mainStatusStrip1.Location = new Point(2, 214);
            mainStatusStrip1.Margin = new Padding(2, 0, 2, 0);
            mainStatusStrip1.Name = "mainStatusStrip1";
            mainStatusStrip1.Padding = new Padding(1, 0, 16, 0);
            mainStatusStrip1.Size = new Size(1004, 27);
            mainStatusStrip1.SizingGrip = false;
            mainStatusStrip1.TabIndex = 6;
            mainStatusStrip1.Text = "statusStrip1";
            // 
            // accountToolStripStatusLabel
            // 
            accountToolStripStatusLabel.AutoSize = false;
            accountToolStripStatusLabel.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            accountToolStripStatusLabel.Name = "accountToolStripStatusLabel";
            accountToolStripStatusLabel.Size = new Size(150, 21);
            accountToolStripStatusLabel.Text = "Account";
            accountToolStripStatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            accountToolStripStatusLabel.ToolTipText = "Account name";
            // 
            // currentToolStripStatusLabel
            // 
            currentToolStripStatusLabel.AutoSize = false;
            currentToolStripStatusLabel.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            currentToolStripStatusLabel.Name = "currentToolStripStatusLabel";
            currentToolStripStatusLabel.Size = new Size(150, 21);
            currentToolStripStatusLabel.Text = "Current: 0.00";
            currentToolStripStatusLabel.TextAlign = ContentAlignment.MiddleRight;
            currentToolStripStatusLabel.ToolTipText = "Current balance";
            // 
            // availableToolStripStatusLabel
            // 
            availableToolStripStatusLabel.AutoSize = false;
            availableToolStripStatusLabel.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            availableToolStripStatusLabel.Name = "availableToolStripStatusLabel";
            availableToolStripStatusLabel.Size = new Size(150, 21);
            availableToolStripStatusLabel.Text = "Available: 0.00";
            availableToolStripStatusLabel.TextAlign = ContentAlignment.MiddleRight;
            availableToolStripStatusLabel.ToolTipText = "Current balance less reserve amount";
            // 
            // stagedToolStripStatusLabel
            // 
            stagedToolStripStatusLabel.AutoSize = false;
            stagedToolStripStatusLabel.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            stagedToolStripStatusLabel.Name = "stagedToolStripStatusLabel";
            stagedToolStripStatusLabel.Size = new Size(150, 21);
            stagedToolStripStatusLabel.Text = "Staged: 0.00";
            stagedToolStripStatusLabel.TextAlign = ContentAlignment.MiddleRight;
            stagedToolStripStatusLabel.ToolTipText = "Balance of staged transactions";
            // 
            // finalToolStripStatusLabel
            // 
            finalToolStripStatusLabel.AutoSize = false;
            finalToolStripStatusLabel.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            finalToolStripStatusLabel.Name = "finalToolStripStatusLabel";
            finalToolStripStatusLabel.Size = new Size(150, 21);
            finalToolStripStatusLabel.Text = "Final: 0.00";
            finalToolStripStatusLabel.TextAlign = ContentAlignment.MiddleRight;
            finalToolStripStatusLabel.ToolTipText = "Available balance less staged transactions";
            // 
            // sumToolStripStatusLabel
            // 
            sumToolStripStatusLabel.AutoSize = false;
            sumToolStripStatusLabel.Font = new Font("Segoe UI", 11F, FontStyle.Italic, GraphicsUnit.Point);
            sumToolStripStatusLabel.ForeColor = SystemColors.GrayText;
            sumToolStripStatusLabel.Name = "sumToolStripStatusLabel";
            sumToolStripStatusLabel.Size = new Size(237, 21);
            sumToolStripStatusLabel.Spring = true;
            sumToolStripStatusLabel.Text = "Sum: 0.00";
            sumToolStripStatusLabel.TextAlign = ContentAlignment.MiddleRight;
            sumToolStripStatusLabel.ToolTipText = "Sum of selected transactions";
            // 
            // groupReminders
            // 
            groupReminders.Controls.Add(dgvReminders);
            groupReminders.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            groupReminders.Location = new Point(3, 4);
            groupReminders.Margin = new Padding(3, 4, 3, 4);
            groupReminders.Name = "groupReminders";
            groupReminders.Padding = new Padding(3, 4, 3, 4);
            groupReminders.Size = new Size(538, 321);
            groupReminders.TabIndex = 4;
            groupReminders.TabStop = false;
            groupReminders.Text = "Reminders";
            // 
            // dgvReminders
            // 
            dgvReminders.BackgroundColor = SystemColors.Window;
            dgvReminders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReminders.ContextMenuStrip = remindersContextMenu;
            dgvReminders.Location = new Point(7, 29);
            dgvReminders.Margin = new Padding(3, 4, 3, 4);
            dgvReminders.Name = "dgvReminders";
            dgvReminders.RowHeadersWidth = 51;
            dgvReminders.RowTemplate.Height = 25;
            dgvReminders.Size = new Size(146, 45);
            dgvReminders.TabIndex = 3;
            dgvReminders.CellBeginEdit += dataGridView_CellBeginEdit;
            dgvReminders.CellMouseDoubleClick += dgvReminders_CellMouseDoubleClick;
            dgvReminders.SelectionChanged += dgvReminders_SelectionChanged;
            // 
            // remindersContextMenu
            // 
            remindersContextMenu.ImageScalingSize = new Size(20, 20);
            remindersContextMenu.Items.AddRange(new ToolStripItem[] { createReminderToolStripMenuItem, editReminderToolStripMenuItem, skipReminderToolStripMenuItem, stageReminderToolStripMenuItem, copyReminderToolStripMenuItem, toolStripSeparator8, openWebsiteToolStripMenuItem, toolStripSeparator6, deleteReminderToolStripMenuItem });
            remindersContextMenu.Name = "remindersContextMenu";
            remindersContextMenu.Size = new Size(172, 184);
            remindersContextMenu.Opening += remindersContextMenu_Opening;
            // 
            // createReminderToolStripMenuItem
            // 
            createReminderToolStripMenuItem.Name = "createReminderToolStripMenuItem";
            createReminderToolStripMenuItem.Size = new Size(171, 24);
            createReminderToolStripMenuItem.Text = "Create...";
            createReminderToolStripMenuItem.ToolTipText = "Create reminder";
            createReminderToolStripMenuItem.Click += createReminderToolStripMenuItem_Click;
            // 
            // editReminderToolStripMenuItem
            // 
            editReminderToolStripMenuItem.Name = "editReminderToolStripMenuItem";
            editReminderToolStripMenuItem.Size = new Size(171, 24);
            editReminderToolStripMenuItem.Text = "Edit...";
            editReminderToolStripMenuItem.ToolTipText = "Edit reminder";
            editReminderToolStripMenuItem.Click += editRemindersToolStripMenuItem_Click;
            // 
            // skipReminderToolStripMenuItem
            // 
            skipReminderToolStripMenuItem.Name = "skipReminderToolStripMenuItem";
            skipReminderToolStripMenuItem.Size = new Size(171, 24);
            skipReminderToolStripMenuItem.Text = "Skip";
            skipReminderToolStripMenuItem.ToolTipText = "Skip reminder(s)";
            skipReminderToolStripMenuItem.Click += skipReminderToolStripMenuItem_Click;
            // 
            // stageReminderToolStripMenuItem
            // 
            stageReminderToolStripMenuItem.Name = "stageReminderToolStripMenuItem";
            stageReminderToolStripMenuItem.Size = new Size(171, 24);
            stageReminderToolStripMenuItem.Text = "Stage";
            stageReminderToolStripMenuItem.ToolTipText = "Copy to ledger and set next due date";
            stageReminderToolStripMenuItem.Click += stageReminderToolStripMenuItem_Click;
            // 
            // copyReminderToolStripMenuItem
            // 
            copyReminderToolStripMenuItem.Name = "copyReminderToolStripMenuItem";
            copyReminderToolStripMenuItem.Size = new Size(171, 24);
            copyReminderToolStripMenuItem.Text = "Copy";
            copyReminderToolStripMenuItem.ToolTipText = "Copy to ledger";
            copyReminderToolStripMenuItem.Click += copyReminderToolStripMenuItem_Click;
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(168, 6);
            // 
            // openWebsiteToolStripMenuItem
            // 
            openWebsiteToolStripMenuItem.Name = "openWebsiteToolStripMenuItem";
            openWebsiteToolStripMenuItem.Size = new Size(171, 24);
            openWebsiteToolStripMenuItem.Text = "Open Website";
            openWebsiteToolStripMenuItem.ToolTipText = "Open institution website associated with this reminder.";
            openWebsiteToolStripMenuItem.Click += openWebsiteToolStripMenuItem_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(168, 6);
            // 
            // deleteReminderToolStripMenuItem
            // 
            deleteReminderToolStripMenuItem.Name = "deleteReminderToolStripMenuItem";
            deleteReminderToolStripMenuItem.Size = new Size(171, 24);
            deleteReminderToolStripMenuItem.Text = "Delete";
            deleteReminderToolStripMenuItem.ToolTipText = "Delete selected reminder(s)";
            deleteReminderToolStripMenuItem.Click += deleteRemindersToolStripMenuItem_Click;
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(hSplit1);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 30);
            mainPanel.Margin = new Padding(3, 4, 3, 4);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1321, 851);
            mainPanel.TabIndex = 3;
            // 
            // threeMonthsAgoToolStripMenuItem
            // 
            threeMonthsAgoToolStripMenuItem.Name = "threeMonthsAgoToolStripMenuItem";
            threeMonthsAgoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.T;
            threeMonthsAgoToolStripMenuItem.Size = new Size(302, 26);
            threeMonthsAgoToolStripMenuItem.Text = "Three Months Ago";
            threeMonthsAgoToolStripMenuItem.ToolTipText = "Of this month and past two months. For example, if today is in December then all transactions since October will be shown.";
            threeMonthsAgoToolStripMenuItem.Click += threeMonthsAgoToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1321, 881);
            Controls.Add(mainPanel);
            Controls.Add(mainMenuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = mainMenuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "MoneyBookTools";
            Load += MainForm_Load;
            mainMenuStrip1.ResumeLayout(false);
            mainMenuStrip1.PerformLayout();
            hSplit1.Panel1.ResumeLayout(false);
            hSplit1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)hSplit1).EndInit();
            hSplit1.ResumeLayout(false);
            vSplit1.Panel1.ResumeLayout(false);
            vSplit1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)vSplit1).EndInit();
            vSplit1.ResumeLayout(false);
            groupAccounts.ResumeLayout(false);
            accountsContextMenuStrip.ResumeLayout(false);
            tableLayoutLedger.ResumeLayout(false);
            tableLayoutLedger.PerformLayout();
            ledgerSplit.Panel1.ResumeLayout(false);
            ledgerSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ledgerSplit).EndInit();
            ledgerSplit.ResumeLayout(false);
            groupLedger.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAccountTransactions).EndInit();
            transactionsContextMenu.ResumeLayout(false);
            groupStaged.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStagedAccountTransactions).EndInit();
            mainStatusStrip1.ResumeLayout(false);
            mainStatusStrip1.PerformLayout();
            groupReminders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReminders).EndInit();
            remindersContextMenu.ResumeLayout(false);
            mainPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mainMenuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private DataGridView dgvAccountTransactions;
        private DataGridView dgvReminders;
        private GroupBox groupLedger;
        private GroupBox groupReminders;
        private ContextMenuStrip remindersContextMenu;
        private ToolStripMenuItem skipReminderToolStripMenuItem;
        private ContextMenuStrip transactionsContextMenu;
        private ToolStripMenuItem deleteTransToolStripMenuItem;
        private ToolStripMenuItem setTransStateToolStripMenuItem;
        private ToolStripMenuItem stageReminderToolStripMenuItem;
        private ToolStripMenuItem editTransToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem editReminderToolStripMenuItem;
        private ToolStripMenuItem copyReminderToolStripMenuItem;
        private CustomListView listViewAccounts;
        private ToolStripMenuItem addTransToolStripMenuItem;
        private SplitContainer hSplit1;
        private SplitContainer vSplit1;
        private GroupBox groupAccounts;
        private ToolStripMenuItem operationsToolStripMenuItem;
        private ToolStripMenuItem importTransactionsToolStripMenuItem;
        private ToolStripMenuItem deleteAllTransactionsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem backupDatabaseToolStripMenuItem;
        private ToolStripMenuItem restoreDatabaseToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem createReminderToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem deleteReminderToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem addReminderToolStripMenuItem;
        private Panel mainPanel;
        private StatusStrip mainStatusStrip1;
        private ToolStripStatusLabel accountToolStripStatusLabel;
        private ToolStripStatusLabel currentToolStripStatusLabel;
        private ToolStripStatusLabel availableToolStripStatusLabel;
        private ToolStripStatusLabel stagedToolStripStatusLabel;
        private ToolStripStatusLabel finalToolStripStatusLabel;
        private ToolStripStatusLabel sumToolStripStatusLabel;
        private ToolStripMenuItem transactionsToolStripMenuItem;
        private ToolStripMenuItem filterToolStripMenuItem;
        private ToolStripMenuItem twoWeeksToolStripMenuItem;
        private ToolStripMenuItem thisMonthToolStripMenuItem;
        private ToolStripMenuItem thisYearToolStripMenuItem;
        private ToolStripMenuItem sortToolStripMenuItem;
        private ToolStripMenuItem dateDescendingToolStripMenuItem;
        private ToolStripMenuItem dateAscendingToolStripMenuItem;
        private TableLayoutPanel tableLayoutLedger;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem openWebsiteToolStripMenuItem;
        private ToolStripMenuItem reconcileNewToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripMenuItem anyStatusMenuItem;
        private ToolStripMenuItem newStatusMenuItem;
        private ToolStripMenuItem reconciledStatusMenuItem;
        private ToolStripMenuItem ignoredStatusMenuItem;
        private ContextMenuStrip accountsContextMenuStrip;
        private ToolStripMenuItem editAccountToolStripMenuItem;
        private ToolStripMenuItem allDatesToolStripMenuItem;
        private ToolStripMenuItem pendingToolStripMenuItem;
        private SplitContainer ledgerSplit;
        private DataGridView dgvStagedAccountTransactions;
        private GroupBox groupStaged;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem deleteTransactionFilesToolStripMenuItem;
        private ToolStripMenuItem threeMonthsAgoToolStripMenuItem;
    }
}