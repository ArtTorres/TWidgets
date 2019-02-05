
namespace TWidgets.Util
{
    public static class ProgressBarTemplates
    {
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
            '[', ' ', '/', ']'
        };
    }
}
