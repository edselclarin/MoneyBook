
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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            refreshToolStripMenuItem = new ToolStripMenuItem();
            transactionsToolStripMenuItem = new ToolStripMenuItem();
            filterToolStripMenuItem = new ToolStripMenuItem();
            twoWeeksToolStripMenuItem = new ToolStripMenuItem();
            thisMonthToolStripMenuItem = new ToolStripMenuItem();
            thisYearToolStripMenuItem = new ToolStripMenuItem();
            clearToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator10 = new ToolStripSeparator();
            newStatusMenuItem = new ToolStripMenuItem();
            stagedStatusMenuItem = new ToolStripMenuItem();
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
            toolStripSeparator1 = new ToolStripSeparator();
            importRemindersToolStripMenuItem = new ToolStripMenuItem();
            exportRemindersToolStripMenuItem = new ToolStripMenuItem();
            deleteRemindersToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            updateAccountDataToolStripMenuItem = new ToolStripMenuItem();
            resetAccountDataToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            backupDatabaseToolStripMenuItem = new ToolStripMenuItem();
            restoreDatabaseToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            hSplit1 = new SplitContainer();
            vSplit1 = new SplitContainer();
            groupAccounts = new GroupBox();
            listViewAccounts = new CustomListView();
            tableLayoutLedger = new TableLayoutPanel();
            statusStrip1 = new StatusStrip();
            accountToolStripStatusLabel = new ToolStripStatusLabel();
            currentToolStripStatusLabel = new ToolStripStatusLabel();
            availableToolStripStatusLabel = new ToolStripStatusLabel();
            stagedToolStripStatusLabel = new ToolStripStatusLabel();
            finalToolStripStatusLabel = new ToolStripStatusLabel();
            sumToolStripStatusLabel = new ToolStripStatusLabel();
            groupLedger = new GroupBox();
            dgvAccountTransactions = new DataGridView();
            transContextMenu = new ContextMenuStrip(components);
            addTransToolStripMenuItem = new ToolStripMenuItem();
            editTransToolStripMenuItem = new ToolStripMenuItem();
            setTransStateToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator7 = new ToolStripSeparator();
            reconcileNewToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator9 = new ToolStripSeparator();
            addReminderToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            deleteTransToolStripMenuItem = new ToolStripMenuItem();
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
            contextMenuStrip1 = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripMenuItem();
            toolStripSeparator13 = new ToolStripSeparator();
            toolStripMenuItem6 = new ToolStripMenuItem();
            toolStripSeparator14 = new ToolStripSeparator();
            toolStripMenuItem7 = new ToolStripMenuItem();
            contextMenuStrip2 = new ContextMenuStrip(components);
            toolStripMenuItem8 = new ToolStripMenuItem();
            toolStripMenuItem9 = new ToolStripMenuItem();
            toolStripMenuItem10 = new ToolStripMenuItem();
            toolStripMenuItem11 = new ToolStripMenuItem();
            toolStripMenuItem12 = new ToolStripMenuItem();
            toolStripSeparator15 = new ToolStripSeparator();
            toolStripMenuItem13 = new ToolStripMenuItem();
            toolStripSeparator16 = new ToolStripSeparator();
            toolStripMenuItem14 = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)hSplit1).BeginInit();
            hSplit1.Panel1.SuspendLayout();
            hSplit1.Panel2.SuspendLayout();
            hSplit1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)vSplit1).BeginInit();
            vSplit1.Panel1.SuspendLayout();
            vSplit1.Panel2.SuspendLayout();
            vSplit1.SuspendLayout();
            groupAccounts.SuspendLayout();
            tableLayoutLedger.SuspendLayout();
            statusStrip1.SuspendLayout();
            groupLedger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccountTransactions).BeginInit();
            transContextMenu.SuspendLayout();
            groupReminders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReminders).BeginInit();
            remindersContextMenu.SuspendLayout();
            mainPanel.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem, transactionsToolStripMenuItem, operationsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1156, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, toolStripSeparator5, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(112, 22);
            openToolStripMenuItem.Text = "&Open...";
            openToolStripMenuItem.ToolTipText = "Open file";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(109, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(112, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.ToolTipText = "Close application";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { refreshToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(44, 20);
            viewToolStripMenuItem.Text = "&View";
            // 
            // refreshToolStripMenuItem
            // 
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.ShortcutKeys = Keys.F5;
            refreshToolStripMenuItem.Size = new Size(132, 22);
            refreshToolStripMenuItem.Text = "&Refresh";
            refreshToolStripMenuItem.ToolTipText = "Refresh";
            refreshToolStripMenuItem.Click += refreshToolStripMenuItem_Click;
            // 
            // transactionsToolStripMenuItem
            // 
            transactionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { filterToolStripMenuItem, sortToolStripMenuItem });
            transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            transactionsToolStripMenuItem.Size = new Size(84, 20);
            transactionsToolStripMenuItem.Text = "Transactions";
            // 
            // filterToolStripMenuItem
            // 
            filterToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { twoWeeksToolStripMenuItem, thisMonthToolStripMenuItem, thisYearToolStripMenuItem, clearToolStripMenuItem, toolStripSeparator10, newStatusMenuItem, stagedStatusMenuItem, reconciledStatusMenuItem, ignoredStatusMenuItem, anyStatusMenuItem, toolStripSeparator11 });
            filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            filterToolStripMenuItem.Size = new Size(109, 22);
            filterToolStripMenuItem.Text = "Filter...";
            filterToolStripMenuItem.ToolTipText = "Show transactions...";
            // 
            // twoWeeksToolStripMenuItem
            // 
            twoWeeksToolStripMenuItem.Name = "twoWeeksToolStripMenuItem";
            twoWeeksToolStripMenuItem.Size = new Size(157, 22);
            twoWeeksToolStripMenuItem.Text = "Two Weeks";
            twoWeeksToolStripMenuItem.ToolTipText = "In past two weeks";
            twoWeeksToolStripMenuItem.Click += twoWeeksToolStripMenuItem_Click;
            // 
            // thisMonthToolStripMenuItem
            // 
            thisMonthToolStripMenuItem.Name = "thisMonthToolStripMenuItem";
            thisMonthToolStripMenuItem.Size = new Size(157, 22);
            thisMonthToolStripMenuItem.Text = "This Month";
            thisMonthToolStripMenuItem.ToolTipText = "Of the current month";
            thisMonthToolStripMenuItem.Click += thisMonthToolStripMenuItem_Click;
            // 
            // thisYearToolStripMenuItem
            // 
            thisYearToolStripMenuItem.Name = "thisYearToolStripMenuItem";
            thisYearToolStripMenuItem.Size = new Size(157, 22);
            thisYearToolStripMenuItem.Text = "This Year";
            thisYearToolStripMenuItem.ToolTipText = "Of the current year";
            thisYearToolStripMenuItem.Click += thisYearToolStripMenuItem_Click;
            // 
            // clearToolStripMenuItem
            // 
            clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            clearToolStripMenuItem.Size = new Size(157, 22);
            clearToolStripMenuItem.Text = "Clear Date Filter";
            clearToolStripMenuItem.ToolTipText = "Show transactions of any date";
            clearToolStripMenuItem.Click += clearToolStripMenuItem_Click;
            // 
            // toolStripSeparator10
            // 
            toolStripSeparator10.Name = "toolStripSeparator10";
            toolStripSeparator10.Size = new Size(154, 6);
            // 
            // newStatusMenuItem
            // 
            newStatusMenuItem.Name = "newStatusMenuItem";
            newStatusMenuItem.Size = new Size(157, 22);
            newStatusMenuItem.Text = "New";
            newStatusMenuItem.ToolTipText = "Show New transactions";
            newStatusMenuItem.Click += newStatusMenuItem_Click;
            // 
            // stagedStatusMenuItem
            // 
            stagedStatusMenuItem.Name = "stagedStatusMenuItem";
            stagedStatusMenuItem.Size = new Size(157, 22);
            stagedStatusMenuItem.Text = "Staged";
            stagedStatusMenuItem.ToolTipText = "Show Staged transactions";
            stagedStatusMenuItem.Click += stagedStatusMenuItem_Click;
            // 
            // reconciledStatusMenuItem
            // 
            reconciledStatusMenuItem.Name = "reconciledStatusMenuItem";
            reconciledStatusMenuItem.Size = new Size(157, 22);
            reconciledStatusMenuItem.Text = "Reconciled";
            reconciledStatusMenuItem.ToolTipText = "Show Reconciled transactions";
            reconciledStatusMenuItem.Click += reconciledStatusMenuItem_Click;
            // 
            // ignoredStatusMenuItem
            // 
            ignoredStatusMenuItem.Name = "ignoredStatusMenuItem";
            ignoredStatusMenuItem.Size = new Size(157, 22);
            ignoredStatusMenuItem.Text = "Ignored";
            ignoredStatusMenuItem.ToolTipText = "Show Ignored transactions";
            ignoredStatusMenuItem.Click += ignoredStatusMenuItem_Click;
            // 
            // anyStatusMenuItem
            // 
            anyStatusMenuItem.Name = "anyStatusMenuItem";
            anyStatusMenuItem.Size = new Size(157, 22);
            anyStatusMenuItem.Text = "Any Status";
            anyStatusMenuItem.ToolTipText = "Show transactions of any status";
            anyStatusMenuItem.Click += anyStatusMenuItem_Click;
            // 
            // toolStripSeparator11
            // 
            toolStripSeparator11.Name = "toolStripSeparator11";
            toolStripSeparator11.Size = new Size(154, 6);
            // 
            // sortToolStripMenuItem
            // 
            sortToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dateDescendingToolStripMenuItem, dateAscendingToolStripMenuItem });
            sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            sortToolStripMenuItem.Size = new Size(109, 22);
            sortToolStripMenuItem.Text = "Sort...";
            // 
            // dateDescendingToolStripMenuItem
            // 
            dateDescendingToolStripMenuItem.Name = "dateDescendingToolStripMenuItem";
            dateDescendingToolStripMenuItem.Size = new Size(163, 22);
            dateDescendingToolStripMenuItem.Text = "Date Descending";
            dateDescendingToolStripMenuItem.ToolTipText = "Sort by date in descending order.";
            dateDescendingToolStripMenuItem.Click += dateDescendingToolStripMenuItem_Click;
            // 
            // dateAscendingToolStripMenuItem
            // 
            dateAscendingToolStripMenuItem.Name = "dateAscendingToolStripMenuItem";
            dateAscendingToolStripMenuItem.Size = new Size(163, 22);
            dateAscendingToolStripMenuItem.Text = "Date Ascending";
            dateAscendingToolStripMenuItem.ToolTipText = "Sort by date in ascending order.";
            dateAscendingToolStripMenuItem.Click += dateAscendingToolStripMenuItem_Click;
            // 
            // operationsToolStripMenuItem
            // 
            operationsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importTransactionsToolStripMenuItem, deleteAllTransactionsToolStripMenuItem, toolStripSeparator1, importRemindersToolStripMenuItem, exportRemindersToolStripMenuItem, deleteRemindersToolStripMenuItem, toolStripSeparator3, updateAccountDataToolStripMenuItem, resetAccountDataToolStripMenuItem, toolStripSeparator4, backupDatabaseToolStripMenuItem, restoreDatabaseToolStripMenuItem });
            operationsToolStripMenuItem.Name = "operationsToolStripMenuItem";
            operationsToolStripMenuItem.Size = new Size(77, 20);
            operationsToolStripMenuItem.Text = "&Operations";
            // 
            // importTransactionsToolStripMenuItem
            // 
            importTransactionsToolStripMenuItem.Name = "importTransactionsToolStripMenuItem";
            importTransactionsToolStripMenuItem.Size = new Size(192, 22);
            importTransactionsToolStripMenuItem.Text = "Import Transactions...";
            importTransactionsToolStripMenuItem.ToolTipText = "Import transactions from file";
            importTransactionsToolStripMenuItem.Click += importTransactionsToolStripMenuItem_Click;
            // 
            // deleteAllTransactionsToolStripMenuItem
            // 
            deleteAllTransactionsToolStripMenuItem.Name = "deleteAllTransactionsToolStripMenuItem";
            deleteAllTransactionsToolStripMenuItem.Size = new Size(192, 22);
            deleteAllTransactionsToolStripMenuItem.Text = "Delete All Transactions";
            deleteAllTransactionsToolStripMenuItem.ToolTipText = "Delete transactions across all accounts";
            deleteAllTransactionsToolStripMenuItem.Click += deleteAllTransactionsToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(189, 6);
            // 
            // importRemindersToolStripMenuItem
            // 
            importRemindersToolStripMenuItem.Name = "importRemindersToolStripMenuItem";
            importRemindersToolStripMenuItem.Size = new Size(192, 22);
            importRemindersToolStripMenuItem.Text = "Import Reminders...";
            importRemindersToolStripMenuItem.ToolTipText = "Import reminders from file";
            importRemindersToolStripMenuItem.Click += importRemindersToolStripMenuItem_Click;
            // 
            // exportRemindersToolStripMenuItem
            // 
            exportRemindersToolStripMenuItem.Name = "exportRemindersToolStripMenuItem";
            exportRemindersToolStripMenuItem.Size = new Size(192, 22);
            exportRemindersToolStripMenuItem.Text = "Export Reminders...";
            exportRemindersToolStripMenuItem.ToolTipText = "Export reminders from file";
            exportRemindersToolStripMenuItem.Click += exportRemindesToolStripMenuItem_Click;
            // 
            // deleteRemindersToolStripMenuItem
            // 
            deleteRemindersToolStripMenuItem.Name = "deleteRemindersToolStripMenuItem";
            deleteRemindersToolStripMenuItem.Size = new Size(192, 22);
            deleteRemindersToolStripMenuItem.Text = "Delete Reminders";
            deleteRemindersToolStripMenuItem.ToolTipText = "Delete all reminders";
            deleteRemindersToolStripMenuItem.Click += deleteRemindersToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(189, 6);
            // 
            // updateAccountDataToolStripMenuItem
            // 
            updateAccountDataToolStripMenuItem.Name = "updateAccountDataToolStripMenuItem";
            updateAccountDataToolStripMenuItem.Size = new Size(192, 22);
            updateAccountDataToolStripMenuItem.Text = "Update Account Data";
            updateAccountDataToolStripMenuItem.ToolTipText = "Update account data from settings file";
            // 
            // resetAccountDataToolStripMenuItem
            // 
            resetAccountDataToolStripMenuItem.Name = "resetAccountDataToolStripMenuItem";
            resetAccountDataToolStripMenuItem.Size = new Size(192, 22);
            resetAccountDataToolStripMenuItem.Text = "Reset Account Data";
            resetAccountDataToolStripMenuItem.ToolTipText = "Reset account data of all accounts";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(189, 6);
            // 
            // backupDatabaseToolStripMenuItem
            // 
            backupDatabaseToolStripMenuItem.Name = "backupDatabaseToolStripMenuItem";
            backupDatabaseToolStripMenuItem.Size = new Size(192, 22);
            backupDatabaseToolStripMenuItem.Text = "Backup Database...";
            backupDatabaseToolStripMenuItem.ToolTipText = "Backup database to tape file and text file";
            backupDatabaseToolStripMenuItem.Click += backupDatabaseToolStripMenuItem_Click;
            // 
            // restoreDatabaseToolStripMenuItem
            // 
            restoreDatabaseToolStripMenuItem.Name = "restoreDatabaseToolStripMenuItem";
            restoreDatabaseToolStripMenuItem.Size = new Size(192, 22);
            restoreDatabaseToolStripMenuItem.Text = "Restore Database...";
            restoreDatabaseToolStripMenuItem.ToolTipText = "Restore table data from text file backup";
            restoreDatabaseToolStripMenuItem.Click += restoreDatabaseToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(116, 22);
            aboutToolStripMenuItem.Text = "&About...";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // hSplit1
            // 
            hSplit1.Dock = DockStyle.Fill;
            hSplit1.FixedPanel = FixedPanel.Panel2;
            hSplit1.Location = new Point(0, 0);
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
            hSplit1.Size = new Size(1156, 503);
            hSplit1.SplitterDistance = 295;
            hSplit1.TabIndex = 3;
            // 
            // vSplit1
            // 
            vSplit1.FixedPanel = FixedPanel.Panel1;
            vSplit1.Location = new Point(5, 3);
            vSplit1.Name = "vSplit1";
            // 
            // vSplit1.Panel1
            // 
            vSplit1.Panel1.Controls.Add(groupAccounts);
            // 
            // vSplit1.Panel2
            // 
            vSplit1.Panel2.Controls.Add(tableLayoutLedger);
            vSplit1.Size = new Size(1139, 276);
            vSplit1.SplitterDistance = 226;
            vSplit1.TabIndex = 0;
            // 
            // groupAccounts
            // 
            groupAccounts.Controls.Add(listViewAccounts);
            groupAccounts.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            groupAccounts.Location = new Point(3, 3);
            groupAccounts.Name = "groupAccounts";
            groupAccounts.Size = new Size(129, 167);
            groupAccounts.TabIndex = 2;
            groupAccounts.TabStop = false;
            groupAccounts.Text = "Accounts";
            // 
            // listViewAccounts
            // 
            listViewAccounts.Location = new Point(6, 22);
            listViewAccounts.Name = "listViewAccounts";
            listViewAccounts.SelectionBackColor = Color.Blue;
            listViewAccounts.SelectionForeColor = Color.Black;
            listViewAccounts.Size = new Size(90, 126);
            listViewAccounts.TabIndex = 1;
            listViewAccounts.UseCompatibleStateImageBehavior = false;
            listViewAccounts.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // tableLayoutLedger
            // 
            tableLayoutLedger.ColumnCount = 1;
            tableLayoutLedger.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutLedger.Controls.Add(statusStrip1, 0, 1);
            tableLayoutLedger.Controls.Add(groupLedger, 0, 0);
            tableLayoutLedger.Location = new Point(3, 3);
            tableLayoutLedger.Name = "tableLayoutLedger";
            tableLayoutLedger.RowCount = 2;
            tableLayoutLedger.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutLedger.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutLedger.Size = new Size(882, 190);
            tableLayoutLedger.TabIndex = 7;
            // 
            // statusStrip1
            // 
            statusStrip1.Dock = DockStyle.None;
            statusStrip1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            statusStrip1.Items.AddRange(new ToolStripItem[] { accountToolStripStatusLabel, currentToolStripStatusLabel, availableToolStripStatusLabel, stagedToolStripStatusLabel, finalToolStripStatusLabel, sumToolStripStatusLabel });
            statusStrip1.Location = new Point(2, 161);
            statusStrip1.Margin = new Padding(2, 0, 2, 0);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(878, 27);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 6;
            statusStrip1.Text = "statusStrip1";
            // 
            // accountToolStripStatusLabel
            // 
            accountToolStripStatusLabel.AutoSize = false;
            accountToolStripStatusLabel.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            accountToolStripStatusLabel.Name = "accountToolStripStatusLabel";
            accountToolStripStatusLabel.Size = new Size(150, 22);
            accountToolStripStatusLabel.Text = "Account";
            accountToolStripStatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            accountToolStripStatusLabel.ToolTipText = "Account name";
            // 
            // currentToolStripStatusLabel
            // 
            currentToolStripStatusLabel.AutoSize = false;
            currentToolStripStatusLabel.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            currentToolStripStatusLabel.Name = "currentToolStripStatusLabel";
            currentToolStripStatusLabel.Size = new Size(150, 22);
            currentToolStripStatusLabel.Text = "Current: 0.00";
            currentToolStripStatusLabel.TextAlign = ContentAlignment.MiddleRight;
            currentToolStripStatusLabel.ToolTipText = "Current balance";
            // 
            // availableToolStripStatusLabel
            // 
            availableToolStripStatusLabel.AutoSize = false;
            availableToolStripStatusLabel.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            availableToolStripStatusLabel.Name = "availableToolStripStatusLabel";
            availableToolStripStatusLabel.Size = new Size(150, 22);
            availableToolStripStatusLabel.Text = "Available: 0.00";
            availableToolStripStatusLabel.TextAlign = ContentAlignment.MiddleRight;
            availableToolStripStatusLabel.ToolTipText = "Current balance less reserve amount";
            // 
            // stagedToolStripStatusLabel
            // 
            stagedToolStripStatusLabel.AutoSize = false;
            stagedToolStripStatusLabel.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            stagedToolStripStatusLabel.Name = "stagedToolStripStatusLabel";
            stagedToolStripStatusLabel.Size = new Size(150, 22);
            stagedToolStripStatusLabel.Text = "Staged: 0.00";
            stagedToolStripStatusLabel.TextAlign = ContentAlignment.MiddleRight;
            stagedToolStripStatusLabel.ToolTipText = "Balance of staged transactions";
            // 
            // finalToolStripStatusLabel
            // 
            finalToolStripStatusLabel.AutoSize = false;
            finalToolStripStatusLabel.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            finalToolStripStatusLabel.Name = "finalToolStripStatusLabel";
            finalToolStripStatusLabel.Size = new Size(150, 22);
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
            sumToolStripStatusLabel.Size = new Size(113, 22);
            sumToolStripStatusLabel.Spring = true;
            sumToolStripStatusLabel.Text = "Sum: 0.00";
            sumToolStripStatusLabel.TextAlign = ContentAlignment.MiddleRight;
            sumToolStripStatusLabel.ToolTipText = "Sum of selected transactions";
            // 
            // groupLedger
            // 
            groupLedger.Controls.Add(dgvAccountTransactions);
            groupLedger.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            groupLedger.Location = new Point(3, 3);
            groupLedger.Name = "groupLedger";
            groupLedger.Size = new Size(137, 66);
            groupLedger.TabIndex = 5;
            groupLedger.TabStop = false;
            groupLedger.Text = "Ledger";
            // 
            // dgvAccountTransactions
            // 
            dgvAccountTransactions.BackgroundColor = SystemColors.Window;
            dgvAccountTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccountTransactions.ContextMenuStrip = transContextMenu;
            dgvAccountTransactions.Location = new Point(6, 24);
            dgvAccountTransactions.Name = "dgvAccountTransactions";
            dgvAccountTransactions.RowTemplate.Height = 25;
            dgvAccountTransactions.Size = new Size(101, 29);
            dgvAccountTransactions.TabIndex = 3;
            dgvAccountTransactions.CellBeginEdit += dataGridView_CellBeginEdit;
            dgvAccountTransactions.CellMouseDoubleClick += dgvAccountTransactions_CellMouseDoubleClick;
            dgvAccountTransactions.SelectionChanged += dgvAccountTransactions_SelectionChanged;
            // 
            // transContextMenu
            // 
            transContextMenu.Items.AddRange(new ToolStripItem[] { addTransToolStripMenuItem, editTransToolStripMenuItem, setTransStateToolStripMenuItem, toolStripSeparator7, reconcileNewToolStripMenuItem, toolStripSeparator9, addReminderToolStripMenuItem, toolStripSeparator2, deleteTransToolStripMenuItem });
            transContextMenu.Name = "transContextMenu";
            transContextMenu.Size = new Size(160, 154);
            transContextMenu.Opening += transContextMenu_Opening;
            // 
            // addTransToolStripMenuItem
            // 
            addTransToolStripMenuItem.Name = "addTransToolStripMenuItem";
            addTransToolStripMenuItem.Size = new Size(159, 22);
            addTransToolStripMenuItem.Text = "Add...";
            addTransToolStripMenuItem.ToolTipText = "Add transaction";
            addTransToolStripMenuItem.Click += addTransToolStripMenuItem_Click;
            // 
            // editTransToolStripMenuItem
            // 
            editTransToolStripMenuItem.Name = "editTransToolStripMenuItem";
            editTransToolStripMenuItem.Size = new Size(159, 22);
            editTransToolStripMenuItem.Text = "Edit...";
            editTransToolStripMenuItem.ToolTipText = "Modify transaction";
            editTransToolStripMenuItem.Click += editTransToolStripMenuItem_Click;
            // 
            // setTransStateToolStripMenuItem
            // 
            setTransStateToolStripMenuItem.Name = "setTransStateToolStripMenuItem";
            setTransStateToolStripMenuItem.Size = new Size(159, 22);
            setTransStateToolStripMenuItem.Text = "Set State...";
            setTransStateToolStripMenuItem.ToolTipText = "Set state of transaction(s)";
            setTransStateToolStripMenuItem.Click += setTransStateToolStripMenuItem_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(156, 6);
            // 
            // reconcileNewToolStripMenuItem
            // 
            reconcileNewToolStripMenuItem.Name = "reconcileNewToolStripMenuItem";
            reconcileNewToolStripMenuItem.Size = new Size(159, 22);
            reconcileNewToolStripMenuItem.Text = "Reconcile New";
            reconcileNewToolStripMenuItem.ToolTipText = "Set state of new transactions to Reconciled";
            reconcileNewToolStripMenuItem.Click += reconcileNewToolStripMenuItem_Click;
            // 
            // toolStripSeparator9
            // 
            toolStripSeparator9.Name = "toolStripSeparator9";
            toolStripSeparator9.Size = new Size(156, 6);
            // 
            // addReminderToolStripMenuItem
            // 
            addReminderToolStripMenuItem.Name = "addReminderToolStripMenuItem";
            addReminderToolStripMenuItem.Size = new Size(159, 22);
            addReminderToolStripMenuItem.Text = "Add Reminder...";
            addReminderToolStripMenuItem.ToolTipText = "Add reminder for this transaction.";
            addReminderToolStripMenuItem.Click += makeReminderToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(156, 6);
            // 
            // deleteTransToolStripMenuItem
            // 
            deleteTransToolStripMenuItem.Name = "deleteTransToolStripMenuItem";
            deleteTransToolStripMenuItem.Size = new Size(159, 22);
            deleteTransToolStripMenuItem.Text = "Delete";
            deleteTransToolStripMenuItem.ToolTipText = "Delete transaction(s)";
            deleteTransToolStripMenuItem.Click += deleteTransToolStripMenuItem_Click;
            // 
            // groupReminders
            // 
            groupReminders.Controls.Add(dgvReminders);
            groupReminders.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            groupReminders.Location = new Point(3, 3);
            groupReminders.Name = "groupReminders";
            groupReminders.Size = new Size(151, 74);
            groupReminders.TabIndex = 4;
            groupReminders.TabStop = false;
            groupReminders.Text = "Reminders";
            // 
            // dgvReminders
            // 
            dgvReminders.BackgroundColor = SystemColors.Window;
            dgvReminders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReminders.ContextMenuStrip = remindersContextMenu;
            dgvReminders.Location = new Point(6, 22);
            dgvReminders.Name = "dgvReminders";
            dgvReminders.RowTemplate.Height = 25;
            dgvReminders.Size = new Size(128, 34);
            dgvReminders.TabIndex = 3;
            dgvReminders.CellBeginEdit += dataGridView_CellBeginEdit;
            dgvReminders.CellMouseDoubleClick += dgvReminders_CellMouseDoubleClick;
            // 
            // remindersContextMenu
            // 
            remindersContextMenu.Items.AddRange(new ToolStripItem[] { createReminderToolStripMenuItem, editReminderToolStripMenuItem, skipReminderToolStripMenuItem, stageReminderToolStripMenuItem, copyReminderToolStripMenuItem, toolStripSeparator8, openWebsiteToolStripMenuItem, toolStripSeparator6, deleteReminderToolStripMenuItem });
            remindersContextMenu.Name = "remindersContextMenu";
            remindersContextMenu.Size = new Size(181, 192);
            remindersContextMenu.Opening += remindersContextMenu_Opening;
            // 
            // createReminderToolStripMenuItem
            // 
            createReminderToolStripMenuItem.Name = "createReminderToolStripMenuItem";
            createReminderToolStripMenuItem.Size = new Size(180, 22);
            createReminderToolStripMenuItem.Text = "Create...";
            createReminderToolStripMenuItem.ToolTipText = "Create reminder";
            createReminderToolStripMenuItem.Click += createReminderToolStripMenuItem_Click;
            // 
            // editReminderToolStripMenuItem
            // 
            editReminderToolStripMenuItem.Name = "editReminderToolStripMenuItem";
            editReminderToolStripMenuItem.Size = new Size(180, 22);
            editReminderToolStripMenuItem.Text = "Edit...";
            editReminderToolStripMenuItem.ToolTipText = "Edit reminder";
            editReminderToolStripMenuItem.Click += editRemindersToolStripMenuItem_Click;
            // 
            // skipReminderToolStripMenuItem
            // 
            skipReminderToolStripMenuItem.Name = "skipReminderToolStripMenuItem";
            skipReminderToolStripMenuItem.Size = new Size(180, 22);
            skipReminderToolStripMenuItem.Text = "Skip";
            skipReminderToolStripMenuItem.ToolTipText = "Skip reminder(s)";
            skipReminderToolStripMenuItem.Click += skipReminderToolStripMenuItem_Click;
            // 
            // stageReminderToolStripMenuItem
            // 
            stageReminderToolStripMenuItem.Name = "stageReminderToolStripMenuItem";
            stageReminderToolStripMenuItem.Size = new Size(180, 22);
            stageReminderToolStripMenuItem.Text = "Stage";
            stageReminderToolStripMenuItem.ToolTipText = "Copy to ledger and set next due date";
            stageReminderToolStripMenuItem.Click += stageReminderToolStripMenuItem_Click;
            // 
            // copyReminderToolStripMenuItem
            // 
            copyReminderToolStripMenuItem.Name = "copyReminderToolStripMenuItem";
            copyReminderToolStripMenuItem.Size = new Size(180, 22);
            copyReminderToolStripMenuItem.Text = "Copy";
            copyReminderToolStripMenuItem.ToolTipText = "Copy to ledger";
            copyReminderToolStripMenuItem.Click += copyReminderToolStripMenuItem_Click;
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(177, 6);
            // 
            // openWebsiteToolStripMenuItem
            // 
            openWebsiteToolStripMenuItem.Name = "openWebsiteToolStripMenuItem";
            openWebsiteToolStripMenuItem.Size = new Size(180, 22);
            openWebsiteToolStripMenuItem.Text = "Open Website";
            openWebsiteToolStripMenuItem.ToolTipText = "Open institution website associated with this reminder.";
            openWebsiteToolStripMenuItem.Click += openWebsiteToolStripMenuItem_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(177, 6);
            // 
            // deleteReminderToolStripMenuItem
            // 
            deleteReminderToolStripMenuItem.Name = "deleteReminderToolStripMenuItem";
            deleteReminderToolStripMenuItem.Size = new Size(180, 22);
            deleteReminderToolStripMenuItem.Text = "Delete";
            deleteReminderToolStripMenuItem.ToolTipText = "Delete selected reminder(s)";
            deleteReminderToolStripMenuItem.Click += deleteRemindersToolStripMenuItem_Click;
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(hSplit1);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 24);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1156, 503);
            mainPanel.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4, toolStripMenuItem5, toolStripSeparator13, toolStripMenuItem6, toolStripSeparator14, toolStripMenuItem7 });
            contextMenuStrip1.Name = "recTransContextMenu";
            contextMenuStrip1.Size = new Size(149, 170);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(148, 22);
            toolStripMenuItem1.Text = "Add...";
            toolStripMenuItem1.ToolTipText = "Add recurring transaction";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(148, 22);
            toolStripMenuItem2.Text = "Edit...";
            toolStripMenuItem2.ToolTipText = "Edit recurring transaction";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(148, 22);
            toolStripMenuItem3.Text = "Skip";
            toolStripMenuItem3.ToolTipText = "Set next due date of recurring transaction(s)";
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(148, 22);
            toolStripMenuItem4.Text = "Stage";
            toolStripMenuItem4.ToolTipText = "Copy to ledger and set next due date";
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(148, 22);
            toolStripMenuItem5.Text = "Copy";
            toolStripMenuItem5.ToolTipText = "Copy to ledger";
            // 
            // toolStripSeparator13
            // 
            toolStripSeparator13.Name = "toolStripSeparator13";
            toolStripSeparator13.Size = new Size(145, 6);
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new Size(148, 22);
            toolStripMenuItem6.Text = "Open Website";
            // 
            // toolStripSeparator14
            // 
            toolStripSeparator14.Name = "toolStripSeparator14";
            toolStripSeparator14.Size = new Size(145, 6);
            // 
            // toolStripMenuItem7
            // 
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            toolStripMenuItem7.Size = new Size(148, 22);
            toolStripMenuItem7.Text = "Delete";
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange(new ToolStripItem[] { toolStripMenuItem8, toolStripMenuItem9, toolStripMenuItem10, toolStripMenuItem11, toolStripMenuItem12, toolStripSeparator15, toolStripMenuItem13, toolStripSeparator16, toolStripMenuItem14 });
            contextMenuStrip2.Name = "recTransContextMenu";
            contextMenuStrip2.Size = new Size(149, 170);
            // 
            // toolStripMenuItem8
            // 
            toolStripMenuItem8.Name = "toolStripMenuItem8";
            toolStripMenuItem8.Size = new Size(148, 22);
            toolStripMenuItem8.Text = "Add...";
            toolStripMenuItem8.ToolTipText = "Add recurring transaction";
            // 
            // toolStripMenuItem9
            // 
            toolStripMenuItem9.Name = "toolStripMenuItem9";
            toolStripMenuItem9.Size = new Size(148, 22);
            toolStripMenuItem9.Text = "Edit...";
            toolStripMenuItem9.ToolTipText = "Edit recurring transaction";
            // 
            // toolStripMenuItem10
            // 
            toolStripMenuItem10.Name = "toolStripMenuItem10";
            toolStripMenuItem10.Size = new Size(148, 22);
            toolStripMenuItem10.Text = "Skip";
            toolStripMenuItem10.ToolTipText = "Set next due date of recurring transaction(s)";
            // 
            // toolStripMenuItem11
            // 
            toolStripMenuItem11.Name = "toolStripMenuItem11";
            toolStripMenuItem11.Size = new Size(148, 22);
            toolStripMenuItem11.Text = "Stage";
            toolStripMenuItem11.ToolTipText = "Copy to ledger and set next due date";
            // 
            // toolStripMenuItem12
            // 
            toolStripMenuItem12.Name = "toolStripMenuItem12";
            toolStripMenuItem12.Size = new Size(148, 22);
            toolStripMenuItem12.Text = "Copy";
            toolStripMenuItem12.ToolTipText = "Copy to ledger";
            // 
            // toolStripSeparator15
            // 
            toolStripSeparator15.Name = "toolStripSeparator15";
            toolStripSeparator15.Size = new Size(145, 6);
            // 
            // toolStripMenuItem13
            // 
            toolStripMenuItem13.Name = "toolStripMenuItem13";
            toolStripMenuItem13.Size = new Size(148, 22);
            toolStripMenuItem13.Text = "Open Website";
            // 
            // toolStripSeparator16
            // 
            toolStripSeparator16.Name = "toolStripSeparator16";
            toolStripSeparator16.Size = new Size(145, 6);
            // 
            // toolStripMenuItem14
            // 
            toolStripMenuItem14.Name = "toolStripMenuItem14";
            toolStripMenuItem14.Size = new Size(148, 22);
            toolStripMenuItem14.Text = "Delete";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1156, 527);
            Controls.Add(mainPanel);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "MoneyBookTools";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            hSplit1.Panel1.ResumeLayout(false);
            hSplit1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)hSplit1).EndInit();
            hSplit1.ResumeLayout(false);
            vSplit1.Panel1.ResumeLayout(false);
            vSplit1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)vSplit1).EndInit();
            vSplit1.ResumeLayout(false);
            groupAccounts.ResumeLayout(false);
            tableLayoutLedger.ResumeLayout(false);
            tableLayoutLedger.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            groupLedger.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAccountTransactions).EndInit();
            transContextMenu.ResumeLayout(false);
            groupReminders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReminders).EndInit();
            remindersContextMenu.ResumeLayout(false);
            mainPanel.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            contextMenuStrip2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
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
        private ContextMenuStrip transContextMenu;
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
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem importRemindersToolStripMenuItem;
        private ToolStripMenuItem deleteRemindersToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem updateAccountDataToolStripMenuItem;
        private ToolStripMenuItem resetAccountDataToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem backupDatabaseToolStripMenuItem;
        private ToolStripMenuItem restoreDatabaseToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem createReminderToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem deleteReminderToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem addReminderToolStripMenuItem;
        private Panel mainPanel;
        private StatusStrip statusStrip1;
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
        private ToolStripMenuItem exportRemindersToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem openWebsiteToolStripMenuItem;
        private ToolStripMenuItem reconcileNewToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem stagedStatusMenuItem;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripMenuItem anyStatusMenuItem;
        private ToolStripMenuItem newStatusMenuItem;
        private ToolStripMenuItem reconciledStatusMenuItem;
        private ToolStripMenuItem ignoredStatusMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripSeparator toolStripSeparator14;
        private ToolStripMenuItem toolStripMenuItem7;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripMenuItem toolStripMenuItem10;
        private ToolStripMenuItem toolStripMenuItem11;
        private ToolStripMenuItem toolStripMenuItem12;
        private ToolStripSeparator toolStripSeparator15;
        private ToolStripMenuItem toolStripMenuItem13;
        private ToolStripSeparator toolStripSeparator16;
        private ToolStripMenuItem toolStripMenuItem14;
    }
}