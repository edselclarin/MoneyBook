namespace MoneyBookTools
{
    public static class DataGridViewExtension
    {
        public static void SetDataGridViewStyle(this DataGridView dgv)
        {
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToResizeRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.EnableHeadersVisualStyles = false; // To allow custom header style.
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor =
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
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
