namespace MoneyBookTools
{
    partial class ImportTransactionsForm
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
            btnYes = new Button();
            btnNo = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnYes
            // 
            btnYes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnYes.Location = new Point(148, 197);
            btnYes.Name = "btnYes";
            btnYes.Size = new Size(75, 23);
            btnYes.TabIndex = 1;
            btnYes.Text = "Yes";
            btnYes.UseVisualStyleBackColor = true;
            btnYes.Click += btnYes_Click;
            // 
            // btnNo
            // 
            btnNo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnNo.Location = new Point(229, 197);
            btnNo.Name = "btnNo";
            btnNo.Size = new Size(75, 23);
            btnNo.TabIndex = 0;
            btnNo.Text = "No";
            btnNo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(28, 15);
            label1.TabIndex = 4;
            label1.Text = "Text";
            // 
            // ImportTransactionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnNo;
            ClientSize = new Size(452, 225);
            Controls.Add(label1);
            Controls.Add(btnNo);
            Controls.Add(btnYes);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ImportTransactionsForm";
            Text = "Import";
            Load += ImportTransactionsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnYes;
        private Button btnNo;
        private Label label1;
    }
}