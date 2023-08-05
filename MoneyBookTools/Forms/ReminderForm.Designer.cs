namespace MoneyBookTools
{
    partial class ReminderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReminderForm));
            dateTime = new DateTimePicker();
            textPayee = new TextBox();
            textMemo = new TextBox();
            comboFrequency = new ComboBox();
            textAmount = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            label5 = new Label();
            textWebsite = new TextBox();
            label1 = new Label();
            panel1 = new Panel();
            buttonCancel = new Button();
            buttonSave = new Button();
            label6 = new Label();
            label3 = new Label();
            comboAccounts = new ComboBox();
            label2 = new Label();
            label4 = new Label();
            label7 = new Label();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dateTime
            // 
            dateTime.Format = DateTimePickerFormat.Short;
            dateTime.Location = new Point(91, 14);
            dateTime.Name = "dateTime";
            dateTime.Size = new Size(100, 25);
            dateTime.TabIndex = 4;
            // 
            // textPayee
            // 
            textPayee.Location = new Point(91, 94);
            textPayee.Name = "textPayee";
            textPayee.Size = new Size(320, 25);
            textPayee.TabIndex = 6;
            // 
            // textMemo
            // 
            textMemo.Location = new Point(91, 134);
            textMemo.Name = "textMemo";
            textMemo.Size = new Size(320, 25);
            textMemo.TabIndex = 7;
            // 
            // comboFrequency
            // 
            comboFrequency.DropDownStyle = ComboBoxStyle.DropDownList;
            comboFrequency.FormattingEnabled = true;
            comboFrequency.Location = new Point(91, 254);
            comboFrequency.Name = "comboFrequency";
            comboFrequency.Size = new Size(100, 25);
            comboFrequency.TabIndex = 1;
            // 
            // textAmount
            // 
            textAmount.Location = new Point(91, 214);
            textAmount.Name = "textAmount";
            textAmount.Size = new Size(100, 25);
            textAmount.TabIndex = 0;
            textAmount.TextAlign = HorizontalAlignment.Right;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(label5, 0, 7);
            tableLayoutPanel1.Controls.Add(dateTime, 1, 1);
            tableLayoutPanel1.Controls.Add(textWebsite, 1, 5);
            tableLayoutPanel1.Controls.Add(comboFrequency, 1, 7);
            tableLayoutPanel1.Controls.Add(label1, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 1, 8);
            tableLayoutPanel1.Controls.Add(label6, 0, 6);
            tableLayoutPanel1.Controls.Add(textAmount, 1, 6);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(comboAccounts, 1, 2);
            tableLayoutPanel1.Controls.Add(textPayee, 1, 3);
            tableLayoutPanel1.Controls.Add(textMemo, 1, 4);
            tableLayoutPanel1.Controls.Add(label2, 0, 3);
            tableLayoutPanel1.Controls.Add(label4, 0, 4);
            tableLayoutPanel1.Controls.Add(label7, 0, 5);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 9;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 11F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(434, 349);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label5.Location = new Point(3, 254);
            label5.Margin = new Padding(3);
            label5.Name = "label5";
            label5.Size = new Size(82, 26);
            label5.TabIndex = 8;
            label5.Text = "Frequency";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textWebsite
            // 
            textWebsite.Location = new Point(91, 174);
            textWebsite.Name = "textWebsite";
            textWebsite.Size = new Size(320, 25);
            textWebsite.TabIndex = 8;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.Location = new Point(3, 14);
            label1.Margin = new Padding(3);
            label1.Name = "label1";
            label1.Size = new Size(82, 26);
            label1.TabIndex = 4;
            label1.Text = "Due Date";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonCancel);
            panel1.Controls.Add(buttonSave);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(91, 294);
            panel1.Name = "panel1";
            panel1.Size = new Size(320, 52);
            panel1.TabIndex = 11;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(81, 15);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 26);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonSave.DialogResult = DialogResult.Cancel;
            buttonSave.Location = new Point(0, 15);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 26);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.Location = new Point(3, 214);
            label6.Margin = new Padding(3);
            label6.Name = "label6";
            label6.Size = new Size(82, 26);
            label6.TabIndex = 9;
            label6.Text = "Amount";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.Location = new Point(3, 54);
            label3.Margin = new Padding(3);
            label3.Name = "label3";
            label3.Size = new Size(82, 26);
            label3.TabIndex = 12;
            label3.Text = "Account";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // comboAccounts
            // 
            comboAccounts.DropDownStyle = ComboBoxStyle.DropDownList;
            comboAccounts.FormattingEnabled = true;
            comboAccounts.Location = new Point(91, 54);
            comboAccounts.Name = "comboAccounts";
            comboAccounts.Size = new Size(156, 25);
            comboAccounts.TabIndex = 5;
            comboAccounts.SelectedIndexChanged += comboAccounts_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.Location = new Point(3, 94);
            label2.Margin = new Padding(3);
            label2.Name = "label2";
            label2.Size = new Size(82, 26);
            label2.TabIndex = 5;
            label2.Text = "Payee";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.Location = new Point(3, 134);
            label4.Margin = new Padding(3);
            label4.Name = "label4";
            label4.Size = new Size(82, 26);
            label4.TabIndex = 7;
            label4.Text = "Memo";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label7.Location = new Point(3, 174);
            label7.Margin = new Padding(3);
            label7.Name = "label7";
            label7.Size = new Size(82, 26);
            label7.TabIndex = 14;
            label7.Text = "Website";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ReminderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 349);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReminderForm";
            Text = "Reminder";
            FormClosing += ReminderForm_FormClosing;
            Load += ReminderForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dateTime;
        private TextBox textPayee;
        private TextBox textMemo;
        private ComboBox comboFrequency;
        private TextBox textAmount;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label1;
        private Panel panel1;
        private Button buttonSave;
        private Button buttonCancel;
        private Label label3;
        private ComboBox comboAccounts;
        private TextBox textWebsite;
        private Label label7;
    }
}