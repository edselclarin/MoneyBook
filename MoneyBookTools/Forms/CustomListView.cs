namespace MoneyBookTools.Forms
{
    public class CustomListView : ListView
    {
        private bool m_bEditMode = false;

        public Color SelectionForeColor { get; set; } = Color.Black;
        public Color SelectionBackColor { get; set; } = Color.White;

        public CustomListView()
            : base()
        {
            DrawColumnHeader += NewListView_DrawColumnHeader;
            DrawItem += NewListView_DrawItem;
            DrawSubItem += NewListView_DrawSubItem;
        }

        private void NewListView_DrawSubItem(object? sender, DrawListViewSubItemEventArgs e)
        {
            if (OwnerDraw)
            {
                var lView = sender as ListView;
                TextFormatFlags flags = GetTextAlignment(lView, e.ColumnIndex);
                Color itemColor = e.Item.ForeColor;

                if (e.Item.Selected && !m_bEditMode)
                {
                    if (e.ColumnIndex == 0 || lView.FullRowSelect)
                    {
                        using (var bkgrBrush = new SolidBrush(SelectionBackColor))
                        {
                            e.Graphics.FillRectangle(bkgrBrush, e.Bounds);
                        }
                        itemColor = SelectionForeColor;
                    }
                }
                else
                {
                    e.DrawBackground();
                }
                TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.SubItem.Font, e.Bounds, itemColor, flags);
            }
        }

        private void NewListView_DrawItem(object? sender, DrawListViewItemEventArgs e)
        {
            if (OwnerDraw)
            {
                var lView = sender as ListView;

                if (m_bEditMode || lView.View == View.Details)
                {
                    return;
                }

                TextFormatFlags flags = GetTextAlignment(lView, 0);
                Color itemColor = e.Item.ForeColor;

                if (e.Item.Selected)
                {
                    using (var bkBrush = new SolidBrush(SelectionBackColor))
                    {
                        e.Graphics.FillRectangle(bkBrush, e.Bounds);
                    }
                    itemColor = SelectionForeColor;
                }
                else
                {
                    e.DrawBackground();
                }

                TextRenderer.DrawText(e.Graphics, e.Item.Text, e.Item.Font, e.Bounds, itemColor, flags);

                if (lView.View == View.Tile && e.Item.SubItems.Count > 1)
                {
                    var subItem = e.Item.SubItems[1];
                    flags = GetTextAlignment(lView, 1);
                    TextRenderer.DrawText(e.Graphics, subItem.Text, subItem.Font, e.Bounds, SystemColors.GrayText, flags);
                }
            }
        }

        private void NewListView_DrawColumnHeader(object? sender, DrawListViewColumnHeaderEventArgs e)
        {
            if (OwnerDraw)
            {
                e.DrawDefault = true;
            }
        }

        private TextFormatFlags GetTextAlignment(ListView lstView, int colIndex)
        {
            TextFormatFlags flags = lstView.View == View.Tile
                ? colIndex == 0 ? TextFormatFlags.Default : TextFormatFlags.Bottom
                : TextFormatFlags.VerticalCenter;

            if (lstView.View == View.Details)
            {
                flags |= TextFormatFlags.LeftAndRightPadding;
            }

            if (lstView.Columns[colIndex].TextAlign != HorizontalAlignment.Left)
            {
                flags |= (TextFormatFlags)((int)lstView.Columns[colIndex].TextAlign ^ 3);
            }

            return flags;
        }
    }
}
