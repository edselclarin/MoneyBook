namespace MoneyBookTools
{
    public static class DataGridViewExtension
    {
        public static void SetDataGridViewStyle(this DataGridView dgv)
        {
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToResizeRows = false;
            dgv.EnableHeadersVisualStyles = false; // To allow custom header style.
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            dgv.DefaultCellStyle.SelectionBackColor = Color.CadetBlue;
        }

        public static void ResizeAllCells(this DataGridView dgv)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
    }
}
