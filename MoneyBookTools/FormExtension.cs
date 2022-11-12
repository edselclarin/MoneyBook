using System.Windows.Forms;

namespace MoneyBookTools
{
    public static class FormExtension
    {
        public static void ShowException(this Form form, Exception ex)
        {
            MessageBox.Show(form, ex.InnerException != null ? ex.InnerException.Message : ex.Message,
                form.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static Hourglass CreateHourglass(this Form form)
        {
            return new Hourglass(form);
        }

        public static void ChangeTheme(this Form form, IColorScheme scheme)
        {
            form.ForeColor = scheme.DefaultForeColor;
            form.BackColor = scheme.DefaultBackColor;

            if (form.MainMenuStrip != null)
            {
                form.MainMenuStrip.ChangeTheme(scheme);
            }

            if (form.ContextMenuStrip != null)
            {
                form.ContextMenuStrip.ChangeTheme(scheme);
            }

            form.Controls.ChangeTheme(scheme);
        }

        public static void ChangeTheme(this Control.ControlCollection controls, IColorScheme scheme)
        {
            foreach (Control ctrl in controls)
            {
                ctrl.ForeColor = scheme.DefaultForeColor;
                ctrl.BackColor = scheme.DefaultBackColor;

                if (ctrl is DataGridView)
                {
                    (ctrl as DataGridView).ChangeTheme(scheme);
                }
                else if (ctrl is CustomListView)
                {
                    (ctrl as CustomListView).ChangeTheme(scheme);
                }
                else if (ctrl is DateTimePicker)
                {
                    (ctrl as DateTimePicker).ChangeTheme(scheme);
                }

                ChangeTheme(ctrl.Controls, scheme);
            }
        }

        public static void ChangeTheme(this MenuStrip menu, IColorScheme scheme)
        {
            menu.Renderer = new ToolStripProfessionalRenderer(new MenuColorTable());

            menu.ForeColor = scheme.DefaultForeColor;
            menu.BackColor = scheme.DefaultBackColor;

            menu.Items.ChangeTheme(scheme);
        }

        public static void ChangeTheme(this ContextMenuStrip contextMenu, IColorScheme scheme)
        {
            contextMenu.Renderer = new ToolStripProfessionalRenderer(new MenuColorTable());

            contextMenu.ForeColor = scheme.DefaultForeColor;
            contextMenu.BackColor = scheme.DefaultBackColor;

            contextMenu.Items.ChangeTheme(scheme);
        }

        public static void ChangeTheme(this ToolStripItemCollection items, IColorScheme scheme)
        {
            foreach (var item in items)
            {
                if (item is ToolStripMenuItem)
                {
                    var tsmi = item as ToolStripMenuItem;

                    tsmi.ForeColor = scheme.DefaultForeColor;
                    tsmi.BackColor = scheme.DefaultBackColor;

                    tsmi.DropDownItems.ChangeTheme(scheme);
                }
                else if (item is ToolStripSeparator)
                {
                    var tss = item as ToolStripSeparator;
                    tss.ForeColor = scheme.DefaultForeColor;
                    tss.BackColor = scheme.DefaultBackColor;
                }
            }
        }

        public static void ChangeTheme(this DataGridView dgv, IColorScheme scheme)
        {
            dgv.ForeColor = scheme.DefaultForeColor;
            dgv.BackgroundColor = 
            dgv.BackColor = scheme.DefaultBackColor;

            dgv.EnableHeadersVisualStyles = false; // To allow custom header style.

            dgv.ColumnHeadersDefaultCellStyle.ForeColor = scheme.HeaderForeColor;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = scheme.HeaderBackColor;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = dgv.ColumnHeadersDefaultCellStyle.ForeColor;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgv.ColumnHeadersDefaultCellStyle.BackColor;

            dgv.DefaultCellStyle.ForeColor = scheme.DefaultForeColor;
            dgv.DefaultCellStyle.BackColor = scheme.DefaultBackColor;
            dgv.DefaultCellStyle.SelectionForeColor = scheme.SelectionForeColor;
            dgv.DefaultCellStyle.SelectionBackColor = scheme.SelectionBackColor;

            dgv.GridColor = scheme.DefaultForeColor;

            if (dgv.ContextMenuStrip != null)
            {
                dgv.ContextMenuStrip.ChangeTheme(scheme);
            }
        }

        public static void ChangeTheme(this CustomListView lv, IColorScheme scheme)
        {
            lv.ForeColor = scheme.DefaultForeColor;
            lv.BackColor = scheme.DefaultBackColor;

            lv.SelectionForeColor = scheme.SelectionForeColor;
            lv.SelectionBackColor = scheme.SelectionBackColor;
        }

        public static void ChangeTheme(this DateTimePicker dtp, IColorScheme scheme)
        {
            dtp.CalendarForeColor = scheme.DefaultForeColor;
            dtp.CalendarMonthBackground = scheme.DefaultBackColor;
            dtp.CalendarTitleForeColor = scheme.DefaultForeColor;
            dtp.CalendarTitleBackColor = scheme.DefaultBackColor;
        }
    }

    /// <summary>
    /// Displays Cursors.WaitCursor for the target Form. 
    /// When the object is disposed the cursor is reverted to Cursors.Default.
    /// USAGE: Add the following to your handler: 
    /// using var hg = this.CreateHourglass();
    /// </summary>
    public sealed class Hourglass : IDisposable
    {
        private readonly Form m_parent;

        public Hourglass(Form parent)
        {
            m_parent = parent;
            parent.Cursor = Cursors.WaitCursor;
        }

        public void Dispose()
        {
            m_parent.Cursor = Cursors.Default;
        }
    }
}
