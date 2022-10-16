
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvFileTransactions = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAccounts = new System.Windows.Forms.TabPage();
            this.dgvAccounts = new System.Windows.Forms.DataGridView();
            this.tabLedger = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboDateOrder = new System.Windows.Forms.ComboBox();
            this.comboAccounts = new System.Windows.Forms.ComboBox();
            this.comboFilter = new System.Windows.Forms.ComboBox();
            this.labelAvailableBalance = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvAccountTransactions = new System.Windows.Forms.DataGridView();
            this.tabOperations = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.linkImportTransactions = new System.Windows.Forms.LinkLabel();
            this.linkDeleteRepeatingTransactions = new System.Windows.Forms.LinkLabel();
            this.linkOpenFile = new System.Windows.Forms.LinkLabel();
            this.linkResetStartingBalances = new System.Windows.Forms.LinkLabel();
            this.linkUpdateStartingBalances = new System.Windows.Forms.LinkLabel();
            this.linkDeleteAllTransactions = new System.Windows.Forms.LinkLabel();
            this.linkImportRepeatingTransactions = new System.Windows.Forms.LinkLabel();
            this.dgvRecurringTransactions = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileTransactions)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).BeginInit();
            this.tabLedger.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountTransactions)).BeginInit();
            this.tabOperations.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecurringTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(680, 24);
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
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAccounts);
            this.tabControl1.Controls.Add(this.tabLedger);
            this.tabControl1.Controls.Add(this.tabOperations);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(680, 500);
            this.tabControl1.TabIndex = 2;
            // 
            // tabAccounts
            // 
            this.tabAccounts.Controls.Add(this.dgvAccounts);
            this.tabAccounts.Location = new System.Drawing.Point(4, 24);
            this.tabAccounts.Name = "tabAccounts";
            this.tabAccounts.Padding = new System.Windows.Forms.Padding(3);
            this.tabAccounts.Size = new System.Drawing.Size(672, 472);
            this.tabAccounts.TabIndex = 1;
            this.tabAccounts.Text = "Accounts";
            this.tabAccounts.UseVisualStyleBackColor = true;
            // 
            // dgvAccounts
            // 
            this.dgvAccounts.AllowUserToOrderColumns = true;
            this.dgvAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAccounts.Location = new System.Drawing.Point(3, 3);
            this.dgvAccounts.Name = "dgvAccounts";
            this.dgvAccounts.RowTemplate.Height = 25;
            this.dgvAccounts.Size = new System.Drawing.Size(666, 466);
            this.dgvAccounts.TabIndex = 0;
            // 
            // tabLedger
            // 
            this.tabLedger.Controls.Add(this.tableLayoutPanel1);
            this.tabLedger.Location = new System.Drawing.Point(4, 24);
            this.tabLedger.Name = "tabLedger";
            this.tabLedger.Size = new System.Drawing.Size(672, 472);
            this.tabLedger.TabIndex = 2;
            this.tabLedger.Text = "Ledger";
            this.tabLedger.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(672, 472);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboDateOrder);
            this.panel1.Controls.Add(this.comboAccounts);
            this.panel1.Controls.Add(this.comboFilter);
            this.panel1.Controls.Add(this.labelAvailableBalance);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(666, 31);
            this.panel1.TabIndex = 1;
            // 
            // comboDateOrder
            // 
            this.comboDateOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDateOrder.FormattingEnabled = true;
            this.comboDateOrder.Location = new System.Drawing.Point(259, 4);
            this.comboDateOrder.Name = "comboDateOrder";
            this.comboDateOrder.Size = new System.Drawing.Size(121, 23);
            this.comboDateOrder.TabIndex = 4;
            this.comboDateOrder.SelectedIndexChanged += new System.EventHandler(this.AccountsTabCombo_SelectedIndexChanged);
            // 
            // comboAccounts
            // 
            this.comboAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAccounts.FormattingEnabled = true;
            this.comboAccounts.Location = new System.Drawing.Point(5, 4);
            this.comboAccounts.Name = "comboAccounts";
            this.comboAccounts.Size = new System.Drawing.Size(121, 23);
            this.comboAccounts.TabIndex = 3;
            this.comboAccounts.SelectedIndexChanged += new System.EventHandler(this.AccountsTabCombo_SelectedIndexChanged);
            // 
            // comboFilter
            // 
            this.comboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFilter.FormattingEnabled = true;
            this.comboFilter.Location = new System.Drawing.Point(132, 4);
            this.comboFilter.Name = "comboFilter";
            this.comboFilter.Size = new System.Drawing.Size(121, 23);
            this.comboFilter.TabIndex = 2;
            this.comboFilter.SelectedIndexChanged += new System.EventHandler(this.AccountsTabCombo_SelectedIndexChanged);
            // 
            // labelAvailableBalance
            // 
            this.labelAvailableBalance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAvailableBalance.BackColor = System.Drawing.Color.Gainsboro;
            this.labelAvailableBalance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelAvailableBalance.Location = new System.Drawing.Point(386, 4);
            this.labelAvailableBalance.Margin = new System.Windows.Forms.Padding(3);
            this.labelAvailableBalance.Name = "labelAvailableBalance";
            this.labelAvailableBalance.Size = new System.Drawing.Size(275, 23);
            this.labelAvailableBalance.TabIndex = 0;
            this.labelAvailableBalance.Text = "Available: 0.00";
            this.labelAvailableBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 40);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvRecurringTransactions);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvAccountTransactions);
            this.splitContainer1.Size = new System.Drawing.Size(666, 429);
            this.splitContainer1.SplitterDistance = 95;
            this.splitContainer1.TabIndex = 3;
            // 
            // dgvAccountTransactions
            // 
            this.dgvAccountTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccountTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAccountTransactions.Location = new System.Drawing.Point(0, 0);
            this.dgvAccountTransactions.Name = "dgvAccountTransactions";
            this.dgvAccountTransactions.RowTemplate.Height = 25;
            this.dgvAccountTransactions.Size = new System.Drawing.Size(666, 330);
            this.dgvAccountTransactions.TabIndex = 2;
            // 
            // tabOperations
            // 
            this.tabOperations.Controls.Add(this.panel2);
            this.tabOperations.Controls.Add(this.dgvFileTransactions);
            this.tabOperations.Location = new System.Drawing.Point(4, 24);
            this.tabOperations.Name = "tabOperations";
            this.tabOperations.Padding = new System.Windows.Forms.Padding(3);
            this.tabOperations.Size = new System.Drawing.Size(672, 472);
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
            this.tableLayoutPanel2.Controls.Add(this.linkResetStartingBalances, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.linkUpdateStartingBalances, 2, 0);
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
            // linkResetStartingBalances
            // 
            this.linkResetStartingBalances.Location = new System.Drawing.Point(325, 33);
            this.linkResetStartingBalances.Margin = new System.Windows.Forms.Padding(3);
            this.linkResetStartingBalances.Name = "linkResetStartingBalances";
            this.linkResetStartingBalances.Size = new System.Drawing.Size(137, 24);
            this.linkResetStartingBalances.TabIndex = 6;
            this.linkResetStartingBalances.TabStop = true;
            this.linkResetStartingBalances.Text = "Reset Starting Balances";
            this.linkResetStartingBalances.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkResetStartingBalances.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkResetStartingBalances_LinkClicked);
            // 
            // linkUpdateStartingBalances
            // 
            this.linkUpdateStartingBalances.Location = new System.Drawing.Point(325, 3);
            this.linkUpdateStartingBalances.Margin = new System.Windows.Forms.Padding(3);
            this.linkUpdateStartingBalances.Name = "linkUpdateStartingBalances";
            this.linkUpdateStartingBalances.Size = new System.Drawing.Size(146, 23);
            this.linkUpdateStartingBalances.TabIndex = 7;
            this.linkUpdateStartingBalances.TabStop = true;
            this.linkUpdateStartingBalances.Text = "Update Starting Balances";
            this.linkUpdateStartingBalances.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkUpdateStartingBalances.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUpdateStartingBalances_LinkClicked);
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecurringTransactions.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRecurringTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecurringTransactions.Location = new System.Drawing.Point(0, 0);
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
            this.dgvRecurringTransactions.Size = new System.Drawing.Size(666, 95);
            this.dgvRecurringTransactions.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 524);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MoneyBookTools";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileTransactions)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabAccounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).EndInit();
            this.tabLedger.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountTransactions)).EndInit();
            this.tabOperations.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecurringTransactions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private DataGridView dgvFileTransactions;
        private TabControl tabControl1;
        private TabPage tabOperations;
        private TabPage tabAccounts;
        private DataGridView dgvAccounts;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private TabPage tabLedger;
        private TableLayoutPanel tableLayoutPanel1;
        private Label labelAvailableBalance;
        private Panel panel1;
        private DataGridView dgvAccountTransactions;
        private ComboBox comboFilter;
        private ComboBox comboAccounts;
        private SplitContainer splitContainer1;
        private ComboBox comboDateOrder;
        private TableLayoutPanel tableLayoutPanel2;
        private LinkLabel linkUpdateStartingBalances;
        private LinkLabel linkResetStartingBalances;
        private LinkLabel linkDeleteAllTransactions;
        private LinkLabel linkImportTransactions;
        private LinkLabel linkOpenFile;
        private LinkLabel linkImportRepeatingTransactions;
        private LinkLabel linkDeleteRepeatingTransactions;
        private Panel panel2;
        private DataGridView dgvRecurringTransactions;
    }
}