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
            textOutput = new TextBox();
            SuspendLayout();
            // 
            // textOutput
            // 
            textOutput.Dock = DockStyle.Fill;
            textOutput.Location = new Point(0, 0);
            textOutput.Multiline = true;
            textOutput.Name = "textOutput";
            textOutput.ScrollBars = ScrollBars.Both;
            textOutput.Size = new Size(373, 150);
            textOutput.TabIndex = 0;
            // 
            // ImportTransactionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(373, 150);
            Controls.Add(textOutput);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ImportTransactionsForm";
            Text = "Import Transactions";
            Load += ImportTransactionsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textOutput;
    }
}