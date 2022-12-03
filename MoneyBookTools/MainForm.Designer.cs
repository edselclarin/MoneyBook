
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twoWeeksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thisMonthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thisYearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateDescendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateAscendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.importRecurringTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportRecurringTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRecurringTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.updateAccountDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetAccountDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.backupDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hSplit1 = new System.Windows.Forms.SplitContainer();
            this.vSplit1 = new System.Windows.Forms.SplitContainer();
            this.groupAccounts = new System.Windows.Forms.GroupBox();
            this.listViewAccounts = new MoneyBookTools.Forms.CustomListView();
            this.tableLayoutLedger = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.accountToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.currentToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.availableToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.stagedToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.finalToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.sumToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupLedger = new System.Windows.Forms.GroupBox();
            this.dgvAccountTransactions = new System.Windows.Forms.DataGridView();
            this.transContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addTransToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTransToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setTransStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.reconcileNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.makeRecTransToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteTransToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupUpcoming = new System.Windows.Forms.GroupBox();
            this.dgvRecurringTransactions = new System.Windows.Forms.DataGridView();
            this.recTransContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editRecTranToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editRecTransToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skipRecTransToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stageRecTransToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyRecTransToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.openWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteRecTransToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hSplit1)).BeginInit();
            this.hSplit1.Panel1.SuspendLayout();
            this.hSplit1.Panel2.SuspendLayout();
            this.hSplit1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vSplit1)).BeginInit();
            this.vSplit1.Panel1.SuspendLayout();
            this.vSplit1.Panel2.SuspendLayout();
            this.vSplit1.SuspendLayout();
            this.groupAccounts.SuspendLayout();
            this.tableLayoutLedger.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupLedger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountTransactions)).BeginInit();
            this.transContextMenu.SuspendLayout();
            this.groupUpcoming.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecurringTransactions)).BeginInit();
            this.recTransContextMenu.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.transactionsToolStripMenuItem,
            this.operationsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1156, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.openToolStripMenuItem.Text = "&Open...";
            this.openToolStripMenuItem.ToolTipText = "Open file";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(109, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.ToolTipText = "Close application";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.refreshToolStripMenuItem.Text = "&Refresh";
            this.refreshToolStripMenuItem.ToolTipText = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // transactionsToolStripMenuItem
            // 
            this.transactionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterToolStripMenuItem,
            this.sortToolStripMenuItem});
            this.transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            this.transactionsToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.transactionsToolStripMenuItem.Text = "Transactions";
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.twoWeeksToolStripMenuItem,
            this.thisMonthToolStripMenuItem,
            this.thisYearToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.filterToolStripMenuItem.Text = "Filter...";
            this.filterToolStripMenuItem.ToolTipText = "Show transactions...";
            // 
            // twoWeeksToolStripMenuItem
            // 
            this.twoWeeksToolStripMenuItem.Name = "twoWeeksToolStripMenuItem";
            this.twoWeeksToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.twoWeeksToolStripMenuItem.Text = "Two Weeks";
            this.twoWeeksToolStripMenuItem.ToolTipText = "In past two weeks";
            this.twoWeeksToolStripMenuItem.Click += new System.EventHandler(this.twoWeeksToolStripMenuItem_Click);
            // 
            // thisMonthToolStripMenuItem
            // 
            this.thisMonthToolStripMenuItem.Name = "thisMonthToolStripMenuItem";
            this.thisMonthToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.thisMonthToolStripMenuItem.Text = "This Month";
            this.thisMonthToolStripMenuItem.ToolTipText = "Of the current month";
            this.thisMonthToolStripMenuItem.Click += new System.EventHandler(this.thisMonthToolStripMenuItem_Click);
            // 
            // thisYearToolStripMenuItem
            // 
            this.thisYearToolStripMenuItem.Name = "thisYearToolStripMenuItem";
            this.thisYearToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.thisYearToolStripMenuItem.Text = "This Year";
            this.thisYearToolStripMenuItem.ToolTipText = "Of the current year";
            this.thisYearToolStripMenuItem.Click += new System.EventHandler(this.thisYearToolStripMenuItem_Click);
            // 
            // sortToolStripMenuItem
            // 
            this.sortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateDescendingToolStripMenuItem,
            this.dateAscendingToolStripMenuItem});
            this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            this.sortToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.sortToolStripMenuItem.Text = "Sort...";
            // 
            // dateDescendingToolStripMenuItem
            // 
            this.dateDescendingToolStripMenuItem.Name = "dateDescendingToolStripMenuItem";
            this.dateDescendingToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.dateDescendingToolStripMenuItem.Text = "Date Descending";
            this.dateDescendingToolStripMenuItem.ToolTipText = "Sort by date in descending order.";
            this.dateDescendingToolStripMenuItem.Click += new System.EventHandler(this.dateDescendingToolStripMenuItem_Click);
            // 
            // dateAscendingToolStripMenuItem
            // 
            this.dateAscendingToolStripMenuItem.Name = "dateAscendingToolStripMenuItem";
            this.dateAscendingToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.dateAscendingToolStripMenuItem.Text = "Date Ascending";
            this.dateAscendingToolStripMenuItem.ToolTipText = "Sort by date in ascending order.";
            this.dateAscendingToolStripMenuItem.Click += new System.EventHandler(this.dateAscendingToolStripMenuItem_Click);
            // 
            // operationsToolStripMenuItem
            // 
            this.operationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importTransactionsToolStripMenuItem,
            this.deleteAllTransactionsToolStripMenuItem,
            this.toolStripSeparator1,
            this.importRecurringTransactionsToolStripMenuItem,
            this.exportRecurringTransactionsToolStripMenuItem,
            this.deleteRecurringTransactionsToolStripMenuItem,
            this.toolStripSeparator3,
            this.updateAccountDataToolStripMenuItem,
            this.resetAccountDataToolStripMenuItem,
            this.toolStripSeparator4,
            this.backupDatabaseToolStripMenuItem,
            this.restoreDatabaseToolStripMenuItem});
            this.operationsToolStripMenuItem.Name = "operationsToolStripMenuItem";
            this.operationsToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.operationsToolStripMenuItem.Text = "&Operations";
            // 
            // importTransactionsToolStripMenuItem
            // 
            this.importTransactionsToolStripMenuItem.Name = "importTransactionsToolStripMenuItem";
            this.importTransactionsToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.importTransactionsToolStripMenuItem.Text = "Import Transactions...";
            this.importTransactionsToolStripMenuItem.ToolTipText = "Import transactions from file";
            this.importTransactionsToolStripMenuItem.Click += new System.EventHandler(this.importTransactionsToolStripMenuItem_Click);
            // 
            // deleteAllTransactionsToolStripMenuItem
            // 
            this.deleteAllTransactionsToolStripMenuItem.Name = "deleteAllTransactionsToolStripMenuItem";
            this.deleteAllTransactionsToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.deleteAllTransactionsToolStripMenuItem.Text = "Delete All Transactions";
            this.deleteAllTransactionsToolStripMenuItem.ToolTipText = "Delete transactions across all accounts";
            this.deleteAllTransactionsToolStripMenuItem.Click += new System.EventHandler(this.deleteAllTransactionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(238, 6);
            // 
            // importRecurringTransactionsToolStripMenuItem
            // 
            this.importRecurringTransactionsToolStripMenuItem.Name = "importRecurringTransactionsToolStripMenuItem";
            this.importRecurringTransactionsToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.importRecurringTransactionsToolStripMenuItem.Text = "Import Recurring Transactions...";
            this.importRecurringTransactionsToolStripMenuItem.ToolTipText = "Import recurring transactions from file";
            this.importRecurringTransactionsToolStripMenuItem.Click += new System.EventHandler(this.importRecurringTransactionsToolStripMenuItem_Click);
            // 
            // exportRecurringTransactionsToolStripMenuItem
            // 
            this.exportRecurringTransactionsToolStripMenuItem.Name = "exportRecurringTransactionsToolStripMenuItem";
            this.exportRecurringTransactionsToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.exportRecurringTransactionsToolStripMenuItem.Text = "Export Recurring Transactions...";
            this.exportRecurringTransactionsToolStripMenuItem.Click += new System.EventHandler(this.exportRecurringTransactionsToolStripMenuItem_Click);
            // 
            // deleteRecurringTransactionsToolStripMenuItem
            // 
            this.deleteRecurringTransactionsToolStripMenuItem.Name = "deleteRecurringTransactionsToolStripMenuItem";
            this.deleteRecurringTransactionsToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.deleteRecurringTransactionsToolStripMenuItem.Text = "Delete Recurring Transactions";
            this.deleteRecurringTransactionsToolStripMenuItem.ToolTipText = "Delete all recurring transactions";
            this.deleteRecurringTransactionsToolStripMenuItem.Click += new System.EventHandler(this.deleteRecurringTransactionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(238, 6);
            // 
            // updateAccountDataToolStripMenuItem
            // 
            this.updateAccountDataToolStripMenuItem.Name = "updateAccountDataToolStripMenuItem";
            this.updateAccountDataToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.updateAccountDataToolStripMenuItem.Text = "Update Account Data";
            this.updateAccountDataToolStripMenuItem.ToolTipText = "Update account data from settings file";
            this.updateAccountDataToolStripMenuItem.Click += new System.EventHandler(this.updateAccountDataToolStripMenuItem_Click);
            // 
            // resetAccountDataToolStripMenuItem
            // 
            this.resetAccountDataToolStripMenuItem.Name = "resetAccountDataToolStripMenuItem";
            this.resetAccountDataToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.resetAccountDataToolStripMenuItem.Text = "Reset Account Data";
            this.resetAccountDataToolStripMenuItem.ToolTipText = "Reset account data of all accounts";
            this.resetAccountDataToolStripMenuItem.Click += new System.EventHandler(this.resetAccountDataToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(238, 6);
            // 
            // backupDatabaseToolStripMenuItem
            // 
            this.backupDatabaseToolStripMenuItem.Name = "backupDatabaseToolStripMenuItem";
            this.backupDatabaseToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.backupDatabaseToolStripMenuItem.Text = "Backup Database...";
            this.backupDatabaseToolStripMenuItem.ToolTipText = "Backup all table data to file";
            this.backupDatabaseToolStripMenuItem.Click += new System.EventHandler(this.backupDatabaseToolStripMenuItem_Click);
            // 
            // restoreDatabaseToolStripMenuItem
            // 
            this.restoreDatabaseToolStripMenuItem.Name = "restoreDatabaseToolStripMenuItem";
            this.restoreDatabaseToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.restoreDatabaseToolStripMenuItem.Text = "Restore Database...";
            this.restoreDatabaseToolStripMenuItem.ToolTipText = "Restore table data from file";
            this.restoreDatabaseToolStripMenuItem.Click += new System.EventHandler(this.restoreDatabaseToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // hSplit1
            // 
            this.hSplit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hSplit1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.hSplit1.Location = new System.Drawing.Point(0, 0);
            this.hSplit1.Name = "hSplit1";
            this.hSplit1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // hSplit1.Panel1
            // 
            this.hSplit1.Panel1.Controls.Add(this.vSplit1);
            // 
            // hSplit1.Panel2
            // 
            this.hSplit1.Panel2.Controls.Add(this.groupUpcoming);
            this.hSplit1.Size = new System.Drawing.Size(1156, 503);
            this.hSplit1.SplitterDistance = 295;
            this.hSplit1.TabIndex = 3;
            // 
            // vSplit1
            // 
            this.vSplit1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.vSplit1.Location = new System.Drawing.Point(5, 3);
            this.vSplit1.Name = "vSplit1";
            // 
            // vSplit1.Panel1
            // 
            this.vSplit1.Panel1.Controls.Add(this.groupAccounts);
            // 
            // vSplit1.Panel2
            // 
            this.vSplit1.Panel2.Controls.Add(this.tableLayoutLedger);
            this.vSplit1.Size = new System.Drawing.Size(1139, 276);
            this.vSplit1.SplitterDistance = 226;
            this.vSplit1.TabIndex = 0;
            // 
            // groupAccounts
            // 
            this.groupAccounts.Controls.Add(this.listViewAccounts);
            this.groupAccounts.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupAccounts.Location = new System.Drawing.Point(3, 3);
            this.groupAccounts.Name = "groupAccounts";
            this.groupAccounts.Size = new System.Drawing.Size(129, 167);
            this.groupAccounts.TabIndex = 2;
            this.groupAccounts.TabStop = false;
            this.groupAccounts.Text = "Accounts";
            // 
            // listViewAccounts
            // 
            this.listViewAccounts.Location = new System.Drawing.Point(6, 22);
            this.listViewAccounts.Name = "listViewAccounts";
            this.listViewAccounts.SelectionBackColor = System.Drawing.Color.Blue;
            this.listViewAccounts.SelectionForeColor = System.Drawing.Color.Black;
            this.listViewAccounts.Size = new System.Drawing.Size(90, 126);
            this.listViewAccounts.TabIndex = 1;
            this.listViewAccounts.UseCompatibleStateImageBehavior = false;
            this.listViewAccounts.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // tableLayoutLedger
            // 
            this.tableLayoutLedger.ColumnCount = 1;
            this.tableLayoutLedger.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutLedger.Controls.Add(this.statusStrip1, 0, 1);
            this.tableLayoutLedger.Controls.Add(this.groupLedger, 0, 0);
            this.tableLayoutLedger.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutLedger.Name = "tableLayoutLedger";
            this.tableLayoutLedger.RowCount = 2;
            this.tableLayoutLedger.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutLedger.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutLedger.Size = new System.Drawing.Size(882, 190);
            this.tableLayoutLedger.TabIndex = 7;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountToolStripStatusLabel,
            this.currentToolStripStatusLabel,
            this.availableToolStripStatusLabel,
            this.stagedToolStripStatusLabel,
            this.finalToolStripStatusLabel,
            this.sumToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(2, 161);
            this.statusStrip1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(878, 27);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // accountToolStripStatusLabel
            // 
            this.accountToolStripStatusLabel.AutoSize = false;
            this.accountToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.accountToolStripStatusLabel.Name = "accountToolStripStatusLabel";
            this.accountToolStripStatusLabel.Size = new System.Drawing.Size(150, 22);
            this.accountToolStripStatusLabel.Text = "Account";
            this.accountToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.accountToolStripStatusLabel.ToolTipText = "Account name";
            // 
            // currentToolStripStatusLabel
            // 
            this.currentToolStripStatusLabel.AutoSize = false;
            this.currentToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.currentToolStripStatusLabel.Name = "currentToolStripStatusLabel";
            this.currentToolStripStatusLabel.Size = new System.Drawing.Size(150, 22);
            this.currentToolStripStatusLabel.Text = "Current: 0.00";
            this.currentToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.currentToolStripStatusLabel.ToolTipText = "Current balance";
            // 
            // availableToolStripStatusLabel
            // 
            this.availableToolStripStatusLabel.AutoSize = false;
            this.availableToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.availableToolStripStatusLabel.Name = "availableToolStripStatusLabel";
            this.availableToolStripStatusLabel.Size = new System.Drawing.Size(150, 22);
            this.availableToolStripStatusLabel.Text = "Available: 0.00";
            this.availableToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.availableToolStripStatusLabel.ToolTipText = "Current balance less reserve amount";
            // 
            // stagedToolStripStatusLabel
            // 
            this.stagedToolStripStatusLabel.AutoSize = false;
            this.stagedToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.stagedToolStripStatusLabel.Name = "stagedToolStripStatusLabel";
            this.stagedToolStripStatusLabel.Size = new System.Drawing.Size(150, 22);
            this.stagedToolStripStatusLabel.Text = "Staged: 0.00";
            this.stagedToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stagedToolStripStatusLabel.ToolTipText = "Balance of staged transactions";
            // 
            // finalToolStripStatusLabel
            // 
            this.finalToolStripStatusLabel.AutoSize = false;
            this.finalToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.finalToolStripStatusLabel.Name = "finalToolStripStatusLabel";
            this.finalToolStripStatusLabel.Size = new System.Drawing.Size(150, 22);
            this.finalToolStripStatusLabel.Text = "Final: 0.00";
            this.finalToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.finalToolStripStatusLabel.ToolTipText = "Available balance less staged transactions";
            // 
            // sumToolStripStatusLabel
            // 
            this.sumToolStripStatusLabel.AutoSize = false;
            this.sumToolStripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.sumToolStripStatusLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.sumToolStripStatusLabel.Name = "sumToolStripStatusLabel";
            this.sumToolStripStatusLabel.Size = new System.Drawing.Size(113, 22);
            this.sumToolStripStatusLabel.Spring = true;
            this.sumToolStripStatusLabel.Text = "Sum: 0.00";
            this.sumToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.sumToolStripStatusLabel.ToolTipText = "Sum of selected transactions";
            // 
            // groupLedger
            // 
            this.groupLedger.Controls.Add(this.dgvAccountTransactions);
            this.groupLedger.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupLedger.Location = new System.Drawing.Point(3, 3);
            this.groupLedger.Name = "groupLedger";
            this.groupLedger.Size = new System.Drawing.Size(137, 66);
            this.groupLedger.TabIndex = 5;
            this.groupLedger.TabStop = false;
            this.groupLedger.Text = "Ledger";
            // 
            // dgvAccountTransactions
            // 
            this.dgvAccountTransactions.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvAccountTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccountTransactions.ContextMenuStrip = this.transContextMenu;
            this.dgvAccountTransactions.Location = new System.Drawing.Point(6, 24);
            this.dgvAccountTransactions.Name = "dgvAccountTransactions";
            this.dgvAccountTransactions.RowTemplate.Height = 25;
            this.dgvAccountTransactions.Size = new System.Drawing.Size(101, 29);
            this.dgvAccountTransactions.TabIndex = 3;
            this.dgvAccountTransactions.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dgvAccountTransactions.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAccountTransactions_CellMouseDoubleClick);
            this.dgvAccountTransactions.SelectionChanged += new System.EventHandler(this.dgvAccountTransactions_SelectionChanged);
            // 
            // transContextMenu
            // 
            this.transContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTransToolStripMenuItem,
            this.editTransToolStripMenuItem,
            this.setTransStateToolStripMenuItem,
            this.toolStripSeparator7,
            this.reconcileNewToolStripMenuItem,
            this.toolStripSeparator9,
            this.makeRecTransToolStripMenuItem,
            this.toolStripSeparator2,
            this.deleteTransToolStripMenuItem});
            this.transContextMenu.Name = "transContextMenu";
            this.transContextMenu.Size = new System.Drawing.Size(181, 176);
            this.transContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.transContextMenu_Opening);
            // 
            // addTransToolStripMenuItem
            // 
            this.addTransToolStripMenuItem.Name = "addTransToolStripMenuItem";
            this.addTransToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addTransToolStripMenuItem.Text = "Add...";
            this.addTransToolStripMenuItem.ToolTipText = "Add transaction";
            this.addTransToolStripMenuItem.Click += new System.EventHandler(this.addTransToolStripMenuItem_Click);
            // 
            // editTransToolStripMenuItem
            // 
            this.editTransToolStripMenuItem.Name = "editTransToolStripMenuItem";
            this.editTransToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editTransToolStripMenuItem.Text = "Edit...";
            this.editTransToolStripMenuItem.ToolTipText = "Modify transaction";
            this.editTransToolStripMenuItem.Click += new System.EventHandler(this.editTransToolStripMenuItem_Click);
            // 
            // setTransStateToolStripMenuItem
            // 
            this.setTransStateToolStripMenuItem.Name = "setTransStateToolStripMenuItem";
            this.setTransStateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.setTransStateToolStripMenuItem.Text = "Set State...";
            this.setTransStateToolStripMenuItem.ToolTipText = "Set state of transaction(s)";
            this.setTransStateToolStripMenuItem.Click += new System.EventHandler(this.setTransStateToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(177, 6);
            // 
            // reconcileNewToolStripMenuItem
            // 
            this.reconcileNewToolStripMenuItem.Name = "reconcileNewToolStripMenuItem";
            this.reconcileNewToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reconcileNewToolStripMenuItem.Text = "Reconcile New";
            this.reconcileNewToolStripMenuItem.ToolTipText = "Set state of new transactions to Reconciled";
            this.reconcileNewToolStripMenuItem.Click += new System.EventHandler(this.reconcileNewToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(177, 6);
            // 
            // makeRecTransToolStripMenuItem
            // 
            this.makeRecTransToolStripMenuItem.Name = "makeRecTransToolStripMenuItem";
            this.makeRecTransToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.makeRecTransToolStripMenuItem.Text = "Make Recurring...";
            this.makeRecTransToolStripMenuItem.ToolTipText = "Make this a recurring transaction.";
            this.makeRecTransToolStripMenuItem.Click += new System.EventHandler(this.makeRecTransToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // deleteTransToolStripMenuItem
            // 
            this.deleteTransToolStripMenuItem.Name = "deleteTransToolStripMenuItem";
            this.deleteTransToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteTransToolStripMenuItem.Text = "Delete";
            this.deleteTransToolStripMenuItem.ToolTipText = "Delete transaction(s)";
            this.deleteTransToolStripMenuItem.Click += new System.EventHandler(this.deleteTransToolStripMenuItem_Click);
            // 
            // groupUpcoming
            // 
            this.groupUpcoming.Controls.Add(this.dgvRecurringTransactions);
            this.groupUpcoming.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupUpcoming.Location = new System.Drawing.Point(3, 3);
            this.groupUpcoming.Name = "groupUpcoming";
            this.groupUpcoming.Size = new System.Drawing.Size(151, 74);
            this.groupUpcoming.TabIndex = 4;
            this.groupUpcoming.TabStop = false;
            this.groupUpcoming.Text = "Upcoming Transactions";
            // 
            // dgvRecurringTransactions
            // 
            this.dgvRecurringTransactions.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvRecurringTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecurringTransactions.ContextMenuStrip = this.recTransContextMenu;
            this.dgvRecurringTransactions.Location = new System.Drawing.Point(6, 22);
            this.dgvRecurringTransactions.Name = "dgvRecurringTransactions";
            this.dgvRecurringTransactions.RowTemplate.Height = 25;
            this.dgvRecurringTransactions.Size = new System.Drawing.Size(128, 34);
            this.dgvRecurringTransactions.TabIndex = 3;
            this.dgvRecurringTransactions.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dgvRecurringTransactions.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRecurringTransactions_CellMouseDoubleClick);
            // 
            // recTransContextMenu
            // 
            this.recTransContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editRecTranToolStripMenuItem,
            this.editRecTransToolStripMenuItem,
            this.skipRecTransToolStripMenuItem,
            this.stageRecTransToolStripMenuItem,
            this.copyRecTransToolStripMenuItem,
            this.toolStripSeparator8,
            this.openWebsiteToolStripMenuItem,
            this.toolStripSeparator6,
            this.deleteRecTransToolStripMenuItem});
            this.recTransContextMenu.Name = "recTransContextMenu";
            this.recTransContextMenu.Size = new System.Drawing.Size(149, 170);
            this.recTransContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.recTransContextMenu_Opening);
            // 
            // editRecTranToolStripMenuItem
            // 
            this.editRecTranToolStripMenuItem.Name = "editRecTranToolStripMenuItem";
            this.editRecTranToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.editRecTranToolStripMenuItem.Text = "Add...";
            this.editRecTranToolStripMenuItem.ToolTipText = "Add recurring transaction";
            this.editRecTranToolStripMenuItem.Click += new System.EventHandler(this.editRecTranToolStripMenuItem_Click);
            // 
            // editRecTransToolStripMenuItem
            // 
            this.editRecTransToolStripMenuItem.Name = "editRecTransToolStripMenuItem";
            this.editRecTransToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.editRecTransToolStripMenuItem.Text = "Edit...";
            this.editRecTransToolStripMenuItem.ToolTipText = "Edit recurring transaction";
            this.editRecTransToolStripMenuItem.Click += new System.EventHandler(this.editRecTransToolStripMenuItem_Click);
            // 
            // skipRecTransToolStripMenuItem
            // 
            this.skipRecTransToolStripMenuItem.Name = "skipRecTransToolStripMenuItem";
            this.skipRecTransToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.skipRecTransToolStripMenuItem.Text = "Skip";
            this.skipRecTransToolStripMenuItem.ToolTipText = "Set next due date of recurring transaction(s)";
            this.skipRecTransToolStripMenuItem.Click += new System.EventHandler(this.skipRecTransToolStripMenuItem_Click);
            // 
            // stageRecTransToolStripMenuItem
            // 
            this.stageRecTransToolStripMenuItem.Name = "stageRecTransToolStripMenuItem";
            this.stageRecTransToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.stageRecTransToolStripMenuItem.Text = "Stage";
            this.stageRecTransToolStripMenuItem.ToolTipText = "Copy to ledger and set next due date";
            this.stageRecTransToolStripMenuItem.Click += new System.EventHandler(this.stageRecTransToolStripMenuItem_Click);
            // 
            // copyRecTransToolStripMenuItem
            // 
            this.copyRecTransToolStripMenuItem.Name = "copyRecTransToolStripMenuItem";
            this.copyRecTransToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.copyRecTransToolStripMenuItem.Text = "Copy";
            this.copyRecTransToolStripMenuItem.ToolTipText = "Copy to ledger";
            this.copyRecTransToolStripMenuItem.Click += new System.EventHandler(this.copyRecTransToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(145, 6);
            // 
            // openWebsiteToolStripMenuItem
            // 
            this.openWebsiteToolStripMenuItem.Name = "openWebsiteToolStripMenuItem";
            this.openWebsiteToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openWebsiteToolStripMenuItem.Text = "Open Website";
            this.openWebsiteToolStripMenuItem.Click += new System.EventHandler(this.openWebsiteToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(145, 6);
            // 
            // deleteRecTransToolStripMenuItem
            // 
            this.deleteRecTransToolStripMenuItem.Name = "deleteRecTransToolStripMenuItem";
            this.deleteRecTransToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.deleteRecTransToolStripMenuItem.Text = "Delete";
            this.deleteRecTransToolStripMenuItem.Click += new System.EventHandler(this.deleteRecTransToolStripMenuItem_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.hSplit1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 24);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1156, 503);
            this.mainPanel.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 527);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MoneyBookTools";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.hSplit1.Panel1.ResumeLayout(false);
            this.hSplit1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hSplit1)).EndInit();
            this.hSplit1.ResumeLayout(false);
            this.vSplit1.Panel1.ResumeLayout(false);
            this.vSplit1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vSplit1)).EndInit();
            this.vSplit1.ResumeLayout(false);
            this.groupAccounts.ResumeLayout(false);
            this.tableLayoutLedger.ResumeLayout(false);
            this.tableLayoutLedger.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupLedger.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountTransactions)).EndInit();
            this.transContextMenu.ResumeLayout(false);
            this.groupUpcoming.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecurringTransactions)).EndInit();
            this.recTransContextMenu.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private DataGridView dgvAccountTransactions;
        private DataGridView dgvRecurringTransactions;
        private GroupBox groupLedger;
        private GroupBox groupUpcoming;
        private ContextMenuStrip recTransContextMenu;
        private ToolStripMenuItem skipRecTransToolStripMenuItem;
        private ContextMenuStrip transContextMenu;
        private ToolStripMenuItem deleteTransToolStripMenuItem;
        private ToolStripMenuItem setTransStateToolStripMenuItem;
        private ToolStripMenuItem stageRecTransToolStripMenuItem;
        private ToolStripMenuItem editTransToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem editRecTransToolStripMenuItem;
        private ToolStripMenuItem copyRecTransToolStripMenuItem;
        private CustomListView listViewAccounts;
        private ToolStripMenuItem addTransToolStripMenuItem;
        private SplitContainer hSplit1;
        private SplitContainer vSplit1;
        private GroupBox groupAccounts;
        private ToolStripMenuItem operationsToolStripMenuItem;
        private ToolStripMenuItem importTransactionsToolStripMenuItem;
        private ToolStripMenuItem deleteAllTransactionsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem importRecurringTransactionsToolStripMenuItem;
        private ToolStripMenuItem deleteRecurringTransactionsToolStripMenuItem;
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
        private ToolStripMenuItem editRecTranToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem deleteRecTransToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem makeRecTransToolStripMenuItem;
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
        private ToolStripMenuItem exportRecurringTransactionsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem openWebsiteToolStripMenuItem;
        private ToolStripMenuItem reconcileNewToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator9;
    }
}