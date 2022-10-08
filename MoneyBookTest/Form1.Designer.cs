namespace MoneyBookTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonGetAccounts = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonGetTransactions = new System.Windows.Forms.Button();
            this.buttonNextTransactions = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGetAccounts
            // 
            this.buttonGetAccounts.Location = new System.Drawing.Point(12, 12);
            this.buttonGetAccounts.Name = "buttonGetAccounts";
            this.buttonGetAccounts.Size = new System.Drawing.Size(111, 23);
            this.buttonGetAccounts.TabIndex = 0;
            this.buttonGetAccounts.Text = "Get Accounts";
            this.buttonGetAccounts.UseVisualStyleBackColor = true;
            this.buttonGetAccounts.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(868, 397);
            this.dataGridView1.TabIndex = 1;
            // 
            // buttonGetTransactions
            // 
            this.buttonGetTransactions.Location = new System.Drawing.Point(129, 12);
            this.buttonGetTransactions.Name = "buttonGetTransactions";
            this.buttonGetTransactions.Size = new System.Drawing.Size(111, 23);
            this.buttonGetTransactions.TabIndex = 2;
            this.buttonGetTransactions.Text = "Get Transactions";
            this.buttonGetTransactions.UseVisualStyleBackColor = true;
            this.buttonGetTransactions.Click += new System.EventHandler(this.buttonGetTransactions_Click);
            // 
            // buttonNextTransactions
            // 
            this.buttonNextTransactions.Location = new System.Drawing.Point(246, 12);
            this.buttonNextTransactions.Name = "buttonNextTransactions";
            this.buttonNextTransactions.Size = new System.Drawing.Size(111, 23);
            this.buttonNextTransactions.TabIndex = 2;
            this.buttonNextTransactions.Text = "Next Transactions";
            this.buttonNextTransactions.UseVisualStyleBackColor = true;
            this.buttonNextTransactions.Click += new System.EventHandler(this.buttonNextTransactions_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 450);
            this.Controls.Add(this.buttonNextTransactions);
            this.Controls.Add(this.buttonGetTransactions);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonGetAccounts);
            this.Name = "Form1";
            this.Text = "MoneyBookTest";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonGetAccounts;
        private DataGridView dataGridView1;
        private Button buttonGetTransactions;
        private Button buttonNextTransactions;
    }
}