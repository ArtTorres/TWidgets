namespace TWidgets
{
    /// <summary>
    /// Gets a collection of progress bar templates.
    /// </summary>
    public static class ProgressBarTemplate
    {
        /// <summary>
        /// The position of the start character in the template.
        /// </summary>
        public const int BAR_START = 0;

        /// <summary>
        /// The position of the background character in the template.
        /// </summary>
        public const int BAR_BACKGROUND = 1;

        /// <summary>
        /// The position of the fill character in the template.
        /// </summary>
        public const int BAR_FILLED = 2;

        /// <summary>
        /// The position of the end character in the template.
        /// </summary>
        public const int BAR_END = 3;

        /// <summary>
        /// The size required for the template.
        /// </summary>
        public const int TEMPLATE_SIZE = 4;

        /// <summary>
        /// Provides a character template for progres bar widgets.
        /// </summary>
        /// <example>
        /// [■■■■■■■■■]
        /// </example>
        public static readonly char[] SIMPLE = new char[] {
            '[', ' ', '■', ']'
        };

        /// <summary>
        /// Provides a character template for progres bar widgets.
        /// </summary>
        /// <example>
        /// ¦█████████¦
        /// </example>
        public static readonly char[] SOLID = new char[] {
            '¦', ' ', '█', '¦'
        };

        /// <summary>
        /// Provides a character template for progres bar widgets.
        /// </summary>
        /// <example>
        /// [>>>>>>>>>]
        /// </example>
        public static readonly char[] ARROW = new char[] {
            '[', ' ', '>', ']'
        };

        /// <summary>
        /// Provides a character template for progres bar widgets.
        /// </summary>
        /// <example>
        /// [\\\\\\\\\]
        /// </example>
        public static readonly char[] INVERTED_BACKSLASH = new char[] {
            '[', ' ', '\\', ']'
        };

        /// <summary>
        /// Provides a character template for progres bar widgets.
        /// </summary>
        /// <example>
        /// [/////////]
        /// </example>
        public static readonly char[] BACKSLASH = new char[] {
            '[', ' ', '/', ']'
        };

        /// <summary>
        /// Provides a character template for progres bar widgets.
        /// </summary>
        /// <example>
        /// ¦|||||||||¦
        /// </example>
        public static readonly char[] BARS = new char[] {
            '¦', ' ', '|', '¦'
        };
    }
}
