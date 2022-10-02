namespace MoneyBookTools
{
    public static class FormExtension
    {
        public static void ShowException(this Form form, Exception ex)
        {
            MessageBox.Show(form, ex.InnerException != null ? ex.InnerException.Message : ex.Message,
                form.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
