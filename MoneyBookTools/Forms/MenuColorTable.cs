﻿namespace MoneyBookTools.Forms
{
    class MenuColorTable : ProfessionalColorTable
    {
        public MenuColorTable()
        {
            // see notes
            UseSystemColors = false;
        }

        public override Color ImageMarginGradientBegin => Color.FromArgb(24, 24, 24);
        public override Color ImageMarginGradientMiddle => Color.FromArgb(24, 24, 24);
        public override Color ImageMarginGradientEnd => Color.FromArgb(24, 24, 24);
    }
}
