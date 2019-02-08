
namespace TWidgets.Util
{
    public static class ProgressBarTemplate
    {
        public const int BAR_START = 0;
        public const int BAR_BACKGROUND = 1;
        public const int BAR_FILLED = 2;
        public const int BAR_END = 3;

        public const int TEMPLATE_SIZE = 4;

        // [■■■■■■■■■]
        public static readonly char[] SIMPLE = new char[] {
            '[', ' ', '■', ']'
        };

        // ¦█████████¦
        public static readonly char[] SOLID = new char[] {
            '¦', ' ', '█', '¦'
        };

        // [>>>>>>>>>]
        public static readonly char[] ARROW = new char[] {
            '[', ' ', '>', ']'
        };

        // [\\\\\\\\\]
        public static readonly char[] INVERTED_BACKSLASH = new char[] {
            '[', ' ', '\\', ']'
        };

        // [/////////]
        public static readonly char[] BACKSLASH = new char[] {
            '[', ' ', '/', ']'
        };

        // ¦|||||||||¦
        public static readonly char[] BARS = new char[] {
            '¦', ' ', '|', '¦'
        };
    }
}
