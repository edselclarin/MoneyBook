namespace MoneyBookTools
{
    partial class FileTransactionsForm
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
            this.groupFileTransactions = new System.Windows.Forms.GroupBox();
            this.dgvFileTransactions = new System.Windows.Forms.DataGridView();
            this.groupFileTransactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // groupFileTransactions
            // 
            this.groupFileTransactions.Controls.Add(this.dgvFileTransactions);
            this.groupFileTransactions.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupFileTransactions.Location = new System.Drawing.Point(12, 12);
            this.groupFileTransactions.Name = "groupFileTransactions";
            this.groupFileTransactions.Size = new System.Drawing.Size(200, 100);
            this.groupFileTransactions.TabIndex = 3;
            this.groupFileTransactions.TabStop = false;
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
            // 
            // FileTransactionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 509);
            this.Controls.Add(this.groupFileTransactions);
            this.MinimizeBox = false;
            this.Name = "FileTransactionsForm";
            this.Text = "File Transactions";
            this.Load += new System.EventHandler(this.FileTransactionsForm_Load);
            this.groupFileTransactions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileTransactions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupFileTransactions;
        private DataGridView dgvFileTransactions;
    }
}