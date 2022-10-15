namespace MoneyBookTools
{
    public static class DataGridViewExtension
    {
        public static void SetDataGridViewStyle(this DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToResizeRows = false;
            dgv.EnableHeadersVisualStyles = false; // To allow custom header style.
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.SandyBrown;
        }
    }
}
