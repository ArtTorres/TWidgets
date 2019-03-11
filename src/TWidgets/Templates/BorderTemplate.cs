namespace TWidgets
{
    /// <summary>
    /// Gets a collection of border templates.
    /// </summary>
    public static class BorderTemplate
    {
        /// <summary>
        /// The position of the top-left character in the template.
        /// </summary>
        public const int BORDER_TOP_LEFT = 0;

        /// <summary>
        /// The position of the top character in the template.
        /// </summary>
        public const int BORDER_TOP = 1;

        /// <summary>
        /// The position of the top-right character in the template.
        /// </summary>
        public const int BORDER_TOP_RIGHT = 2;

        /// <summary>
        /// The position of the left character in the template.
        /// </summary>
        public const int BORDER_LEFT = 3;

        /// <summary>
        /// The position of the background character in the template.
        /// </summary>
        public const int BACKGROUND = 4;

        /// <summary>
        /// The position of the right character in the template.
        /// </summary>
        public const int BORDER_RIGHT = 5;

        /// <summary>
        /// The position of the bottom-left character in the template.
        /// </summary>
        public const int BORDER_BOTTOM_LEFT = 6;

        /// <summary>
        /// The position of the bottom character in the template.
        /// </summary>
        public const int BORDER_BOTTOM = 7;

        /// <summary>
        /// The position of the bottom-right character in the template.
        /// </summary>
        public const int BORDER_BOTTOM_RIGHT = 8;

        /// <summary>
        /// The size required for the template.
        /// </summary>
        public const int TEMPLATE_SIZE = 9;

        /// <summary>
        /// Provides a character template for bordered widgets.
        /// </summary>
        public static readonly char[] DOTTED = new char[] {
            '·', '·', '·',
            '·', ' ', '·',
            '·', '·', '·'
        };

        /// <summary>
        /// Provides a character template for bordered widgets.
        /// </summary>
        public static readonly char[] STARS = new char[] {
            '*', '*', '*',
            '*', ' ', '*',
            '*', '*', '*'
        };

        /// <summary>
        /// Provides a character template for bordered widgets.
        /// </summary>
        public static readonly char[] RIDGE = new char[] {
            '╔', '═', '╗',
            '║', ' ', '║',
            '╚', '═', '╝'
        };

        /// <summary>
        /// Provides a character template for bordered widgets.
        /// </summary>
        public static readonly char[] FILL = new char[] {
            '█', '█', '█',
            '█', '█', '█',
            '█', '█', '█'
        };

        /// <summary>
        /// Provides a character template for bordered widgets.
        /// </summary>
        public static readonly char[] SOLID = new char[] {
            '┌', '─', '┐',
            '│', ' ', '│',
            '└', '─', '┘'
        };
    }
}
