
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
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabOperations = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkImportTransactions = new System.Windows.Forms.LinkLabel();
            this.linkRestoreDatabase = new System.Windows.Forms.LinkLabel();
            this.linkAccountData = new System.Windows.Forms.LinkLabel();
            this.linkBackupDatabase = new System.Windows.Forms.LinkLabel();
            this.linkOpenFile = new System.Windows.Forms.LinkLabel();
            this.linkDeleteAllTransactions = new System.Windows.Forms.LinkLabel();
            this.linkImportRepeatingTransactions = new System.Windows.Forms.LinkLabel();
            this.linkResetAccountData = new System.Windows.Forms.LinkLabel();
            this.linkDeleteRepeatingTransactions = new System.Windows.Forms.LinkLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupOperations = new System.Windows.Forms.GroupBox();
            this.dgvFileTransactions = new System.Windows.Forms.DataGridView();
            this.tabOutlook = new System.Windows.Forms.TabPage();
            this.hSplit1 = new System.Windows.Forms.SplitContainer();
            this.vSplit1 = new System.Windows.Forms.SplitContainer();
            this.groupAccounts = new System.Windows.Forms.GroupBox();
            this.listViewAccounts = new MoneyBookTools.CustomListView();
            this.groupLedger = new System.Windows.Forms.GroupBox();
            this.tableLayoutLedger = new System.Windows.Forms.TableLayoutPanel();
            this.dgvAccountTransactions = new System.Windows.Forms.DataGridView();
            this.transContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addTransToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTransToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setTransStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteTransToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelLedger = new System.Windows.Forms.Panel();
            this.labelProjectedBalance = new System.Windows.Forms.Label();
            this.comboFilter = new System.Windows.Forms.ComboBox();
            this.labelActualBalance = new System.Windows.Forms.Label();
            this.comboDateOrder = new System.Windows.Forms.ComboBox();
            this.labelStagedBalance = new System.Windows.Forms.Label();
            this.labelAvailableBalance = new System.Windows.Forms.Label();
            this.groupUpcoming = new System.Windows.Forms.GroupBox();
            this.dgvRecurringTransactions = new System.Windows.Forms.DataGridView();
            this.recTransContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editRecTransToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skipRecTransToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stageRecTransToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyRecTransToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.tabOperations.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupOperations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileTransactions)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountTransactions)).BeginInit();
            this.transContextMenu.SuspendLayout();
            this.panelLedger.SuspendLayout();
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
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1156, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
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
            // tabOperations
            // 
            this.tabOperations.Controls.Add(this.tableLayoutPanel2);
            this.tabOperations.Location = new System.Drawing.Point(4, 24);
            this.tabOperations.Name = "tabOperations";
            this.tabOperations.Padding = new System.Windows.Forms.Padding(3);
            this.tabOperations.Size = new System.Drawing.Size(1148, 475);
            this.tabOperations.TabIndex = 0;
            this.tabOperations.Text = "Operations";
            this.tabOperations.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1142, 469);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.linkImportTransactions);
            this.panel1.Controls.Add(this.linkRestoreDatabase);
            this.panel1.Controls.Add(this.linkAccountData);
            this.panel1.Controls.Add(this.linkBackupDatabase);
            this.panel1.Controls.Add(this.linkOpenFile);
            this.panel1.Controls.Add(this.linkDeleteAllTransactions);
            this.panel1.Controls.Add(this.linkImportRepeatingTransactions);
            this.panel1.Controls.Add(this.linkResetAccountData);
            this.panel1.Controls.Add(this.linkDeleteRepeatingTransactions);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(801, 62);
            this.panel1.TabIndex = 2;
            // 
            // linkImportTransactions
            // 
            this.linkImportTransactions.Location = new System.Drawing.Point(3, 3);
            this.linkImportTransactions.Margin = new System.Windows.Forms.Padding(3);
            this.linkImportTransactions.Name = "linkImportTransactions";
            this.linkImportTransactions.Size = new System.Drawing.Size(153, 23);
            this.linkImportTransactions.TabIndex = 1;
            this.linkImportTransactions.TabStop = true;
            this.linkImportTransactions.Text = "Import Transactions";
            this.linkImportTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkImportTransactions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkImportTransactions_LinkClicked);
            // 
            // linkRestoreDatabase
            // 
            this.linkRestoreDatabase.Location = new System.Drawing.Point(527, 32);
            this.linkRestoreDatabase.Name = "linkRestoreDatabase";
            this.linkRestoreDatabase.Size = new System.Drawing.Size(122, 23);
            this.linkRestoreDatabase.TabIndex = 9;
            this.linkRestoreDatabase.TabStop = true;
            this.linkRestoreDatabase.Text = "Restore Database";
            this.linkRestoreDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkRestoreDatabase.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRestoreDatabase_LinkClicked);
            // 
            // linkAccountData
            // 
            this.linkAccountData.Location = new System.Drawing.Point(374, 3);
            this.linkAccountData.Margin = new System.Windows.Forms.Padding(3);
            this.linkAccountData.Name = "linkAccountData";
            this.linkAccountData.Size = new System.Drawing.Size(147, 23);
            this.linkAccountData.TabIndex = 7;
            this.linkAccountData.TabStop = true;
            this.linkAccountData.Text = "Update Account Data";
            this.linkAccountData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkAccountData.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUpdateAccountData_LinkClicked);
            // 
            // linkBackupDatabase
            // 
            this.linkBackupDatabase.Location = new System.Drawing.Point(527, 3);
            this.linkBackupDatabase.Name = "linkBackupDatabase";
            this.linkBackupDatabase.Size = new System.Drawing.Size(122, 23);
            this.linkBackupDatabase.TabIndex = 8;
            this.linkBackupDatabase.TabStop = true;
            this.linkBackupDatabase.Text = "Backup Database";
            this.linkBackupDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkBackupDatabase.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBackupDatabase_LinkClicked);
            // 
            // linkOpenFile
            // 
            this.linkOpenFile.Location = new System.Drawing.Point(664, 3);
            this.linkOpenFile.Margin = new System.Windows.Forms.Padding(3);
            this.linkOpenFile.Name = "linkOpenFile";
            this.linkOpenFile.Size = new System.Drawing.Size(70, 23);
            this.linkOpenFile.TabIndex = 0;
            this.linkOpenFile.TabStop = true;
            this.linkOpenFile.Text = "Open File";
            this.linkOpenFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkOpenFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOpenFile_LinkClicked);
            // 
            // linkDeleteAllTransactions
            // 
            this.linkDeleteAllTransactions.Location = new System.Drawing.Point(3, 32);
            this.linkDeleteAllTransactions.Margin = new System.Windows.Forms.Padding(3);
            this.linkDeleteAllTransactions.Name = "linkDeleteAllTransactions";
            this.linkDeleteAllTransactions.Size = new System.Drawing.Size(153, 23);
            this.linkDeleteAllTransactions.TabIndex = 2;
            this.linkDeleteAllTransactions.TabStop = true;
            this.linkDeleteAllTransactions.Text = "Delete All Transactions";
            this.linkDeleteAllTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkDeleteAllTransactions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDeleteAllTransactions_LinkClicked);
            // 
            // linkImportRepeatingTransactions
            // 
            this.linkImportRepeatingTransactions.Location = new System.Drawing.Point(162, 3);
            this.linkImportRepeatingTransactions.Margin = new System.Windows.Forms.Padding(3);
            this.linkImportRepeatingTransactions.Name = "linkImportRepeatingTransactions";
            this.linkImportRepeatingTransactions.Size = new System.Drawing.Size(206, 23);
            this.linkImportRepeatingTransactions.TabIndex = 4;
            this.linkImportRepeatingTransactions.TabStop = true;
            this.linkImportRepeatingTransactions.Text = "Import Repeating Transactions";
            this.linkImportRepeatingTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkImportRepeatingTransactions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkImportRepeatingTransactions_LinkClicked);
            // 
            // linkResetAccountData
            // 
            this.linkResetAccountData.Location = new System.Drawing.Point(374, 31);
            this.linkResetAccountData.Margin = new System.Windows.Forms.Padding(3);
            this.linkResetAccountData.Name = "linkResetAccountData";
            this.linkResetAccountData.Size = new System.Drawing.Size(147, 24);
            this.linkResetAccountData.TabIndex = 6;
            this.linkResetAccountData.TabStop = true;
            this.linkResetAccountData.Text = "Reset Account Data";
            this.linkResetAccountData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkResetAccountData.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkResetAccountData_LinkClicked);
            // 
            // linkDeleteRepeatingTransactions
            // 
            this.linkDeleteRepeatingTransactions.Location = new System.Drawing.Point(162, 31);
            this.linkDeleteRepeatingTransactions.Margin = new System.Windows.Forms.Padding(3);
            this.linkDeleteRepeatingTransactions.Name = "linkDeleteRepeatingTransactions";
            this.linkDeleteRepeatingTransactions.Size = new System.Drawing.Size(206, 24);
            this.linkDeleteRepeatingTransactions.TabIndex = 5;
            this.linkDeleteRepeatingTransactions.TabStop = true;
            this.linkDeleteRepeatingTransactions.Text = "Delete Repeating Transactions";
            this.linkDeleteRepeatingTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkDeleteRepeatingTransactions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDeleteRepeatingTransactions_LinkClicked);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupOperations);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1136, 395);
            this.panel2.TabIndex = 3;
            // 
            // groupOperations
            // 
            this.groupOperations.Controls.Add(this.dgvFileTransactions);
            this.groupOperations.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupOperations.Location = new System.Drawing.Point(3, 3);
            this.groupOperations.Name = "groupOperations";
            this.groupOperations.Size = new System.Drawing.Size(200, 100);
            this.groupOperations.TabIndex = 2;
            this.groupOperations.TabStop = false;
            // 
            // dgvFileTransactions
            // 
            this.dgvFileTransactions.AllowUserToAddRows = false;
            this.dgvFileTransactions.AllowUserToDeleteRows = false;
            this.dgvFileTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFileTransactions.Location = new System.Drawing.Point(6, 22);
            this.dgvFileTransactions.Name = "dgvFileTransactions";
            this.dgvFileTransactions.ReadOnly = true;
            this.dgvFileTransactions.Size = new System.Drawing.Size(73, 31);
            this.dgvFileTransactions.TabIndex = 1;
            this.dgvFileTransactions.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
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
            this.groupLedger.Size = new System.Drawing.Size(892, 202);
            this.groupLedger.TabIndex = 5;
            this.groupLedger.TabStop = false;
            this.groupLedger.Text = "Ledger";
            // 
            // tableLayoutLedger
            // 
            this.tableLayoutLedger.ColumnCount = 1;
            this.tableLayoutLedger.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutLedger.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutLedger.Controls.Add(this.dgvAccountTransactions, 0, 1);
            this.tableLayoutLedger.Controls.Add(this.panelLedger, 0, 0);
            this.tableLayoutLedger.Location = new System.Drawing.Point(6, 22);
            this.tableLayoutLedger.Name = "tableLayoutLedger";
            this.tableLayoutLedger.RowCount = 2;
            this.tableLayoutLedger.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutLedger.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutLedger.Size = new System.Drawing.Size(873, 162);
            this.tableLayoutLedger.TabIndex = 9;
            // 
            // dgvAccountTransactions
            // 
            this.dgvAccountTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccountTransactions.ContextMenuStrip = this.transContextMenu;
            this.dgvAccountTransactions.Location = new System.Drawing.Point(3, 42);
            this.dgvAccountTransactions.Name = "dgvAccountTransactions";
            this.dgvAccountTransactions.RowTemplate.Height = 25;
            this.dgvAccountTransactions.Size = new System.Drawing.Size(101, 34);
            this.dgvAccountTransactions.TabIndex = 3;
            this.dgvAccountTransactions.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dgvAccountTransactions.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAccountTransactions_CellMouseDoubleClick);
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
            this.addTransToolStripMenuItem.Text = "Add";
            this.addTransToolStripMenuItem.ToolTipText = "Add transaction";
            this.addTransToolStripMenuItem.Click += new System.EventHandler(this.addTransToolStripMenuItem_Click);
            // 
            // editTransToolStripMenuItem
            // 
            this.editTransToolStripMenuItem.Name = "editTransToolStripMenuItem";
            this.editTransToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.editTransToolStripMenuItem.Text = "Edit";
            this.editTransToolStripMenuItem.ToolTipText = "Modify transaction";
            this.editTransToolStripMenuItem.Click += new System.EventHandler(this.editTransToolStripMenuItem_Click);
            // 
            // setTransStateToolStripMenuItem
            // 
            this.setTransStateToolStripMenuItem.Name = "setTransStateToolStripMenuItem";
            this.setTransStateToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.setTransStateToolStripMenuItem.Text = "Set State...";
            this.setTransStateToolStripMenuItem.ToolTipText = "Set state of selected transactions";
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
            this.deleteTransToolStripMenuItem.ToolTipText = "Delete selected transactions";
            this.deleteTransToolStripMenuItem.Click += new System.EventHandler(this.deleteTransToolStripMenuItem_Click);
            // 
            // panelLedger
            // 
            this.panelLedger.Controls.Add(this.labelProjectedBalance);
            this.panelLedger.Controls.Add(this.comboFilter);
            this.panelLedger.Controls.Add(this.labelActualBalance);
            this.panelLedger.Controls.Add(this.comboDateOrder);
            this.panelLedger.Controls.Add(this.labelStagedBalance);
            this.panelLedger.Controls.Add(this.labelAvailableBalance);
            this.panelLedger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLedger.Location = new System.Drawing.Point(3, 3);
            this.panelLedger.Name = "panelLedger";
            this.panelLedger.Size = new System.Drawing.Size(867, 33);
            this.panelLedger.TabIndex = 6;
            // 
            // labelProjectedBalance
            // 
            this.labelProjectedBalance.BackColor = System.Drawing.Color.Gainsboro;
            this.labelProjectedBalance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelProjectedBalance.Location = new System.Drawing.Point(704, 1);
            this.labelProjectedBalance.Margin = new System.Windows.Forms.Padding(3);
            this.labelProjectedBalance.Name = "labelProjectedBalance";
            this.labelProjectedBalance.Size = new System.Drawing.Size(130, 25);
            this.labelProjectedBalance.TabIndex = 9;
            this.labelProjectedBalance.Text = "Projected: 0.00";
            this.labelProjectedBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboFilter
            // 
            this.comboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFilter.FormattingEnabled = true;
            this.comboFilter.Location = new System.Drawing.Point(0, 1);
            this.comboFilter.Name = "comboFilter";
            this.comboFilter.Size = new System.Drawing.Size(143, 25);
            this.comboFilter.TabIndex = 5;
            this.comboFilter.SelectedIndexChanged += new System.EventHandler(this.AccountCombo_SelectedIndexChanged);
            // 
            // labelActualBalance
            // 
            this.labelActualBalance.BackColor = System.Drawing.Color.Gainsboro;
            this.labelActualBalance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelActualBalance.Location = new System.Drawing.Point(296, 1);
            this.labelActualBalance.Margin = new System.Windows.Forms.Padding(3);
            this.labelActualBalance.Name = "labelActualBalance";
            this.labelActualBalance.Size = new System.Drawing.Size(130, 25);
            this.labelActualBalance.TabIndex = 8;
            this.labelActualBalance.Text = "Actual: 0.00";
            this.labelActualBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboDateOrder
            // 
            this.comboDateOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDateOrder.FormattingEnabled = true;
            this.comboDateOrder.Location = new System.Drawing.Point(147, 1);
            this.comboDateOrder.Name = "comboDateOrder";
            this.comboDateOrder.Size = new System.Drawing.Size(143, 25);
            this.comboDateOrder.TabIndex = 6;
            this.comboDateOrder.SelectedIndexChanged += new System.EventHandler(this.AccountCombo_SelectedIndexChanged);
            // 
            // labelStagedBalance
            // 
            this.labelStagedBalance.BackColor = System.Drawing.Color.Gainsboro;
            this.labelStagedBalance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelStagedBalance.Location = new System.Drawing.Point(568, 1);
            this.labelStagedBalance.Margin = new System.Windows.Forms.Padding(3);
            this.labelStagedBalance.Name = "labelStagedBalance";
            this.labelStagedBalance.Size = new System.Drawing.Size(130, 25);
            this.labelStagedBalance.TabIndex = 7;
            this.labelStagedBalance.Text = "Staged: 0.00";
            this.labelStagedBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelAvailableBalance
            // 
            this.labelAvailableBalance.BackColor = System.Drawing.Color.Gainsboro;
            this.labelAvailableBalance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAvailableBalance.Location = new System.Drawing.Point(432, 1);
            this.labelAvailableBalance.Margin = new System.Windows.Forms.Padding(3);
            this.labelAvailableBalance.Name = "labelAvailableBalance";
            this.labelAvailableBalance.Size = new System.Drawing.Size(130, 25);
            this.labelAvailableBalance.TabIndex = 1;
            this.labelAvailableBalance.Text = "Available: 0.00";
            this.labelAvailableBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.editRecTransToolStripMenuItem,
            this.skipRecTransToolStripMenuItem,
            this.stageRecTransToolStripMenuItem,
            this.copyRecTransToolStripMenuItem});
            this.recTransContextMenu.Name = "recTransContextMenu";
            this.recTransContextMenu.Size = new System.Drawing.Size(104, 92);
            this.recTransContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.recTransContextMenu_Opening);
            // 
            // editRecTransToolStripMenuItem
            // 
            this.editRecTransToolStripMenuItem.Name = "editRecTransToolStripMenuItem";
            this.editRecTransToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.editRecTransToolStripMenuItem.Text = "Edit";
            this.editRecTransToolStripMenuItem.ToolTipText = "Edit recurring transaction";
            this.editRecTransToolStripMenuItem.Click += new System.EventHandler(this.editRecTransToolStripMenuItem_Click);
            // 
            // skipRecTransToolStripMenuItem
            // 
            this.skipRecTransToolStripMenuItem.Name = "skipRecTransToolStripMenuItem";
            this.skipRecTransToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.skipRecTransToolStripMenuItem.Text = "Skip";
            this.skipRecTransToolStripMenuItem.ToolTipText = "Skip selected items";
            this.skipRecTransToolStripMenuItem.Click += new System.EventHandler(this.skipRecTransToolStripMenuItem_Click);
            // 
            // stageRecTransToolStripMenuItem
            // 
            this.stageRecTransToolStripMenuItem.Name = "stageRecTransToolStripMenuItem";
            this.stageRecTransToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.stageRecTransToolStripMenuItem.Text = "Stage";
            this.stageRecTransToolStripMenuItem.ToolTipText = "Post to ledger and set next due date";
            this.stageRecTransToolStripMenuItem.Click += new System.EventHandler(this.stageRecTransToolStripMenuItem_Click);
            // 
            // copyRecTransToolStripMenuItem
            // 
            this.copyRecTransToolStripMenuItem.Name = "copyRecTransToolStripMenuItem";
            this.copyRecTransToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.copyRecTransToolStripMenuItem.Text = "Copy";
            this.copyRecTransToolStripMenuItem.ToolTipText = "Copy to ledger";
            this.copyRecTransToolStripMenuItem.Click += new System.EventHandler(this.copyRecTransToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabOutlook);
            this.tabControl1.Controls.Add(this.tabOperations);
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
            this.tabOperations.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupOperations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileTransactions)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountTransactions)).EndInit();
            this.transContextMenu.ResumeLayout(false);
            this.panelLedger.ResumeLayout(false);
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
        private TabPage tabOperations;
        private LinkLabel linkImportTransactions;
        private LinkLabel linkDeleteRepeatingTransactions;
        private LinkLabel linkOpenFile;
        private LinkLabel linkResetAccountData;
        private LinkLabel linkAccountData;
        private LinkLabel linkDeleteAllTransactions;
        private LinkLabel linkImportRepeatingTransactions;
        private DataGridView dgvFileTransactions;
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
        private LinkLabel linkRestoreDatabase;
        private LinkLabel linkBackupDatabase;
        private CustomListView listViewAccounts;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private ToolStripMenuItem addTransToolStripMenuItem;
        private SplitContainer hSplit1;
        private SplitContainer vSplit1;
        private TableLayoutPanel tableLayoutLedger;
        private Panel panelLedger;
        private GroupBox groupAccounts;
        private Panel panel2;
        private GroupBox groupOperations;
        private Label labelProjectedBalance;
    }
}