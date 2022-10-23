
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.linkImportTransactions = new System.Windows.Forms.LinkLabel();
            this.linkDeleteRepeatingTransactions = new System.Windows.Forms.LinkLabel();
            this.linkOpenFile = new System.Windows.Forms.LinkLabel();
            this.linkResetAccountData = new System.Windows.Forms.LinkLabel();
            this.linkAccountData = new System.Windows.Forms.LinkLabel();
            this.linkDeleteAllTransactions = new System.Windows.Forms.LinkLabel();
            this.linkImportRepeatingTransactions = new System.Windows.Forms.LinkLabel();
            this.dgvFileTransactions = new System.Windows.Forms.DataGridView();
            this.tabOutlook = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.labelPendingBalance = new System.Windows.Forms.Label();
            this.comboFilter = new System.Windows.Forms.ComboBox();
            this.labelAvailableBalance = new System.Windows.Forms.Label();
            this.comboDateOrder = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvAccountTransactions = new System.Windows.Forms.DataGridView();
            this.transContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setToUnclearedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setToClearedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setToPendingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setToReconciledMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvRecurringTransactions = new System.Windows.Forms.DataGridView();
            this.recTransContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.skipSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.tabOperations.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileTransactions)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(858, 24);
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
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // tabOperations
            // 
            this.tabOperations.Controls.Add(this.panel2);
            this.tabOperations.Controls.Add(this.dgvFileTransactions);
            this.tabOperations.Location = new System.Drawing.Point(4, 24);
            this.tabOperations.Name = "tabOperations";
            this.tabOperations.Padding = new System.Windows.Forms.Padding(3);
            this.tabOperations.Size = new System.Drawing.Size(850, 472);
            this.tabOperations.TabIndex = 0;
            this.tabOperations.Text = "Operations";
            this.tabOperations.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(660, 62);
            this.panel2.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 183F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.linkImportTransactions, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.linkDeleteRepeatingTransactions, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.linkOpenFile, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.linkResetAccountData, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.linkAccountData, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.linkDeleteAllTransactions, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.linkImportRepeatingTransactions, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(658, 60);
            this.tableLayoutPanel2.TabIndex = 1;
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
            // linkDeleteRepeatingTransactions
            // 
            this.linkDeleteRepeatingTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkDeleteRepeatingTransactions.Location = new System.Drawing.Point(142, 33);
            this.linkDeleteRepeatingTransactions.Margin = new System.Windows.Forms.Padding(3);
            this.linkDeleteRepeatingTransactions.Name = "linkDeleteRepeatingTransactions";
            this.linkDeleteRepeatingTransactions.Size = new System.Drawing.Size(177, 24);
            this.linkDeleteRepeatingTransactions.TabIndex = 5;
            this.linkDeleteRepeatingTransactions.TabStop = true;
            this.linkDeleteRepeatingTransactions.Text = "Delete Repeating Transactions";
            this.linkDeleteRepeatingTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkDeleteRepeatingTransactions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDeleteRepeatingTransactions_LinkClicked);
            // 
            // linkOpenFile
            // 
            this.linkOpenFile.Location = new System.Drawing.Point(482, 3);
            this.linkOpenFile.Margin = new System.Windows.Forms.Padding(3);
            this.linkOpenFile.Name = "linkOpenFile";
            this.linkOpenFile.Size = new System.Drawing.Size(70, 23);
            this.linkOpenFile.TabIndex = 0;
            this.linkOpenFile.TabStop = true;
            this.linkOpenFile.Text = "Open FIle";
            this.linkOpenFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkOpenFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOpenFile_LinkClicked);
            // 
            // linkResetAccountData
            // 
            this.linkResetAccountData.Location = new System.Drawing.Point(325, 33);
            this.linkResetAccountData.Margin = new System.Windows.Forms.Padding(3);
            this.linkResetAccountData.Name = "linkResetAccountData";
            this.linkResetAccountData.Size = new System.Drawing.Size(137, 24);
            this.linkResetAccountData.TabIndex = 6;
            this.linkResetAccountData.TabStop = true;
            this.linkResetAccountData.Text = "Reset Account Data";
            this.linkResetAccountData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkResetAccountData.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkResetAccountData_LinkClicked);
            // 
            // linkAccountData
            // 
            this.linkAccountData.Location = new System.Drawing.Point(325, 3);
            this.linkAccountData.Margin = new System.Windows.Forms.Padding(3);
            this.linkAccountData.Name = "linkAccountData";
            this.linkAccountData.Size = new System.Drawing.Size(146, 23);
            this.linkAccountData.TabIndex = 7;
            this.linkAccountData.TabStop = true;
            this.linkAccountData.Text = "Update Account Data";
            this.linkAccountData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkAccountData.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUpdateAccountData_LinkClicked);
            // 
            // linkDeleteAllTransactions
            // 
            this.linkDeleteAllTransactions.Location = new System.Drawing.Point(3, 33);
            this.linkDeleteAllTransactions.Margin = new System.Windows.Forms.Padding(3);
            this.linkDeleteAllTransactions.Name = "linkDeleteAllTransactions";
            this.linkDeleteAllTransactions.Size = new System.Drawing.Size(133, 23);
            this.linkDeleteAllTransactions.TabIndex = 2;
            this.linkDeleteAllTransactions.TabStop = true;
            this.linkDeleteAllTransactions.Text = "Delete All Transactions";
            this.linkDeleteAllTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkDeleteAllTransactions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDeleteAllTransactions_LinkClicked);
            // 
            // linkImportRepeatingTransactions
            // 
            this.linkImportRepeatingTransactions.Location = new System.Drawing.Point(142, 3);
            this.linkImportRepeatingTransactions.Margin = new System.Windows.Forms.Padding(3);
            this.linkImportRepeatingTransactions.Name = "linkImportRepeatingTransactions";
            this.linkImportRepeatingTransactions.Size = new System.Drawing.Size(175, 23);
            this.linkImportRepeatingTransactions.TabIndex = 4;
            this.linkImportRepeatingTransactions.TabStop = true;
            this.linkImportRepeatingTransactions.Text = "Import Repeating Transactions";
            this.linkImportRepeatingTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkImportRepeatingTransactions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkImportRepeatingTransactions_LinkClicked);
            // 
            // dgvFileTransactions
            // 
            this.dgvFileTransactions.AllowUserToAddRows = false;
            this.dgvFileTransactions.AllowUserToDeleteRows = false;
            this.dgvFileTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFileTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFileTransactions.Location = new System.Drawing.Point(6, 74);
            this.dgvFileTransactions.Name = "dgvFileTransactions";
            this.dgvFileTransactions.ReadOnly = true;
            this.dgvFileTransactions.Size = new System.Drawing.Size(660, 392);
            this.dgvFileTransactions.TabIndex = 1;
            this.dgvFileTransactions.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            // 
            // tabOutlook
            // 
            this.tabOutlook.Controls.Add(this.splitContainer2);
            this.tabOutlook.Location = new System.Drawing.Point(4, 24);
            this.tabOutlook.Name = "tabOutlook";
            this.tabOutlook.Size = new System.Drawing.Size(850, 472);
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
            this.splitContainer2.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(850, 472);
            this.splitContainer2.SplitterDistance = 154;
            this.splitContainer2.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(154, 472);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
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
            this.splitContainer3.Size = new System.Drawing.Size(692, 472);
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
            this.tableLayoutPanel3.Size = new System.Drawing.Size(692, 300);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(686, 30);
            this.panel3.TabIndex = 4;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 6;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.labelPendingBalance, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.comboFilter, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelAvailableBalance, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.comboDateOrder, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(686, 30);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // labelPendingBalance
            // 
            this.labelPendingBalance.BackColor = System.Drawing.Color.Gainsboro;
            this.labelPendingBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPendingBalance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPendingBalance.Location = new System.Drawing.Point(403, 3);
            this.labelPendingBalance.Margin = new System.Windows.Forms.Padding(3);
            this.labelPendingBalance.Name = "labelPendingBalance";
            this.labelPendingBalance.Size = new System.Drawing.Size(144, 24);
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
            this.labelAvailableBalance.Size = new System.Drawing.Size(144, 24);
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
            this.groupBox1.Size = new System.Drawing.Size(686, 258);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transactions";
            // 
            // dgvAccountTransactions
            // 
            this.dgvAccountTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccountTransactions.ContextMenuStrip = this.transContextMenu;
            this.dgvAccountTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAccountTransactions.Location = new System.Drawing.Point(3, 19);
            this.dgvAccountTransactions.Name = "dgvAccountTransactions";
            this.dgvAccountTransactions.RowTemplate.Height = 25;
            this.dgvAccountTransactions.Size = new System.Drawing.Size(680, 236);
            this.dgvAccountTransactions.TabIndex = 3;
            this.dgvAccountTransactions.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dgvAccountTransactions.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAccountTransactions_CellMouseDoubleClick);
            // 
            // transContextMenu
            // 
            this.transContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setToUnclearedMenuItem,
            this.setToClearedMenuItem,
            this.setToPendingMenuItem,
            this.setToReconciledMenuItem});
            this.transContextMenu.Name = "transContextMenu";
            this.transContextMenu.Size = new System.Drawing.Size(166, 92);
            this.transContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.transContextMenu_Opening);
            // 
            // setToUnclearedMenuItem
            // 
            this.setToUnclearedMenuItem.Name = "setToUnclearedMenuItem";
            this.setToUnclearedMenuItem.Size = new System.Drawing.Size(165, 22);
            this.setToUnclearedMenuItem.Text = "Set to Uncleared";
            this.setToUnclearedMenuItem.ToolTipText = "Set status of selected items to Uncleared";
            this.setToUnclearedMenuItem.Click += new System.EventHandler(this.setToUnclearedMenuItem_Click);
            // 
            // setToClearedMenuItem
            // 
            this.setToClearedMenuItem.Name = "setToClearedMenuItem";
            this.setToClearedMenuItem.Size = new System.Drawing.Size(165, 22);
            this.setToClearedMenuItem.Text = "Set to Cleared";
            this.setToClearedMenuItem.ToolTipText = "Set status of selected items to Cleared";
            this.setToClearedMenuItem.Click += new System.EventHandler(this.setToClearedMenuItem_Click);
            // 
            // setToPendingMenuItem
            // 
            this.setToPendingMenuItem.Name = "setToPendingMenuItem";
            this.setToPendingMenuItem.Size = new System.Drawing.Size(165, 22);
            this.setToPendingMenuItem.Text = "Set to Pending";
            this.setToPendingMenuItem.Click += new System.EventHandler(this.setToPendingMenuItem_Click);
            // 
            // setToReconciledMenuItem
            // 
            this.setToReconciledMenuItem.Name = "setToReconciledMenuItem";
            this.setToReconciledMenuItem.Size = new System.Drawing.Size(165, 22);
            this.setToReconciledMenuItem.Text = "Set to Reconciled";
            this.setToReconciledMenuItem.ToolTipText = "Set status of selected items to Reconciled";
            this.setToReconciledMenuItem.Click += new System.EventHandler(this.setToReconciledMenuItem_Click);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(692, 168);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvRecurringTransactions);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(686, 162);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recurring Transactions";
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
            this.dgvRecurringTransactions.Size = new System.Drawing.Size(680, 140);
            this.dgvRecurringTransactions.TabIndex = 3;
            this.dgvRecurringTransactions.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            // 
            // recTransContextMenu
            // 
            this.recTransContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.skipSelectedToolStripMenuItem});
            this.recTransContextMenu.Name = "recTransContextMenu";
            this.recTransContextMenu.Size = new System.Drawing.Size(144, 26);
            this.recTransContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.recTransContextMenu_Opening);
            // 
            // skipSelectedToolStripMenuItem
            // 
            this.skipSelectedToolStripMenuItem.Name = "skipSelectedToolStripMenuItem";
            this.skipSelectedToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.skipSelectedToolStripMenuItem.Text = "Skip Selected";
            this.skipSelectedToolStripMenuItem.ToolTipText = "Skip selected items";
            this.skipSelectedToolStripMenuItem.Click += new System.EventHandler(this.skipSelectedRecTransToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabOutlook);
            this.tabControl1.Controls.Add(this.tabOperations);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(858, 500);
            this.tabControl1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 524);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MoneyBookTools";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabOperations.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileTransactions)).EndInit();
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
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel2;
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
        private TreeView treeView1;
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
        private ToolStripMenuItem skipSelectedToolStripMenuItem;
        private ContextMenuStrip transContextMenu;
        private ToolStripMenuItem setToUnclearedMenuItem;
        private ToolStripMenuItem setToClearedMenuItem;
        private ToolStripMenuItem setToReconciledMenuItem;
        private ToolStripMenuItem setToPendingMenuItem;
        private TableLayoutPanel tableLayoutPanel4;
        private Label labelPendingBalance;
    }
}