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

        public static void SetDataSource(this DataGridView dgv, object dataSource, bool resizeCells)
        {
            dgv.DataSource = dataSource;

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
    }
}
