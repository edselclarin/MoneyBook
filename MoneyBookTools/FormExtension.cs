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
