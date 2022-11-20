namespace MoneyBookTools.Forms
{
    public interface IColorScheme
    {
        Color DefaultForeColor { get; }
        Color DefaultBackColor { get; }

        Color SelectionForeColor { get; }
        Color SelectionBackColor { get; }

        Color HeaderForeColor { get; }
        Color HeaderBackColor { get; }
    }

    public class DarkColorScheme : IColorScheme
    {
        public Color DefaultForeColor { get; } = Color.FromArgb(179, 179, 179);
        public Color DefaultBackColor { get; } = Color.FromArgb(24, 24, 24);

        public Color SelectionForeColor { get; } = Color.White;
        public Color SelectionBackColor { get; } = Color.CadetBlue;

        public Color HeaderForeColor { get; } = Color.White;
        public Color HeaderBackColor { get; } = Color.FromArgb(96, 96, 96);

        protected DarkColorScheme()
        {
        }

        public static DarkColorScheme Create()
        {
            return new DarkColorScheme();
        }
    }
}