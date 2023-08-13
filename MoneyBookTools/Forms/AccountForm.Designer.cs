namespace MoneyBookTools.Forms
{
    partial class AccountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountForm));
            label1 = new Label();
            textName = new TextBox();
            textDescription = new TextBox();
            textStartingBalance = new TextBox();
            textReserveAmount = new TextBox();
            textType = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            buttonSave = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(48, 19);
            label1.TabIndex = 0;
            label1.Text = "Name:";
            // 
            // textName
            // 
            textName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textName.Location = new Point(134, 12);
            textName.Name = "textName";
            textName.Size = new Size(194, 25);
            textName.TabIndex = 1;
            // 
            // textDescription
            // 
            textDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textDescription.Location = new Point(134, 43);
            textDescription.Name = "textDescription";
            textDescription.Size = new Size(194, 25);
            textDescription.TabIndex = 1;
            // 
            // textStartingBalance
            // 
            textStartingBalance.Location = new Point(134, 105);
            textStartingBalance.Name = "textStartingBalance";
            textStartingBalance.Size = new Size(87, 25);
            textStartingBalance.TabIndex = 1;
            // 
            // textReserveAmount
            // 
            textReserveAmount.Location = new Point(134, 136);
            textReserveAmount.Name = "textReserveAmount";
            textReserveAmount.Size = new Size(87, 25);
            textReserveAmount.TabIndex = 1;
            // 
            // textType
            // 
            textType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textType.Location = new Point(134, 74);
            textType.Name = "textType";
            textType.ReadOnly = true;
            textType.Size = new Size(194, 25);
            textType.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 46);
            label2.Name = "label2";
            label2.Size = new Size(81, 19);
            label2.TabIndex = 0;
            label2.Text = "Description:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 77);
            label3.Name = "label3";
            label3.Size = new Size(40, 19);
            label3.TabIndex = 0;
            label3.Text = "Type:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 108);
            label4.Name = "label4";
            label4.Size = new Size(110, 19);
            label4.TabIndex = 0;
            label4.Text = "Starting Balance:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 139);
            label5.Name = "label5";
            label5.Size = new Size(113, 19);
            label5.TabIndex = 0;
            label5.Text = "Reserve Amount:";
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonSave.Location = new Point(133, 195);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 26);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // AccountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(340, 233);
            Controls.Add(buttonSave);
            Controls.Add(textReserveAmount);
            Controls.Add(textStartingBalance);
            Controls.Add(textType);
            Controls.Add(textDescription);
            Controls.Add(textName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AccountForm";
            Text = "Account";
            Load += AccountForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textName;
        private TextBox textDescription;
        private TextBox textStartingBalance;
        private TextBox textReserveAmount;
        private TextBox textType;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button buttonSave;
    }
}