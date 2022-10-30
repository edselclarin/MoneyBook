
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabOperations = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvFileTransactions = new System.Windows.Forms.DataGridView();
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
            this.tabOutlook = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.labelActualBalance = new System.Windows.Forms.Label();
            this.labelPendingBalance = new System.Windows.Forms.Label();
            this.comboFilter = new System.Windows.Forms.ComboBox();
            this.labelAvailableBalance = new System.Windows.Forms.Label();
            this.comboDateOrder = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvAccountTransactions = new System.Windows.Forms.DataGridView();
            this.transContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addTransToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTransToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setTransStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteTransToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileTransactions)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabOutlook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountTransactions)).BeginInit();
            this.transContextMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(951, 24);
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
            this.tabOperations.Size = new System.Drawing.Size(943, 472);
            this.tabOperations.TabIndex = 0;
            this.tabOperations.Text = "Operations";
            this.tabOperations.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.dgvFileTransactions, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(937, 466);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // dgvFileTransactions
            // 
            this.dgvFileTransactions.AllowUserToAddRows = false;
            this.dgvFileTransactions.AllowUserToDeleteRows = false;
            this.dgvFileTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFileTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFileTransactions.Location = new System.Drawing.Point(3, 67);
            this.dgvFileTransactions.Name = "dgvFileTransactions";
            this.dgvFileTransactions.ReadOnly = true;
            this.dgvFileTransactions.Size = new System.Drawing.Size(931, 396);
            this.dgvFileTransactions.TabIndex = 1;
            this.dgvFileTransactions.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
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
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(652, 58);
            this.panel1.TabIndex = 2;
            // 
            // linkImportTransactions
            // 
            this.linkImportTransactions.Location = new System.Drawing.Point(3, 3);
            this.linkImportTransactions.Margin = new System.Windows.Forms.Padding(3);
            this.linkImportTransactions.Name = "linkImportTransactions";
            this.linkImportTransactions.Size = new System.Drawing.Size(128, 23);
            this.linkImportTransactions.TabIndex = 1;
            this.linkImportTransactions.TabStop = true;
            this.linkImportTransactions.Text = "Import Transactions";
            this.linkImportTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkImportTransactions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkImportTransactions_LinkClicked);
            // 
            // linkRestoreDatabase
            // 
            this.linkRestoreDatabase.AutoSize = true;
            this.linkRestoreDatabase.Location = new System.Drawing.Point(452, 36);
            this.linkRestoreDatabase.Name = "linkRestoreDatabase";
            this.linkRestoreDatabase.Size = new System.Drawing.Size(97, 15);
            this.linkRestoreDatabase.TabIndex = 9;
            this.linkRestoreDatabase.TabStop = true;
            this.linkRestoreDatabase.Text = "Restore Database";
            this.linkRestoreDatabase.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRestoreDatabase_LinkClicked);
            // 
            // linkAccountData
            // 
            this.linkAccountData.Location = new System.Drawing.Point(318, 3);
            this.linkAccountData.Margin = new System.Windows.Forms.Padding(3);
            this.linkAccountData.Name = "linkAccountData";
            this.linkAccountData.Size = new System.Drawing.Size(128, 23);
            this.linkAccountData.TabIndex = 7;
            this.linkAccountData.TabStop = true;
            this.linkAccountData.Text = "Update Account Data";
            this.linkAccountData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkAccountData.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUpdateAccountData_LinkClicked);
            // 
            // linkBackupDatabase
            // 
            this.linkBackupDatabase.AutoSize = true;
            this.linkBackupDatabase.Location = new System.Drawing.Point(452, 7);
            this.linkBackupDatabase.Name = "linkBackupDatabase";
            this.linkBackupDatabase.Size = new System.Drawing.Size(97, 15);
            this.linkBackupDatabase.TabIndex = 8;
            this.linkBackupDatabase.TabStop = true;
            this.linkBackupDatabase.Text = "Backup Database";
            this.linkBackupDatabase.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBackupDatabase_LinkClicked);
            // 
            // linkOpenFile
            // 
            this.linkOpenFile.Location = new System.Drawing.Point(569, 3);
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
            this.linkDeleteAllTransactions.Size = new System.Drawing.Size(128, 23);
            this.linkDeleteAllTransactions.TabIndex = 2;
            this.linkDeleteAllTransactions.TabStop = true;
            this.linkDeleteAllTransactions.Text = "Delete All Transactions";
            this.linkDeleteAllTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkDeleteAllTransactions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDeleteAllTransactions_LinkClicked);
            // 
            // linkImportRepeatingTransactions
            // 
            this.linkImportRepeatingTransactions.Location = new System.Drawing.Point(137, 3);
            this.linkImportRepeatingTransactions.Margin = new System.Windows.Forms.Padding(3);
            this.linkImportRepeatingTransactions.Name = "linkImportRepeatingTransactions";
            this.linkImportRepeatingTransactions.Size = new System.Drawing.Size(175, 23);
            this.linkImportRepeatingTransactions.TabIndex = 4;
            this.linkImportRepeatingTransactions.TabStop = true;
            this.linkImportRepeatingTransactions.Text = "Import Repeating Transactions";
            this.linkImportRepeatingTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkImportRepeatingTransactions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkImportRepeatingTransactions_LinkClicked);
            // 
            // linkResetAccountData
            // 
            this.linkResetAccountData.Location = new System.Drawing.Point(318, 31);
            this.linkResetAccountData.Margin = new System.Windows.Forms.Padding(3);
            this.linkResetAccountData.Name = "linkResetAccountData";
            this.linkResetAccountData.Size = new System.Drawing.Size(128, 24);
            this.linkResetAccountData.TabIndex = 6;
            this.linkResetAccountData.TabStop = true;
            this.linkResetAccountData.Text = "Reset Account Data";
            this.linkResetAccountData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkResetAccountData.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkResetAccountData_LinkClicked);
            // 
            // linkDeleteRepeatingTransactions
            // 
            this.linkDeleteRepeatingTransactions.Location = new System.Drawing.Point(137, 31);
            this.linkDeleteRepeatingTransactions.Margin = new System.Windows.Forms.Padding(3);
            this.linkDeleteRepeatingTransactions.Name = "linkDeleteRepeatingTransactions";
            this.linkDeleteRepeatingTransactions.Size = new System.Drawing.Size(175, 24);
            this.linkDeleteRepeatingTransactions.TabIndex = 5;
            this.linkDeleteRepeatingTransactions.TabStop = true;
            this.linkDeleteRepeatingTransactions.Text = "Delete Repeating Transactions";
            this.linkDeleteRepeatingTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkDeleteRepeatingTransactions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDeleteRepeatingTransactions_LinkClicked);
            // 
            // tabOutlook
            // 
            this.tabOutlook.Controls.Add(this.splitContainer2);
            this.tabOutlook.Location = new System.Drawing.Point(4, 24);
            this.tabOutlook.Name = "tabOutlook";
            this.tabOutlook.Size = new System.Drawing.Size(943, 472);
            this.tabOutlook.TabIndex = 3;
            this.tabOutlook.Text = "Outlook";
            this.tabOutlook.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(943, 472);
            this.splitContainer2.SplitterDistance = 174;
            this.splitContainer2.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(158, 193);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tableLayoutPanel3);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer3.Size = new System.Drawing.Size(765, 472);
            this.splitContainer3.SplitterDistance = 300;
            this.splitContainer3.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(765, 300);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(759, 30);
            this.panel3.TabIndex = 4;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 6;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.labelActualBalance, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelPendingBalance, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.comboFilter, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelAvailableBalance, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.comboDateOrder, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(759, 30);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // labelActualBalance
            // 
            this.labelActualBalance.BackColor = System.Drawing.Color.Gainsboro;
            this.labelActualBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelActualBalance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelActualBalance.Location = new System.Drawing.Point(533, 3);
            this.labelActualBalance.Margin = new System.Windows.Forms.Padding(3);
            this.labelActualBalance.Name = "labelActualBalance";
            this.labelActualBalance.Size = new System.Drawing.Size(134, 24);
            this.labelActualBalance.TabIndex = 8;
            this.labelActualBalance.Text = "Actual: 0.00";
            this.labelActualBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPendingBalance
            // 
            this.labelPendingBalance.BackColor = System.Drawing.Color.Gainsboro;
            this.labelPendingBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPendingBalance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPendingBalance.Location = new System.Drawing.Point(393, 3);
            this.labelPendingBalance.Margin = new System.Windows.Forms.Padding(3);
            this.labelPendingBalance.Name = "labelPendingBalance";
            this.labelPendingBalance.Size = new System.Drawing.Size(134, 24);
            this.labelPendingBalance.TabIndex = 7;
            this.labelPendingBalance.Text = "Pending: 0.00";
            this.labelPendingBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboFilter
            // 
            this.comboFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFilter.FormattingEnabled = true;
            this.comboFilter.Location = new System.Drawing.Point(3, 3);
            this.comboFilter.Name = "comboFilter";
            this.comboFilter.Size = new System.Drawing.Size(119, 23);
            this.comboFilter.TabIndex = 5;
            this.comboFilter.SelectedIndexChanged += new System.EventHandler(this.AccountCombo_SelectedIndexChanged);
            // 
            // labelAvailableBalance
            // 
            this.labelAvailableBalance.BackColor = System.Drawing.Color.Gainsboro;
            this.labelAvailableBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAvailableBalance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelAvailableBalance.Location = new System.Drawing.Point(253, 3);
            this.labelAvailableBalance.Margin = new System.Windows.Forms.Padding(3);
            this.labelAvailableBalance.Name = "labelAvailableBalance";
            this.labelAvailableBalance.Size = new System.Drawing.Size(134, 24);
            this.labelAvailableBalance.TabIndex = 1;
            this.labelAvailableBalance.Text = "Available: 0.00";
            this.labelAvailableBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboDateOrder
            // 
            this.comboDateOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboDateOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDateOrder.FormattingEnabled = true;
            this.comboDateOrder.Location = new System.Drawing.Point(128, 3);
            this.comboDateOrder.Name = "comboDateOrder";
            this.comboDateOrder.Size = new System.Drawing.Size(119, 23);
            this.comboDateOrder.TabIndex = 6;
            this.comboDateOrder.SelectedIndexChanged += new System.EventHandler(this.AccountCombo_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvAccountTransactions);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(759, 258);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ledger";
            // 
            // dgvAccountTransactions
            // 
            this.dgvAccountTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccountTransactions.ContextMenuStrip = this.transContextMenu;
            this.dgvAccountTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAccountTransactions.Location = new System.Drawing.Point(3, 19);
            this.dgvAccountTransactions.Name = "dgvAccountTransactions";
            this.dgvAccountTransactions.RowTemplate.Height = 25;
            this.dgvAccountTransactions.Size = new System.Drawing.Size(753, 236);
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(765, 168);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvRecurringTransactions);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(759, 162);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Upcoming Transactions";
            // 
            // dgvRecurringTransactions
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecurringTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRecurringTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecurringTransactions.ContextMenuStrip = this.recTransContextMenu;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecurringTransactions.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRecurringTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecurringTransactions.Location = new System.Drawing.Point(3, 19);
            this.dgvRecurringTransactions.Name = "dgvRecurringTransactions";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecurringTransactions.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRecurringTransactions.RowTemplate.Height = 25;
            this.dgvRecurringTransactions.Size = new System.Drawing.Size(753, 140);
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
            this.tabControl1.Size = new System.Drawing.Size(951, 500);
            this.tabControl1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 524);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MoneyBookTools";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabOperations.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileTransactions)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabOutlook.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountTransactions)).EndInit();
            this.transContextMenu.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
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
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer3;
        private TableLayoutPanel tableLayoutPanel3;
        private DataGridView dgvAccountTransactions;
        private Panel panel3;
        private ComboBox comboDateOrder;
        private ComboBox comboFilter;
        private Label labelAvailableBalance;
        private DataGridView dgvRecurringTransactions;
        private TabControl tabControl1;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ContextMenuStrip recTransContextMenu;
        private ToolStripMenuItem skipRecTransToolStripMenuItem;
        private ContextMenuStrip transContextMenu;
        private TableLayoutPanel tableLayoutPanel4;
        private Label labelPendingBalance;
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
        private ListView listView1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private ToolStripMenuItem addTransToolStripMenuItem;
    }
}