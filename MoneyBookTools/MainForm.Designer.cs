
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
            this.operationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.importRecurringTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRecurringTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.updateAccountDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetAccountDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.backupDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabOutlook = new System.Windows.Forms.TabPage();
            this.hSplit1 = new System.Windows.Forms.SplitContainer();
            this.vSplit1 = new System.Windows.Forms.SplitContainer();
            this.groupAccounts = new System.Windows.Forms.GroupBox();
            this.listViewAccounts = new MoneyBookTools.CustomListView();
            this.groupLedger = new System.Windows.Forms.GroupBox();
            this.tableLayoutLedger = new System.Windows.Forms.TableLayoutPanel();
            this.panelLedger = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelAccount = new System.Windows.Forms.Label();
            this.comboFilter = new System.Windows.Forms.ComboBox();
            this.labelProjectedBalance = new System.Windows.Forms.Label();
            this.comboDateOrder = new System.Windows.Forms.ComboBox();
            this.labelActualBalance = new System.Windows.Forms.Label();
            this.labelAvailableBalance = new System.Windows.Forms.Label();
            this.labelStagedBalance = new System.Windows.Forms.Label();
            this.labelSum = new System.Windows.Forms.Label();
            this.dgvAccountTransactions = new System.Windows.Forms.DataGridView();
            this.transContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addTransToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTransToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setTransStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteRecTransToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.tabOutlook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hSplit1)).BeginInit();
            this.hSplit1.Panel1.SuspendLayout();
            this.hSplit1.Panel2.SuspendLayout();
            this.hSplit1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vSplit1)).BeginInit();
            this.vSplit1.Panel1.SuspendLayout();
            this.vSplit1.Panel2.SuspendLayout();
            this.vSplit1.SuspendLayout();
            this.groupAccounts.SuspendLayout();
            this.groupLedger.SuspendLayout();
            this.tableLayoutLedger.SuspendLayout();
            this.panelLedger.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountTransactions)).BeginInit();
            this.transContextMenu.SuspendLayout();
            this.groupUpcoming.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecurringTransactions)).BeginInit();
            this.recTransContextMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
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
            // operationsToolStripMenuItem
            // 
            this.operationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importTransactionsToolStripMenuItem,
            this.deleteAllTransactionsToolStripMenuItem,
            this.toolStripSeparator1,
            this.importRecurringTransactionsToolStripMenuItem,
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
            // tabOutlook
            // 
            this.tabOutlook.Controls.Add(this.hSplit1);
            this.tabOutlook.Location = new System.Drawing.Point(4, 24);
            this.tabOutlook.Name = "tabOutlook";
            this.tabOutlook.Size = new System.Drawing.Size(1148, 475);
            this.tabOutlook.TabIndex = 3;
            this.tabOutlook.Text = "Outlook";
            this.tabOutlook.UseVisualStyleBackColor = true;
            // 
            // hSplit1
            // 
            this.hSplit1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.hSplit1.Location = new System.Drawing.Point(3, 3);
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
            this.hSplit1.Size = new System.Drawing.Size(1134, 457);
            this.hSplit1.SplitterDistance = 277;
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
            this.vSplit1.Panel2.Controls.Add(this.groupLedger);
            this.vSplit1.Size = new System.Drawing.Size(1115, 238);
            this.vSplit1.SplitterDistance = 204;
            this.vSplit1.TabIndex = 0;
            // 
            // groupAccounts
            // 
            this.groupAccounts.Controls.Add(this.listViewAccounts);
            this.groupAccounts.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupAccounts.Location = new System.Drawing.Point(3, 3);
            this.groupAccounts.Name = "groupAccounts";
            this.groupAccounts.Size = new System.Drawing.Size(145, 202);
            this.groupAccounts.TabIndex = 2;
            this.groupAccounts.TabStop = false;
            this.groupAccounts.Text = "Accounts";
            // 
            // listViewAccounts
            // 
            this.listViewAccounts.Location = new System.Drawing.Point(6, 22);
            this.listViewAccounts.Name = "listViewAccounts";
            this.listViewAccounts.SelectionBackColor = System.Drawing.Color.Blue;
            this.listViewAccounts.Size = new System.Drawing.Size(90, 126);
            this.listViewAccounts.TabIndex = 1;
            this.listViewAccounts.UseCompatibleStateImageBehavior = false;
            this.listViewAccounts.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // groupLedger
            // 
            this.groupLedger.Controls.Add(this.tableLayoutLedger);
            this.groupLedger.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupLedger.Location = new System.Drawing.Point(3, 3);
            this.groupLedger.Name = "groupLedger";
            this.groupLedger.Size = new System.Drawing.Size(892, 218);
            this.groupLedger.TabIndex = 5;
            this.groupLedger.TabStop = false;
            this.groupLedger.Text = "Ledger";
            // 
            // tableLayoutLedger
            // 
            this.tableLayoutLedger.ColumnCount = 1;
            this.tableLayoutLedger.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutLedger.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutLedger.Controls.Add(this.panelLedger, 0, 0);
            this.tableLayoutLedger.Controls.Add(this.dgvAccountTransactions, 0, 1);
            this.tableLayoutLedger.Location = new System.Drawing.Point(6, 22);
            this.tableLayoutLedger.Name = "tableLayoutLedger";
            this.tableLayoutLedger.RowCount = 2;
            this.tableLayoutLedger.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutLedger.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutLedger.Size = new System.Drawing.Size(873, 180);
            this.tableLayoutLedger.TabIndex = 9;
            // 
            // panelLedger
            // 
            this.panelLedger.Controls.Add(this.tableLayoutPanel1);
            this.panelLedger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLedger.Location = new System.Drawing.Point(3, 3);
            this.panelLedger.Name = "panelLedger";
            this.panelLedger.Size = new System.Drawing.Size(867, 63);
            this.panelLedger.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.labelAccount, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboFilter, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelProjectedBalance, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboDateOrder, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelActualBalance, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelAvailableBalance, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelStagedBalance, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelSum, 5, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(832, 62);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // labelAccount
            // 
            this.labelAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAccount.BackColor = System.Drawing.Color.DimGray;
            this.labelAccount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAccount.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.labelAccount.Location = new System.Drawing.Point(3, 3);
            this.labelAccount.Margin = new System.Windows.Forms.Padding(3);
            this.labelAccount.Name = "labelAccount";
            this.labelAccount.Size = new System.Drawing.Size(132, 25);
            this.labelAccount.TabIndex = 10;
            this.labelAccount.Text = "Account";
            this.labelAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboFilter
            // 
            this.comboFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFilter.FormattingEnabled = true;
            this.comboFilter.Location = new System.Drawing.Point(141, 34);
            this.comboFilter.Name = "comboFilter";
            this.comboFilter.Size = new System.Drawing.Size(132, 25);
            this.comboFilter.TabIndex = 5;
            this.comboFilter.SelectedIndexChanged += new System.EventHandler(this.AccountCombo_SelectedIndexChanged);
            // 
            // labelProjectedBalance
            // 
            this.labelProjectedBalance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelProjectedBalance.BackColor = System.Drawing.Color.DarkGray;
            this.labelProjectedBalance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelProjectedBalance.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelProjectedBalance.Location = new System.Drawing.Point(555, 3);
            this.labelProjectedBalance.Margin = new System.Windows.Forms.Padding(3);
            this.labelProjectedBalance.Name = "labelProjectedBalance";
            this.labelProjectedBalance.Size = new System.Drawing.Size(132, 25);
            this.labelProjectedBalance.TabIndex = 9;
            this.labelProjectedBalance.Text = "Projected: 0.00";
            this.labelProjectedBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboDateOrder
            // 
            this.comboDateOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboDateOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDateOrder.FormattingEnabled = true;
            this.comboDateOrder.Location = new System.Drawing.Point(3, 34);
            this.comboDateOrder.Name = "comboDateOrder";
            this.comboDateOrder.Size = new System.Drawing.Size(132, 25);
            this.comboDateOrder.TabIndex = 6;
            this.comboDateOrder.SelectedIndexChanged += new System.EventHandler(this.AccountCombo_SelectedIndexChanged);
            // 
            // labelActualBalance
            // 
            this.labelActualBalance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelActualBalance.BackColor = System.Drawing.Color.DarkGray;
            this.labelActualBalance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelActualBalance.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelActualBalance.Location = new System.Drawing.Point(141, 3);
            this.labelActualBalance.Margin = new System.Windows.Forms.Padding(3);
            this.labelActualBalance.Name = "labelActualBalance";
            this.labelActualBalance.Size = new System.Drawing.Size(132, 25);
            this.labelActualBalance.TabIndex = 8;
            this.labelActualBalance.Text = "Actual: 0.00";
            this.labelActualBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelAvailableBalance
            // 
            this.labelAvailableBalance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAvailableBalance.BackColor = System.Drawing.Color.DarkGray;
            this.labelAvailableBalance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAvailableBalance.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelAvailableBalance.Location = new System.Drawing.Point(279, 3);
            this.labelAvailableBalance.Margin = new System.Windows.Forms.Padding(3);
            this.labelAvailableBalance.Name = "labelAvailableBalance";
            this.labelAvailableBalance.Size = new System.Drawing.Size(132, 25);
            this.labelAvailableBalance.TabIndex = 1;
            this.labelAvailableBalance.Text = "Available: 0.00";
            this.labelAvailableBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelStagedBalance
            // 
            this.labelStagedBalance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStagedBalance.BackColor = System.Drawing.Color.DarkGray;
            this.labelStagedBalance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelStagedBalance.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelStagedBalance.Location = new System.Drawing.Point(417, 3);
            this.labelStagedBalance.Margin = new System.Windows.Forms.Padding(3);
            this.labelStagedBalance.Name = "labelStagedBalance";
            this.labelStagedBalance.Size = new System.Drawing.Size(132, 25);
            this.labelStagedBalance.TabIndex = 7;
            this.labelStagedBalance.Text = "Staged: 0.00";
            this.labelStagedBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelSum
            // 
            this.labelSum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSum.BackColor = System.Drawing.Color.Transparent;
            this.labelSum.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelSum.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelSum.Location = new System.Drawing.Point(693, 3);
            this.labelSum.Margin = new System.Windows.Forms.Padding(3);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(136, 25);
            this.labelSum.TabIndex = 11;
            this.labelSum.Text = "Sum: 0.00";
            this.labelSum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvAccountTransactions
            // 
            this.dgvAccountTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccountTransactions.ContextMenuStrip = this.transContextMenu;
            this.dgvAccountTransactions.Location = new System.Drawing.Point(3, 72);
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
            this.toolStripSeparator2,
            this.deleteTransToolStripMenuItem});
            this.transContextMenu.Name = "transContextMenu";
            this.transContextMenu.Size = new System.Drawing.Size(129, 98);
            this.transContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.transContextMenu_Opening);
            // 
            // addTransToolStripMenuItem
            // 
            this.addTransToolStripMenuItem.Name = "addTransToolStripMenuItem";
            this.addTransToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.addTransToolStripMenuItem.Text = "Add...";
            this.addTransToolStripMenuItem.ToolTipText = "Add transaction";
            this.addTransToolStripMenuItem.Click += new System.EventHandler(this.addTransToolStripMenuItem_Click);
            // 
            // editTransToolStripMenuItem
            // 
            this.editTransToolStripMenuItem.Name = "editTransToolStripMenuItem";
            this.editTransToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.editTransToolStripMenuItem.Text = "Edit...";
            this.editTransToolStripMenuItem.ToolTipText = "Modify transaction";
            this.editTransToolStripMenuItem.Click += new System.EventHandler(this.editTransToolStripMenuItem_Click);
            // 
            // setTransStateToolStripMenuItem
            // 
            this.setTransStateToolStripMenuItem.Name = "setTransStateToolStripMenuItem";
            this.setTransStateToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.setTransStateToolStripMenuItem.Text = "Set State...";
            this.setTransStateToolStripMenuItem.ToolTipText = "Set state of transaction(s)";
            this.setTransStateToolStripMenuItem.Click += new System.EventHandler(this.setTransStateToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(125, 6);
            // 
            // deleteTransToolStripMenuItem
            // 
            this.deleteTransToolStripMenuItem.Name = "deleteTransToolStripMenuItem";
            this.deleteTransToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
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
            this.toolStripSeparator6,
            this.deleteRecTransToolStripMenuItem});
            this.recTransContextMenu.Name = "recTransContextMenu";
            this.recTransContextMenu.Size = new System.Drawing.Size(181, 164);
            this.recTransContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.recTransContextMenu_Opening);
            // 
            // editRecTranToolStripMenuItem
            // 
            this.editRecTranToolStripMenuItem.Name = "editRecTranToolStripMenuItem";
            this.editRecTranToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editRecTranToolStripMenuItem.Text = "Add...";
            this.editRecTranToolStripMenuItem.ToolTipText = "Add recurring transaction";
            this.editRecTranToolStripMenuItem.Click += new System.EventHandler(this.editRecTranToolStripMenuItem_Click);
            // 
            // editRecTransToolStripMenuItem
            // 
            this.editRecTransToolStripMenuItem.Name = "editRecTransToolStripMenuItem";
            this.editRecTransToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editRecTransToolStripMenuItem.Text = "Edit...";
            this.editRecTransToolStripMenuItem.ToolTipText = "Edit recurring transaction";
            this.editRecTransToolStripMenuItem.Click += new System.EventHandler(this.editRecTransToolStripMenuItem_Click);
            // 
            // skipRecTransToolStripMenuItem
            // 
            this.skipRecTransToolStripMenuItem.Name = "skipRecTransToolStripMenuItem";
            this.skipRecTransToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.skipRecTransToolStripMenuItem.Text = "Skip";
            this.skipRecTransToolStripMenuItem.ToolTipText = "Set next due date of recurring transaction(s)";
            this.skipRecTransToolStripMenuItem.Click += new System.EventHandler(this.skipRecTransToolStripMenuItem_Click);
            // 
            // stageRecTransToolStripMenuItem
            // 
            this.stageRecTransToolStripMenuItem.Name = "stageRecTransToolStripMenuItem";
            this.stageRecTransToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stageRecTransToolStripMenuItem.Text = "Stage";
            this.stageRecTransToolStripMenuItem.ToolTipText = "Copy to ledger and set next due date";
            this.stageRecTransToolStripMenuItem.Click += new System.EventHandler(this.stageRecTransToolStripMenuItem_Click);
            // 
            // copyRecTransToolStripMenuItem
            // 
            this.copyRecTransToolStripMenuItem.Name = "copyRecTransToolStripMenuItem";
            this.copyRecTransToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyRecTransToolStripMenuItem.Text = "Copy";
            this.copyRecTransToolStripMenuItem.ToolTipText = "Copy to ledger";
            this.copyRecTransToolStripMenuItem.Click += new System.EventHandler(this.copyRecTransToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(177, 6);
            // 
            // deleteRecTransToolStripMenuItem
            // 
            this.deleteRecTransToolStripMenuItem.Name = "deleteRecTransToolStripMenuItem";
            this.deleteRecTransToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteRecTransToolStripMenuItem.Text = "Delete";
            this.deleteRecTransToolStripMenuItem.Click += new System.EventHandler(this.deleteRecTransToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabOutlook);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1156, 503);
            this.tabControl1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 527);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MoneyBookTools";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabOutlook.ResumeLayout(false);
            this.hSplit1.Panel1.ResumeLayout(false);
            this.hSplit1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hSplit1)).EndInit();
            this.hSplit1.ResumeLayout(false);
            this.vSplit1.Panel1.ResumeLayout(false);
            this.vSplit1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vSplit1)).EndInit();
            this.vSplit1.ResumeLayout(false);
            this.groupAccounts.ResumeLayout(false);
            this.groupLedger.ResumeLayout(false);
            this.tableLayoutLedger.ResumeLayout(false);
            this.panelLedger.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountTransactions)).EndInit();
            this.transContextMenu.ResumeLayout(false);
            this.groupUpcoming.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecurringTransactions)).EndInit();
            this.recTransContextMenu.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private TabPage tabOutlook;
        private DataGridView dgvAccountTransactions;
        private ComboBox comboDateOrder;
        private ComboBox comboFilter;
        private Label labelAvailableBalance;
        private DataGridView dgvRecurringTransactions;
        private TabControl tabControl1;
        private GroupBox groupLedger;
        private GroupBox groupUpcoming;
        private ContextMenuStrip recTransContextMenu;
        private ToolStripMenuItem skipRecTransToolStripMenuItem;
        private ContextMenuStrip transContextMenu;
        private Label labelStagedBalance;
        private ToolStripMenuItem deleteTransToolStripMenuItem;
        private Label labelActualBalance;
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
        private TableLayoutPanel tableLayoutLedger;
        private Panel panelLedger;
        private GroupBox groupAccounts;
        private Label labelProjectedBalance;
        private Label labelAccount;
        private TableLayoutPanel tableLayoutPanel1;
        private Label labelSum;
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
    }
}